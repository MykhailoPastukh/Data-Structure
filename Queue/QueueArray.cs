﻿using System;
using System.Linq;

namespace DataStructure
{
    public class QueueArray<T> : IQueue<T>
    {
        private T[] _queue;

        public QueueArray()
        {
            _queue = new T[0];
        }

        public T this[int index]
        {
            get {
                if (index >= 0 && index < _queue.Length)
                {
                    return _queue[index];
                }
                throw new IndexOutOfRangeException();
            }
            set {
                if (index >= 0 && index < _queue.Length)
                {
                    _queue[index] = value;
                }
                else throw new IndexOutOfRangeException();
            }
        }

        public void Add(T item)
        {
            if (_queue.Length == 0)
            {
                _queue = new T[1];
                _queue[0] = item;
            }
            else
            {
                T[] arr = _queue;
                _queue = new T[arr.Length + 1];
                _queue[0] = item;
                for (int i = 0; i < arr.Length; i++)
                {
                    _queue[i + 1] = arr[i];
                }
            }
        }

        public void Clear()
        {
            _queue = new T[0];
        }

        public T Get()
        {
            if (_queue.Length == 0)
            {
                throw new DataStructureIsEmptyOnReadExeption("QueueArray");
            }
            T[] arr = _queue;
            _queue = new T[arr.Length - 1];
            for (int i = 0; i < _queue.Length; i++)
            {
                _queue[i] = arr[i];
            }
            return arr.Last();
        }

        public bool IsEmpty()
        {
            return _queue.Length == 0;
        }

        public int Size()
        {
            return _queue.Length;
        }
    }
}