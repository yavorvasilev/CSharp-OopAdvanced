using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class AbstractItem : IItem
{
    public AbstractItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus)
    {
        this.Name = name;
        this.StrengthBonus = strengthBonus;
        this.AgilityBonus = agilityBonus;
        this.IntelligenceBonus = intelligenceBonus;
        this.HitPointsBonus = hitPointsBonus;
        this.DamageBonus = damageBonus;
    }

    public long AgilityBonus { get; set; }
    public long DamageBonus { get; set; }
    public long HitPointsBonus { get; set; }
    public long IntelligenceBonus { get; set; }
    public string Name { get; set; }
    public long StrengthBonus { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"###Item: {this.Name}");
        sb.AppendLine($"###+{this.StrengthBonus} Strength");
        sb.AppendLine($"###+{this.AgilityBonus} Agility");
        sb.AppendLine($"###+{this.IntelligenceBonus} Intelligence");
        sb.AppendLine($"###+{this.HitPointsBonus} HitPoints");
        sb.AppendLine($"###+{this.DamageBonus} Damage");

        return sb.ToString().Trim();
    }
}
