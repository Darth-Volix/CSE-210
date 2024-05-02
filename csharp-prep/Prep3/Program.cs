using System;

class Program
{
    static void Main(string[] args)
    {
       Random randomGenerator = new Random();
       int number = randomGenerator.Next(1, 11);

       Console.WriteLine("Welcome to the Magic Number Guessing Game!");

       string user_input;
       int user_guess;

       Console.Write("What is your guess? ");
       user_input = Console.ReadLine();
       user_guess= int.Parse(user_input);

       if (user_guess < number)
       {
        Console.WriteLine("Higher");
       }
       else if (user_guess > number)
       {
        Console.WriteLine("Lower");
       }
       else
       {
        Console.WriteLine("You guessed it!");
       }

    }
}