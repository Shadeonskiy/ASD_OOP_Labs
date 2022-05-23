using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class BinaryTreeNode : IComparable
    {
        public BinaryTreeNode(int value)
        {
            Value = value;
        }
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }
        public int Value { get; set; }
        public int CompareTo(object obj)
        {
            return Value.CompareTo(obj);
        }
    }
    class BinaryTree
    {
        private BinaryTreeNode head;
        public int Count { get; private set; }
        public void Add(int value)
        {
            if(head == null)
            {
                head = new BinaryTreeNode(value);
            }
            else
            {
                AddTo(head, value);
            }
            Count++;
        }
        public void AddTo(BinaryTreeNode node, int value)
        {
            if(value.CompareTo(node.Value) < 0)
            {
                if(node.Left == null)
                {
                    node.Left = new BinaryTreeNode(value);
                }
                else
                {
                    AddTo(node.Left, value);
                }
            }
            else
            {
                if(node.Right == null)
                {
                    node.Right = new BinaryTreeNode(value);
                }
                else
                {
                    AddTo(node.Right, value);
                }
            }
        }
        public BinaryTreeNode FindWithParent(int value, out BinaryTreeNode parent)
        {
            BinaryTreeNode current = head;
            parent = null;
            while(current != null)
            {
                int result = current.CompareTo(value);
                if(result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if(result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }
            return current;
        }
        public bool Remove(int value)
        {
            BinaryTreeNode parent;
            BinaryTreeNode current;
            current = FindWithParent(value, out parent);
            if(current == null)
            {
                return false;
            }
            Count--;
            //якщо елемент не має правого нащадка
            if(current.Right == null)
            {
                if(parent == null)
                {
                    head = current.Left;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if(result > 0)
                    {
                        parent.Left = current.Left;
                    }
                    else if(result < 0)
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            //якщо елемент має правого нащадка, який не має лівого нащадка
            else if(current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (parent == null)
                {
                    head = current.Right;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        parent.Left = current.Right;
                    }
                    else if (result < 0)
                    {
                        parent.Right = current.Right;
                    }
                }
            }
            //якщо елемент має правого нащадка, який має лівого нащадка
            else
            {
                BinaryTreeNode leftmost = current.Right.Left;
                BinaryTreeNode leftmostParent = current.Right;
                while(leftmost.Left != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }
                leftmostParent.Left = leftmost.Right;
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;
                if(parent == null)
                {
                    head = leftmost;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        parent.Left = leftmost;
                    }
                    else if (result < 0)
                    {
                        parent.Right = leftmost;
                    }
                }
            }
            return true;
        }
        public System.Collections.IEnumerator GetEnumerator()
        {
            return InOrderTraversal();
        }
        public IEnumerator<int> InOrderTraversal()
        {
            if (head != null)
            {
                Stack<BinaryTreeNode> stack = new Stack<BinaryTreeNode>();
                BinaryTreeNode current = head;
                bool goLeft = true;
                stack.Push(current);
                while (stack.Count > 0)
                {
                    if (goLeft)
                    {
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }
                    yield return current.Value;
                    if (current.Right != null)
                    {
                        current = current.Right;
                        goLeft = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goLeft = false;
                    }
                }
            }
        }
    }
}
