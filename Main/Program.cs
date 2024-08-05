using ListADT;

int[] arr = [-11, 12,-42, 0, 1, 90, 68, 6,-9];
ListADT<int> test = new ListADT<int>(ref arr);
test.InsertionSort();
test.Print();

