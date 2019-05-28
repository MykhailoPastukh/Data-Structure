using System;

namespace DataStructure
{
    public delegate void DataStructureEventHandler<T>(IDataStructure<T> sender, EventArgs e);
    public abstract class DataStructure<T> : IDataStructure<T>
    {
        public event DataStructureEventHandler<T> AddElement;
        public event DataStructureEventHandler<T> RemoveElement;
        public event DataStructureEventHandler<T> ContainerEmpty;
        public event DataStructureEventHandler<T> ContainerFull;

        protected void OnAddElement(DataStructEventArgs<T> e)
        {
            AddElement?.Invoke(this, e);
        }
        protected void OnRemoveElement(DataStructEventArgs<T> e)
        {
            RemoveElement?.Invoke(this, e);
        }
        protected void OnContainerEmpty(DataStructEventArgs<T> e)
        {
            ContainerEmpty?.Invoke(this, e);
        }
        protected void OnContainerFull(DataStructEventArgs<T> e)
        {
            ContainerFull?.Invoke(this, e);
        }

        public abstract void Add(T item);
        public abstract T Get();
        public abstract void Clear();
        public abstract bool IsEmpty();
        public abstract int Size();
    }
}
