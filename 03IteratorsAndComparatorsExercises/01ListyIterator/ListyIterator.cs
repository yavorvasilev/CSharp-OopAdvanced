namespace _01ListyIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListyIterator<T> : IEnumerable<T>
    {
        private IList<T> collection;
        private int currentIndex;

        public ListyIterator(params T[] collection)
        {
            this.collection = new List<T>(collection);
            this.currentIndex = 0;
        }

        public bool Move()
        {
            if (this.currentIndex > this.collection.Count - 1)
            {
                return false;
            }
            this.currentIndex += 1;
            return true;
        }
        public bool HasNext()
        {
            if (this.currentIndex == this.collection.Count - 1)
            {
                return false;
            }
            return true;
        }
        public T Print()
        {
            if (collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            return collection[currentIndex];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.collection.Count; i++)
            {
                yield return this.collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
