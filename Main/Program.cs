using System.ComponentModel.DataAnnotations;
using ListADT;
using SinglyList;
Singly<int> sl = new Singly<int>();

sl.Append(10);
sl.Append(20);
sl.Append(30);
sl.Append(40);
sl.Append(50);


sl.Print();
Console.WriteLine("................................................");
Console.WriteLine(sl.Delete(1));
Console.WriteLine(sl.Delete(1));
Console.WriteLine(sl.Delete(1));
//sl.Print();


