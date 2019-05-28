using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructure
{
    public class RingBufferLinkedList<T> : DataStructure<T>, IRingBuffer<T>, IEnumerable<T>
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
                throw new IndexOutOfRangeException();
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

        public override void Add(T item)
        {
            if (_count < _size)
            {
                _end = _end.GetNext();
                _end.SetItem(item);
                _count++;
                OnAddElement(new DataStructEventArgs<T>(item));
            }
            else
            {
                OnContainerFull(new DataStructEventArgs<T>(item));
                throw new DataStructureIsFullOnInsertExeption("RingBufferLinkedList");
            }
        }

        public override void Clear()
        {
            _end = _first.GetPrevious();
            _count = 0;
            OnContainerEmpty(new DataStructEventArgs<T>());
        }

        public override T Get()
        {
            if(_count == 0)
            {
                throw new DataStructureIsEmptyOnReadExeption("RingBufferLinkedList");
            }
            T result = _first.GetItem();
            _first = _first.GetNext();
            _count--;
            OnRemoveElement(new DataStructEventArgs<T>(result));
            return result;
        }

        public override bool IsEmpty()
        {
             return _count == 0;         
        }

        public override int Size()
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public EnumeratorForRingBufLinkedList<T> GetEnumerator()
        {
            //Node<T> first = new Node<T>(_end.GetItem());
            //Node<T> current = _end.GetPrevious();
            //int i = _count-1;
            //while (i>0)
            //{
            //    Node<T> newNode = new Node<T>(current.GetItem());
            //    first.SetPrevious(newNode);
            //    newNode.SetNext(first);
            //    first = newNode;
            //    current = current.GetPrevious();
            //    i--;
            //}
            return new EnumeratorForRingBufLinkedList<T>(_first,_count);
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}