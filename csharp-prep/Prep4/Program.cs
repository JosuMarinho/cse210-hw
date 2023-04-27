using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a series of numbers. Enter 0 to stop.");

        int input = -1;

        while (input != 0)
        {
            Console.Write("Number: ");
            if (int.TryParse(Console.ReadLine(), out input))
            {
                numbers.Add(input);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers entered.");
            return;
        }

        int sum = 0;
        int max = numbers[0];

        foreach (int num in numbers)
        {
            sum += num;
            if (num > max)
            {
                max = num;
            }
        }

        double average = (double) sum / numbers.Count;

        Console.WriteLine("Sum: " + sum);
        Console.WriteLine("Average: " + average);
        Console.WriteLine("Max: " + max);
    }
}
