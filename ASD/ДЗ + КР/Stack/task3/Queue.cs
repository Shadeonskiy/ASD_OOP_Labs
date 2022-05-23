using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    internal class Queue<T> : IEnumerable
    {
        LinkedList<T> _items = new LinkedList<T> ();
        public int Count
        {
            get { return _items.Count; }
        }
        public void Enqueue(T value)
        {
            _items.AddFirst(value);
        }
        public T Dequeue()
        {
            if(_items.Count == 0)
            {
                throw new InvalidOperationException("Черга пуста");
            }
            T last = _items.Last.Value;
            _items.RemoveLast();
            return last;
        }
        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Черга пуста");
            }
            return _items.Last.Value;
        }
        System.Collections.IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode <T> current = _items.Last;
            while(current != null)
            {
                yield return current.Value;
                current = current.Previous;
            }
        }
    }
}
