namespace _08CustomList
{
    using System;
    using System.Linq;

    public static class Sorter
    {
        public static Box<T> Sort<T>(Box<T> collection)
            where T : IComparable
        {
            var sortedContainer = collection.Container.OrderBy(t => t).ToList();
            return new Box<T>(sortedContainer);
        }
    }
}
