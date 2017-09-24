namespace _08MilitaryElite.Entities
{

    using Interfaces;

    public class Mission : IMission
    {
        public Mission(string name, string state)
        {
            this.Name = name;
            this.State = state;
        }

        public string Name { get; }
        public string State { get; }

        public override string ToString()
        {
            return $"Code Name: {this.Name} State: {this.State}";
        }
    }
}
