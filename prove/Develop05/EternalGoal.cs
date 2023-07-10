using System;

class EternalGoal : Goal
{
    private int value;

    public int Value
    {
        get { return value; }
        set { completionCount = value; }
    }

    public int completionCount { get; private set; }

    public override void ShowDetails()
    {
        Console.WriteLine($"Objective name: {Name}");
        Console.WriteLine($"Completed: {Completed}");
        Console.WriteLine($"You win {Value} points!");
    }
}