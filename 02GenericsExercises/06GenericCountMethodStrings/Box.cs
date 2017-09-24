namespace _06GenericCountMethodStrings
{

    using System.Linq;
    using System.Collections.Generic;
    using System;

    public class Box<T>
        where T : IComparable<T>
    {
        private List<T> data;

        public Box()
        {
            this.data = new List<T>();
        }

        public List<T> Data
        {
            get { return this.data; }
        }

        public int GetCountOfComparing(T value)               
        {
            var greaterElements = data.Count(e => e.CompareTo(value) > 0);

            return greaterElements;
        }

    }
}
