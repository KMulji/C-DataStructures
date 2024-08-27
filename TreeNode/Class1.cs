using System.Transactions;

namespace TreeNode;

public class TreeNode<T>
{
    public T? _data { get; set; }
    public TreeNode<T>? _parent { get; set; }

    public List<TreeNode<T>> _children { get; set; } = [];

    public int GetHeight()
    {
        int height = 1;
        TreeNode<T> curr = this;

        while (curr._parent != null)
        {
            height++;
            curr = curr._parent;
        }

        return height;
    }
}

