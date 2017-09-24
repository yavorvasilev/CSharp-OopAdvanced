namespace _03Iterator
{
    using System;
    using System.Collections.Generic;

    public class ListIterator
    {
        private List<string> collection;
        private int currentIndex = 0;

        public ListIterator()
        {

        }

        public ListIterator(List<string> collection) : this()
        {
            this.Collection = collection;
        }

        public List<string> Collection
        {
            get
            {
                return this.collection;
            }
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentException("Collection cannot be empty or null");
                }
                this.collection = value;
            }
        }

        public int CurrentIndex { get { return this.currentIndex; } set { this.currentIndex = value; } }

        public bool Move()
        {
            if (this.CurrentIndex + 1 < this.Collection.Count )
            {
                this.CurrentIndex++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            if (this.currentIndex + 1 < this.collection.Count)
            {
                return true;
            }
            return false;
        }

        public string Print()
        {
            if (this.Collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            return this.Collection[this.CurrentIndex];
        }
    }
}
