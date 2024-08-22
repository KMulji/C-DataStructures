namespace Stack;
using Node;
public class StackADT<T>
{

    private Node<T>? _head;
    public StackADT()
    {
        _head = null;
    }

    public void Push(T val)
    {
        Node<T> temp = new(val);
        if (_head == null)
        {
            _head = temp;
            return;
        }
        temp.Next = _head;
        _head = temp;
    }
    public T Pop()
    {
        T ans;
        if (_head == null)
        {
            return (T)(object)-1;
        }
        if (_head.Next == null)
        {
            ans = _head.Data;
            _head = null;

            return ans;
        }
        Node<T>? temp = _head;
        _head = _head.Next;
        ans = temp.Data;
        return ans;
    }
    public T Peek()
    {
        if (_head == null)
        {
            return (T)(object)-1;
        }
        return _head.Data;
    }
    public void Print()
    {
        Node<T>? curr = _head;

        while (curr != null && curr.Next != null)
        {
            Console.WriteLine(curr.Data);
            curr = curr.Next;
        }
    }
}
