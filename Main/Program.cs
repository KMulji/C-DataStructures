using ListADT;

int[] arr = [2, 4, 6, 8, 10];
ListADT<int> test = new ListADT<int>(ref arr);
test.Append(12);

test.Append(13);
test.Append(14);
test.Append(15);
test.Append(16);
test.Append(17);

test.Print();
Console.WriteLine("Length is " + test.Length);
Console.WriteLine("Size is " + test.Size);
Console.WriteLine("-----------------");

Console.WriteLine(test.BinSearch(13));
