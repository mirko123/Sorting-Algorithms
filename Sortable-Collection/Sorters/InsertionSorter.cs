namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            int length = collection.Count;
            for (int unsortedIndex = 0; unsortedIndex < length; unsortedIndex++)
            {
                int i = unsortedIndex;
                while (i > 0 && collection[i - 1].CompareTo(collection[i]) > 0)
                {
                    T temp = collection[i - 1];
                    collection[i - 1] = collection[i];
                    collection[i] = temp;
                    i--;
                }
            }
        }
    }
}
