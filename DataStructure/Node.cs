using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    class Node
    {
        private Node _next;
        private Node _previous;
        private int _item;
        public int GetItem()
        {
            return _item;
        }
        public void SetItem(int item)
        {
            _item = item;
        }
        public Node GetNext()
        {
            return _next;
        }
        public void SetNext(Node next)
        {
            _next = next;
        }
        public Node GetPrevious()
        {
            return _previous;
        }
        public void SetPrevious(Node previous)
        {
            _previous = previous;
        }
    }
}
