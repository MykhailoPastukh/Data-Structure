using System;

namespace DataStructure
{
    public class StackArray : IStack
    {
        private int[] _stack;

        public StackArray()
        {
            _stack = new int[0];
        }

        public void Add(int number)
        {
            if (_stack.Length == 0)
            {
                _stack = new int[1];
                _stack[0] = number;
            }
            else
            {
                int[] arr = _stack;
                _stack = new int[arr.Length + 1];
                _stack[0] = number;
                for (int i = 0; i < arr.Length; i++)
                {
                    _stack[i + 1] = arr[i];
                }
            }
        }

        public void Clear()
        {
            _stack = new int[0];
        }

        public int Get()
        {
            if (_stack.Length == 0)
            {
                throw new InvalidOperationException("StackArray empty");
            }
            int[] arr = _stack;
            _stack = new int[arr.Length - 1];
            for (int i = 1; i < arr.Length; i++)
            {
                _stack[i - 1] = arr[i];
            }
            return arr[0];
        }

        public bool IsEmpty()
        {
            return _stack.Length == 0;
        }

        public int Size()
        {
            return _stack.Length;
        }
    }
}