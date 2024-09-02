using BST;
using BNode;
BST<int> bt = new();
bt.Insert(30);
bt.Insert(20);
bt.Insert(10);
bt.Insert(5);

void printBSTVisual(BNode<int> root, string prefix = "", bool isLeft = false)
{
    if (root != null)
    {
        Console.Write(prefix);

        if (isLeft)
        {
            Console.Write("├── ");
        }
        else
        {
            Console.Write("└── ");
        }
        Console.WriteLine(root._data);


        //Print the left subtree
        printBSTVisual(root._left, prefix + (isLeft ? "│   " : "    "), true);
        //Print the right subtree
        printBSTVisual(root._right, prefix + (isLeft ? "│   " : "    "), false);
    }
}
printBSTVisual(bt.Root);
