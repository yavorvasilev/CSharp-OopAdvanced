using System.Collections.Generic;

namespace _04GenericSwapMethodStrings
{
    public class Box<T>
    {
        //private List<T> data;

        public Box(T value)
        {
            this.Value = value;
        }

        public T Value { get; }

        public override string ToString()
        {
            return $"{this.Value.GetType().FullName}: {this.Value}";
        }
    }
}
