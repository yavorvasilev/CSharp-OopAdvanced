using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


public class RecipeItem : AbstractItem, IRecipe
{
    public RecipeItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus, List<string> requiredItems) 
        : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
    {
        this.RequiredItems = requiredItems.ToList();
    }

    //public Recipe(string name, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitPointsBonus, int damageBonus, params string[] requiredItems)
    //{
    //    this.Name = name;
    //    this.StrengthBonus = strengthBonus;
    //    this.AgilityBonus = agilityBonus;
    //    this.IntelligenceBonus = intelligenceBonus;
    //    this.HitPointsBonus = hitPointsBonus;
    //    this.DamageBonus = damageBonus;
    //    this.RequiredItems = requiredItems.ToList();
    //}

    //public int AgilityBonus { get; set; }
    //public int DamageBonus { get; set; }
    //public int HitPointsBonus { get; set; }
    //public int IntelligenceBonus { get; set; }
    //public string Name { get; set; }
    //public int StrengthBonus { get; set; }

    public List<string> RequiredItems { get; set; }
}
