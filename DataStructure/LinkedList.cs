using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class LinkedList : ILinkedList
    {
        private Node _first;
        private Node _last;
        private int _size;
        public void Add(int item)
        {
            Node node = new Node(item);
            if (_first == null)
            {
                _first = node;
                _last = node;
            }
            else
            {
                _last.SetNext(node);
                node.SetPrevious(_last);
                _last = node;
            }
            _size++;
        }

        public void Clear()
        {
            _first = null;
            _last = null;
            _size = 0;
        }

        public int Get()
        {
            if (_first == null)
            {
                throw new NullReferenceException();
            }
            Node result = _last;
            _last = _last.GetPrevious();
            if (_size == 1)
            {
                Clear();
            }
            else
            {
                _last.SetNext(null);
                _size--;
            }
            return result.GetItem();
        }

        public int GetFirst()
        {
            if (_first == null)
            {
                throw new NullReferenceException();
            }
            Node result = _first;
            _first = _first.GetNext();
            if (_size == 1)
            {
                Clear();
            }
            else
            {
                _first.SetPrevious(null);
                _size--;
            }
            return result.GetItem();
        }

        public bool IsEmpty()
        {
            return _first == null;   
        }

        public int Size()
        {
            return _size;
        }
    }
}
