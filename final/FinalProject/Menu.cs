using System;
using System.Collections.Generic;

public class Menu
{
    private List<Recipe> menuItems;

    public Menu()
    {
        menuItems = new List<Recipe>();
    }

    public void AddItem(Recipe recipe)
    {
        menuItems.Add(recipe);
    }

    public void RemoveItem(Recipe recipe)
    {
        menuItems.Remove(recipe);
    }

    public void ShowMenu()
    {
        Console.WriteLine("Weekly Menu:");
        foreach (var recipe in menuItems)
        {
            Console.WriteLine(recipe.Name);
        }
    }

    public List<Recipe> MenuItems
    {
        get { return menuItems; }
    }
}