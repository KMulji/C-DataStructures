using ListADT;

int[] arr = [23, 12, -7, 16, 18, 35, 35, 28, 5];
int[] arr2 = [-11, 12, -42, 0, 1, 90, 68, 6, -9];
ListADT<int> test = new ListADT<int>(ref arr);
test.QuickSort();
test.Print();

