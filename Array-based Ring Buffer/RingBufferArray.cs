using System;

namespace DataStructure
{
    public class RingBufferArray : IRingBuffer
    {
        private int[] _ringBuffer;
        private int _start;
        private int _end;
        private int _size;

        public RingBufferArray(int size)
        {
            if (size < 1)
            {
                throw new ArgumentException("Size should be greater than 0");
            }
            _ringBuffer = new int[size];
            _start = 0;
            _end = 0;
        }
        public void Add(int number)
        {            
            _ringBuffer[_end] = number;
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

        public int Get()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("RingBufferArray empty");
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