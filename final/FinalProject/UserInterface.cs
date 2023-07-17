using System;
using System.Collections.Generic;
using System.IO;

public class UserInterface
{
    private Menu _menu;
    private MenuPlanner _menuPlanner;
    private Inventory _inventory;

    public UserInterface()
    {
        _menu = new Menu();
        _inventory = new Inventory();
        _menuPlanner = new MenuPlanner(_inventory);
        InitializeMenu();
        _inventory.LoadInventoryFromFile();
    }

    public void Run()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Show weekly menu");
            Console.WriteLine("2. Add recipe to the menu");
            Console.WriteLine("3. Remove recipe from the menu");
            Console.WriteLine("4. Generate shopping list");
            Console.WriteLine("5. Exit");
            Console.Write("Enter an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ShowWeeklyMenu();
                    break;
                case "2":
                    AddRecipe();
                    break;
                case "3":
                    RemoveRecipe();
                    break;
                case "4":
                    GenerateShoppingList();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private void InitializeMenu()
    {
        Recipe recipe1 = new Recipe()
        {
            Name = "Pasta with Tomato Sauce",
            Ingredients = new List<Product>()
            {
                new Product() { Name = "Pasta", Price = 2 },
                new Product() { Name = "Tomato Sauce", Price = 3 },
                new Product() { Name = "Grated Cheese", Price = 2 }
            }
        };

        Recipe recipe2 = new Recipe()
        {
            Name = "Caesar Salad",
            Ingredients = new List<Product>()
            {
                new Product() { Name = "Lettuce", Price = 1.5m },
                new Product() { Name = "Chicken", Price = 5 },
                new Product() { Name = "Croutons", Price = 1 },
                new Product() { Name = "Caesar Dressing", Price = 2 }
            }
        };

        _menu.AddItem(recipe1);
        _menu.AddItem(recipe2);
    }

    private void ShowWeeklyMenu()
    {
        _menu.ShowMenu();
    }

    private void AddRecipe()
    {
        Console.WriteLine("Add new recipe:");

        Console.Write("Enter the recipe name: ");
        string recipeName = Console.ReadLine();

        List<Product> ingredients = new List<Product>();

        bool addIngredients = true;
        while (addIngredients)
        {
            Console.Write("Enter the ingredient name (or '0' to finish): ");
            string ingredientName = Console.ReadLine();

            if (ingredientName == "0")
            {
                addIngredients = false;
            }
            else
            {
                Console.Write("Enter the ingredient price: ");
                decimal ingredientPrice;
                if (decimal.TryParse(Console.ReadLine(), out ingredientPrice))
                {
                    ingredients.Add(new Product { Name = ingredientName, Price = ingredientPrice });
                }
                else
                {
                    Console.WriteLine("Invalid price. The ingredient will not be added.");
                }
            }
        }

        Recipe newRecipe = new Recipe { Name = recipeName, Ingredients = ingredients };
        _menu.AddItem(newRecipe);
        Console.WriteLine("Recipe added to the menu successfully.");

        // Guardar las recetas en el archivo "recipe.txt"
        SaveRecipesToFile();
    }

    private void RemoveRecipe()
    {
        Console.WriteLine("Select the recipe you want to remove:");
        for (int i = 0; i < _menu.MenuItems.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_menu.MenuItems[i].Name}");
        }

        Console.Write("Enter the number of the recipe: ");
        if (int.TryParse(Console.ReadLine(), out int option) && option >= 1 && option <= _menu.MenuItems.Count)
        {
            _menu.RemoveItem(_menu.MenuItems[option - 1]);
            Console.WriteLine("Recipe removed successfully.");
        }
        else
        {
            Console.WriteLine("Invalid option.");
        }
        SaveRecipesToFile();
    }

    private void GenerateShoppingList()
    {
        List<Recipe> selectedRecipes = _menuPlanner.SelectRecipes(_menu.MenuItems);
        ShoppingList shoppingList = _menuPlanner.GenerateShoppingList(selectedRecipes);
        shoppingList.ShowShoppingList();
    }

    private void SaveRecipesToFile()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter("recipe.txt"))
            {
                foreach (var recipe in _menu.MenuItems)
                {
                    writer.Write(recipe.Name + ",");
                    foreach (var ingredient in recipe.Ingredients)
                    {
                        writer.Write(ingredient.Name + ",");
                    }
                    writer.WriteLine();
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error: Failed to write recipes to file. {ex.Message}");
        }
    }
}