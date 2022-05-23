using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class LinkedList
    {
        public LinkedList(int Value, LinkedList Next)
        {
            this.Value = Value;
            this.Next = Next;
        }
        public int Value { get; set; }
        public LinkedList Next { get; set; }
        public static int ReadInt(string message)
        {
            int Value;
            do
            {
                Console.WriteLine(message);
            } while (!Int32.TryParse(Console.ReadLine(), out Value));
            return Value;
        }
        public static LinkedList CreateList()
        {
            int Size = ReadInt("Введiть кiлькiсть елементiв, що мають бути доданi до лiнiйно-зв'язного списку");
            int index = Size - 1;
            int value = ReadInt($"Введiть {index}-й елемент списку:");
            var current = new LinkedList(value, null);
            while (index > 0)
            {
                index--;
                value = ReadInt($"Введiть {index}-й елемент списку:");
                var previous = new LinkedList(value, current);
                current = previous;
            }
            return current;
        }
        public void Swap(ref LinkedList head, int Value1, int Value2)
        {
            LinkedList node1 = head;
            LinkedList node2 = head;
            LinkedList previous1 = null;
            LinkedList previous2 = null;
            if (Value1 != Value2)
            {
                if (head.Value.Equals(Value1))
                {
                    while (node2 != null)
                    {
                        if (node2.Next.Value.Equals(Value2))
                        {
                            previous2 = node2;
                            node2 = node2.Next;
                            break;
                        }
                        node2 = node2.Next;
                    }
                    if (node2 == null)
                    {
                        throw new ArgumentException("Такого елемента не існує");
                    }
                    if(node1.Next.Equals(node2))
                    {
                        head = node2;
                        node2.Next = node1;
                        node1.Next = node2.Next;

                    }
                    else if(node2.Next.Equals(node1))
                    {
                        head = node1;
                        node1.Next = node2;
                        node2.Next = node1.Next;
                    }
                    else
                    {
                        head = node2.Next;
                    }
                }
                else if (head.Value.Equals(Value2))
                {

                }
                else
                {
                    while (node1 != null)
                    {
                        if (node1.Next.Value.Equals(Value1))
                        {
                            previous1 = node1;
                            node1 = node1.Next;
                            break;
                        }
                        node1 = node1.Next;
                    }
                    if (node1 == null)
                    {
                        throw new ArgumentException("Такого елемента не існує");
                    }
                    while (node2 != null)
                    {
                        if (node2.Next.Value.Equals(Value2))
                        {
                            previous2 = node2;
                            node2 = node2.Next;
                            break;
                        }
                        node2 = node2.Next;
                    }
                    if (node2 == null)
                    {
                        throw new ArgumentException("Такого елемента не існує");
                    }
                    if (node1.Next.Equals(node2))
                    {
                        previous1.Next = node2;
                        previous2.Next = node2.Next;
                        node2.Next = node1;
                    }
                    else if(node2.Next.Equals(node1))
                    {
                        previous2.Next = node1;
                        previous1.Next = node1.Next;
                        node1.Next = node2;
                    }
                    else
                    {
                        previous1.Next = node2;
                        LinkedList Temporary = node2.Next;
                        node2.Next = node1.Next;
                        previous2.Next = node1;
                        node1.Next = Temporary;
                    }
                }
            }
        }
        public LinkedList AddFirst(ref LinkedList head, int Value)
        {
            LinkedList newnode = new LinkedList(Value, head);
            head = newnode;
            return head;
        }
        public void AddLast(LinkedList head, int Value)
        {
            LinkedList newnode = new LinkedList(Value, null);
            while (head.Next != null)
            {
                head = head.Next;
            }
            head.Next = newnode;
        }
        public void AddAfter(LinkedList head,int PreviousValue, int AdditionalValue)
        {
            while(head != null)
            {
                if (head.Value.Equals(PreviousValue))
                {
                    LinkedList newnode = new LinkedList(AdditionalValue, head.Next);
                    head.Next = newnode;
                    break;
                }
                head = head.Next;
            }
            if(head == null)
            {
                throw new ArgumentException();
            }
  
        }
        public void AddBefore(ref LinkedList head, int NextValue, int AdditionalValue)
        {
            if(head.Value.Equals(NextValue))
            {
                head.AddFirst(ref head, AdditionalValue);
            }
            else
            {
                LinkedList current = head;
                while (current != null)
                {
                    if (current.Next.Value.Equals(NextValue))
                    {
                        LinkedList newnode = new LinkedList(AdditionalValue, current.Next);
                        current.Next = newnode;
                        break;
                    }
                    current = current.Next;
                }
                if(current == null)
                {
                    throw new ArgumentException();
                }
            }
            
        }
        public static LinkedList GetList(int[] Array)
        {
            int index = Array.Length - 1;
            var last = new LinkedList(Array[index], null);
            while (index > 0)
            {
                index--;
                var newnode = new LinkedList(Array[index], last);
                last = newnode;
            }
            return last;
        }
        public bool Remove(ref LinkedList head, int removableitem)
        {
            LinkedList previous = null;
            LinkedList current = head;
            while(current != null)
            {
                if(current.Value.Equals(removableitem))
                {
                    if(previous != null)
                    {
                        previous.Next = current.Next;
                    }
                    else
                    {
                        head = current.Next;
                        current.Next = null;
                    }
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }
        public static void Display(LinkedList head, string message)
        {
            Console.WriteLine(message);
            while(head != null)
            {
                Console.Write(head.Value + " ");
                head = head.Next;
            }
            Console.WriteLine();
        }
    }
}
