namespace _08MilitaryElite.Entities
{
    using Interfaces;
    using System.Text;

    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int code) 
            : base(id, firstName, lastName)
        {
            this.Code = code;
        }

        public int Code { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Code Number: {this.Code}");

            return sb.ToString().Trim();
        }
    }
}
