using System;

namespace DataStructure
{
    public class QueueLinkedList<T> : IQueue<T>
    {
        private Node<T> _first;
        private Node<T> _last;
        private int _size;

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < _size)
                {
                    if (index == _size - 1) return _last.GetItem();

                    Node<T> result = _first;
                    for (int i = 0; i < index; i++)
                    {
                        result = result.GetNext();
                    }
                    return result.GetItem();
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < _size)
                {
                    if (index == _size - 1)
                    {
                        _last.SetItem(value);
                        return;
                    }
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
                throw new DataStructureIsEmptyOnReadExeption("QueueLinkedList");
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