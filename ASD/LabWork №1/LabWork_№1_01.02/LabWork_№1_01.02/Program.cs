using System;

namespace LabWork__1_01._02
{
    class Program
    {
        static void Sort(int[] Array)
        {
            int index = 0;
            int indexMin = 0;
            int Temporary;
            for (index = 0; index < Array.Length; index++)
            {
                indexMin = index;
                for (int j = index + 1; j < Array.Length; j++)
                {
                    if (Array[j] < Array[indexMin])
                    {
                        indexMin = j;
                    }
                }
                if (index != indexMin)
                {
                    Temporary = Array[index];
                    Array[index] = Array[indexMin];
                    Array[indexMin] = Temporary;
                }
            }
        }
        static void Sort(LinkedList current)
        {
            int Temporary;
            LinkedList index = null;
            while(current != null)
            {
                index = current.Next;
                while(index != null)
                {
                    if(current.Data > index.Data)
                    {
                        Temporary = current.Data;
                        current.Data = index.Data;
                        index.Data = Temporary;
                    }
                    index = index.Next;
                }
                current = current.Next;
            }
        }
        static bool IsSort(int[] Array)
        {
            int index = 0;
            bool IsSort = true;
            while(index != Array.Length && IsSort)
            {
                if (Array[index] > Array[index + 1])
                {
                    IsSort = false;
                }
                index++;
            }
            return IsSort;
        }
        static bool IsSort(LinkedList head)
        {
            bool IsSort = true;
            while(head.Next != null && IsSort)
            {
                if(head.Data > head.Next.Data)
                {
                    IsSort = false;
                }
                head = head.Next;
            }
            return IsSort;
        }
        static void Output(LinkedList head)
        {
            Console.WriteLine("\t\t---�i�i���-��'����� ������---");
            while (head != null)
            {
                Console.Write(head.Data + " ");
                head = head.Next;
            }
            Console.WriteLine();
        }
        static void Output(int[] Array)
        {
            int index = 0;
            Console.WriteLine("\t\t\t---�����---");
            for (index = 0; index < Array.Length; index++) 
            {
                Console.Write(Array[index] + " ");
            }
            Console.WriteLine();
        }
        static int[] CreateArray()
        {
            int index = 0;
            int ArrayLength;
            Console.WriteLine("����i�� �i���i��� �������i� ������ > 0");
            while (!Int32.TryParse(Console.ReadLine(), out ArrayLength) || ArrayLength <= 0)
            {
                Console.WriteLine("����i�� �i���i��� �������i� ������ > 0");
            }
            int[] Array = new int[ArrayLength];
            int LeftLimit = 0;
            int RightLimit = 0;
            Console.WriteLine("����i�� �i������ ������� �����");
            Console.Write("�i�� �������: ");
            while (!Int32.TryParse(Console.ReadLine(), out LeftLimit))
            {
                Console.Write("�i�� �������: ");
            }
            Console.Write("����� �������: ");
            while (!Int32.TryParse(Console.ReadLine(), out RightLimit))
            {
                Console.Write("����� �������: ");
            }
            if(LeftLimit > RightLimit)
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
        static void LinearSearch(int [] Array)
        {
            int index = 0;
            Console.WriteLine("�i�i���� ����� � �������i����� �����i");
            Separator();
            int _choice_;
            Console.WriteLine("������� ����� �� �����? 1 - ���; 2 - �i");
            while (!Int32.TryParse(Console.ReadLine(), out _choice_) || (_choice_ != 1 && _choice_ != 2))
            {
                Console.WriteLine("������� ����� �� �����? 1 - ���; 2 - �i");
            }
            if(_choice_ == 1)
            {
                Separator();
                Output(Array);
                Separator();
            }
            Console.WriteLine("����i�� ������� ������, ���� �����i��� ������");
            int key;
            while(!Int32.TryParse(Console.ReadLine(),out key))
            {
                Console.WriteLine("����i�� ������� ������, ���� �����i��� ������");
            }
            Separator();
            bool Found = false;
            DateTime StartTime = DateTime.Now;
            while (index < Array.Length && !Found)
            {
                if (Array[index] == key)
                {
                    Found = true;
                }
                index++;
            }
            if (Found)
            {
                Console.WriteLine("������� ��������, ���� ���������� �����: " + index + ".");      
            }
            else
            {
                Console.WriteLine("������� �� ��������.");
            }
            Console.WriteLine($"��� ������ ��������� = {DateTime.Now - StartTime}");
        }
        static void LinearSearch(LinkedList head)
        {
            int index = 0;
            Console.WriteLine("�i�i���� ����� � �i�i���-��'������ ������");
            Separator();
            int _choice_;
            Console.WriteLine("������� ������ �� �����? 1 - ���; 2 - �i");
            while (!Int32.TryParse(Console.ReadLine(), out _choice_) || (_choice_ != 1 && _choice_ != 2))
            {
                Console.WriteLine("������� ������ �� �����? 1 - ���; 2 - �i");
            }
            if (_choice_ == 1)
            {
                Separator();
                Output(head);
                Separator();
            }
            Console.WriteLine("����i�� ������� ������, ���� �����i��� ������");
            int key;
            while (!Int32.TryParse(Console.ReadLine(), out key))
            {
                Console.WriteLine("����i�� ������� ������, ���� �����i��� ������");
            }
            Separator();
            bool Found = false;
            DateTime StartTime = DateTime.Now;
            while(head != null && !Found)
            {
                if(head.Data == key)
                {
                    Found = true;
                }
                index++;
                head = head.Next;
            }
            if (Found)
            {
                Console.WriteLine($"������� ��������, ���� ���������� �����: {index}.");      
            }
            else
            {
                Console.WriteLine("������� �� ��������.");
            }
            Console.WriteLine($"��� ������ ��������� = {DateTime.Now - StartTime}");
        }
        static void BarrierSearch(int [] nArray, int ArrayLength)
        {
            int index = 0;
            Console.WriteLine("����� � �������� � �������i����� �����i");
            Separator();
            int _choice_;
            Console.WriteLine("������� ����� �� �����? 1 - ���; 2 - �i");
            while (!Int32.TryParse(Console.ReadLine(), out _choice_) || (_choice_ != 1 && _choice_ != 2))
            {
                Console.WriteLine("������� ����� �� �����? 1 - ���; 2 - �i");
            }
            if (_choice_ == 1)
            {
                Separator();
                Output(nArray);
                Separator();
            }
            Console.WriteLine("����i�� ������� ������, ���� �����i��� ������");
            int key;
            while (!Int32.TryParse(Console.ReadLine(), out key))
            {
                Console.WriteLine("����i�� ������� ������, ���� �����i��� ������");
            }
            Separator();
            Array.Resize(ref nArray, ArrayLength + 1);
            nArray[ArrayLength] = key;
            DateTime StartTime = DateTime.Now;
            while (nArray[index] != key)
            {
                index++;
            }
            if (index == ArrayLength)
            {
                Console.WriteLine ("������� �� ��������.");
            }
            else
            {
                Console.WriteLine("������� ��������, ���� ���������� �����: " + (index + 1) + ".");
            }
            Console.WriteLine($"��� ������ ��������� = {DateTime.Now - StartTime}");
            Array.Resize(ref nArray, ArrayLength);
        }
        static void BarrierSearch(LinkedList head)
        {
            int index = 0;
            Console.WriteLine("����� � �������� � �i�i���-��'������ ������");
            Separator();
            int _choice_;
            Console.WriteLine("������� ������ �� �����? 1 - ���; 2 - �i");
            while (!Int32.TryParse(Console.ReadLine(), out _choice_) || (_choice_ != 1 && _choice_ != 2))
            {
                Console.WriteLine("������� ������ �� �����? 1 - ���; 2 - �i");
            }
            if (_choice_ == 1)
            {
                Separator();
                Output(head);
                Separator();
            }
            Console.WriteLine("����i�� ������� ������, ���� �����i��� ������");
            int key;
            while (!Int32.TryParse(Console.ReadLine(), out key))
            {
                Console.WriteLine("����i�� ������� ������, ���� �����i��� ������");
            }
            Separator();
            LinkedList newNode = new LinkedList(key, null);
            LinkedList temp = head;
            while(temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newNode;
            temp = head;
            DateTime StartTime = DateTime.Now;
            while (temp.Data != key)
            {
                temp = temp.Next;
                index++;
            }
            if (temp.Next == null)
            {
                Console.WriteLine("������� �� ��������.");
            }
            else
            {
                Console.WriteLine("������� ��������, ���� ���������� �����: " + (index + 1) + ".");
            }
            Console.WriteLine($"��� ������ ��������� = {DateTime.Now - StartTime}");
            while (head.Next.Next != null)
            {
                head = head.Next;
            }
            head.Next = null;
        }
        static void BinarySearch(int [] Array, bool isGoldenRation)
        {
            double goldenration = (Math.Sqrt(5) + 1) / 2;
            double lambda = 0;
            if (isGoldenRation)
            {
                lambda = goldenration;
            }
            else
            {
                lambda = 1;
            }
            Console.WriteLine("�i������ ����� � �������i����� �����i");
            Separator();
            int _choice_;
            Console.WriteLine("������� ����� �� �����? 1 - ���; 2 - �i");
            while (!Int32.TryParse(Console.ReadLine(), out _choice_) || (_choice_ != 1 && _choice_ != 2))
            {
                Console.WriteLine("������� ����� �� �����? 1 - ���; 2 - �i");
            }
            if (_choice_ == 1)
            {
                Separator();
                Output(Array);
                Separator();
            }
            Console.WriteLine("����i�� ������� ������, ���� �����i��� ������");
            int key;
            while (!Int32.TryParse(Console.ReadLine(), out key))
            {
                Console.WriteLine("����i�� ������� ������, ���� �����i��� ������");
            }
            Separator();
            int Left = 0, Right = Array.Length - 1;
            int Middle = 0;
            DateTime StartTime = DateTime.Now;
            while (Left < Right)
            {
                Middle = (int)((Left + lambda*Right) / (1+lambda));
                if (key > Array[Middle])
                {
                    Left = Middle + 1;
                }
                else
                {
                    Right = Middle;
                }
            }
            if(Array[Right] == key)
            {
                Console.WriteLine("������� ��������, ���� ���������� �����: " + (Right + 1) + ".");
            }
            else
            {
                Console.WriteLine("������� �� ��������.");
            }
            Console.WriteLine($"��� ������ ��������� = {DateTime.Now - StartTime}");
        }
        static void BinarySearch(LinkedList head, bool isGoldenRation)
        {
            double goldenration = (Math.Sqrt(5) + 1) / 2;
            double lambda = 0;
            if (isGoldenRation)
            {
                lambda = goldenration;
            }
            else
            {
                lambda = 1;
            }
            Console.WriteLine("�i������ ����� � �i�i���-��'������ ������");
            Separator();
            int _choice_;
            Console.WriteLine("������� ������ �� �����? 1 - ���; 2 - �i");
            while (!Int32.TryParse(Console.ReadLine(), out _choice_) || (_choice_ != 1 && _choice_ != 2))
            {
                Console.WriteLine("������� ������ �� �����? 1 - ���; 2 - �i");
            }
            if (_choice_ == 1)
            {
                Separator();
                Output(head);
                Separator();
            }
            Console.WriteLine("����i�� ������� ������, ���� �����i��� ������");
            int key;
            while (!Int32.TryParse(Console.ReadLine(), out key))
            {
                Console.WriteLine("����i�� ������� ������, ���� �����i��� ������");
            }
            Separator();
            int indexLeft = 0, indexRight = LinkedList.GetLength(head), indexMiddle = 0;
            LinkedList nodeLeft = head, nodeRight = null, nodeMiddle = null;
            DateTime StartTime = DateTime.Now;
            while (nodeRight == null || nodeLeft.Data != nodeRight.Data)
            {
                indexMiddle = (int)((indexLeft + lambda * indexRight) / (1 + lambda));
                nodeMiddle = LinkedList.GetElement(nodeLeft, indexMiddle - indexLeft);
                if(key > nodeMiddle.Data)
                {
                    indexLeft = indexMiddle + 1;
                    nodeLeft = nodeMiddle.Next;
                }
                else
                {
                    indexRight = indexMiddle;
                    nodeRight = nodeMiddle;
                }
            }
            if(key == nodeRight.Data)
            {
                Console.WriteLine("������� ��������, ���� ���������� �����: " + (indexRight + 1) + ".");
            }
            else
            {
                Console.WriteLine("������� �� ��������.");
            }
            Console.WriteLine($"��� ������ ��������� = {DateTime.Now - StartTime}");
        }
        static void Separator()//����� ��������� �� ����� �i�i� �������������
        {
            Console.WriteLine("-------------------------------------------------------");
        }
       
        static void Menu()
        {
            int[] Array = CreateArray();
            LinkedList head = LinkedList.GetList(Array);
            bool _exit_ = false;
            int _choice_;
            int menu = 0;
            while(!_exit_)
            {
                Console.WriteLine("�����i�� ��������, �� ���� ��������(1-7)\n1. ������� ����� i ������ �� �����\n2. �������� ����� �����\n3. �������� �i�i���-��'����� ������\n4. �i�i���� �����\n5. ����� � ��������\n6. �i������ �����\n7. �i������ ����� �� �����i �������� ��������");
                while (!Int32.TryParse(Console.ReadLine(), out menu))//�����i��� �� ��������i��� �����
                {
                    Console.WriteLine("�����i�� ��������, �� ���� ��������(1-7)\n1. ������� ����� i ������ �� �����\n2. �������� ����� �����\n3. �������� �i�i���-��'����� ������\n4. �i�i���� �����\n5. ����� � ��������\n6. �i������ �����\n7. �i������ ����� �� �����i �������� ��������");
                }
                Separator();
                switch(menu)
                {
                    case 1:
                        Output(Array);
                        Separator();
                        Output(head);
                        Separator();
                        break;
                    case 2:
                        Array = CreateArray();
                        Separator();
                        break;
                    case 3:
                        head = LinkedList.GetList(CreateArray());
                        Separator();
                        break;
                    case 4:
                        LinearSearch(Array);
                        Separator();
                        LinearSearch(head);
                        Separator();
                        break;
                    case 5:
                        BarrierSearch(Array, Array.Length);
                        Separator();
                        BarrierSearch(head);
                        Separator();
                        break;
                    case 6:
                        if(IsSort(Array) && IsSort(head))
                        {
                            BinarySearch(Array, false);
                            Separator();
                            BinarySearch(head, false);
                        }
                        else
                        {
                            Console.WriteLine("����� i ������ �� �i����������. �i����������? (1 - ���, 2 - �i)");
                            while(!Int32.TryParse(Console.ReadLine(), out _choice_) || (_choice_ != 1 && _choice_ != 2))
                            {
                                Console.WriteLine("����� i ������ �� �i����������. �i����������? (1 - ���, 2 - �i)");
                            }
                            if(_choice_ == 1)
                            {
                                Sort(Array);
                                Sort(head);
                                Separator();
                                BinarySearch(Array, false);
                                Separator();
                                BinarySearch(head, false);
                            }
                        }
                        Separator();
                        break;
                    case 7:
                        if (IsSort(Array) && IsSort(head))
                        {
                            BinarySearch(Array, true);
                            Separator();
                            BinarySearch(head, true);
                        }
                        else
                        {
                            Console.WriteLine("����� i ������ �� �i����������. �i����������? (1 - ���, 2 - �i)");
                            while (!Int32.TryParse(Console.ReadLine(), out _choice_) || (_choice_ != 1 && _choice_ != 2))
                            {
                                Console.WriteLine("����� i ������ �� �i����������. �i����������? (1 - ���, 2 - �i)");
                            }
                            if (_choice_ == 1)
                            {
                                Sort(Array);
                                Sort(head);
                                Separator();
                                BinarySearch(Array, true);
                                Separator();
                                BinarySearch(head, true);
                            }
                        }
                        Separator();
                        break;
                    default:
                        _exit_ = true;
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("����������� ������ � ��� �1. ��������� ���������. I��-11");
            Console.WriteLine("��������� ������ � �������i���� ������� i �������");
            Menu();
        }
    }
}
