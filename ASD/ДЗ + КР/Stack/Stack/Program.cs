using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
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
            string message;
            var stack = new Stack<char>();
            Separator();
            do
            {
                Console.WriteLine("Введіть рядок, що складається з послідовності символів '(',')'");
                message = Console.ReadLine();
            }while(string.IsNullOrEmpty(message));
            Separator();
            foreach(var symbol in message)
            {
                try
                {
                    switch (symbol)
                    {
                        case '(':
                            stack.Push(symbol);
                            break;
                        case ')':
                            stack.Pop();
                            break;
                    }
                }
                catch(InvalidOperationException)
                {
                    Console.WriteLine("Додати цифри та знаки арифметичній дій не можна!.");
                    return;
                }
            }
            if(stack.Count == 0)
            {
                Console.WriteLine("Додати цифри та знаки арифметичній дій можна.");
            }
            else
            {
                Console.WriteLine("Додати цифри та знаки арифметичній дій не можна!.");
            }
            Separator();
        }
    }
}