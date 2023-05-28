using System;
using System.Collections.Generic;
class Program


{
    public static void Main()
    {
        Scripture scripture = new Scripture(new Reference("John 3:16"), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life..");
        Program program = new Program();
        program.Run(scripture);
    }

    public void Run(Scripture scripture)
    {
        while (!scripture.AreAllWordsHidden())
        {
            Console.Clear();
            scripture.DisplayScripture();
            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords();



        }
    }
}

