using System.Collections;
using System.Collections.Generic;

namespace task4
{
    public class SetOfStacks : IEnumerable
    {
        private List<Stack<int>> _stacks = new List<Stack<int>>();
        public int max_amount { get; set; }
        public SetOfStacks()
        {
            max_amount = 5;
        }
        public SetOfStacks(int max_amount)
        {
            this.max_amount = max_amount;
        }
        private bool IsEmptyOrFull()
        {
            if (_stacks.Count == 0 || _stacks.Last().Count == max_amount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Push(int value)
        {
            if(IsEmptyOrFull())
            {
                _stacks.Add(new Stack<int>());
            }
            _stacks.Last().Push(value);
        }
        public int Pop()
        {
            var stack = _stacks.Last();
            int item = stack.Pop();
            if(stack.Count == 0)
            {
                _stacks.Remove(stack);
            }
            return item;
        }

        System.Collections.IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<int> GetEnumerator()
        {
            for(int index = 0;index < _stacks.Count; index++)
            {
                foreach (var item in _stacks[index])
                {
                    yield return item;
                }
            }
        }
    }
}
