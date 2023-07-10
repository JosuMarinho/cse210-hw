using System;
using System.Collections.Generic;

public class UserInterface
{
    private Menu menu;
    private MenuPlanner menuPlanner;
    private Inventory inventory;

    public UserInterface()
    {
        menu = new Menu();
        inventory = new Inventory();
        menuPlanner = new MenuPlanner(inventory);
        InitializeMenu();
        InitializeInventory();
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

        menu.AddItem(recipe1);
        menu.AddItem(recipe2);
    }

    private void InitializeInventory()
    {
        Product product1 = new Product() { Name = "Pasta", Price = 5 };
        Product product2 = new Product() { Name = "Tomato Sauce", Price = 4 };
        Product product3 = new Product() { Name = "Grated Cheese", Price = 3 };
        Product product4 = new Product() { Name = "Lettuce", Price = 1 };
        Product product5 = new Product() { Name = "Chicken", Price = 10 };
        Product product6 = new Product() { Name = "Croutons", Price = 2 };
        Product product7 = new Product() { Name = "Caesar Dressing", Price = 2 };

        inventory.AddProduct(product1);
        inventory.AddProduct(product2);
        inventory.AddProduct(product3);
        inventory.AddProduct(product4);
        inventory.AddProduct(product5);
        inventory.AddProduct(product6);
        inventory.AddProduct(product7);
    }

    private void ShowWeeklyMenu()
    {
        menu.ShowMenu();
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
    menu.AddItem(newRecipe);
    Console.WriteLine("Recipe added to the menu successfully.");
}

    private void RemoveRecipe()
    {
        Console.WriteLine("Select the recipe you want to remove:");
        for (int i = 0; i < menu.MenuItems.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {menu.MenuItems[i].Name}");
        }

        Console.Write("Enter the number of the recipe: ");
        if (int.TryParse(Console.ReadLine(), out int option) && option >= 1 && option <= menu.MenuItems.Count)
        {
            menu.RemoveItem(menu.MenuItems[option - 1]);
            Console.WriteLine("Recipe removed successfully.");
        }
        else
        {
            Console.WriteLine("Invalid option.");
        }
    }

    private void GenerateShoppingList()
    {
        List<Recipe> selectedRecipes = menuPlanner.SelectRecipes(menu.MenuItems);
        ShoppingList shoppingList = menuPlanner.GenerateShoppingList(selectedRecipes);
        shoppingList.ShowShoppingList();
    }
}
