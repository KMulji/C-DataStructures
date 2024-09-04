namespace ANode;

public class ANode<T>
{
    public required T Data { get; set; }
    public required int Height { get; set; }

    public ANode<T>? Left { get; set; }
    public ANode<T>? Right { get; set; }

}
