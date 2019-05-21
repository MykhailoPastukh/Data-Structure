using System;
using System.Linq;

namespace DataStructure
{
    public class QueueArray
    {
        private int[] _queue;

        public QueueArray()
        {
            _queue = new int[0];
        }
        public void Add(int number)
        {
            if (_queue.Length == 0)
            {
                _queue = new int[1];
                _queue[0] = number;
            }
            else
            {
                int[] arr = _queue;
                _queue = new int[arr.Length + 1];
                _queue[0] = number;
                for (int i = 0; i < arr.Length; i++)
                {
                    _queue[i + 1] = arr[i];
                }
            }
        }

        public void Clear()
        {
            _queue = new int[0];
        }

        public int Get()
        {
            if (_queue.Length == 0)
            {
                throw new InvalidOperationException("QueueArray empty");
            }
            int[] arr = _queue;
            _queue = new int[arr.Length - 1];
            for (int i = 0; i < _queue.Length; i++)
            {
                _queue[i] = arr[i];
            }
            return arr.Last();
        }

        public bool IsEmpty()
        {
            return _queue.Length == 0;
        }

        public int Size()
        {
            return _queue.Length;
        }
    }
}