using System;
using System.Collections;

namespace DataStructure
{
    public class EnumeratorForArrayBasedStructures<T> : IEnumerator
    {
        public T[] _dataStructure;
        int position = -1;

        public EnumeratorForArrayBasedStructures(T[] list)
        {
            _dataStructure = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _dataStructure.Length);
        }

        public void Reset()
        {
            position = -1;
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
                    return _dataStructure[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}