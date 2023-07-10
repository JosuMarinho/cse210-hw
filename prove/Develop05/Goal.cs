using System;

abstract class Goal
{
    private string name;
    private bool completed;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public bool Completed
    {
        get { return completed; }
        set { completed = value; }
    }

    public bool IsCompleted { get; internal set; }

    public virtual void MarkAsCompleted()
    {
        Console.WriteLine("This goal type cannot be marked as completed!");
    }

    public virtual void ShowDetails()
    {
        Console.WriteLine($"Goal name: {Name}");
        Console.WriteLine($"Completed: {Completed}");
    }
}
