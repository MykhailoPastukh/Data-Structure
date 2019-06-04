using System;
using System.Collections.Generic;

namespace DataStructure
{
    public static class DataStructureExtension
    {
        public static IEnumerable<T> Filter<T>(this IDataStructure<T> items, Func<T, bool> predicate)
        {
            for (int i = 0; i < items.Size(); i++)
            {
                if (predicate(items[i]))
                {
                    yield return items[i];
                }
            }            
        }
    }
}