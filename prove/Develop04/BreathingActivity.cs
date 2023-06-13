using System;
using System.Diagnostics;
using System.Threading;

public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        Name = "Breathing Activity";
        Description = "This activity will help you relax by focusing on your breathing.";
    }

    protected override void PerformActivity()
    {
        int breatheInDuration = 4000;
        int breatheOutDuration = 6000;

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.Elapsed.TotalSeconds < Duration)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(breatheInDuration);

            Console.WriteLine("Breathe out...");
            Thread.Sleep(breatheOutDuration);

            Console.WriteLine("");
        }

        stopwatch.Stop();

        Console.WriteLine("Well Done!.");

        List<string> animationStrings = new List<string>();
        animationStrings.Add (" |"); 
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
    }
}
