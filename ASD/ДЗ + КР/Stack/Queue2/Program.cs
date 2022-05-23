using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        public static void Separator()
        {
            int index = 0;
            for (index = 0; index < Console.WindowWidth - 1; index++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("=");
            }
            Console.WriteLine();
            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            int[] array1 = new int[] { 1, 3, 5, 7, 9};
            int[] array2 = new int[] { 2, 4, 6, 8};
            Queue<int> queue1 = new Queue<int>();
            queue1.Enqueue(1);
            queue1.Enqueue(3);
            /*queue1.Enqueue(5);
            /*queue1.Enqueue(7);
            queue1.Enqueue(9);
            Queue<int> queue2 = new Queue<int>();
            /*queue2.Enqueue(2);*/
            /*queue2.Enqueue(4);*/
            /*queue2.Enqueue(6);*/
            /*queue2.Enqueue(8);*/
            Console.WriteLine("Перша черга");
            foreach (int item in queue1)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Separator();
            Console.WriteLine("Друга черга");
            foreach (int item in queue2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Separator();
            Queue<int> result = new Queue<int>();
            int value = 0;
            while (queue1.Count > 0 && queue2.Count > 0)
            {
                if(queue1.Peek() < queue2.Peek())
                {
                    value = queue1.Dequeue();
                    result.Enqueue(value);
                }
                else
                {
                    value = queue2.Dequeue();
                    result.Enqueue(value);
                }
            }
            while(queue1.Count > 0)
            {
                value = queue1.Dequeue();
                result.Enqueue(value);
            }
            while (queue2.Count > 0)
            {
                value = queue2.Dequeue();
                result.Enqueue(value);
            }
            Console.WriteLine("Об'єднана черга");
            foreach (int item in result)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Separator();
        }
    }
}