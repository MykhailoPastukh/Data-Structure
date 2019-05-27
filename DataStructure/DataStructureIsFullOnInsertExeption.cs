using System;

namespace DataStructure
{
    public class DataStructureIsFullOnInsertExeption : Exception
    {
        public DataStructureIsFullOnInsertExeption(string structure)
             : base(String.Format("{0} is fullOnRead on read", structure))
        {

        }
    }
} 