using System;

namespace DataStructure
{
    public class QueueLinkedList<T> : IQueue<T>
    {
        private Node<T> _first;
        private Node<T> _last;
        private int _size;

        public void Add(T item)
        {
            Node<T> node = new Node<T>(item);
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

        public T Get()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Queue empty");
            }
            Node<T> result = _last;
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