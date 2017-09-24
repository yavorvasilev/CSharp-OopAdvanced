using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IItem
{
    string Name { get; set; }

    long StrengthBonus { get; set; }

    long AgilityBonus { get; set; }

    long IntelligenceBonus { get; set; }

    long HitPointsBonus { get; set; }

    long DamageBonus { get; set; }
}