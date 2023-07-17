using System;
using System.Collections.Generic;

public class Menu
{
    private List<Recipe> _menuItems;

    public Menu()
    {
        _menuItems = new List<Recipe>();
    }

    public void AddItem(Recipe recipe)
    {
        _menuItems.Add(recipe);
    }

    public void RemoveItem(Recipe recipe)
    {
        _menuItems.Remove(recipe);
    }

    public void ShowMenu()
    {
        Console.WriteLine("Weekly Menu:");
        foreach (var recipe in _menuItems)
        {
            Console.WriteLine(recipe.Name);
        }
    }

    public List<Recipe> MenuItems
    {
        get { return _menuItems; }
    }
}