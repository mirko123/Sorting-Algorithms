namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private List<T> Items { get;  set; }
        public int Count { get { return this.Items.Count; } }

        public SortableCollection()
        {
            this.Items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        public SortableCollection(params T[] items)
            : this(items.AsEnumerable())
        {
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }
        
        public int BinarySearch(T item)
        {
            int arrLength = Items.Count;
            int start = 0;
            int end = arrLength;
            int midleIndex = arrLength / 2;
            while (start <= end)
            {
                midleIndex = start + (end - start) / 2;
                if (item.CompareTo(Items[midleIndex]) < 0 )
                {
                    end = midleIndex;
                }
                else if (item.CompareTo(Items[midleIndex]) > 0)
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
            // TODO
        }

        public int InterpolationSearch(T item)
        {
            throw new NotImplementedException();
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            var length = Items.Count;
            for (int i = 0; i < length; i++)
            {
                int r = i + rnd.Next(0, length - i);
                var temp = Items[i];
                Items[i] = Items[r];
                Items[r] = temp;
            }
        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return string.Format("{0}", string.Join(", ", this.Items));
        }   
    }
}