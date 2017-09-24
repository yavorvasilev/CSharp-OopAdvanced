namespace _09CollectionHierarchy
{
    using Interfaces;

    public class MyList<T> : Collection<T>, IMyList<T>
    {
        public int Add(T element)
        {
            this.List.Insert(0, element);
            return 0;
        }

        public T Remove()
        {
            T temp = this.List[0];
            this.List.RemoveAt(0);
            return temp;
        }

        public int Used
        {
            get
            {
                return this.List.Count;
            }
        }
    }
}
