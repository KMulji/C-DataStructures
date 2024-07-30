using ListADT;

float[] arr = [2.2f, 4.5f, 6.5f];
ListADT<float> test = new ListADT<float>(ref arr);
test.Append(12.1f);
test.Append(12.2f);

test.Append(13.1f);
test.Append(14.2f);
test.Append(15.5f);
// test.Append(16);
// test.Append(17);

test.Print();
Console.WriteLine("Length is " + test.Length);
Console.WriteLine("Size is " + test.Size);
Console.WriteLine("-----------------");
Console.WriteLine(test.BinSearch(12.2f));
