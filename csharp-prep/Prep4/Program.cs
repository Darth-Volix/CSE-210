using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        string user_input;
        int user_number;
        int sum;
        double average;
        int largest_number;
        int smallest_number;

        Console.WriteLine("");
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        Console.Write("Enter Number: ");
        user_input = Console.ReadLine();
        user_number = int.Parse(user_input);

        do
        {
            numbers.Add(user_number);
            Console.Write("Enter Number: ");
            user_input = Console.ReadLine();
            user_number = int.Parse(user_input);
        } while (user_number != 0);

        sum = numbers.Sum();
        average = (double)sum / numbers.Count();
        largest_number = numbers.Max();
        smallest_number = numbers.Max();
        numbers.Sort();

        foreach (int number in numbers)
        {
            if (number < smallest_number && number > 0)
            {
                smallest_number = number;
            }
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest_number}");
        Console.WriteLine($"The smallest positive number is: {smallest_number}");
        Console.WriteLine("The sorted list is:");

        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine("");

    }
}