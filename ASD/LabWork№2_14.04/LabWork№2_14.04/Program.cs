using System;

namespace LabWork_2_14._04
{
    class Program
    {
        static void Main(string[] args)
        {
            int _choice_;
            bool _exit_ = false;
            Console.WriteLine("Лабораторна робота з АСД №2. Литвинчук Владислав. IПЗ-11");
            Console.WriteLine("Алгоритми сортування у одновимiрних масивах i списках");
            InputOutput.Initiate(out var Array,out var List);
            InputOutput.PrintMenu();
            while (!_exit_)
            {
                do
                {
                    Console.WriteLine("Виберiть алгоритм, що буде запущено (1-7)");
                } while (!Int32.TryParse(Console.ReadLine(), out _choice_));
                InputOutput.Separator();
                switch(_choice_)
                {
                    case 1:
                        InputOutput.PrintMenu();
                        InputOutput.Separator();
                        break;
                    case 2:
                        InputOutput.Initiate(out Array, out List);
                        InputOutput.Separator();
                        break;
                    case 3:
                        InputOutput.PrintCollection(Array);
                        InputOutput.Separator();
                        InputOutput.PrintCollection(List);
                        InputOutput.Separator();
                        break;
                    case 4:
                        SortingAlgorithms.InsertionSort(Array);
                        InputOutput.Separator();
                        SortingAlgorithms.InsertionSort(List);
                        InputOutput.Separator();
                        break;
                    case 5:
                        SortingAlgorithms.SelectionSort(Array);
                        InputOutput.Separator();
                        SortingAlgorithms.SelectionSort(List);
                        InputOutput.Separator();
                        break;
                    case 6:
                        SortingAlgorithms.MergeSort(Array,true);
                        InputOutput.Separator();
                        SortingAlgorithms.MergeSort(List, true);
                        break;
                    default:
                        _exit_ = true;
                        break;
                }
            }
        }
    }
}
