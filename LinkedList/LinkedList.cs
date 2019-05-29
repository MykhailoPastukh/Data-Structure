using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructure
{
    public class LinkedList<T> : DataStructure<T>, ILinkedList<T>, IEnumerable<T>
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
            OnAddElement(new DataStructEventArgs<T>(node.GetItem()));         
        }

        public override void Clear()
        {
            _first = null;
            _last = null;
            _size = 0;
            OnContainerEmpty(new DataStructEventArgs<T>());
        }

        public override T Get()
        {
            if (_size == 0)
            {
                throw new DataStructureIsEmptyOnReadExeption("Linked List");
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
            OnRemoveElement(new DataStructEventArgs<T>(result.GetItem()));
            return result.GetItem();
        }

        public T GetFirst()
        {
            if (_size == 0)
            {
                throw new DataStructureIsEmptyOnReadExeption("Linked List");
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
            OnRemoveElement(new DataStructEventArgs<T>(result.GetItem()));
            return result.GetItem();
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