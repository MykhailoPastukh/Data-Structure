using System;

namespace DataStructure
{
    public class QueueLinkedList : IQueue
    {
        private Node _first;
        private Node _last;
        private int _size;

        public void Add(int item)
        {
            Node node = new Node(item);
            node.SetItem(item);
            if (_size == 0)
            {
                _first = node;
                _last = node;
            }
            else
            {
                _first.SetPrevious(node);
                node.SetNext(_first);
                _first = node;
            }
            _size++;
        }

        public int Get()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Queue empty");
            }
            Node result = _last;
            _last = _last.GetPrevious();
            if (_size != 1)
            {
                _last.SetNext(null);
                _size--;
            }
            else
            {
                Clear();
            }
            return result.GetItem();
        }

        public void Clear()
        {
            _first = null;
            _last = null;
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