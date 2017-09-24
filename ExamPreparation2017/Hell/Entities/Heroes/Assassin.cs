using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Assassin : AbstractHero
{
    private const long AssassinStrength = 25;
    private const long AssassinAgility = 100;
    private const long AssassinIntelligence = 15;
    private const long AssassinHitPoints = 150;
    private const long AssassinDamage = 300;

    public Assassin(string name)
        : base(name, AssassinStrength, AssassinAgility, AssassinIntelligence, AssassinHitPoints, AssassinDamage)
    {

    }
}
