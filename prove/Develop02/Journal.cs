using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }

    public void WriteNewEntry()
    {
        // Select a random prompt
        string prompt = GetRandomPrompt();

        // Get user's response
        Console.WriteLine(prompt);
        string response = Console.ReadLine();

        // Create a new entry with current date
        Entry entry = new Entry
        {
            Prompt = prompt,
            Response = response,
            Date = DateTime.Now
        };

        // Add the entry to the journal
        entries.Add(entry);

        Console.WriteLine("Entry saved successfully!");
    }

    private string GetRandomPrompt()
    {
        // Define a list of prompts
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        // Generate a random index to select a prompt from the list
        Random random = new Random();
        int index = random.Next(prompts.Count);

        // Return the randomly selected prompt
        return prompts[index];
    }

    public void DisplayJournal()
    {
        foreach (Entry entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine();
        }
    }

    public void SaveJournalToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                writer.WriteLine($"{entry.Date}\t{entry.Prompt}\t{entry.Response}");
            }
        }

        Console.WriteLine($"Journal saved to file: {filename}");
    }

    public void LoadJournalFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            entries.Clear();

            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('\t');
                    if (parts.Length == 3)
                    {
                        Entry entry = new Entry
                        {
                            Date = DateTime.Parse(parts[0]),
                            Prompt = parts[1],
                            Response = parts[2]
                        };

                        entries.Add(entry);
                    }
                }
            }

            Console.WriteLine($"Journal loaded from file: {filename}");
        }
        else
        {
            Console.WriteLine($"File not found: {filename}");
        }
    }
}
