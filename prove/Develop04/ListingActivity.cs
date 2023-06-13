using System;
using System.Threading;

public class ListingActivity : MindfulnessActivity
{
    private string[] listingPrompts = {
        "When have you felt the Holy Ghost this month?.",
        "What a great action you received this week.",
        "What are you thankful to God for?.",
        "What made you laugh this week?."
    };

    public ListingActivity()
    {
        Name = "Listing Activity";
        Description = "This activity will help you reflect on the good things in your life by having a list as many things as you can in certain area.";
    }

    protected override void PerformActivity()
    {
        Random random = new Random();
        int count = 0;

        Console.WriteLine(listingPrompts[random.Next(listingPrompts.Length)]);
        Thread.Sleep(3000);

        for (int i = 0; i < Duration; i++)
        {
            Console.WriteLine("You may begin in:");
            string item = Console.ReadLine();
            count++;

            Console.WriteLine("Keep listing...");
            Thread.Sleep(1000);
        }
        Console.WriteLine("Well Done!.");
        Console.WriteLine("");
        Console.WriteLine($"You have listed {count} items.");
    }
}
