namespace _08MilitaryElite.Entities
{
    using System.Collections.Generic;
    using Interfaces;
    using System.Text;

    public class LeutenantGeneral : Private, ILeutenantGeneral
    {
        public LeutenantGeneral(int id, string firstName, string lastName, double salary) 
            : base(id, firstName, lastName, salary)
        {
            this.Soldiers = new List<ISoldier>();
        }

        public List<ISoldier> Soldiers { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            if (this.Soldiers.Count > 0)
            {
                foreach (var soldier in this.Soldiers)
                {
                    sb.AppendLine($"  {soldier.ToString()}");
                }
            }
            return sb.ToString().Trim();
        }

    }
}
