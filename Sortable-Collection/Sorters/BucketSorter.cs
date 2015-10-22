namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;

    public class BucketSorter : ISorter<int>
    {
        public void Sort(List<int> collection)
        {
            List<int> bucket1 = new List<int>();
            List<int> bucket2 = new List<int>();
            List<int> bucket3 = new List<int>();
            List<int> bucket4 = new List<int>();
            List<int> bucket5 = new List<int>();
            List<int> bucket6 = new List<int>();

            int mask1 = 31 << 5;
            int mask2 = 31 << 10;
            int mask3 = 31 << 15;
            int mask4 = 31 << 20;
            int mask5 = 31 << 25;
            // TODO

            foreach (var item in collection)
            {
                if ((item & mask5) != 0)
                {
                    bucket6.Add(item);
                }
                else if ((item & mask4) != 0)
                {
                    bucket5.Add(item);
                }
                else if ((item & mask3) != 0)
                {
                    bucket4.Add(item);
                }
                else if ((item & mask2) != 0)
                {
                    bucket3.Add(item);
                }
                else if ((item & mask1) != 0)
                {
                    bucket2.Add(item);
                }
                else
                {
                    bucket1.Add(item);
                }
            }
            bucket1.Sort();
            bucket2.Sort();
            bucket3.Sort();
            bucket4.Sort();
            bucket5.Sort();
            bucket6.Sort();

            {
                int i = 0;

                for (int j = 0; j < bucket1.Count; j++, i++)
                {
                    collection[i] = bucket1[j];
                }
                for (int j = 0; j < bucket2.Count; j++, i++)
                {
                    collection[i] = bucket2[j];
                }
                for (int j = 0; j < bucket3.Count; j++, i++)
                {
                    collection[i] = bucket3[j];
                }
                for (int j = 0; j < bucket4.Count; j++, i++)
                {
                    collection[i] = bucket4[j];
                }
                for (int j = 0; j < bucket5.Count; j++, i++)
                {
                    collection[i] = bucket5[j];
                }
                for (int j = 0; j < bucket6.Count; j++, i++)
                {
                    collection[i] = bucket6[j];
                }
            }
        }
    }
}
