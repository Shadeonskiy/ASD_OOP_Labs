using System;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree Tree = new BinaryTree();
            Tree.Add(8);
            Tree.Add(5);
            Tree.Add(12);
            Tree.Add(3);
            Tree.Add(7);
            Tree.Add(10);
            Tree.Add(15);
            foreach(var item in Tree)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Tree.Remove(9);
            foreach (var item in Tree)
            {
                Console.Write(item + " ");
            }
        }
    }
}
