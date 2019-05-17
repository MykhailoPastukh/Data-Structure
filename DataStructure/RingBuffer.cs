using System;

namespace DataStructure
{
    public class RingBuffer : IRingBuffer
    {
        private int _size;
        private int _count;
        private Node _first;
        private Node _end;

        public RingBuffer(int length)
        {
            if (length < 1)
            {
                throw new ArgumentException();
            }
            _first = new Node(0);

            Node currentNode = _first;
            for (int i = 0; i < length-1; i++)
            {
                currentNode.SetNext(new Node(i+1));
                currentNode.GetNext().SetPrevious(currentNode);
                currentNode = currentNode.GetNext();
            }
            currentNode.SetNext(_first);
            _first.SetPrevious(currentNode);
            _size = length;
            _end = _first.GetPrevious();
        }

        public void Add(int item)
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

        public int Get()
        {
            if(_count == 0)
            {
                throw new NullReferenceException("Ring Buffer empty");
            }
            int result = _first.GetItem();
            _first.SetItem(0);
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
            Node currentNode = _end;
            Node lastNode = _end.GetNext();
            for (int i = 0; i < length; i++)
            {
                currentNode.SetNext(new Node(0));
                currentNode.GetNext().SetPrevious(currentNode);
                currentNode.GetNext().SetNext(lastNode);
                currentNode = currentNode.GetNext();
            }
            _size += length;
        }
    }
}
