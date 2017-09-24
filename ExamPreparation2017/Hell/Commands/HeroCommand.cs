
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HeroCommand : Command
{
    public HeroCommand(List<string> args, IManager manager) : base(args, manager)
    {
    }

    public override string Execute()
    {
        var result = this.Manager.AddHero(this.Args);
        return result;
    }
}
