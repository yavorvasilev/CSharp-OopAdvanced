using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class HeroManager : IManager
{
    public Dictionary<string, IHero> heroes;

    public HeroManager()
    {
        this.heroes = new Dictionary<string, IHero>();
    }

    public string AddHero(List<string> arguments) //HeroCommand
    {
        string result = null;

        string heroName = arguments[0];
        string heroType = arguments[1];

        try
        {
            Type clazz = Type.GetType(heroType);
            var constructors = clazz.GetConstructors();
            IHero hero = (IHero)constructors[0].Invoke(new object[] { heroName });


            heroes.Add(heroName, hero);

            // adding Hero
            result = string.Format($"Created {heroType} - {hero.Name}");
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string AddItemToHero(List<string> arguments)
    {
        string result = null;

        //Ма те много бе!
        string itemName = arguments[0];
        string heroName = arguments[1];
        long strengthBonus = long.Parse(arguments[2]);
        long agilityBonus = long.Parse(arguments[3]);
        long intelligenceBonus = long.Parse(arguments[4]);
        long hitPointsBonus = long.Parse(arguments[5]);
        long damageBonus = long.Parse(arguments[6]);


        //CommonItem newItem = new CommonItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus,
        //    damageBonus);
        CommonItem newItem = new CommonItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus,
            damageBonus);
        heroes[heroName].AddItem(newItem);
        //heroes[heroName].CheckingAndCombineRecipe();
        //тука трябваше да добавя към hero ама промених едно нещо и то много неща се счупиха и реших просто да не добавям

        result = string.Format(Constants.ItemCreateMessage, newItem.Name, heroName);
        return result;
    }

    public string AddRecipeToHero(List<string> arguments)
    {
        string itemName = arguments[0];
        string heroName = arguments[1];
        long strengthBonus = long.Parse(arguments[2]);
        long agilityBonus = long.Parse(arguments[3]);
        long intelligenceBonus = long.Parse(arguments[4]);
        long hitPointsBonus = long.Parse(arguments[5]);
        long damageBonus = long.Parse(arguments[6]);
        var requiredItems = arguments.Skip(7).ToList();

        RecipeItem recipe = new RecipeItem(itemName, strengthBonus, agilityBonus, intelligenceBonus,
            hitPointsBonus, damageBonus, requiredItems);

        var hero = heroes[heroName];
        hero.AddRecipe(recipe);
        //hero.CheckingAndCombineRecipe();

        return $"Added recipe - {itemName} to Hero - {heroName}";
    }

    //public string CreateGame()
    //{
    //    StringBuilder result = new StringBuilder();

    //    foreach (var hero in heroes)
    //    {
    //        result.AppendLine(hero.Key);
    //    }

    //    return result.ToString();
    //}

    public string Inspect(List<string> arguments)
    {
        string heroName = arguments[0];

        return this.heroes[heroName].ToString();
    }

    public string Quit()
    {
        var sb = new StringBuilder();
        int count = 1;

        foreach (var item in heroes
            .OrderByDescending(h => h.Value.PrimaryStats)
            .ThenByDescending(h => h.Value.SecondaryStats))
        {
            var hero = item.Value;
            var items = hero.Items.Select(i => i.Name).ToList();
            sb.AppendLine($"{count++}. {hero.GetType()}: {hero.Name}");
            sb.AppendLine($"###HitPoints: {hero.HitPoints}");
            sb.AppendLine($"###Damage: {hero.Damage}");
            sb.AppendLine($"###Strength: {hero.Strength}");
            sb.AppendLine($"###Agility: {hero.Agility}");
            sb.AppendLine($"###Intelligence: {hero.Intelligence}");
            if (items.Count == 0)
            {
                sb.AppendLine("###Items: None");
            }
            else
            {
                sb.AppendLine($"###Items: {string.Join(", ", items)}");
            }
        }
        return sb.ToString().Trim();
    }

    ////Само Батман знае как работи това
    //public static void GenerateResult()
    //{
    //    const string PropName = "_connectionString";

    //    var type = typeof(HeroCommand);

    //    FieldInfo fieldInfo = null;
    //    PropertyInfo propertyInfo = null;
    //    while (fieldInfo == null && propertyInfo == null && type != null)
    //    {
    //        fieldInfo = type.GetField(PropName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    //        if (fieldInfo == null)
    //        {
    //            propertyInfo = type.GetProperty(PropName,
    //                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    //        }

    //        type = type.BaseType;
    //    }
    //}

    //public static void DontTouchThisMethod()
    //{
    //    //това не трябва да го пипаме, че ако го махнем ще ни счупи цялата логика
    //    var l = new List<string>();
    //    var m = new Manager();
    //    HeroCommand cmd = new HeroCommand(l, m);
    //    var str = "Execute";
    //    Console.WriteLine(str);
    //}
}