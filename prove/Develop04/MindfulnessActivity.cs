using System;
using System.Threading;

public abstract class MindfulnessActivity
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int Duration { get; set; }

    public void Start()
    {
        Console.WriteLine("");
        Console.WriteLine($"Starting {Name}...");
        Console.WriteLine("");
        Console.WriteLine(Description);
        Console.WriteLine("");
        Console.WriteLine($"Duration: {Duration} seconds");
        Console.WriteLine("");
        Console.WriteLine("Get ready...");


        List<string> animationStrings = new List<string>();
        animationStrings.Add(" |");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("_");
        animationStrings.Add("\\");

        foreach (string animationString in animationStrings)
        {
            Console.Write(animationString);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }

        Thread.Sleep(3000);
        Console.WriteLine("");

        PerformActivity();

        Console.WriteLine($"You have completed {Name} for {Duration} seconds");
        Thread.Sleep(3000);


        foreach (string animationString in animationStrings)
        {
            Console.Write(animationString);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.Clear();
    }

    protected abstract void PerformActivity();
}
