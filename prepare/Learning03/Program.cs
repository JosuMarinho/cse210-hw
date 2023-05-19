using System;

public class Program
{
    public static void Main()
    {
        Fraction fraction1 = new Fraction(3, 4);
        Fraction fraction2 = new Fraction(5);
        Fraction fraction3 = new Fraction();

        Console.WriteLine($"Fraction 1: {fraction1.GetFractionString()}");    // Output: 3/4
        Console.WriteLine($"Fraction 1 Decimal Value: {fraction1.GetDecimalValue()}");    // Output: 0.75

        Console.WriteLine($"Fraction 2: {fraction2.GetFractionString()}");    // Output: 5/1
        Console.WriteLine($"Fraction 2 Decimal Value: {fraction2.GetDecimalValue()}");    // Output: 5

        Console.WriteLine($"Fraction 3: {fraction3.GetFractionString()}");    // Output: 1/1
        Console.WriteLine($"Fraction 3 Decimal Value: {fraction3.GetDecimalValue()}");    // Output: 1
    }
}
