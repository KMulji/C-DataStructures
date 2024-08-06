using ListADT;

int[] arr = [-11, 12, -42, 0, 90, -9,80];
ListADT<int> test = new ListADT<int>(ref arr);
test.BubbleSort();
test.Print();

