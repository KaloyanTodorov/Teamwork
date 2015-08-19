﻿namespace KitchenPC.UnitTests
{
    using System;
    using System.Collections.Generic;
    using KitchenPC.Categorization;
    using KitchenPC.Categorization.Interfaces;
    using KitchenPC.Categorization.Logic;
    using KitchenPC.Ingredients;
    using KitchenPC.Recipes;
    using KitchenPC.Recipes.Enums;

    using NUnit.Framework;

    internal class MockIngredientCommonality : IIngredientCommonality
    {


        public MockIngredientCommonality(Guid ingid, float commonality)
        {
            this.IngredientId = ingid;
            this.Commonality = commonality;
        }

        public Guid IngredientId { get; set; }

        public float Commonality { get; set; }
    }

    internal class MockRecipeClassification : IRecipeClassification
    {
        public MockRecipeClassification()
        {
        }

        public MockRecipeClassification(Recipe recipe, RecipeTag tag)
        {
            this.Recipe = recipe;

            this.IsBreakfast = tag == RecipeTag.Breakfast;
            this.IsLunch = tag == RecipeTag.Lunch;
            this.IsDinner = tag == RecipeTag.Dinner;
            this.IsDessert = tag == RecipeTag.Dessert;
        }

        public Recipe Recipe { get; set; }

        public bool IsBreakfast { get; set; }
        public bool IsLunch { get; set; }

        public bool IsDinner { get; set; }

        public bool IsDessert { get; set; }
    }

    internal class MockCategorizationDBLoader : IDBLoader
    {
        public IEnumerable<IIngredientCommonality> LoadCommonIngredients()
        {
            return new MockIngredientCommonality[]
         {
            new MockIngredientCommonality(Mock.Ingredients.SALT.Id, 1f),
            new MockIngredientCommonality(Mock.Ingredients.GRANULATED_SUGAR.Id, 0.90f),
            new MockIngredientCommonality(Mock.Ingredients.EGGS.Id, 0.88f),
            new MockIngredientCommonality(Mock.Ingredients.ALL_PURPOSE_FLOUR.Id, 0.76f),
            new MockIngredientCommonality(Mock.Ingredients.SALTED_BUTTER.Id, 0.63f),
            new MockIngredientCommonality(Mock.Ingredients.VANILLA_EXTRACT.Id, 0.50f),
            new MockIngredientCommonality(Mock.Ingredients.WATER.Id, 0.40f),
            new MockIngredientCommonality(Mock.Ingredients.BLACK_PEPPER.Id, 0.35f),
            new MockIngredientCommonality(Mock.Ingredients.BAKING_POWDER.Id, 0.35f),
            new MockIngredientCommonality(Mock.Ingredients.LOWFAT_MILK.Id, 0.33f),
            new MockIngredientCommonality(Mock.Ingredients.LIGHT_BROWN_SUGAR.Id, 0.32f),
            new MockIngredientCommonality(Mock.Ingredients.BAKING_SODA.Id, 0.31f)
         };
        }

        public IEnumerable<IRecipeClassification> LoadTrainingData()
        {
            // Some fake training data to classify other recipes

            return new MockRecipeClassification[]
         {
            // Breakfast
            new MockRecipeClassification(Mock.Recipes.MockRecipe("Patriotic French Toast", "French toast with a cream cheese topping and fresh fruit!"), RecipeTag.Breakfast),
            new MockRecipeClassification(Mock.Recipes.MockRecipe("Blueberry and Raspberry Pancake Topping", "Blueberries and raspberries mingle in this thick, rich, delicious topping for pancakes or waffles."), RecipeTag.Breakfast),
            new MockRecipeClassification(Mock.Recipes.MockRecipe("Basic Crepes", "Here is a simple but delicious crepe batter which can be made in minutes. It's made  from ingredients that everyone has on hand."), RecipeTag.Breakfast),
            new MockRecipeClassification(Mock.Recipes.MockRecipe("Health Nut Blueberry Muffins", "An awesome healthy alternative to the usual blueberry muffin."), RecipeTag.Breakfast),
            new MockRecipeClassification(Mock.Recipes.MockRecipe("Peanut Butter Banana Smoothie", "It is so refreshing and it's sweet and tasty."), RecipeTag.Breakfast),

            // Lunch
            new MockRecipeClassification(Mock.Recipes.MockRecipe("Turkey Wild Rice Soup", "a hearty soup"), RecipeTag.Lunch),
            new MockRecipeClassification(Mock.Recipes.MockRecipe("Elise's Favorite Waldorf Salad", "A slightly sweet salad with a touch of cinnamon."), RecipeTag.Lunch),
            new MockRecipeClassification(Mock.Recipes.MockRecipe("Wonderful Chicken Curry Salad", "I created this salad for a party last year.  Serve on croissants or lettuce leaves. For a fancy presentation, line a platter with red leaf lettuce, and top with cream puff shells that have been stuffed."), RecipeTag.Lunch),
            new MockRecipeClassification(Mock.Recipes.MockRecipe("Cream Cheese and Ham Spread", "Simple, but flavorful, spread that is great with crackers or celery."), RecipeTag.Lunch),
            new MockRecipeClassification(Mock.Recipes.MockRecipe("Cucumber Dip II", "A cool, fresh-tasting dip, perfect with pretzels, vegetables, and chips."), RecipeTag.Lunch),

            // Dinner
            new MockRecipeClassification(Mock.Recipes.MockRecipe("Homemade Italian Turkey Sausage", "Pens Joyce Haworth from Des Plaines, Illinois, 'When the stores in my area stopped carrying our favorite turkey sausage, I was desperate! I went to the library for some books on sausage-making...and was surprised to learn how easy it is! We use this sweet"), RecipeTag.Dinner),
            new MockRecipeClassification(Mock.Recipes.MockRecipe("Barbeque Pork Two Ways", "Easy and delicious! Pork shoulder, slow-cooked or simmered on the stovetop with onion and spices. Serve hot in sandwich buns."), RecipeTag.Dinner),
            new MockRecipeClassification(Mock.Recipes.MockRecipe("Polynesian Ribs", "A friend shared this recipe more than 30 years ago, and I've been using it ever since. I make the ribs a day ahead and let the flavors meld, then I reheat and serve them the next day."), RecipeTag.Dinner),
            new MockRecipeClassification(Mock.Recipes.MockRecipe("Parmesan Crusted Dinner Rolls", "These are delicious white bread rolls that are dipped in butter, then rolled in Parmesan and left to rise. These are especially great for Thanksgiving and Christmas."), RecipeTag.Dinner),
            new MockRecipeClassification(Mock.Recipes.MockRecipe("Glazed Meatloaf II", "This meatloaf is great! It's my husband's favorite. The glaze makes it delicious and moist."), RecipeTag.Dinner),

            // Desserts
            new MockRecipeClassification(Mock.Recipes.MockRecipe("Banana Oatmeal Cookies", "Spicy oatmeal cookies with banana and walnuts"), RecipeTag.Dessert),
            new MockRecipeClassification(Mock.Recipes.MockRecipe("Cheesecake", "I chose to combine the cheesecake with a devils food cake, creating three layers with a rich butter-cream icing between each layer. Then I covered it with more icing and chocolate chips."), RecipeTag.Dessert),
            new MockRecipeClassification(Mock.Recipes.MockRecipe("Chocolate Toffee Bars", "Tastes like English Toffee "), RecipeTag.Dessert),
            new MockRecipeClassification(Mock.Recipes.MockRecipe("Eclair Cake", "No bake -- Super easy!"), RecipeTag.Dessert),
            new MockRecipeClassification(Mock.Recipes.MockRecipe("Rum Cakes", "Mini Bundts -- Adorable!"), RecipeTag.Dessert)
         };
        }
    }

    [TestFixture]
    internal class Categorization
    {
        private CategorizationEngine engine;

        [TestFixtureSetUp]
        public void Setup()
        {
            this.engine = new CategorizationEngine(new MockCategorizationDBLoader());
        }

        [Test]
        public void TestMeal()
        {
            // Strange sounding recipes, but these are designed to target certain frequently used words from the training data.
            var breakfast = this.engine.Categorize(Mock.Recipes.MockRecipe("French toast pancakes", "with crepes and muffins."));
            var dinner = this.engine.Categorize(Mock.Recipes.MockRecipe("turkey ribs meatloaf", "parmesan barbeque"));
            var dessert = this.engine.Categorize(Mock.Recipes.MockRecipe("cookies cake", "cookies and cake"));

            Assert.IsTrue(breakfast.MealBreakfast, "Recipe should be classified as a breakfast.");
            Assert.IsTrue(dinner.MealDinner, "Recipe should be classified as a dinner.");
            Assert.IsTrue(dessert.MealDessert, "Recipe should be classified as a dessert.");
        }

        [Test]
        public void TestDiet()
        {
            var recepy = Mock.Recipes.MockRecipe("Gluten Free Juice", "No Gluten Trust me!");
            var ingredient = new IngredientUsage { Ingredient = Mock.Ingredients.SALT };
            recepy.AddIngredient(ingredient);
            var categorization = this.engine.Categorize(recepy);

            Assert.IsTrue(categorization.DietGlutenFree, "Recipe should be classified as Gluten Free.");
            Assert.IsTrue(categorization.DietNoAnimals, "Recipe should be classified as No Animals.");
            Assert.IsTrue(categorization.DietNoMeat, "Recipe should be classified as No Meat.");
            Assert.IsTrue(categorization.DietNoPork, "Recipe should be classified as No Pork.");
            Assert.IsTrue(categorization.DietNoRedMeat, "Recipe should be classified as No Red Meat.");
        }

        [Test]
        public void TestNutrition()
        {
            var nutrition = this.engine.Categorize(Mock.Recipes.MIRACLE_DIET);

            Assert.IsTrue(nutrition.NutritionLowCalorie);
            Assert.IsTrue(nutrition.NutritionLowCarb);
            Assert.IsTrue(nutrition.NutritionLowFat);
            Assert.IsTrue(nutrition.NutritionLowSodium);
            Assert.IsTrue(nutrition.NutritionLowSugar);
        }

        [Test]
        public void TestSkill()
        {
            var skill = this.engine.Categorize(Mock.Recipes.QUICK_SANDWHICH);

            Assert.IsTrue(skill.SkillEasy);
            Assert.IsTrue(skill.SkillQuick);
            Assert.IsTrue(skill.SkillCommon);
        }

        [Test]
        public void TestTaste()
        {
            var taste = this.engine.Categorize(Mock.Recipes.SWEET_AND_SPICY_CHICKEN);

            Assert.AreEqual(taste.TasteMildToSpicy, 125);
            Assert.AreEqual(taste.TasteSavoryToSweet, 125);
        }
    }
}