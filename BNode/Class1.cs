namespace BNode;

public class BNode<T>
{
    public T? _data { get; set; }
    public BNode<T>? _left { get; set; }
    public BNode<T>? _right { get; set; }
    public BNode<T>? _parent { get; set; }
    public int Height()
    {
        BNode<T> curr = this;
        int height = 1;
        while (curr._parent != null)
        {
            height += 1;
            curr = curr._parent;
        }

        return height;
    }
}
