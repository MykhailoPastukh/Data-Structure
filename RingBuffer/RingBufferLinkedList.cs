using System;

namespace DataStructure
{
    public class RingBufferLinkedList<T> : IRingBuffer<T>
    {
        private int _size;
        private int _count;
        private Node<T> _first;
        private Node<T> _end;

        public RingBufferLinkedList(int length)
        {
            if (length < 1)
            {
                throw new ArgumentException();
            }
            _first = new Node<T>();

            Node<T> currentNode = _first;
            for (int i = 0; i < length-1; i++)
            {
                currentNode.SetNext(new Node<T>());
                currentNode.GetNext().SetPrevious(currentNode);
                currentNode = currentNode.GetNext();
            }
            currentNode.SetNext(_first);
            _first.SetPrevious(currentNode);
            _size = length;
            _end = _first.GetPrevious();
        }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < _count)
                {
                    if (index == _count - 1) return _end.GetItem();

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
                if (index == _count - 1)
                {
                    _end.SetItem(value);
                    return;
                }
                if (index >= 0 && index < _count)
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
            if (_count < _size)
            {
                _end = _end.GetNext();
                _end.SetItem(item);
                _count++;
            }
            else
            {
                throw new DataStructureIsFullOnInsertExeption("RingBufferLinkedList");
            }
        }

        public void Clear()
        {
            _end = _first.GetPrevious();
            _count = 0;
        }

        public T Get()
        {
            if(_count == 0)
            {
                throw new DataStructureIsEmptyOnReadExeption("RingBufferLinkedList");
            }
            T result = _first.GetItem();
            _first = _first.GetNext();
            _count--;
            return result;
        }

        public bool IsEmpty()
        {
             return _count == 0;         
        }

        public int Size()
        {
            return _count;
        }

        public void Expand(int length)
        {
            Node<T> currentNode = _end;
            Node<T> lastNode = _end.GetNext();
            for (int i = 0; i < length; i++)
            {
                currentNode.SetNext(new Node<T>());
                currentNode.GetNext().SetPrevious(currentNode);
                currentNode.GetNext().SetNext(lastNode);
                currentNode = currentNode.GetNext();
            }
            _size += length;
        }
    }
}