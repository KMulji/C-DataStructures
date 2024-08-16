namespace SinglyList;

using System.Globalization;
using Microsoft.VisualBasic;
using Node;
public class Singly<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;

    private int _length;
    public Singly()
    {
        _head = null;
        _tail = null;
    }
    public void Append(T val)
    {
        Node<T> temp;
        if (_head == null || _tail == null)
        {
            temp = new Node<T>(val);
            _head = temp;
            _tail = temp;
            _length++;
            return;
        }
        temp = new Node<T>(val);
        _tail.Next = temp;
        _tail = temp;
        _length++;
    }
    public void Prepend(T val)
    {
        Node<T> temp;
        if (_head == null || _tail == null)
        {
            temp = new Node<T>(val);
            _head = temp;
            _tail = temp;
            _length++;
            return;
        }
        temp = new Node<T>(val);
        temp.Next = _head;
        _head = temp;
        _length++;

    }
    public void Print()
    {
        if (_head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }
        Node<T>? temp = _head;

        while (temp != null)
        {
            Console.WriteLine(temp.Data);
            temp = temp.Next;
        }
    }
    public void Insert(int index, T val)
    {
        if (index < 0 || index > _length)
        {
            return;
        }
        if (_head == null || _tail == null)
        {
            Append(val);
        }
        Node<T>? temp = new Node<T>(val);

        if (index == 0)
        {
            Prepend(val);
            return;
        }
        if (index == _length)
        {
            Append(val);
            return;
        }
        Node<T>? j = _head;
        Node<T>? i = null;

        int k = 0;

        while (k != index)
        {
            i = j;
            j = j.Next;
            k++;
        }
        temp.Next = j;
        i.Next = temp;
        _length++;
    }
    public T Pop()
    {
        T ans;
        if (_head == null || _tail == null)
        {

            return (T)(object)-1;
        }
        if (_length == 1)
        {
            ans = _head.Data;
            _head = null;
            _tail = null;
            _length--;
            return ans;
        }
        ans = _head.Data;

        Node<T>? temp = _head;
        _head = _head.Next;

        temp.Next = null;
        temp = null;
        _length--;
        return ans;
    }
    public T PopBack()
    {
        T ans;
        if (_head == null || _tail == null)
        {
            return (T)(object)-1;
        }
        if (_length == 1)
        {
            ans = _head.Data;
            _head = null;
            _tail = null;
            _length--;
            return ans;
        }
        Node<T>? curr = _head;

        while (curr.Next != _tail)
        {

            curr = curr.Next;
        }
        Node<T>? temp = curr;
        ans = _tail.Data;
        _tail = curr;
        _tail.Next = null;
        temp = null;
        return ans;
    }
    public T Delete(int index)
    {
        //bounds
        if (index < 0 || index >= _length)
        {
            return (T)(object)-1;
        }
        T ans;
        if (_head == null || _tail == null)
        {
            return (T)(object)-1; ;
        }
        if (index == 0)
        {
            ans = _head.Data;
            Pop();
            return ans;
        }
        Node<T>? curr = _head;
        Node<T>? prev = null;
        int k = 0;
        while (k != index)
        {

            prev = curr;
            curr = curr.Next;
            k++;
        }
        ans = curr.Data;
        prev.Next = curr.Next;
        curr.Next = null;
        return ans;
    }
    public void MergeSort()
    {
        Singly<T> s2 = new();
        s2._head = _head;
        s2._tail = _tail;
        MergeSortS(s2);
    }
    private Singly<T> MergeSortS(Singly<T> sl)
    {
        if (sl._head == null || sl._head.Next == null)
        {
            Singly<T> test = new();
            test._head = sl._head;
            test._tail = sl._tail;
            return test;
        }
        Node<T>? fast = sl._head;
        Node<T>? mid = sl._head;

        while (fast != null && fast.Next != null)
        {
            fast = fast.Next.Next;
            mid = mid.Next;
        }

        Singly<T> left = new();

        left._head = sl._head;
        left._tail = mid;

        Singly<T> right = new();
        right._head = mid.Next;
        Node<T>? tails = right._head;
        mid.Next = null;

        while (tails != null && tails.Next != null)
        {
            tails = tails.Next;
        }

        right._tail = tails;

        left= MergeSortS(left);
        right = MergeSortS(right);
        Singly<T> List = Merge(left, right);
        return List;

    }
    private static Singly<T> Merge(Singly<T> left, Singly<T> right)
    {
        Singly<T> newList = new();
        Node<T> curr = left._head;
        Node<T> curr2 = right._head;

        while (curr != null && curr2 != null)
        {
            if (IsLessThan(curr.Data, curr2.Data) || IsEqualTo(curr.Data, curr2.Data))
            {
                if (newList._head == null)
                {
                    Node<T> temp = new(curr.Data);
                    newList._head = temp;
                    newList._tail = temp;
                }
                else
                {
                    Node<T> temp = new(curr.Data);
                    newList._tail.Next = temp;
                    newList._tail = temp;
                }
            }
            else
            {
                if (newList._head == null)
                {
                    Node<T> temp = new(curr2.Data);
                    newList._head = temp;
                    newList._tail = temp;
                }
                else
                {
                    Node<T> temp = new(curr2.Data);
                    newList._tail.Next = temp;
                    newList._tail = temp;
                }
            }
        }
        while (curr != null)
        {
            Node<T> temp = new(curr.Data);
            newList._tail.Next = temp;
            newList._tail = temp;
        }
        while (curr2 != null)
        {
            Node<T> temp = new(curr2.Data);
            newList._tail.Next = temp;
            newList._tail = temp;
        }
        return newList;
    }
    private static bool Compare(T a, T b, int res)
    {
        Comparer<T> comparer = Comparer<T>.Default;
        return comparer.Compare(a, b) == res ? true : false;
    }
    private static bool IsBiggerThan(T a, T b)
    {
        return Compare(a, b, 1);
    }
    private static bool IsEqualTo(T a, T b)
    {
        return Compare(a, b, 0);
    }
    private static bool IsLessThan(T a, T b)
    {
        return Compare(a, b, -1);
    }

}
