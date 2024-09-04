namespace AVL;
using ANode;
public class AVL<T>
{
    public ANode<T>? Root { get; set; }

    public void Insert(T val)
    {
        if (Root == null)
        {
            ANode<T> temp = new()
            {
                Data = val,
                Height = 1
            };
            Root = temp;
        }
        InsertS(Root, val);
    }
    private ANode<T> InsertS(ANode<T> root, T val)
    {

        if (root == null)
        {
            ANode<T> temp = new()
            {
                Data = val,
                Height = 1
            };
            return temp;
        }
        else if (IsBiggerThan(val, root.Data))
        {
            root.Right = InsertS(root.Right, val);
        }
        else if (IsLessThan(val, root.Data))
        {
            root.Left = InsertS(root.Left, val);
        }
        // calculate height
        root.Height = HeightCal(root);

        // LL Rotation 
        if (BalanceFactor(root) == 2 && BalanceFactor(root.Left) == 1)
        {

            ANode<T> pl = root.Left;
            ANode<T> plr = pl.Right;

            pl.Right = root;
            root.Left = plr;

            root.Height = HeightCal(root);
            pl.Height = HeightCal(root);

            if (root == Root)
            {
                Root = pl;
            }

            return pl;
        }
        //LR Rotation
        else if (BalanceFactor(root) == 2 && BalanceFactor(root.Left) == -1)
        {
            ANode<T> pl = root.Left;
            ANode<T> plr = pl.Right;
            ANode<T> plrl = plr.Left;
            ANode<T> plrr = plr.Right;

            plr.Left = pl;
            plr.Right = root;
            pl.Right = plrl;
            root.Left = plrr;

            root.Height = HeightCal(root);
            plr.Height = HeightCal(plr);
            pl.Height = HeightCal(pl);
            if (Root == root)
            {
                Root = plr;
            }
        }
        //RR Rotation
        else if (BalanceFactor(root) == -2 && BalanceFactor(root.Right) == -1)
        {
            ANode<T> pr = root.Right;
            ANode<T> prl = pr.Left;

            pr.Left = root;
            root.Right = prl;

            root.Height = HeightCal(root);
            pr.Height = HeightCal(pr);

            if (root == Root)
            {
                Root = pr;
            }

            return pr;

        }
        //RL rotation
        else if (BalanceFactor(root) == -2 && BalanceFactor(root.Right) == 1)
        {
            ANode<T> pr = root.Right;
            ANode<T> prl = pr.Left;
            ANode<T> prll = prl.Left;
            ANode<T> prlr = prl.Right;

            prl.Left = root;
            prl.Right = pr;
            root.Right = prll;
            pr.Left = prlr;

            root.Height = HeightCal(root);
            pr.Height = HeightCal(pr);
            prl.Height = HeightCal(prl);

            if (Root == root)
            {
                Root = prl;
            }
            return prl;
        }
        return root;
    }
    private int HeightCal(ANode<T> root)
    {
        int lHeight = root != null && root.Left != null ? root.Left.Height : 0;
        int rHeight = root != null && root.Right != null ? root.Right.Height : 0;
        return lHeight > rHeight ? lHeight + 1 : rHeight + 1;
    }
    private int BalanceFactor(ANode<T> root)
    {
        int lHeight = root != null && root.Left != null ? root.Left.Height : 0;
        int rHeight = root != null && root.Right != null ? root.Right.Height : 0;
        return lHeight - rHeight;
    }
    public void Display()
    {
        DisplayS(Root);
    }
    private void DisplayS(ANode<T> root, string prefix = "", bool isLeft = false)
    {
        if (root != null)
        {
            Console.Write(prefix);

            if (isLeft)
            {
                Console.Write("├── ");
            }
            else
            {
                Console.Write("└── ");
            }
            Console.WriteLine(root.Data);


            //Print the left subtree
            DisplayS(root.Left, prefix + (isLeft ? "│   " : "    "), true);
            //Print the right subtree
            DisplayS(root.Right, prefix + (isLeft ? "│   " : "    "), false);
        }

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
