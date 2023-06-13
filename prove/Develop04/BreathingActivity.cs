using System;
using System.Threading;

public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        Name = "Welcome to the Breathing Activity";
        Description = "This activity will help you relax by focusing on your breathing in and out slowly.";
    }

    protected override void PerformActivity()
    {
        for (int i = 0; i < Duration; i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(1000);
            Console.WriteLine("Breathe out...");
            Thread.Sleep(1000);
        }
    }
}
