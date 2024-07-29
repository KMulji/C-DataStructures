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

for (int i = 0; i < 7; i++)
{
    test.Pop();
}
test.Print();
Console.WriteLine("Length is " + test.Length);
Console.WriteLine("Size is " + test.Size);
Console.WriteLine("-----------------");
test.Pop();
test.Pop();
test.Pop();
test.Pop();
Console.WriteLine("-----------------");
test.Print();
Console.WriteLine("Length is " + test.Length);
Console.WriteLine("Size is " + test.Size);


for (int i = 0; i < 7; i++)
{
    test.Append(i + 1);
}
Console.WriteLine("-----------------");
test.Print();
Console.WriteLine("Length is " + test.Length);
Console.WriteLine("Size is " + test.Size);
Console.WriteLine("-----------------");
test.Append(3000);
test.Append(4000);
test.Print();
Console.WriteLine("Length is " + test.Length);
Console.WriteLine("Size is " + test.Size);
Console.WriteLine("-----------------");
int n = test.Length;
for (int i = 0; i < n; i++)
{
    test.Pop();
}
Console.WriteLine("Length is " + test.Length);
Console.WriteLine("Size is " + test.Size);
