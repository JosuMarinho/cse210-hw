using System;

class SimpleGoal : Goal
{
    public int Value { get; set; }

    public override void MarkAsCompleted()
    {
        Completed = true;
        Console.WriteLine($"¡Congratulations! You have completed the objective {Name}");
        Console.WriteLine($"¡You have earned {Value} points!");
    }
}
