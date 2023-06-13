using System;
using System.Threading;

public class ReflectionActivity : MindfulnessActivity
{
    private string[] reflectionPrompts = {
        "Think about a time when you stood up for someone.",
        "Think about a time when you accomplished something difficult.",
        "Think about a time when you helped someone in need.",
        "Think about a time when you did something selfless."
    };

    public ReflectionActivity()
    {
        Name = "Reflection Activity";
        Description = "This activity will help you reflect on moments in your life when you demonstrated strength and resilience.";
    }

    protected override void PerformActivity()
    {
        Random random = new Random();
        int count = 0;

        Console.WriteLine("Reflect on the following prompts:");

        for (int i = 0; i < Duration; i++)
        {
            Console.WriteLine(reflectionPrompts[random.Next(reflectionPrompts.Length)]);
            count++;
            Thread.Sleep(2000);
        }

        Console.WriteLine($"You have reflected on {count} prompts.");
    }
}
