namespace _03Stack
{
    using System.Linq;
    using System.Collections.Generic;
    using System;
    using System.Collections;

    public class Stack<T> : IEnumerable<T>
    {
        private IList<T> stackCollection;

        public Stack()
        {
            this.stackCollection = new List<T>();
        }

        public void Push(params T[] elements)
        {
            foreach (var element in elements)
            {
                this.stackCollection.Add(element);
            }
        }

        public void Pop()
        {
            if (stackCollection.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }
            var reminder = stackCollection.Last();
            stackCollection.Remove(reminder);
        }

        public IEnumerator<T> GetEnumerator()
        {
            //var collaction = stackCollection.Reverse().ToList();

            for (int i = stackCollection.Count - 1; i >= 0; i--)
            {
                yield return this.stackCollection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
