using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructure
{
    public class QueueLinkedList<T> : DataStructure<T>, IQueue<T>, IEnumerable<T>
    {
        private Node<T> _first;
        private Node<T> _last;
        private int _size;

        public override T this[int index]
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

        public override void Add(T item)
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
            OnAddElement(new DataStructEventArgs<T>(node.GetItem()));
            _size++;
        }

        public override T Get()
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
            OnRemoveElement(new DataStructEventArgs<T>(result.GetItem()));
            return result.GetItem();
        }

        public override void Clear()
        {
            _first = null;
            _last = null;
            _size = 0;
            OnContainerEmpty(new DataStructEventArgs<T>());
        }

        public override bool IsEmpty()
        {
            return _size == 0;
        }

        public override int Size()
        {
            return _size;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public EnumeratorForLinkedList<T> GetEnumerator()
        {
            return new EnumeratorForLinkedList<T>(_first);
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}