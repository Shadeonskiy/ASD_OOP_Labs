using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork_3_15._05
{
    public enum Color
    {
        Black,
        Red
    }
    internal class Red_Black_Tree_Node : IComparable
    {
        public Red_Black_Tree_Node? parent { get; set; }
        public Red_Black_Tree_Node? left { get; set; }
        public Red_Black_Tree_Node? right { get; set; }
        public int value { get; set; }
        public Color color { get; set; }
        public Red_Black_Tree_Node(int value)
        {
            parent = null;
            left = null;
            right = null;
            this.value = value;
            color = Color.Red;
        }
        public Red_Black_Tree_Node(int value, Red_Black_Tree_Node? parent, Red_Black_Tree_Node? left, Red_Black_Tree_Node? right)
        {
            this.parent = parent;
            this.left = left;
            this.right = right;
            this.value = value;
            color = Color.Red;
        }
        public int CompareTo(object obj)
        {
            return value.CompareTo(obj);
        }
    }
}
