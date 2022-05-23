using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
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
            Separator();
            int ArrayLength = 0;
            do
            {
                Console.WriteLine("Введіть кількість будівель");
            }while(!Int32.TryParse(Console.ReadLine(), out ArrayLength) || ArrayLength < 2);
            Separator();
            Queue<int> queue = new Queue<int>();
            Console.WriteLine("Введіть висоти {0} будівель:", ArrayLength);
            string message = Console.ReadLine().Trim();
            var symbols = message.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            int[] array = new int[ArrayLength];
            int index = 0;
            Separator();
            foreach (var item in symbols)
            {
                if(Int32.TryParse(item, out var number))
                {
                    array[index++] = number;
                }
            }
            int first = array[0];
            foreach(var item in array)
            {
                if(item > first)
                {
                    queue.Enqueue(item);
                }
            }
            Console.WriteLine($"Кількість будівель, що буде видно: {queue.Count}");
            Console.WriteLine("Висоти будівель: ");
            while(queue.Count > 0)
            {
                Console.Write(queue.Dequeue() + " ");
            }
            Console.WriteLine();
        }
    }
}