namespace _04Froggy
{
    using System.Collections;
    using System.Collections.Generic;

    public class Lake : IEnumerable<int>
    {
        private IList<int> stones;

        public Lake(List<int> stones)
        {
            this.stones = new List<int>(stones);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stones.Count; i+=2)
            {
                yield return this.stones[i];
            }
            int oddIndex;
            if (stones.Count % 2 == 0)
            {
                oddIndex = stones.Count - 1;
            }
            else
            {
                oddIndex = stones.Count - 2;
            }
            for (int i = oddIndex; oddIndex >= 0; oddIndex-=2)
            {
                yield return this.stones[oddIndex];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
