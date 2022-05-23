using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork_3_15._05
{
    internal class Red_Black_Tree : IEnumerable
    {
        public Red_Black_Tree_Node? root { get; private set; }
        public int Count { get; private set; }
        public Red_Black_Tree()
        {
            root = null;
        }
        public Red_Black_Tree(Red_Black_Tree_Node root)
        {
            this.root = root;
        }
        public void Add(int value)
        {
            Red_Black_Tree_Node node = null;
            if(root == null)
            {
                root = new Red_Black_Tree_Node(value);
                root.color = Color.Black;
                return;
            }
            else
            {
                node = AddTo(root, value);
            }
            Count++;
            if (node.parent.parent == null || node.parent == null)
            {
                return;
            }
            Fix(node);
        }
        private Red_Black_Tree_Node AddTo(Red_Black_Tree_Node node, int value)
        {
            if (value.CompareTo(node.value) < 0)
            {
                if(node.left == null)
                {
                    node.left = new Red_Black_Tree_Node(value);
                    node.left.parent = node;
                    return node.left;
                }
                else
                {
                    node = AddTo(node.left, value);
                }
            }
            else
            {
                if(node.right == null)
                {
                    node.right = new Red_Black_Tree_Node(value);
                    node.right.parent = node;
                    return node.right;
                }
                else
                {
                    node = AddTo(node.right, value);
                }
            }
            return node;
        }
        public Red_Black_Tree_Node? Find(int value)
        {
            var current = root;
            while (current != null)
            {
                int result = current.CompareTo(value);
                if (result > 0)
                {
                    current = current.left;
                }
                else if (result < 0)
                {
                    current = current.right;
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
            Red_Black_Tree_Node current;
            current = Find(value);
            if (current == null)
            {
                return false;
            }
            Count--;
            //якщо елемент не має правого нащадка
            if (current.right == null)
            {
                if (current.parent == null)
                {
                    root = current.left;
                    current.left.parent = null;
                }
                else
                {
                    int result = current.parent.CompareTo(current.value);
                    if (result > 0)
                    {
                        current.parent.left = current.left;
                        current.left.parent = current.parent;
                    }
                    else if (result < 0)
                    {
                        current.parent.right = current.left;
                        current.left.parent = current.parent;
                    }
                }
            }
            //якщо елемент має правого нащадка, який не має лівого нащадка
            else if (current.right.left == null)
            {
                current.right.left = current.left;
                if (current.parent == null)
                {
                    root = current.right;
                    current.right.parent = null;
                }
                else
                {
                    int result = current.parent.CompareTo(current.value);
                    if (result > 0)
                    {
                        current.parent.left = current.right;
                        current.right.parent = current.parent;
                    }
                    else if (result < 0)
                    {
                        current.parent.right = current.right;
                        current.right.parent = current.parent;
                    }
                }
            }
            //якщо елемент має правого нащадка, який має лівого нащадка
            else
            {
                var leftmost = current.right.left;
                while (leftmost.left != null)
                {
                    leftmost = leftmost.left;
                }
                leftmost.parent.left = leftmost.right;
                leftmost.left = current.left;
                leftmost.right = current.right;
                if (current.parent == null)
                {
                    root = leftmost;
                    leftmost.parent = null;
                }
                else
                {
                    int result = current.parent.CompareTo(current.value);
                    if (result > 0)
                    {
                        current.parent.left = leftmost;
                        leftmost.parent = current.parent;
                    }
                    else if (result < 0)
                    {
                        current.parent.right = leftmost;
                        leftmost.parent = current.parent;
                    }
                }
            }
            if (current.parent == root)
            {
                Fix(current.parent);
            }
            return true;
        }
        private void Fix(Red_Black_Tree_Node node)
        {
            while(node.parent.color == Color.Red)
            {
                if(node.parent == node.parent.parent.left)
                {
                    var rightAunt = node.parent.parent.right;
                    if(rightAunt != null && rightAunt.color == Color.Red)
                    {
                        node.parent.color = Color.Black;
                        rightAunt.color = Color.Black;
                        node.parent.parent.color = Color.Red;
                        node = node.parent.parent;
                    }
                    else
                    {
                        if(node == node.parent.right)
                        {
                            node = node.parent;
                            LeftRotate(node);
                        }
                        node.parent.color = Color.Black;
                        node.parent.parent.color = Color.Red;
                        RightRotate(node.parent.parent);
                    }
                }
                else
                {
                    var leftAunt = node.parent.parent.left;
                    if(leftAunt != null && leftAunt.color == Color.Red)
                    {
                        node.parent.color = Color.Black;
                        leftAunt.color = Color.Black;
                        node.parent.parent.color = Color.Red;
                        node = node.parent.parent;
                    }
                    else
                    {
                        if(node == node.parent.left)
                        {
                            node = node.parent;
                            RightRotate(node);
                        }
                        node.parent.color = Color.Black;
                        node.parent.parent.color = Color.Red;
                        LeftRotate(node);
                    }
                }
                if(node == root)
                {
                    break;
                }
            }
            root.color = Color.Black;
        }
        private void LeftRotate(Red_Black_Tree_Node node)
        {
            if(node.right == null)
            {
                return;
            }
            var rightSubtree = node.right;
            node.right = rightSubtree.left;
            if (rightSubtree.left != null)
            {
                rightSubtree.left.parent = node;
            }
            rightSubtree.parent = node.parent;
            if(node.parent == null)
            {
                root = rightSubtree;
            }
            else if(node.parent.left == node)
            {
                node.parent.left = rightSubtree;
            }
            else
            {
                node.parent.right = rightSubtree;
            }
            rightSubtree.left = node;
            node.parent = rightSubtree;
        }
        private void RightRotate(Red_Black_Tree_Node node)
        {
            if (node.left == null)
            {
                return;
            }
            var leftSubtree = node.left;
            node.left = leftSubtree.right;
            if(leftSubtree.right != null)
            {
                leftSubtree.right.parent = node;
            }
            leftSubtree.parent = node.parent;
            if (node.parent == null)
            {
                root = leftSubtree;
            }
            else if(node.parent.left == node)
            {
                node.parent.left = leftSubtree;
            }
            else
            {
                node.parent.right = leftSubtree;
            }
            leftSubtree.right = node;
            node.parent = leftSubtree;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return InOrderTraversal();
        }
        public IEnumerator<int> InOrderTraversal()
        {
            if (root != null)
            {
                Stack<Red_Black_Tree_Node> stack = new Stack<Red_Black_Tree_Node>();
                Red_Black_Tree_Node current = root;
                bool goLeft = true;
                stack.Push(current);
                while (stack.Count > 0)
                {
                    Console.ResetColor();
                    if (goLeft)
                    {
                        while (current.left != null)
                        {
                            stack.Push(current);
                            current = current.left;
                        }
                    }
                    if(current.color == Color.Black)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    yield return current.value;
                    Console.ResetColor();
                    if (current.right != null)
                    {
                        current = current.right;
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
