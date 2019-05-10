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

        public void Add(Node node)
        {
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

        public Node Get()
        {
            if (_first == null)
            {
                return null;
            }
            Node result = _first;
            _first = _first.GetNext();
            _size--;
            result.SetNext(null);
            return result;
        }

        public void Clear()
        {
            _first = null;
            _size = 0;
        }

        public bool IsEmpty()
        {
            if (_first == null)
            {
                return true;
            }
            return false;
        }

        public int Size()
        {
            return _size;
        }
    }
}
