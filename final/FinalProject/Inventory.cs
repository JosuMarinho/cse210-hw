using System;
using System.Collections.Generic;
using System.IO;

public class Inventory
{
    private List<Product> products;

    public Inventory()
    {
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public void RemoveProduct(Product product)
    {
        products.Remove(product);
    }

    public bool CheckAvailability(Recipe recipe)
    {
        foreach (var ingredient in recipe.Ingredients)
        {
            bool ingredientFound = false;
            foreach (var product in products)
            {
                if (product.Name == ingredient.Name)
                {
                    ingredientFound = true;
                    break;
                }
            }
            if (!ingredientFound)
            {
                return false;
            }
        }
        return true;
    }
private void SaveInventoryToFile()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter("recipe.txt"))
            {
                foreach (var product in products)
                {
                    writer.WriteLine($"{product.Name},{product.Price}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: Failed to write inventory to file. {ex.Message}");
        }
    }

    private void LoadInventoryFromFile()
    {
        if (File.Exists("recipe.txt"))
        {
            try
            {
                using (StreamReader reader = new StreamReader("recipe.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            string productName = parts[0];
                            decimal productPrice;
                            if (decimal.TryParse(parts[1], out productPrice))
                            {
                                products.Add(new Product { Name = productName, Price = productPrice });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: Failed to load inventory from file. {ex.Message}");
            }
        }
    }

    internal void SaveRecipesToFile()
    {
        throw new NotImplementedException();
    }
}
