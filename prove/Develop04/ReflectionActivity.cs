using System;
using System.Threading;
using System.Collections.Generic;

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
        DateTime endTime = DateTime.Now.AddSeconds(Duration);


        Console.WriteLine("Reflect on the following prompts:");
        Console.WriteLine("");

        List<string> animationStrings = new List<string>();
        animationStrings.Add(" |");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("_");
        animationStrings.Add("\\");

        //for (int i = 0; i < Duration; i++)
        while (DateTime.Now < endTime)
        {
            Console.WriteLine(reflectionPrompts[random.Next(reflectionPrompts.Length)]);
            count++;
            Thread.Sleep(4000);

            foreach (string animationString in animationStrings)
            {
                Console.Write(animationString);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine("");
            Console.WriteLine("When you have something in mind, press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
        Console.WriteLine("");
        Console.WriteLine("Well Done!.");
        Console.WriteLine("");
        Console.WriteLine($"You have reflected on {count} prompts.");
        Console.WriteLine("");
    }
}

