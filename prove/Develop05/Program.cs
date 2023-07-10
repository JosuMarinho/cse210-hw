using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    private static List<Goal> _goals = new List<Goal>();
    private static int _score = 0;

    static void Main(string[] args)
    {
        LoadGoals();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Current Score: " + _score);
            Console.WriteLine();
            Console.WriteLine("------- Main Menu ------");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.WriteLine("--------------------------");
            Console.Write("Select a choice from the menu: ");
            int option = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (option)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoals();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("----- Create Goal -----");
        Console.WriteLine("Types of Goals:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter the type of goal: ");
        int typeOption = Convert.ToInt32(Console.ReadLine());

        switch (typeOption)
        {
            case 1:
                CreateSimpleGoal();
                break;
            case 2:
                CreateEternalGoal();
                break;
            case 3:
                CreateChecklistGoal();
                break;
            default:
                Console.WriteLine("Invalid option. Try again.");
                break;
        }
    }

    static void CreateSimpleGoal()
    {
        Console.WriteLine("----- Create Simple Goal -----");
        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of your goal?: ");
        string description = Console.ReadLine();
        Console.Write("Enter the goal value: ");
        int value = Convert.ToInt32(Console.ReadLine());

        SimpleGoal goal = new SimpleGoal
        {
            Name = name,
            Value = value,
            Completed = false
        };

        _goals.Add(goal);
        Console.WriteLine($"The simple goal '{name}' has been created.");
    }

    static void CreateEternalGoal()
    {
        Console.WriteLine("----- Create Eternal Goal -----");
        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of your goal?: ");
        string description = Console.ReadLine();
        Console.Write("Enter the goal value: ");
        int value = Convert.ToInt32(Console.ReadLine());

        EternalGoal goal = new EternalGoal
        {
            Name = name,
            Value = value
        };

        _goals.Add(goal);
        Console.WriteLine($"The eternal goal '{name}' has been created.");
    }

    static void CreateChecklistGoal()
    {
        Console.WriteLine("----- Create Checklist Goal -----");
        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter the desired count: ");
        int desiredCount = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the bonus: ");
        int bonus = Convert.ToInt32(Console.ReadLine());

        CheckListGoal goal = new CheckListGoal
        {
            Name = name,
            DesiredCount = desiredCount,
            Bonus = bonus,

            CompletionCount = 0
        };

        _goals.Add(goal);
        Console.WriteLine($"The checklist goal '{name}' has been created.");
    }

    static void RecordEvent()
    {
        Console.WriteLine("----- Record Event -----");
        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine();

        Goal goal = _goals.Find(g => g.Name == name);
        if (goal != null && goal is CheckListGoal checklistGoal)
        {
            checklistGoal.RegisterEvent();
            _score += checklistGoal.Bonus;

            Console.WriteLine("Event recorded successfully.");
            Console.WriteLine("Current Score: " + _score);
        }
        else
        {
            Console.WriteLine("No checklist goal found with that name.");
        }
    }

    static void ListGoals()
    {
        Console.WriteLine("----- Goal List -----");
        foreach (Goal goal in _goals)
        {
            Console.Write("[");
            if (!goal.IsCompleted)
                Console.Write(" ");
            else
                Console.Write("X");
            Console.Write("] ");

            if (goal is CheckListGoal checklistGoal)
            {
                Console.WriteLine($"{goal.Name} - Completed {checklistGoal.CompletionCount}/{checklistGoal.DesiredCount} times");
            }
            else
            {
                Console.WriteLine(goal.Name);
            }
        }
    }
    static void MarkGoalAsCompleted(string goalName)
{
    Goal goal = _goals.Find(g => g.Name == goalName);
    if (goal != null && goal is SimpleGoal simpleGoal)
    {
        if (!simpleGoal.Completed)
        {
            simpleGoal.MarkAsCompleted();
            _score += simpleGoal.Value;
            Console.WriteLine($"Goal '{goalName}' marked as completed.");
        }
        else
        {
            Console.WriteLine($"Goal '{goalName}' is already completed.");
        }
    }
    else
    {
        Console.WriteLine("No simple goal found with that name.");
    }
}

    static void SaveGoals()
    {
        string json = JsonSerializer.Serialize(_goals);
        File.WriteAllText("goals.json", json);
        Console.WriteLine("Goals saved successfully.");
    }

    static void LoadGoals()
    {
        if (File.Exists("goals.json"))
        {
            string json = File.ReadAllText("goals.json");
            _goals = JsonSerializer.Deserialize<List<Goal>>(json);
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("Goals file not found.");
        }
    }
}
