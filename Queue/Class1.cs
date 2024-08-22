namespace Queue;
using Node;
public class QueueADT<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;

    public QueueADT()
    {
        _head = null;
        _tail = null;
    }
    public void Enqueue(T val)
    {
        Node<T> temp = new(val);
        if (_head == null || _tail == null)
        {
            _head = temp;
            _tail = temp;
            return;
        }
        _tail.Next = temp;
        _tail = temp;
    }
    public T Dequeue()
    {
        Node<T>? temp;
        T ans;
        if (_head == null || _tail == null)
        {
            return (T)(object)-1;
        }
        if (_head.Next == null)
        {
            ans = _head.Data;
            _head = null;
            return ans;
        }
        temp = _head;
        _head = _head.Next;
        temp.Next = null;
        ans = temp.Data;

        return ans;

    }
    public T peek()
    {
        if (_head == null)
        {
            return (T)(object)-1;
        }
        return _head.Data;
    }
    public T Contains(T key)
    {
        if (_head == null)
        {
            return (T)(object)-1;
        }
        Node<T> curr = _head;
        while (curr != null && curr.Next != null)
        {
            if (IsEqualTo(curr.Data, key))
            {
                return curr.Data;
            }
            curr = curr.Next;
        }
        return (T)(object)-1;
    }
    public void Clear()
    {
        _tail = null;
        _head = null;

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
