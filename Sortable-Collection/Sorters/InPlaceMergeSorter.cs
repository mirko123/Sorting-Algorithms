namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class InPlaceMergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        private List<T> items;

        public void Sort(List<T> collection)
        {
            this.items = collection;
            MergeSort(0, items.Count);
        }

        private void MergeSort(int firstIndex, int lastIndex)
        {
          //  if (firstIndex >= lastIndex)
            if (lastIndex - firstIndex <= 1)
                return;

            int middleIndex = firstIndex + (lastIndex - firstIndex) / 2;
            MergeSort(firstIndex, middleIndex);
            MergeSort(middleIndex, lastIndex);

            Merge(firstIndex, middleIndex, lastIndex);
        }

        private void Merge(int leftIndex, int rightIndex, int lastIndex)
        {
            while (leftIndex <= rightIndex || rightIndex < lastIndex)
            {
                if (leftIndex < rightIndex && rightIndex< lastIndex)
                {
                    if (items[leftIndex].CompareTo(items[rightIndex]) > 0)
                    {
                        T temp = items[rightIndex];
                        for (int i = rightIndex; i > leftIndex; i--)
                        {
                            items[i] = items[i - 1];
                        }
                        items[leftIndex] = temp;
                        rightIndex++;
                    }
                }
                else 
                {
                    return;
                }
                leftIndex++;
            }
        }
        private void MoveElementsINArray(int fromIndex, int toIndex)
        {

        }
    }
}
