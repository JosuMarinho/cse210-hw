class CheckListGoal : Goal
{
    public int DesiredCount { get; set; }
    public int RegisteredCount { get; set; }
    public int Bonus { get; set; }

    public override void MarkAsCompleted()
    {
        if (RegisteredCount >= DesiredCount)
        {
            Completed = true;
            Console.WriteLine($"¡Congratulations! You have completed the objective {Name}");
            Console.WriteLine($"¡You have earned  {Bonus} additional bonus points as a bonus!");
        }
        else
        {
            Console.WriteLine($"You have not yet completed the desired amount for the goal: {Name}");
        }
    }

    public void RegisterEvent()
    {
        RegisteredCount++;
        Console.WriteLine($"¡You have registered an event for: {Name}!");
        MarkAsCompleted();
    }

    public override void ShowDetails()
    {
        Console.WriteLine($"Objetivo name: {Name}");
        Console.WriteLine($"Completed: {Completed}");
        Console.WriteLine($"Desired quantity: {DesiredCount}");
        Console.WriteLine($"RegisteredCount:  {RegisteredCount}");
    }
}