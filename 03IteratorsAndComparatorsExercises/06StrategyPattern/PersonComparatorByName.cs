namespace _06StrategyPattern
{
    using System.Collections.Generic;

    public class PersonComparatorByName : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.Name.Length.CompareTo(y.Name.Length) == 0)
            {
                return x.Name.ToLower()[0].CompareTo(y.Name.ToLower()[0]);
            }
            return x.Name.Length.CompareTo(y.Name.Length);
        }
    }
}
