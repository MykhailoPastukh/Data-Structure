using System;

namespace DataStructure
{
    public class StackLinkedList<T> : IStack<T>
    {
        private Node<T> _first;
        private int _size;

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < _size)
                {
                    Node<T> result = _first;
                    for (int i = 0; i < index; i++)
                    {
                        result = result.GetNext();
                    }
                    return result.GetItem();
                }
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < _size)
                {
                    Node<T> result = _first;
                    for (int i = 0; i < index; i++)
                    {
                        result = result.GetNext();
                    }
                    result.SetItem(value);
                }
                else throw new IndexOutOfRangeException();
            }
        }

        public void Add(T item)
        {
            Node<T> node = new Node<T>(item);
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

        public T Get()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Stack empty");
            }
            T result = _first.GetItem();
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