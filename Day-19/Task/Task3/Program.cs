using Task3;

namespace Task2
{
    using System;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {
            TreeNode root = new TreeNode(10);
            root.InsertRecursive(root, 5);
            root.InsertRecursive(root, 15);
            root.InsertRecursive(root, 3);
            root.InsertRecursive(root, 7);
            root.InsertRecursive(root, 12);
            root.InsertRecursive(root, 18);
            Console.WriteLine(root.GetMin(root));

        }
    }
}