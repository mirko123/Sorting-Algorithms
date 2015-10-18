namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            QuickSort(collection, 0, collection.Count - 1);
            // TODO
        }     
        private static void QuickSort(List<T> arr, int low, int height)
        {
            if (low < height)
            {
                int partition = Partition(arr, low, height);
                QuickSort(arr, low, partition);
                QuickSort(arr, partition + 1, height);
            }
        }

        private static int Partition(List<T> arr, int low, int height)
        {
            T pivot = arr[low];
            int i = low - 1;
            int j = height + 1;

            while (true)
            {
                do
                {
                    j--;
                } while (arr[j].CompareTo(pivot) > 0);
                do
                {
                    i++;
                } while (arr[i].CompareTo(pivot) < 0);

                if (i < j)
                {
                    T temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
                else return j;
            }
        }
    }
}
