using ListADT;

int[] arr = [];
ListADT<int> test = new ListADT<int>();

// test.Append(16);
// test.Append(17);
test.Insert(7, 0);
test.Print();
test.Delete(0);
test.Print();
Console.WriteLine("Length is " + test.Length);
Console.WriteLine("Size is " + test.Size);
Console.WriteLine("-----------------");
// Console.WriteLine(test.BinSearch(12.2f));
