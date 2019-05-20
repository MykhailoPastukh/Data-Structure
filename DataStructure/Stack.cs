using System;

namespace DataStructure
{
    public class Stack : IStack
    {
        private Node _first;
        private int _size;

        public void Add(int item)
        {
            Node node = new Node(item);
            if (_size == 0)
            {
                _first = node;
            }
            else
            {
                node.SetNext(_first);
                _first.SetPrevious(node);
                _first = node;
            }
            _size++;
        }

        public int Get()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Stack empty");
            }
            int result = _first.GetItem();
            if (_size == 1)
            {
                Clear();
            }
            else
            {
                _first = _first.GetNext();
                _size--;
            }
            return result;
        }

        public void Clear()
        {
            _first = null;
            _size = 0;
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public int Size()
        {
            return _size;
        }
    }
}