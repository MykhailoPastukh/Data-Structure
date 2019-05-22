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
                throw new InvalidOperationException("Ring buffer full");
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
                throw new InvalidOperationException("Ring Buffer empty");
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