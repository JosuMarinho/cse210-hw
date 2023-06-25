using System;

// Clase EternalGoal (hereda de Goal)
class EternalGoal : Goal
{
    public int Value { get; set; }

    public override void ShowDetails()
    {
        Console.WriteLine($"Objetiv name: {Name}");
        Console.WriteLine($"Completed: {Completed}");
        Console.WriteLine($"¡You win {Value} puntos!");
    }
}
