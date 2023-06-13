using System;
using System.Threading;

public class ListingActivity : MindfulnessActivity
{
    private string[] listingPrompts = {
        "List as many fruits as you can.",
        "List as many countries as you can.",
        "List as many animals as you can.",
        "List as many colors as you can."
    };

    public ListingActivity()
    {
        Name = "Listing Activity";
        Description = "This activity will help you practice focus and concentration by listing items in a specific category.";
    }

    protected override void PerformActivity()
    {
        Random random = new Random();
        int count = 0;

        Console.WriteLine(listingPrompts[random.Next(listingPrompts.Length)]);
        Thread.Sleep(3000);

        for (int i = 0; i < Duration; i++)
        {
            Console.WriteLine("Enter an item: ");
            string item = Console.ReadLine();
            count++;

            Console.WriteLine("Keep listing...");
            Thread.Sleep(1000);
        }

        Console.WriteLine($"You have listed {count} items.");
    }
}
