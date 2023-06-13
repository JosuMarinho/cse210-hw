using System;
using System.Threading;

public abstract class MindfulnessActivity
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int Duration { get; set; }

    public void Start()
    {
        Console.WriteLine($"Starting {Name}...");
        Console.WriteLine(Description);
        Console.WriteLine($"Duration: {Duration} seconds");
        Console.WriteLine("Get ready...");
        Thread.Sleep(3000);
        Console.WriteLine("Begin!");

        PerformActivity();

        Console.WriteLine($"You have completed {Name} for {Duration} seconds");
        Thread.Sleep(3000);
    }

    protected abstract void PerformActivity();
}
