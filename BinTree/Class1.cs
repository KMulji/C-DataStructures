namespace BinTree;
using BNode;
using System.Collections.Generic;

public class BinTree<T>
{
    public BNode<T>? _root { get; set; }

    public void PreOrder()
    {
        BNode<T>? curr = _root;

        PreOrderS(curr);


    }
    private void PreOrderS(BNode<T>? head)
    {
        if (head == null)
        {
            return;
        }
        Console.WriteLine(head._data);
        PreOrderS(head._left);
        PreOrderS(head._right);

    }
    public void InOrder()
    {
        BNode<T>? curr = _root;

        InOrderS(curr);


    }
    private void InOrderS(BNode<T>? head)
    {
        if (head == null)
        {
            return;
        }
        InOrderS(head._left);
        Console.WriteLine(head._data);
        InOrderS(head._right);

    }
    public void PostOrder()
    {
        BNode<T>? curr = _root;
        PostOrderS(curr);
    }
    private void PostOrderS(BNode<T>? curr)
    {
        if (curr == null)
        {
            return;
        }
        PostOrderS(curr._left);
        PostOrderS(curr._right);
        Console.WriteLine(curr._data);
    }
    public void LevelOrder()
    {
        BNode<T>? curr = _root;
        LevelOrderS(curr);
    }
    private void LevelOrderS(BNode<T>? head)
    {
        Queue<BNode<T>> qt = new();
        qt.Enqueue(head);
        while (qt.Count != 0)
        {
            BNode<T> top = qt.Peek();
            qt.Dequeue();
            Console.WriteLine(top._data);
            if (top._left != null)
            {
                qt.Enqueue(top._left);
            }
            if (top._right != null)
            {
                qt.Enqueue(top._right);
            }
        }
    }
}