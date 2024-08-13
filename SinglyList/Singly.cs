namespace SinglyList;

using System.Globalization;
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
        Node<T> temp = _head;

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

}
