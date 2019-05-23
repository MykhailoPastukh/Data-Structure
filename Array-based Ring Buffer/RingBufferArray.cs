using System;

namespace DataStructure
{
    public class RingBufferArray<T> : IRingBuffer<T>
    {
        private T[] _ringBuffer;
        private int _start;
        private int _end;
        private int _size;

        public RingBufferArray(int size)
        {
            if (size < 1)
            {
                throw new ArgumentException("Size should be greater than 0");
            }
            _ringBuffer = new T[size];
            _start = 0;
            _end = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < _size)
                {
                    index += _start;
                    if(index >= _size)
                    {
                        index = _size-1;
                    }
                    return _ringBuffer[index];
                }
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < _size)
                {
                    index += _start;
                    if (index >= _size)
                    {
                        index = _size - 1;
                    }
                    _ringBuffer[index] = value;
                }
                else throw new IndexOutOfRangeException();
            }
        }

        public void Add(T item)
        {            
            _ringBuffer[_end] = item;
            _size++;
            _end++;
            if (_end > _ringBuffer.Length - 1)
            {
                _end = 0;
            }
            if (_start == _end - 1 && _size != 1)
            {
                _start++;
            }
            if (_end == _start)
            {
                _size = _ringBuffer.Length;
            }
        }

        public void Clear()
        {          
            _start = 0;
            _end = 0;
            _size = 0;
        }

        public T Get()
        {
            if (IsEmpty())
            {
                throw new DataStructureIsEmptyOnReadExeption("RingBufferArray");
            }
            else
            {
                _size--;
                _start++;
                if (_start>_ringBuffer.Length-1)
                {
                    _start = 0;
                    return _ringBuffer[_ringBuffer.Length - 1];
                }
                return _ringBuffer[_start-1];
            }
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