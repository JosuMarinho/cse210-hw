using System;

class SimpleGoal : Goal
{
    private int value;
    private int completionCount
    public int Value
    {
        get { return value; }
        set { completionCount = value; }
    }

    public override void MarkAsCompleted()
    {
        Completed = true;
        Console.WriteLine($"Congratulations! You have completed the objective {Name}");
        Console.WriteLine($"You have earned {Value} points!");
    }
    public override void ShowDetails()
    {
        Console.WriteLine($"Goal name: {Name}");
        Console.WriteLine($"Completed: {Completed}");
        Console.WriteLine($"Goal value: {Value}");
    }
}