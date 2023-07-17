using System;
using System.Collections.Generic;

public class ShoppingList
{
    private List<Product> _products;

    public ShoppingList()
    {
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public void RemoveProduct(Product product)
    {
        _products.Remove(product);
    }

    public decimal CalculateTotalCost()
    {
        decimal totalCost = 0;
        foreach (var product in _products)
        {
            totalCost += product.Price;
        }
        return totalCost;
    }

    public void ShowShoppingList()
    {
        Console.WriteLine("Shopping List:");
        foreach (var product in _products)
        {
            Console.WriteLine($"{product.Name} - Price: {product.Price}");
        }

        Console.WriteLine($"Total Cost: {CalculateTotalCost()}");
    }

    public List<Product> Products
    {
        get { return _products; }
    }
}