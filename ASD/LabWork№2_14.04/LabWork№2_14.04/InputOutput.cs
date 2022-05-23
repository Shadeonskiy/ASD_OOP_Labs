using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork_2_14._04
{
    public static class InputOutput
    {
        public static void Separator()
        {
            Console.WriteLine("======================================================");
        }
        public static void PrintMenu()
        {
            Separator();
            Console.WriteLine("\t\t\tМЕНЮ");
            Separator();
            Console.WriteLine("1. Вивести меню на екран");
            Console.WriteLine("2. Створити масив i список");
            Console.WriteLine("3. Вивести масив i список на екран");
            Console.WriteLine("4. Сортування вставкою (Insertion Sort)");
            Console.WriteLine("5. Сортування вибором (Selection Sort)");
            Console.WriteLine("6. Сортування злиттям (Merge Sort)");
            Console.WriteLine("Iнше. Вихiд ");
            Separator();
        }
        public static void PrintCollection(int[] Array)
        {
            int index = 0;
            for (index = 0; index < Array.Length - 1; index++)
            {
                Console.Write(Array[index] + " ");
            }
            Console.WriteLine(Array[^1]);
        }
        public static void PrintCollection(LinkedList List)
        {
            while(List.Next != null)
            {
                Console.Write(List.Data + " ");
                List = List.Next;
            }
            Console.WriteLine(List.Data);
        }
        public static void Initiate(out int[] Array, out LinkedList List)
        {
            Array = GetArray();
            List = GetList(Array);
        }
        public static int[] GetArray()
        {
            int index = 0;
            int ArrayLength;
            do
            {
                Console.WriteLine("Введiть кiлькiсть елементiв масиву");
            } while (!Int32.TryParse(Console.ReadLine(), out ArrayLength) || ArrayLength <= 0);
            int[] Array = new int[ArrayLength];
            int LeftLimit = 0;
            int RightLimit = 0;
            Console.WriteLine("Введiть дiапазон значень чисел");
            Console.Write("Лiва границя: ");
            while (!Int32.TryParse(Console.ReadLine(), out LeftLimit))
            {
                Console.Write("Лiва границя: ");
            }
            Console.Write("Права границя: ");
            while (!Int32.TryParse(Console.ReadLine(), out RightLimit))
            {
                Console.Write("Права границя: ");
            }
            if (LeftLimit > RightLimit)
            {
                int Temporary;
                Temporary = LeftLimit;
                LeftLimit = RightLimit;
                RightLimit = Temporary;
            }
            Random rand = new Random();
            for (index = 0; index < ArrayLength; index++)
            {
                Array[index] = rand.Next(LeftLimit, RightLimit + 1);
            }
            return Array;
        }
        public static LinkedList GetList(int[] Array)
        {
            int index = Array.Length - 1;
            var List = new LinkedList(Array[index], null, null);
            while (index > 0)
            {
                index--; 
                var temp = new LinkedList(Array[index], List, null);
                List.Previous = temp;
                List = temp;
            }
            return List;
        }
    }
}
