using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Stack : IStack
    {
        private Node _first;
        private int _size;

        public void Add(int item)
        {
            Node node = new Node(item);
            if (_first == null)
            {
                _first = node;
            }
            else
            {
                node.SetNext(_first);
                _first.SetPrevious(node);
                _first = node;
            }
            _size++;
        }

        public int Get()
        {
            if (_first == null)
            {
                throw new NullReferenceException();
            }
            Node result = _first;
            _first = _first.GetNext();
            _size--;
            return result.GetItem();
        }

        public void Clear()
        {
            _first = null;
            _size = 0;
        }

        public bool IsEmpty()
        {
            return (_first == null) ? true : false;
        }

        public int Size()
        {
            return _size;
        }
    }
}