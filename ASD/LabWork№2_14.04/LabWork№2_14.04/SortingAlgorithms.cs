using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork_2_14._04
{
    internal class SortingAlgorithms
    {
        public static void InsertionSort(int[] NotSortedArray)
        {
            DateTime Start = DateTime.Now;
            int[] SortedArray = new int[NotSortedArray.Length];
            Array.Copy(NotSortedArray, SortedArray, NotSortedArray.Length);
            int key, j, index;
            for (index = 0; index < SortedArray.Length; index++)
            {
                key = SortedArray[index];
                j = index;
                while (j > 0 && SortedArray[j - 1] > key)
                {
                    SortedArray[j] = SortedArray[--j];
                }
                SortedArray[j] = key;
            }
            Console.WriteLine("Початковий масив: ");
            /*InputOutput.PrintCollection(NotSortedArray);*/
            Console.WriteLine("Вiдсортований масив: ");
            /*InputOutput.PrintCollection(SortedArray);*/
            Console.WriteLine("Час сортування: {0} секунд", (DateTime.Now - Start).TotalSeconds);
        }
        public static void InsertionSort(LinkedList NotSortedList)
        {
            DateTime Start = DateTime.Now;
            LinkedList.CopyTo(NotSortedList,0, out var SortedList, LinkedList.GetLength(NotSortedList));
            int j, index = 0;
            while (SortedList != null)
            {
                var key = SortedList;
                j = index;
                while (j > 0 && SortedList.Previous.Data > key.Data)
                {
                    LinkedList.Swap(SortedList.Previous, SortedList);
                    j--;
                }
                SortedList = LinkedList.GetElement(LinkedList.GetFirst(SortedList), j);
                LinkedList.Swap(key, SortedList);
                SortedList = LinkedList.GetElement(LinkedList.GetFirst(SortedList), index);
                index++;
                if (SortedList.Next == null) break;
                SortedList = SortedList.Next;
            }
            Console.WriteLine("Початковий список: ");
            /*InputOutput.PrintCollection(NotSortedList);*/
            Console.WriteLine("Вiдсортований список: ");
            /*InputOutput.PrintCollection(LinkedList.GetFirst(SortedList));*/
            Console.WriteLine("Час сортування: {0} секунд", (DateTime.Now - Start).TotalSeconds);
        }
        public static void SelectionSort(int[] NotSortedArray)
        {
            DateTime Start = DateTime.Now;
            int[] SortedArray = new int[NotSortedArray.Length];
            Array.Copy(NotSortedArray, SortedArray, NotSortedArray.Length);
            int indexmin;
            for (int i = 0; i < SortedArray.Length; i++)
            {
                indexmin = i;
                for (int j = i + 1; j < SortedArray.Length; j++)
                {
                    if (SortedArray[j] < SortedArray[indexmin])
                    {
                        indexmin = j;
                    }
                }
                if (i != indexmin)
                {
                    int temp = SortedArray[i];
                    SortedArray[i] = SortedArray[indexmin];
                    SortedArray[indexmin] = temp;
                }
            }
            Console.WriteLine("Початковий масив: ");
            /*InputOutput.PrintCollection(NotSortedArray);*/
            Console.WriteLine("Вiдсортований масив: ");
            /*InputOutput.PrintCollection(SortedArray);*/
            Console.WriteLine("Час сортування: {0} секунд", (DateTime.Now - Start).TotalSeconds);
        }
        public static void SelectionSort(LinkedList NotSortedList)
        {
            DateTime Start = DateTime.Now;
            LinkedList.CopyTo(NotSortedList,0, out var SortedList, LinkedList.GetLength(NotSortedList));
            int indexmin, index = 0;
            while(SortedList.Next != null)
            {
                indexmin = index;
                var Temporary = SortedList.Next;
                while(Temporary != null)
                {
                    var Minimum = LinkedList.GetElement(LinkedList.GetFirst(SortedList), indexmin);
                    if (Temporary.Data < Minimum.Data)
                    {
                        indexmin = Temporary.IndexOf(SortedList, index);
                    }
                    Temporary = Temporary.Next;
                }
                if(index != indexmin)
                {
                    var node1 = LinkedList.GetElement(LinkedList.GetFirst(SortedList), index);
                    var node2 = LinkedList.GetElement(LinkedList.GetFirst(SortedList), indexmin);
                    LinkedList.Swap(node1, node2);
                    SortedList = node2;
                }
                index++;
                SortedList = SortedList.Next;
            }
            Console.WriteLine("Початковий список: ");
           /* InputOutput.PrintCollection(NotSortedList);*/
            Console.WriteLine("Вiдсортований список: ");
           /* InputOutput.PrintCollection(LinkedList.GetFirst(SortedList));*/
            Console.WriteLine("Час сортування: {0} секунд", (DateTime.Now - Start).TotalSeconds);
        }
        public static void MergeSort(int[] NotSortedArray, bool start)
        {
            int[] SortedArray = new int[NotSortedArray.Length];
            Array.Copy(NotSortedArray, SortedArray, NotSortedArray.Length);
            DateTime Start = DateTime.Now;
            MergeSort(SortedArray);
            Console.WriteLine("Початковий масив: ");
           /* InputOutput.PrintCollection(NotSortedArray);*/
            Console.WriteLine("Вiдсортований масив: ");
            /*InputOutput.PrintCollection(SortedArray);*/
            Console.WriteLine("Час сортування: {0} секунд", (DateTime.Now - Start).TotalSeconds);
        }
        public static void MergeSort(int[] array)
        {
            if(array.Length <= 1)
            {
                return;
            }
            int LeftSize = array.Length / 2;
            int RightSize = array.Length - LeftSize;
            int[] left = new int[LeftSize];
            int[] right = new int[RightSize];
            Array.Copy(array, 0, left, 0, LeftSize);
            Array.Copy(array, LeftSize, right, 0, RightSize);
            MergeSort(left);
            MergeSort(right);
            Merge(array, left, right);
        }
        private static void Merge(int[] array, int[] left, int[] right)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int targetIndex = 0;
            int Size = left.Length + right.Length;
            while (Size > 0)
            {
                if(leftIndex >= left.Length)
                {
                    array[targetIndex] = right[rightIndex++];
                }
                else if(rightIndex >= right.Length)
                {
                    array[targetIndex] = left[leftIndex++];
                }
                else if(left[leftIndex] <= right[rightIndex])
                {
                    array[targetIndex] = left[leftIndex++];
                }
                else
                {
                    array[targetIndex] = right[rightIndex++];
                }
                targetIndex++;
                Size--;
            }
        }
        public static void MergeSort(LinkedList NotSortedList, bool start)
        {
            LinkedList.CopyTo(NotSortedList, 0, out var SortedList, LinkedList.GetLength(NotSortedList));
            DateTime Start = DateTime.Now;
            SortedList = MergeSort(SortedList);
            Console.WriteLine("Початковий список: ");
          /*  InputOutput.PrintCollection(NotSortedList);*/
            Console.WriteLine("Вiдсортований список: ");
           /* InputOutput.PrintCollection(SortedList);*/
            Console.WriteLine("Час сортування: {0} секунд", (DateTime.Now - Start).TotalSeconds);
        }
        public static LinkedList MergeSort(LinkedList List)
        {
            int Length = LinkedList.GetLength(List);
            if (Length <= 1)
            {
                return List;
            }
            int LeftSize = Length / 2;
            int RightSize = Length - LeftSize;
            LinkedList.CopyTo(List, 0, out var Left, LeftSize);
            LinkedList.CopyTo(List, LeftSize, out var Right, RightSize);
            Left = MergeSort(Left);
            Right = MergeSort(Right);
            return Merge(Left, Right);
        }
        private static LinkedList Merge(LinkedList left, LinkedList right)
        {
            LinkedList List = null;
            int leftIndex = 0;
            int rightIndex = 0;
            int leftLength = LinkedList.GetLength(left);
            int rightLength = LinkedList.GetLength(right);
            int Size = leftLength + rightLength;
            while(Size > 0)
            {
                if(leftIndex >= leftLength)
                {
                    List = LinkedList.Add(List, right.Data);
                    right = right.Next;
                    rightIndex++;
                }
                else if (rightIndex >= rightLength)
                {
                    List = LinkedList.Add(List, left.Data);
                    left = left.Next;
                    leftIndex++;
                }
                else if (LinkedList.GetElement(LinkedList.GetFirst(left),leftIndex).Data <= LinkedList.GetElement(LinkedList.GetFirst(right), rightIndex).Data)
                {
                    List = LinkedList.Add(List, left.Data);
                    left = left.Next;
                    leftIndex++;
                }
                else
                {
                    List = LinkedList.Add(List, right.Data);
                    right = right.Next;
                    rightIndex++;
                }
                Size--;
            }
            return LinkedList.GetFirst(List);
        }
    }
}
