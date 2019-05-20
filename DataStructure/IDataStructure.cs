using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public interface IDataStructure
    {
        void Add(int number);
        int Get();
        void Clear();
        bool IsEmpty();
        int Size();
    }
}
