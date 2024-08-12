namespace Node;

public class Node<T>
{
    private T _data;
    private Node<T>? _next;

    public Node(T data)
    {
        _data = data;
        _next = null;
    }

    public T Data
    {
        get { return _data; }
        set { _data = value; }
    }
    public Node<T>? Next
    {
        get { return _next; }
        set { _next = value; }
    }

}
