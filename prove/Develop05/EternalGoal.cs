using System;

class EternalGoal : Goal
{
    public int Value { get; set; }

    public override void ShowDetails()
    {
        Console.WriteLine($"Objetive name: {Name}");
        Console.WriteLine($"Completed: {Completed}");
        Console.WriteLine($"¡You win {Value} points!");
    }
}
