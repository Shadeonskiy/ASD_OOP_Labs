using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
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
            int value = 0;
            bool _exit_ = false;
            Separator();
            do
            {
                Console.WriteLine("Введіть максимальну довжину (висоту) стеку");
            } while (!Int32.TryParse(Console.ReadLine(), out value));
            var set_of_stacks = new SetOfStacks(value);
            while(!_exit_)
            {
                int choose = 0;
                Separator();
                do
                {
                    Console.WriteLine("Оберіть команду, яку хочете виконати:\n1 - Додати елемент у стек\n2 - Видалити останній елемент зі стеку\n3 - Показати стек\nІнша - вихід");
                } while (!Int32.TryParse(Console.ReadLine(), out choose));
                switch (choose)
                {
                    case 1:
                        Separator();
                        do
                        {
                            Console.WriteLine("Введіть число, яке хочете додати");
                        } while (!Int32.TryParse(Console.ReadLine(), out value));
                        set_of_stacks.Push(value);
                        break;
                    case 2:
                        Separator();
                        try
                        {
                            Console.WriteLine($"Видалений елемент: {set_of_stacks.Pop()}");
                        }
                        catch(InvalidOperationException)
                        {
                            Console.WriteLine("Стек пустий");
                        }
                        break;
                    case 3:
                        Separator();
                        foreach (var item in set_of_stacks)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                        break;
                    default:
                        _exit_ = true;
                        break;
                }
            }
        }
    }
}
