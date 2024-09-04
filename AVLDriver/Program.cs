using ANode;
using AVL;

AVL<int> al = new();


for (int i = 1; i <= 9; i++)
{
    al.Insert(i);
}
al.Display();
al.Delete(4);
Console.WriteLine("----------------");
al.Display();
Console.WriteLine("eof");


