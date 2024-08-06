namespace ListADT;
public class ListADT<T>
{
    private T[] _arr;
    private int _size;
    private int _length;
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return _arr[index];
            }
        }
        set
        {
            if (index < 0 || index >= _length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                _arr[index] = value;
            }
        }
    }
    public int Size
    {
        get { return _size; }
    }
    public int Length
    {
        get { return _length; }
    }
    public ListADT()
    {
        _arr = new T[1];
        _size = 1;
        _length = 0;
    }
    public ListADT(ref T[] arr)
    {
        _arr = new T[arr.Length * 2];
        _size = arr.Length * 2;
        _length = arr.Length;
        Array.Copy(arr, _arr, arr.Length);
    }
    public void Print()
    {
        if (_length == 0)
        {
            Console.WriteLine("List is Empty");
            return;
        }
        for (int i = 0; i < _length; i++)
        {
            Console.WriteLine(this[i]);
        }
    }
    public void Append(T val)
    {
        if (_length == _size)
        {
            Expand();
        }
        _arr[_length++] = val;
    }
    public T Pop()
    {
        if (_length == (int)(_size * 0.5))
        {
            Shrink();
        }
        T ans = _arr[_length - 1];
        _length--;
        return ans;
    }
    public void Insert(T val, int index)
    {
        if (Bounds(index))
        {
            throw new IndexOutOfRangeException();
        }
        if (_length == _size)
        {
            Expand();
        }
        if (_length == 0 && _size > 0)
        {
            _arr[0] = val;
            _length++;
            return;
        }
        int end = _length;
        while (end != index)
        {
            _arr[end] = _arr[end - 1];
            end--;
        }
        _length++;
        _arr[end] = val;
    }
    public T Delete(int index)
    {
        if (_length == 0)
        {
            Console.WriteLine("Cannot delete from empty list");
            return (T)(object)-1;
        }

        if (_length == (int)(_size * 0.5))
        {
            Shrink();
        }
        if (_length == 1)
        {
            _length--;
            return _arr[0];
        }
        T ans = _arr[index];
        for (int i = index; i < _length; i++)
        {
            _arr[i] = _arr[i + 1];
        }
        _length--;
        return ans;
    }
    public int BinSearch(T key)
    {
        int lo = 0;
        int hi = _length - 1;

        while (lo <= hi)
        {
            int mid = lo + (hi - lo) / 2;
            if (IsEqualTo(_arr[mid], key))
            {
                return mid;
            }
            else if (IsBiggerThan(_arr[mid], key))
            {
                hi = mid - 1;
            }
            else if (IsLessThan(_arr[mid], key))
            {
                lo = mid + 1;
            }
        }
        return -1;
    }
    public void SelectionSort()
    {
        int minIndex = 0;
        T minVal;
        for (int i = 0; i < _length - 1; i++)
        {
            minIndex = i;
            minVal = _arr[i];
            for (int j = i + 1; j < _length; j++)
            {
                if (IsLessThan(_arr[j], minVal))
                {
                    minIndex = j;
                    minVal = _arr[j];
                }
            }
            T temp = _arr[i];
            _arr[i] = _arr[minIndex];
            _arr[minIndex] = temp;
        }
    }
    public void InsertionSort()
    {
        int j = 0;
        for (int i = 0; i < _length; i++)
        {
            j = i;
            while (j > 0 && IsLessThan(_arr[j], _arr[j - 1]))
            {
                T temp = _arr[j];
                _arr[j] = _arr[j - 1];
                _arr[j - 1] = temp;
                j--;
            }
        }
    }
    public void BubbleSort()
    {
        for (int i = 0; i < _length; i++)
        {
            for (int j = 0; j < _length - 1; j++)
            {
                if (IsBiggerThan(_arr[j], _arr[j + 1]))
                {
                    T temp = _arr[j];
                    _arr[j] = _arr[j + 1];
                    _arr[j + 1] = temp;
                }
            }
        }
    }
    public void MergeSort()
    {
        T[] a = new T[_length];
        Array.Copy(_arr, a, _length);
        MergeSortS(a);
        _arr = a;

    }
    private void MergeSortS(T[] a)
    {
        // split step
        if (a.Length <= 1)
        {
            return;
        }

        int m = a.Length / 2;
        T[] left = SubArray(a, 0, m - 1);
        T[] right = SubArray(a, m, a.Length - 1);
        MergeSortS(left);
        MergeSortS(right);

        //merge step
        int i = 0;
        int j = 0;
        int k = 0;

        while (i < left.Length && j < right.Length)
        {
            if (IsLessThan(left[i], right[j]) || IsEqualTo(left[i], right[j]))
            {
                a[k] = left[i++];
            }
            else
            {
                a[k] = right[j++];
            }
            k++;
        }
        // deal with left overs
        while (i < left.Length)
        {
            a[k++] = left[i++];
        }
        while (j < right.Length)
        {
            a[k++] = right[j++];
        }
    }
    private T[] SubArray(T[] a, int si, int ei)
    {
        T[] res = new T[ei - si + 1];
        Array.Copy(a, si, res, 0, ei - si + 1);
        return res;
    }
    private bool Bounds(int index)
    {
        return index < 0 || index >= _length;
    }
    private static bool Compare(T a, T b, int res)
    {
        Comparer<T> comparer = Comparer<T>.Default;
        return comparer.Compare(a, b) == res ? true : false;
    }
    private static bool IsBiggerThan(T a, T b)
    {
        return Compare(a, b, 1);
    }
    private static bool IsEqualTo(T a, T b)
    {
        return Compare(a, b, 0);
    }
    private static bool IsLessThan(T a, T b)
    {
        return Compare(a, b, -1);
    }
    private void Expand()
    {
        T[] newArray = new T[_size * 2];
        Array.Copy(_arr, newArray, _arr.Length);
        _arr = newArray;
        _size *= 2;

    }
    private void Shrink()
    {
        T[] newArray = new T[_size * 1 / 2];
        Array.Copy(_arr, newArray, _length);
        _arr = newArray;
        _size = _size * 1 / 2;
    }
}
