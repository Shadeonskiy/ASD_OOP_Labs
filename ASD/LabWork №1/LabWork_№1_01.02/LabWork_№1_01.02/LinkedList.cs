using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork__1_01._02
{
    public class LinkedList
    {
        public LinkedList Next;
        public int Data;
        public LinkedList(int Data, LinkedList Next)
        {
            this.Data = Data;
            this.Next = Next;
        }
        public static LinkedList GetList(int[] Array)
        {
            int index = Array.Length - 1;
            var last = new LinkedList(Array[index], null);
            while (index > 0)
            {
                index--;
                var temp = new LinkedList(Array[index], last);
                last = temp;
            }
            return last;
        }
        public static LinkedList GetElement(LinkedList head, int iterations)
        {
            int index = 0;
            for (index = 0; index < iterations; index++)
            {
                head = head.Next;
            }
            return head;
        }
        public static int GetLength(LinkedList head)
        {
            int counter = 0;
            while(head.Next != null)
            {
                counter++;
                head = head.Next;
            }
            return counter;
        }
    }
}
