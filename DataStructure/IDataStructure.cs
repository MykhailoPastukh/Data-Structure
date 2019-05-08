﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    interface IDataStructure
    {
        void Add(Node node);
        Node Get();
        void Clear();
        bool IsEmpty();
        int Size();
    }
}
