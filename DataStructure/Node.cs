namespace DataStructure
{
    public class Node<T>
    {
        private Node<T> _next;
        private Node<T> _previous;
        private T _item;
        public Node()
        {

        }
        public Node(T item)
        {
            _item = item;
        }
        public T GetItem()
        {
            return _item;
        }
        public void SetItem(T item)
        {
            _item = item;
        }
        public Node<T> GetNext()
        {
            return _next;
        }
        public void SetNext(Node<T> next)
        {
            _next = next;
        }
        public Node<T> GetPrevious()
        {
            return _previous;
        }
        public void SetPrevious(Node<T> previous)
        {
            _previous = previous;
        }
    }
}