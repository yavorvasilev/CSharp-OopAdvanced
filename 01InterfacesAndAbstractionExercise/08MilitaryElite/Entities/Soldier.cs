namespace _08MilitaryElite.Entities
{
    using Interfaces;

    public abstract class Soldier : ISoldier
    {
        public Soldier(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public string FirstName { get; }
        public int Id { get; }
        public string LastName { get; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} ";
        }
    }
}
