using System;

namespace DataStructure
{
    public delegate void DataStructureEventHandler<T>(IDataStructure<T> sender, EventArgs e);
    public class DataStructure<T> : IDataStructure<T>
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

        public virtual void Add(T item)
        {
            throw new NotImplementedException();
        }
        public virtual T Get()
        {
            throw new NotImplementedException();
        }
        public virtual void Clear()
        {
            throw new NotImplementedException();
        }
        public virtual bool IsEmpty()
        {
            throw new NotImplementedException();
        }
        public virtual int Size()
        {
            throw new NotImplementedException();
        }
    }
}
