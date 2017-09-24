using System.Collections;
using System.Collections.Generic;


public interface IHero
{
    string Name { get; }

    long Strength { get; set; }

    long Agility { get; set; }

    long Intelligence { get; set; }

    long HitPoints { get; set; }

    long Damage { get; set; }

    ICollection<IItem> Items { get; }

    void AddRecipe(RecipeItem recipe);

    void AddItem(IItem item);

    //void AddItem(CommonItem item);

    //void CheckingAndCombineRecipe();

    long PrimaryStats { get; }

    long SecondaryStats { get; }
}
