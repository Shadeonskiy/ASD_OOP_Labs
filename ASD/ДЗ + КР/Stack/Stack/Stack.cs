using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class Stack<T>
    {
        LinkedList<T> _items = new LinkedList<T>();
        public int Count
        {
            get { return _items.Count; }
        }
        public void Push(T value)
        {
            _items.AddLast(value);
        }
        public T Pop()
        {
            if( _items.Count == 0 )
            {
                throw new InvalidOperationException("Cтек пустий");
            }
            T result = _items.Last.Value;
            _items.RemoveLast();
            return result;
        }
        public T Peek()
        {
            return _items.Last.Value;
        }
    }
}
