namespace Task3;

public class TreeNode
{
    public int value;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int value)
    {
        this.value = value;
        left = null;
        right = null;
    }

    public TreeNode InsertRecursive(TreeNode node, int value)  
    {
        if (node == null)
            return new TreeNode(value);

        if (value < node.value)  
            node.left = InsertRecursive(node.left, value); 
        else if (value > node.value)
            node.right = InsertRecursive(node.right, value);  

        return node;
    }
    public int GetMin(TreeNode node)
    {
        if (node == null)
            return int.MaxValue;

        int left = GetMin(node.left);
        int right = GetMin(node.right);

        return Math.Min(node.value, Math.Min(left, right));
    }

    
}