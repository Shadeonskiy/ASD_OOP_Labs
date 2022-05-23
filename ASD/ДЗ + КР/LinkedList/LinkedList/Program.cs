using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8 };
            LinkedList instance = LinkedList.GetList(array);
            LinkedList head = instance;
            LinkedList.Display(head, "Зв'язний список: ");
            instance.AddFirst(ref head, 6);
            LinkedList.Display(head, "Зв'язний список: ");
            instance.AddLast(head, 9);
            LinkedList.Display(head, "Зв'язний список: ");
            instance.Remove(ref head, 6);
            LinkedList.Display(head, "Зв'язний список: ");
            instance.AddAfter(head,5, 6);
            LinkedList.Display(head, "Зв'язний список: ");
            instance.AddBefore(ref head, 1, 100);
            LinkedList.Display(head, "Зв'язний список: ");
            instance.Swap(ref head, 5, 4);
            LinkedList.Display(head, "Зв'язний список: ");
            /*LinkedList list = LinkedList.CreateList();
            LinkedList.Display(list, "==========LinkedList==========");*/
        }
    }
}
