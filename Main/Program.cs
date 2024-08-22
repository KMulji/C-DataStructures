using Queue;

QueueADT<int> qt = new();
for (int i = 0; i < 10; i++)
{
    qt.Enqueue(i);
}
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(qt.Dequeue());
}

Console.WriteLine(qt.Contains(11));





