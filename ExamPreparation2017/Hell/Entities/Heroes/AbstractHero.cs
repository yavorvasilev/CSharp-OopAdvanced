using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public abstract class AbstractHero : IHero, IComparable<AbstractHero>
{
    private IInventory inventory;
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;

    protected AbstractHero(string name, long strength, long agility, long intelligence, long hitPoints, long damage)
    {
        this.Name = name;
        this.strength = strength;
        this.agility = agility;
        this.intelligence = intelligence;
        this.hitPoints = hitPoints;
        this.damage = damage;
        this.inventory = new HeroInventory();
        //this.Items = new List<IItem>();
    }

    public string Name { get; private set; }

    public long Strength
    {
        get { return this.strength + this.inventory.TotalStrengthBonus; }
        set { this.strength = value; }
    }

    public long Agility
    {
        get { return this.agility + this.inventory.TotalAgilityBonus; }
        set { this.agility = value; }
    }

    public long Intelligence
    {
        get { return this.intelligence + this.inventory.TotalIntelligenceBonus; }
        set { this.intelligence = value; }
    }

    public long HitPoints
    {
        get { return this.hitPoints + this.inventory.TotalHitPointsBonus; }
        set { this.hitPoints = value; }
    }

    public long Damage
    {
        get { return this.damage + this.inventory.TotalDamageBonus; }
        set { this.damage = value; }
    }

    public long PrimaryStats
    {
        get { return this.Strength + this.Agility + this.Intelligence; }
    }

    public long SecondaryStats
    {
        get { return this.HitPoints + this.Damage; }
    }

    //REFLECTION
    public ICollection<IItem> Items
    {
        get
        {
            //Type type = this.inventory.GetType();
            //FieldInfo field = type.GetField("commonItems", BindingFlags.NonPublic | BindingFlags.Instance);
            //Dictionary<string, IItem> items = (Dictionary<string, IItem>)field.GetValue(this.inventory);
            //return items.Select(x => x.Value).ToList();

            Type type = this.inventory.GetType();
            var field = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute), true).Length != 0);
            Dictionary<string, IItem> items = (Dictionary<string, IItem>)field.GetValue(this.inventory);
            return items.Select(x => x.Value).ToList();
        }
    }

    public void AddItem(IItem item)
    {
        this.inventory.AddCommonItem(item);
    }

    //public void AddItem(CommonItem item)
    //{
    //    this.inventory.AddCommonItem(item);
    //}

    public void AddRecipe(RecipeItem recipe)
    {
        this.inventory.AddRecipeItem(recipe);
    }

    //public void CheckingAndCombineRecipe()
    //{
    //    this.inventory.CheckRecipes();
    //}

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Hero: {this.Name}, Class: {base.GetType()}");
        sb.AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}");
        sb.AppendLine($"Strength: {this.Strength}");
        sb.AppendLine($"Agility: {this.Agility}");
        sb.AppendLine($"Intelligence: {this.Intelligence}");
        if (this.Items.Count == 0)
        {
            sb.AppendLine("Items: None");
            return sb.ToString().Trim();
        }
        sb.AppendLine($"Items:");
        foreach (IItem item in this.Items)
        {
            sb.AppendLine(item.ToString());
        }
        return sb.ToString().Trim();
    }

    public int CompareTo(AbstractHero other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }
        if (ReferenceEquals(null, other))
        {
            return 1;
        }
        var primary = this.PrimaryStats.CompareTo(other.PrimaryStats);
        if (primary != 0)
        {
            return primary;
        }
        return this.SecondaryStats.CompareTo(other.SecondaryStats);
    }
}