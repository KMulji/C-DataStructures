namespace PriorityQueueADT;


using NodePQ;
public class PriorityQueueADT<T>
{
    NodePQ<T>? _head;
    NodePQ<T>? _tail;

    public PriorityQueueADT()
    {
        _head = null;
        _tail = null;
    }
    public void Push(T val, int prio)
    {
        NodePQ<T>? temp = new(val, prio);
        if (_head == null || _tail == null)
        {
            _head = temp;
            _tail = temp;
            return;
        }
        if (prio > _head.Prio)
        {
            temp.Next = _head;
            _head = temp;
            return;
        }
        NodePQ<T>? start = _head;
        while (start != null && start.Next != null)
        {
            NodePQ<T>? startNext = (NodePQ<T>?)start.Next;
            if (startNext.Prio < prio)
            {
                break;
            }
            start = startNext;
        }
        if (start.Next == null)
        {
            _tail.Next = temp;
            _tail=temp;
            return;
        }
        temp.Next = start.Next;
        start.Next = temp;
    }
    public T Peek()
    {
        if (_head == null || _tail == null)
        {
            return (T)(object)-1;
        }
        return _head.Data;
    }
    public void Pop()
    {
        if (_head == null || _tail == null)
        {
            return;
        }
        if (_head.Next == null)
        {
            _head = null;
            return;
        }
        NodePQ<T> temp = _head;
        _head = (NodePQ<T>)_head.Next;
        temp.Next = null;
    }
    public void Print()
    {
        NodePQ<T> curr = _head;

        while (curr != null)
        {
            Console.WriteLine(curr.Data + " " + curr.Prio);

            curr = (NodePQ<T>)curr.Next;
        }
    }
}
