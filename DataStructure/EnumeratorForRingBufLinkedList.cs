using System;
using System.Collections;

namespace DataStructure
{
    public class EnumeratorForRingBufLinkedList<T> : IEnumerator
    {
        public Node<T> _first;
        private Node<T> _position;
        private int _size, _current;
        public EnumeratorForRingBufLinkedList(Node<T> first, int size)
        {
            _first = first;
            _position = null;
            _size = size;
            _current = -1;
        }

        public bool MoveNext()
        {
            _current++;
            if (_position == null)
                _position = _first;
            else
                _position = _position.GetNext();
            return _current != _size;
        }

        public void Reset()
        {
            _position = _first;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public T Current
        {
            get
            {
                try
                {
                    return _position.GetItem();
                }
                catch (NullReferenceException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}