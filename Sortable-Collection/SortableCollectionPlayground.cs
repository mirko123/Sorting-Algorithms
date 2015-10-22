namespace Sortable_Collection
{
    using System;

    using Sortable_Collection.Sorters;

    public class SortableCollectionPlayground
    {
        private static Random Random = new Random();

        public static int BinarySearchRecursive(int[] arr, int element)
        {
            return 1;
        }

        public static int BinarySearchIterative(int[] arr, int element)
        {
            int arrLength = arr.Length;
            int start = 0;
            int end = arrLength;
            int midleIndex = arrLength / 2;
            while (start <= end)
            {
                midleIndex = start + (end - start) / 2;
                if (element < arr[midleIndex])
                {
                    end = midleIndex;
                }
                else if (element > arr[midleIndex])
                {
                    start = midleIndex;
                }
                else
                {
                    return midleIndex;
                }
            }
           // throw new ArgumentException("Elementa ne e nameren");
            return -1;
        }

        public static void Main(string[] args)
        {
            const int NumberOfElementsToSort = 22;
            const int MaxValue = 150;

            var array = new int[NumberOfElementsToSort];

            for (int i = 0; i < NumberOfElementsToSort; i++)
            {
                array[i] = Random.Next(MaxValue);
            }

            var collectionToSort = new SortableCollection<int>(array);
         /*  // collectionToSort.Sort(new BucketSorter { Max = MaxValue });

            Console.WriteLine(collectionToSort);

            var collection = new SortableCollection<int>(2, -1, 5, 0, -3);
            Console.WriteLine(collection);

            collection.Sort(new Quicksorter<int>());
            Console.WriteLine(collection);*/

       /*     int[] arr = new int[]
            {
              //  1,15,312,12,213,53,63,9312,321,435
                1,2,3,5,6,77,78,132,3323,31123,32121,943234
            };
            Console.WriteLine("Index: {0}",BinarySearchIterative(arr, 31123));*/
            //ddz
            //dghgg
            collectionToSort.Sort(new InPlaceMergeSorter<int>());
            Console.WriteLine(collectionToSort);
        }
    }
}
