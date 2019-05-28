using System;
using System.Collections;
namespace DataStructure
{
    public class Enumer<T> : IEnumerator
    {
        public Node<T> _first;
        private Node<T> _position;
        public Enumer(Node<T> first)
        {
            _first = first;
            _position = null;
        }

        public bool MoveNext()
        {
            if (_position == null)
                _position = _first;
            else
                _position = _position.GetNext();
            return _position != null;
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
