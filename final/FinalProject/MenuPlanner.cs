using System;
using System.Collections.Generic;

public class MenuPlanner
{
    private Inventory _inventory;

    public MenuPlanner(Inventory inventory)
    {
        _inventory = inventory;
    }

    public List<Recipe> SelectRecipes(List<Recipe> availableRecipes)
    {
        List<Recipe> selectedRecipes = new List<Recipe>();
        foreach (var recipe in availableRecipes)
        {
            if (_inventory.CheckAvailability(recipe))
            {
                selectedRecipes.Add(recipe);
            }
        }
        return selectedRecipes;
    }

    public ShoppingList GenerateShoppingList(List<Recipe> selectedRecipes)
    {
        ShoppingList shoppingList = new ShoppingList();
        foreach (var recipe in selectedRecipes)
        {
            foreach (var ingredient in recipe.Ingredients)
            {
                if (!shoppingList.Products.Exists(p => p.Name == ingredient.Name))
                {
                    shoppingList.AddProduct(ingredient);
                }
            }
        }
        return shoppingList;
    }
}
