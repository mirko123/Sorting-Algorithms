namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            var items = MergeSort(collection);
            for (int i = 0; i < collection.Count; i++)
            {
                collection[i] = items[i];
            }
        }

        private static List<T> MergeSort(List<T> arr)
        {
            if (arr.Count <= 1)
                return arr;

            int middleIndex = arr.Count / 2;

            List<T> left = new List<T>(middleIndex);
            List<T> right = new List<T>(arr.Count - middleIndex);

            for (int leftIndex = 0; leftIndex < middleIndex; leftIndex++)
            {
                left.Add(arr[leftIndex]);
            }

            for (int rightIndex = middleIndex; rightIndex < arr.Count; rightIndex++)
            {
                right.Add(arr[rightIndex]);
            }

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private static List<T> Merge(List<T> left, List<T> right)
        {
            int leftIndex = 0;
            int rightIndex = 0;

            int leftLength = left.Count;
            int rightLength = right.Count;

            List<T> result = new List<T>(leftLength + rightLength);

            while(leftIndex < leftLength || rightIndex < rightLength)
            {
                if (leftIndex < leftLength && rightIndex < rightLength)
                {
                    if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
                    {
                        result.Add(left[leftIndex]);
                        leftIndex++;
                    }
                    else
                    {
                        result.Add(right[rightIndex]);
                        rightIndex++;
                    }
                }
                else if (leftIndex < leftLength)
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else if (rightIndex < rightLength)
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
                else break;
            }
            return result;
        }
    }
}
