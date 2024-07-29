﻿namespace ListADT;
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
        if (_length == _size)
        {
            Expand();
        }
        this[_length++] = val;
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
