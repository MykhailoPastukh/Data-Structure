using System;

namespace DataStructure
{
    public class DataStructEventArgs<T> : EventArgs
    {
        public T Element { set; get; }
        public DataStructEventArgs(){ }
        public DataStructEventArgs(T element)
        {
            Element = element;
        }
    }
}