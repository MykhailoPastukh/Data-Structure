using System;

namespace DataStructure
{
    public class DataStructureIsEmptyOnReadExeption : Exception
    {
        public DataStructureIsEmptyOnReadExeption(string structure)
            : base(String.Format("{0} is empty on read",structure))
        {

        }
    }
}