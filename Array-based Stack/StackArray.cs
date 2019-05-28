﻿using System;

namespace DataStructure
{
    public class StackArray<T> : DataStructure<T>, IStack<T>
    {
        private T[] _stack;

        public StackArray()
        {
            _stack = new T[0];
        }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < _stack.Length)
                {
                    return _stack[index];
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < _stack.Length)
                {
                    _stack[index] = value;
                }
                else throw new IndexOutOfRangeException();
            }
        }

        public override void Add(T item)
        {
            if (_stack.Length == 0)
            {
                _stack = new T[1];
                _stack[0] = item;
            }
            else
            {
                T[] arr = _stack;
                _stack = new T[arr.Length + 1];
                _stack[0] = item;
                for (int i = 0; i < arr.Length; i++)
                {
                    _stack[i + 1] = arr[i];
                }
            }
            OnAddElement(new DataStructEventArgs<T>(item));
        }

        public override void Clear()
        {
            _stack = new T[0];
            OnContainerEmpty(new DataStructEventArgs<T>());
        }

        public override T Get()
        {
            if (_stack.Length == 0)
            {
                throw new DataStructureIsEmptyOnReadExeption("StackArray");
            }
            T[] arr = _stack;
            _stack = new T[arr.Length - 1];
            for (int i = 1; i < arr.Length; i++)
            {
                _stack[i - 1] = arr[i];
            }
            OnRemoveElement(new DataStructEventArgs<T>(arr[0]));
            return arr[0];
        }

        public override bool IsEmpty()
        {
            return _stack.Length == 0;
        }

        public override int Size()
        {
            return _stack.Length;
        }
    }
}