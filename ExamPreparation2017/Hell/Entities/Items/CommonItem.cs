using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CommonItem : AbstractItem
{
    //public CommonItem(string name, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitPointsBonus, int damageBonus)
    //{
    //    this.Name = name;
    //    this.StrengthBonus = strengthBonus;
    //    this.AgilityBonus = agilityBonus;
    //    this.IntelligenceBonus = intelligenceBonus;
    //    this.HitPointsBonus = hitPointsBonus;
    //    this.DamageBonus = damageBonus;
    //}

    //public int AgilityBonus { get; set; }
    //public int DamageBonus { get; set; }
    //public int HitPointsBonus { get; set; }
    //public int IntelligenceBonus { get; set; }
    //public string Name { get; set; }
    //public int StrengthBonus { get; set; }

    public CommonItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus) 
        : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
    {

    }
}
