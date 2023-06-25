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
        LoadGoals();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("------- Main Menu ------");
            Console.WriteLine("1. Create simple Goal");
            Console.WriteLine("2. Create eternal Goal");
            Console.WriteLine("3. Create checklist Goal");
            Console.WriteLine("4. Register event");
            Console.WriteLine("5. Show Goal list");
            Console.WriteLine("6. Show score");
            Console.WriteLine("7. Save Goals");
            Console.WriteLine("8. Load targets");
            Console.WriteLine("9. Quit");
            Console.WriteLine("--------------------------");
            Console.Write("Select a choice from the menu: ");
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
                case 4:
                    RegisterEvent();
                    break;
                case 5:
                    ShowGoalList();
                    break;
                case 6:
                    ShowScore();
                    break;
                case 7:
                    SaveGoals();
                    break;
                case 8:
                    LoadGoals();
                    break;
                case 9:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void CreateSimpleGoal()
    {
        Console.WriteLine("----- Create SimpleGoal -----");
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
        Console.WriteLine($"The eternal goal '{name}' has been created..");
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

    static void ShowScore()
    {
        Console.WriteLine($"Current score: {score}");
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