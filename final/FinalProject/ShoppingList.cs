using System;
using System.Collections.Generic;
public class ShoppingList
{
    private List<Product> products;

    public ShoppingList()
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

    public decimal CalculateTotalCost()
    {
        decimal totalCost = 0;
        foreach (var product in products)
        {
            totalCost += product.Price;
        }
        return totalCost;
    }

    public void ShowShoppingList()
    {
        Console.WriteLine("Shopping List:");
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Name} - Price: {product.Price}");
        }

        Console.WriteLine($"Total Cost: {CalculateTotalCost()}");
    }

    public List<Product> Products
    {
        get { return products; }
    }
}