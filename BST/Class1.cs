namespace BST;
using BNode;
public class BST<T>
{
    public BNode<T>? Root { get; set; }

    public void Insert(T val)
    {
        if (Root == null)
        {
            BNode<T> temp = new();
            temp._data = val;
            Root = temp;
        }
        InsertS(Root, val);
    }
    private void InsertS(BNode<T>? root, T val)
    {

        if (root._left == null || root._right == null)
        {
            //we need to insert here
            BNode<T> temp = new();
            temp._data = val;
            if (IsBiggerThan(val, root._data) && root._right == null)
            {
                root._right = temp;
                temp._parent = root;
            }
            else if (IsLessThan(val, root._data) && root._left == null)
            {
                root._left = temp;
                temp._parent = root;
            }
        }
        if (IsBiggerThan(val, root._data))
        {
            InsertS(root._right, val);
        }
        else if (IsLessThan(val, root._data))
        {
            InsertS(root._left, val);
        }
    }
    public void Delete(T val)
    {
        DeleteS(Root, val);
    }
    private void DeleteS(BNode<T>? root, T val)
    {
        if (root == null)
        {
            return;
        }
        else if (IsBiggerThan(val, root._data))
        {
            DeleteS(root._right, val);
        }
        else if (IsLessThan(val, root._data))
        {
            DeleteS(root._left, val);
        }
        else
        {
            //leaf
            if (root._left == null && root._right == null)
            {
                BNode<T>? parr = root._parent;
                // we know its root
                if (parr == null)
                {
                    Root = null;
                    return;
                }
                // if parent !=null
                if (root._parent._left == root)
                {
                    root._parent._left = null;
                }
                else if (root._parent._right == root)
                {
                    root._parent._right = null;
                }
            }
            else if (root._left == null || root._right == null)
            {
                BNode<T>? parr = root._parent;
                // we know its root
                if (parr == null)
                {
                    Root = null;
                    return;
                }
                if (root._parent._left == root)
                {
                    BNode<T> leftOfDeleted = root._left;
                    leftOfDeleted._parent = root._parent;
                    root._parent._left = leftOfDeleted;

                }
                else if (root._parent._right == root)
                {
                    BNode<T> rightOfDeleted = root._right;
                    rightOfDeleted._parent = root._parent;
                    root._parent._right = rightOfDeleted;
                }
            }
            else if (root._left != null && root._right != null)
            {
                BNode<T> min = findMinimum(root._right);
                root._data = min._data;
                DeleteS(min, min._data);
            }
        }
    }
    
    private BNode<T> findMinimum(BNode<T> root)
    {
        while (root._left != null)
        {
            root = root._left;
        }
        return root;
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
}
