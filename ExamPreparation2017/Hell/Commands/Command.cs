
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Command : ICommand
{
    private IManager manager;
    private List<string> args;

    public IManager Manager { get; set; }
  
    public List<string> Args { get; set; }


    public Command(List<string> args, IManager manager)
    {
        this.Manager = manager;
        this.Args = args;
    }

    public abstract string Execute();
}
