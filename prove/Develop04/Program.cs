using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Mindfulness Program");
        Console.WriteLine("-------------------");

        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    SetDuration(breathingActivity);
                    breathingActivity.Start();
                    break;
                case "2":
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    SetDuration(reflectionActivity);
                    reflectionActivity.Start();
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    SetDuration(listingActivity);
                    listingActivity.Start();
                    break;
                case "4":
                    Console.WriteLine("Exiting the program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private static void SetDuration(MindfulnessActivity activity)
    {
        Console.Write("Enter the duration in seconds: ");
        if (int.TryParse(Console.ReadLine(), out int duration))
        {
            activity.Duration = duration;
        }
        else
        {
            Console.WriteLine("Invalid duration. Using default duration of 60 seconds.");
            activity.Duration = 60;
        }
    }
}
