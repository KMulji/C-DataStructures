namespace NodePQ;
using Node;
public class NodePQ<T> : Node<T>
{
    private int _prio;
    public NodePQ(T val, int prio) : base(val)
    {
        _prio = prio;
    }
    public int Prio
    {
        get { return _prio; }
        set { _prio = value; }
    }

}
