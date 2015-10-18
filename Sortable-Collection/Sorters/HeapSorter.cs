namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class HeapSorter<T> : ISorter<T> where T : IComparable<T>
    {
        private int length;
        public void Sort(List<T> collection)
        {
            length = collection.Count;
            for (int i = 0; i < collection.Count; i++)
            {
                if (true)
                {
                    
                }
            }
        }

        private void Heap(List<T> items, int index)
        {
            if (index < length)
            {
                int log = (int)Math.Log(index,2);
                int fromIndex = log + index % 2;

                Heap(items, fromIndex);
                Heap(items, fromIndex + 1);
            }
        }
    }
}
