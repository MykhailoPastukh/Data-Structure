namespace DataStructure
{
    public interface IDataStructure<T>
    {
        void Add(T item);
        T Get();
        void Clear();
        bool IsEmpty();
        int Size();

        T this[int index]
        {
            get;
            set;
        }
    }
}