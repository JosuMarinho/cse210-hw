using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static int score = 0;

    static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("You have {0} points.", score);
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu: ");
            int option = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (option)
            {
                case 1:
                    CreateGoalSubMenu();
                    break;
                case 2:
                    ShowGoalList();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RegisterEvent();
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

    static void CreateGoalSubMenu()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        int option = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        switch (option)
        {
            case 1:
                CreateSimpleGoal();
                break;
            case 2:
                CreateEternalGoal();
                break;
            case 3:
                CreateCheckListGoal();
                break;
            default:
                Console.WriteLine("Invalid option. Try again.");
                break;
        }
    }

    static void CreateSimpleGoal()
    {
        Console.WriteLine("----- Create Simple Goal -----");
        Console.Write("Enter the Goal name: ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of your goal?: ");
        string description = Console.ReadLine();
        Console.Write("Enter the Goal value: ");
        int value = Convert.ToInt32(Console.ReadLine());

        SimpleGoal goal = new SimpleGoal
        {
            Name = name,
            Value = value,
        };

        goals.Add(goal);
        Console.WriteLine($"The simple goal '{name}' has been created.");
    }

    static void CreateEternalGoal()
    {
        Console.WriteLine("----- Create Eternal Goal -----");
        Console.Write("Enter the Goal name: ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of your goal?: ");
        string description = Console.ReadLine();
        Console.Write("Enter the Goal value: ");
        int value = Convert.ToInt32(Console.ReadLine());

        EternalGoal goal = new EternalGoal
        {
            Name = name,
            Value = value
        };

        goals.Add(goal);
        Console.WriteLine($"The eternal goal '{name}' has been created.");
    }

    static void CreateCheckListGoal()
    {
        Console.WriteLine("----- Create Checklist Goal -----");
        Console.Write("Enter the Goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter the desired count: ");
        int desiredCount = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the bonus: ");
        int bonus = Convert.ToInt32(Console.ReadLine());

        CheckListGoal goal = new CheckListGoal
        {
            Name = name,
            DesiredCount = desiredCount,
            Bonus = bonus
        };

        goals.Add(goal);
        Console.WriteLine($"The checklist goal '{name}' has been created.");
    }

    static void RegisterEvent()
    {
        Console.WriteLine("----- Register Event -----");
        Console.Write("Enter the Goal name: ");
        string name = Console.ReadLine();

        Goal goal = goals.Find(g => g.Name == name);
        if (goal != null && goal is CheckListGoal checklistGoal)
        {
            checklistGoal.RegisterEvent();
            score += checklistGoal.Bonus;
        }
        else
        {
            Console.WriteLine("No checklist goal found with that name.");
        }
    }

    static void ShowGoalList()
    {
        Console.WriteLine("----- Goal List -----");
        foreach (Goal goal in goals)
        {
            Console.WriteLine();
            goal.ShowDetails();
        }
    }

    static void SaveGoals()
    {
        string json = JsonSerializer.Serialize(goals);
        File.WriteAllText("goals.json", json);
        Console.WriteLine("Goals saved successfully.");
    }

    static void LoadGoals()
    {
        if (File.Exists("goals.json"))
        {
            string json = File.ReadAllText("goals.json");
            goals = JsonSerializer.Deserialize<List<Goal>>(json);
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("Goals file not found.");
        }
    }
}
