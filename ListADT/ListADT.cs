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
            if (index < 0 || index > _length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                if (_length == _size)
                {
                    Expand();
                }
                _arr[index] = value;
                _length++;
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
        _arr = new T[10];
        _size = 10;
        _length = 10;
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
        this[_length] = val;
    }
    public T Pop()
    {
        if (_length == (int)(_size * 0.5))
        {
            Shrink();
        }
        T ans = this[_length - 1];
        _length--;
        return ans;
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
