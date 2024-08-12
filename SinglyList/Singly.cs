namespace SinglyList;

using Node;
public class Singly<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;

    public void Append(T val)
    {
        Node<T> temp;
        if (_head == _tail)
        {
            temp = new Node<T>(val);
            _head = temp;
            _tail = temp;
            return;
        }
        temp = new Node<T>(val);
        temp.Next = _head;
        _head = temp;
        
    }

    public Singly()
    {
        _head = null;
        _tail = null;
    }



}
