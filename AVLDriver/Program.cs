using ANode;
using AVL;

AVL<int> al = new();

al.Insert(44);
al.Insert(17);
al.Insert(62);
al.Insert(32);
al.Insert(50);
al.Insert(78);
al.Insert(48);
al.Insert(54);
al.Insert(88);



al.Display();

al.Delete(32);
Console.WriteLine("----------------");
al.Display();
Console.WriteLine("eof");