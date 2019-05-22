using System;

namespace DataStructure
{
    public class LinkedList<T> : ILinkedList<T>
    {
        private Node<T> _first;
        private Node<T> _last;
        private int _size;
        public void Add(T item)
        {
            Node<T> node = new Node<T>(item);
            if (_size == 0)
            {
                _first = node;
                _last = node;
            }
            else
            {
                _last.SetNext(node);
                node.SetPrevious(_last);
                _last = node;
            }
            _size++;
        }

        public void Clear()
        {
            _first = null;
            _last = null;
            _size = 0;
        }

        public T Get()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Linked List Empty");
            }
            Node<T> result = _last;
            _last = _last.GetPrevious();
            if (_size == 1)
            {
                Clear();
            }
            else
            {
                _last.SetNext(null);
                _size--;
            }
            return result.GetItem();
        }

        public T GetFirst()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Linked List Empty");
            }
            Node<T> result = _first;
            _first = _first.GetNext();
            if (_size == 1)
            {
                Clear();
            }
            else
            {
                _first.SetPrevious(null);
                _size--;
            }
            return result.GetItem();
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