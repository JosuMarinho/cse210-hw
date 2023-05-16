using System;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    journal.WriteNewEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    Console.Write("Enter a filename to save the journal: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveJournalToFile(saveFilename);
                    break;
                case "4":
                    Console.Write("Enter a filename to load the journal: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadJournalFromFile(loadFilename);
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
