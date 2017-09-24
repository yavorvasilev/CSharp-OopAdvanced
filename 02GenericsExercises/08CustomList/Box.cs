namespace _08CustomList
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
        where T : IComparable
    {
        private IList<T> container;

        public Box()
        {
            this.container = new List<T>();
        }
        public Box(IList<T> container) : this()
        {
            this.Container = container;
        }

        public IList<T> Container
        {
            get { return this.container; }
            set { this.container = value; }
        }

        public void Add(T element)
        {
            this.container.Add(element);
        }

        public T Remove(int index)
        {
            var reminder = this.container[index];
            this.container.RemoveAt(index);

            return reminder;
        }

        public bool Contains(T element)
        {
            return this.container.Contains(element);
        }

        public void Swap(int index1, int index2)
        {
            var reminder = this.container[index1];
            this.container[index1] = this.container[index2];
            this.container[index2] = reminder;
        }

        public int CountGreaterThan(T element)
        {
            return this.container.Count(t => t.CompareTo(element) > 0);
        }

        public T Max()
        {
            return this.container.Max();
        }

        public T Min()
        {
            return this.container.Min();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in this.container)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }

    }
}
