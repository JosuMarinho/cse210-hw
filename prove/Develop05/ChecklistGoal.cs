class CheckListGoal : Goal
{
    private int completionCount;
    private int desiredCount;
    private int registeredCount;
    private int bonus;

    public int CompletionCount
    {
        get { return completionCount; }
        set { completionCount = value; }
    }

    public int DesiredCount
    {
        get { return desiredCount; }
        set { desiredCount = value; }
    }

    public int RegisteredCount
    {
        get { return registeredCount; }
        set { registeredCount = value; }
    }

    public int Bonus
    {
        get { return bonus; }
        set { bonus = value; }
    }

    public override void MarkAsCompleted()
    {
        if (RegisteredCount >= DesiredCount)
        {
            Completed = true;
            Console.WriteLine($"Congratulations! You have completed the objective {Name}");
            Console.WriteLine($"You have earned {Bonus} additional bonus points!");
        }
        else
        {
            Console.WriteLine($"You have not yet completed the desired amount for the goal: {Name}");
        }
    }

    public void RegisterEvent()
    {
        RegisteredCount++;
        Console.WriteLine($"You have registered an event for: {Name}!");
        MarkAsCompleted();
    }

    public override void ShowDetails()
    {
        Console.WriteLine($"Objective name: {Name}");
        Console.WriteLine($"Completed: {Completed}");
        Console.WriteLine($"Desired quantity: {DesiredCount}");
        Console.WriteLine($"RegisteredCount: {RegisteredCount}");
    }
}