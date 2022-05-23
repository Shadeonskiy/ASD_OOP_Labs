using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork_3_15._05
{
    class Program
    {
        static void Main(string[] args)
        {
            Red_Black_Tree tree = new Red_Black_Tree();
            tree.Add(11);
            tree.Add(2);
            tree.Add(14);
            tree.Add(1);
            tree.Add(7);
            tree.Add(5);
            tree.Add(8);
            tree.Add(15);
            /*tree.Add(1);
            tree.Add(2);
            tree.Add(3);
            tree.Add(4);
            tree.Add(5);*/
            foreach (var item in tree)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(item + " ");
            }
            Console.WriteLine();
            tree.Remove(11);
            foreach (var item in tree)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}