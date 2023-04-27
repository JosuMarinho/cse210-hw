using System;

class Program
{
    static void Main(string[] args)
    {
        do
        {
            // Generate a random number between 1 and 100
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
            int numGuesses = 0;

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out guess))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                numGuesses++;

                if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it in " + numGuesses + " guesses!");
                }
            }

            Console.Write("Do you want to play again? (yes/no) ");
        } while (Console.ReadLine().ToLower() == "yes");
    }
}
