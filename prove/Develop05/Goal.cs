using System;

class Goal
{
    public string Name { get; set; }
    public bool Completed { get; set; }
    public bool IsCompleted { get; internal set; }

    public virtual void MarkAsCompleted()
    {
        Console.WriteLine("¡This target type cannot be marked as completed!");
    }

    public virtual void ShowDetails()
    {
        Console.WriteLine($"Goal name: {Name}");
        Console.WriteLine($"Completed: {Completed}");
    }
}
