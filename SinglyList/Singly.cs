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
        Node<T> currHead = _head;
        _head = MergeSortS(currHead);
        Node<T> curr = _head;

        while (curr.Next != null)
        {
            curr = curr.Next;
        }
        _tail = curr;
    }

    private Node<T> MergeSortS(Node<T>? head)
    {
        // base case
        if (head == null || head.Next == null)
        {
            return head;
        }

        //find mid
        Node<T>? mid = head;
        Node<T>? fast = head;

        while (fast.Next != null && fast.Next.Next != null)
        {
            mid = mid.Next;
            fast = fast.Next.Next;
        }

        //split list and call
        Node<T>? left = head;
        Node<T>? right = mid.Next;

        mid.Next = null;

        left = MergeSortS(left);
        right = MergeSortS(right);

        //merge new list
        return Merge(left, right);
    }
    private Node<T> Merge(Node<T> left, Node<T> right)
    {
        Node<T>? newHead = null;
        Node<T>? newTail = null;
        Node<T> curr = left;
        Node<T> curr2 = right;
        while (curr != null && curr2 != null)
        {
            if (IsLessThan(curr.Data, curr2.Data) || IsEqualTo(curr.Data, curr2.Data))
            {
                Node<T> temp = new Node<T>(curr.Data);
                if (newHead == null)
                {
                    newHead = temp;
                    newTail = temp;

                }
                else
                {
                    newTail.Next = temp;
                    newTail = temp;
                }
                curr = curr.Next;
            }
            else
            {
                Node<T> temp = new Node<T>(curr2.Data);
                if (newHead == null)
                {
                    newHead = temp;
                    newTail = temp;
                }
                else
                {
                    newTail.Next = temp;
                    newTail = temp;
                }
                curr2 = curr2.Next;
            }

        }
        while (curr != null)
        {
            Node<T> temp = new(curr.Data);
            newTail.Next = temp;
            newTail = temp;
            curr = curr.Next;
        }
        while (curr2 != null)
        {
            Node<T> temp = new(curr2.Data);
            newTail.Next = temp;
            newTail = temp;
            curr2 = curr2.Next;
        }
        return newHead;
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
