using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace Hell.Tests
{
    [TestFixture]
    public class HeroInventoryTests
    {
        private IInventory inventory;

        [SetUp]
        public void TestInit()
        {
            //Arrange
            this.inventory = new HeroInventory();
        }

        [Test]
        public void CheckingTotalStrengthPoints()
        {

            var knife = new CommonItem("Knife", 0, 10, 50, 100, 100);
            var axe = new CommonItem("Axe", 100, 100, 100, 1000, 2500);

            this.inventory.AddCommonItem(knife);
            this.inventory.AddCommonItem(axe);

            //Assert
            Assert.AreEqual(100, inventory.TotalStrengthBonus, "TotalBonus must be equal to 100 points");

        }

        [Test]
        public void CheckingTotalAgilityPoints()
        {
            var knife = new CommonItem("Knife", 0, 10, 50, 100, 100);
            var axe = new CommonItem("Axe", 100, 100, 100, 1000, 2500);

            this.inventory.AddCommonItem(knife);
            this.inventory.AddCommonItem(axe);

            //Assert
            Assert.AreEqual(110, inventory.TotalAgilityBonus, "TotalBonus must be equal to 110 points");
        }

        [Test]
        public void CheckingTotalIntelligencePoints()
        {
            var knife = new CommonItem("Knife", 0, 10, 50, 100, 100);
            var axe = new CommonItem("Axe", 100, 100, 100, 1000, 2500);

            this.inventory.AddCommonItem(knife);
            this.inventory.AddCommonItem(axe);

            //Assert
            Assert.AreEqual(150, inventory.TotalIntelligenceBonus, "TotalBonus must be equal to 150 points");
        }

        [Test]
        public void CheckingTotalHitPoints()
        {
            var knife = new CommonItem("Knife", 0, 10, 50, 100, 100);
            var axe = new CommonItem("Axe", 100, 100, 100, 1000, 2500);

            this.inventory.AddCommonItem(knife);
            this.inventory.AddCommonItem(axe);

            //Assert
            Assert.AreEqual(1100, inventory.TotalHitPointsBonus, "TotalBonus must be equal to 1100 points");
        }

        [Test]
        public void CheckingTotalDamagePoints()
        {
            var knife = new CommonItem("Knife", 0, 10, 50, 100, 100);
            var axe = new CommonItem("Axe", 0, 0, 100, 100, 350);

            this.inventory.AddCommonItem(knife);
            this.inventory.AddCommonItem(axe);

            //Assert
            Assert.AreEqual(450, inventory.TotalDamageBonus, "TotalBonus must be equal to 450 points");
            
        }

        [Test]
        public void FieldsAccessModifierTest()
        {

            FieldInfo[] inventoryType = this.inventory.GetType().GetFields();

            Assert.AreEqual(0, inventoryType.Length, "Field must be private!");
        }

        [Test]
        public void CheckingCountOfItemsDictionary()
        {
            var knife = new CommonItem("Knife", 100, 100, 100, 100, 100);
            var stick = new CommonItem("Stick", 100, 100, 100, 100, 100);
            var spear = new CommonItem("Spear", 100, 100, 100, 100, 100);

            this.inventory.AddCommonItem(knife);

            Type type = this.inventory.GetType();
            var commonItemsField = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute), true).Length != 0);

            Dictionary<string, IItem> items = (Dictionary<string, IItem>)commonItemsField.GetValue(this.inventory);

            var listCommanItems = items.Select(x => x.Value).ToList();

            Assert.AreEqual(1, listCommanItems.Count);
        }

        [Test]
        public void CheckingCountOfRecipeDictionary()
        {
            var requiredItems = new List<string> { "Knife", "Stick", "Spear" };

            IRecipe recipe = new RecipeItem("Axe", 100, 100, 100, 100, 100, requiredItems);

            this.inventory.AddRecipeItem(recipe);

            Type type = this.inventory.GetType();
            var recipeField = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => f.Name == "recipeItems");

            Dictionary<string, IRecipe> recipes = (Dictionary<string, IRecipe>)recipeField.GetValue(this.inventory);

            var listRecepeItems = recipes.Select(x => x.Value).ToList();

            Assert.AreEqual(1, listRecepeItems.Count);
        }

        [Test]
        public void CheckingRecipeCombination()
        {
            var knife = new CommonItem("Knife", 100, 100, 100, 100, 100);
            var stick = new CommonItem("Stick", 100, 100, 100, 100, 100);
            var spear = new CommonItem("Spear", 100, 100, 100, 100, 100);

            this.inventory.AddCommonItem(knife);
            this.inventory.AddCommonItem(stick);
            this.inventory.AddCommonItem(spear);

            var requiredItems = new List<string> { "Knife", "Stick", "Spear" };

            IRecipe recipe = new RecipeItem("Axe", 1000, 1000, 1000, 1000, 1000, requiredItems);

          

            this.inventory.AddRecipeItem(recipe);

            Assert.AreEqual(1000, this.inventory.TotalDamageBonus);
        }

        [Test]
        public void CheckingRecipeCombinationFirstRecipeAfterCommonItem()
        {

            var requiredItems = new List<string> { "Knife", "Stick", "Spear" };
            IRecipe recipe = new RecipeItem("Axe", 10000, 10000, 10000, 10000, 10000, requiredItems);

            var knife = new CommonItem("Knife", 100, 100, 100, 100, 100);
            var stick = new CommonItem("Stick", 100, 100, 100, 100, 100);
            var spear = new CommonItem("Spear", 100, 100, 100, 100, 100);

            this.inventory.AddCommonItem(knife);
            this.inventory.AddCommonItem(stick);
            this.inventory.AddCommonItem(spear);

            this.inventory.AddRecipeItem(recipe);

            Assert.AreEqual(10000, this.inventory.TotalDamageBonus);
        }

        [Test]
        public void TestConstructor()
        {
            var newInventory = new HeroInventory();

            Assert.IsNotNull(newInventory);
        }

        [Test]
        public void CheckingFirstAddingItemAfterAddingRecipeAndLastAddingItem()
        {
            this.inventory.AddCommonItem(new CommonItem("Knife", 1, 2, 3, 4, 5));

            var requiredItems = new List<string> { "Knife", "Stick" };
            IRecipe recipe = new RecipeItem("Axe", 10000, 10000, 10000, 10000, 10000, requiredItems);
            this.inventory.AddRecipeItem(recipe);

            this.inventory.AddCommonItem(new CommonItem("Stick", 1, 2, 3, 4, 5));

            Assert.AreEqual(10000, this.inventory.TotalDamageBonus);
        }
    }

}


