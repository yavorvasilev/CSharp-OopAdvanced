namespace _08MilitaryElite.Entities
{
    using Interfaces;

    class Repair : IRepair
    {
        public Repair(string name, int hours)
        {
            this.Name = name;
            this.Hours = hours;
        }

        public int Hours { get; }
        public string Name { get; }

        public override string ToString()
        {
            return $"Part Name: {this.Name} Hours Worked: {this.Hours}";
        }
    }
}
