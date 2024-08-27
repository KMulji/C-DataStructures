using BNode;
using BinTree;
using System.Collections.Generic;

Queue<BNode<int>> qt = new();
BinTree<int> bt = new();

BNode<int> root = new();
bool left = false;
bool right = false;
int val = 0;
Console.WriteLine("Enter a root value");
val = Convert.ToInt32(Console.ReadLine());

root._data = val;
qt.Enqueue(root);
bt._root = root;
while (qt.Count != 0)
{
    BNode<int> top = qt.Peek();
    qt.Dequeue();
    Console.WriteLine($"Does {top._data} have a left child");
    left = Convert.ToBoolean(Console.ReadLine());
    Console.WriteLine($"Does {top._data} have a right child");
    right = Convert.ToBoolean(Console.ReadLine());
    if (left == true)
    {
        BNode<int> l = new();
        Console.WriteLine("Enter a left value");
        val = Convert.ToInt32(Console.ReadLine());
        l._data = val;
        top._left = l;
        qt.Enqueue(l);
    }
    if (right == true)
    {
        BNode<int> r = new();
        Console.WriteLine("Enter a right value");
        val = Convert.ToInt32(Console.ReadLine());
        r._data = val;
        top._right = r;
        qt.Enqueue(r);
    }
}

bt.PreOrder();
Console.WriteLine("-----------------------");
bt.InOrder();
Console.WriteLine("-----------------------");
bt.PostOrder();
Console.WriteLine("-----------------------");
bt.LevelOrder();





