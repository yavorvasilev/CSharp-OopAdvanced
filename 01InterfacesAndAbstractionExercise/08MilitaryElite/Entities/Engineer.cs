namespace _08MilitaryElite.Entities
{
    using System.Collections.Generic;
    using Interfaces;
    using System.Text;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, double salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<IRepair>();
        }

        public List<IRepair> Repairs { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Repairs:");
            foreach (var repair in this.Repairs)
            {
                sb.AppendLine($"  {repair.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}
