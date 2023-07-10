using System;
using System.Collections.Generic;

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
}
