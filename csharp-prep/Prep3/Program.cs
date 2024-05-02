using System;

class Program
{
    static void Main(string[] args)
    {
        string response = "yes";

        do
        {
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 100);

            Console.WriteLine("");
            Console.WriteLine("Welcome to the Magic Number Guessing Game!");

            string user_input;
            int user_guess = 0;
            int guess_count = 0;

            while (user_guess != number)
            {
                Console.Write("What is your guess? ");
                user_input = Console.ReadLine();
                user_guess= int.Parse(user_input);

                guess_count++;

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
                Console.WriteLine("");
                Console.WriteLine($"You did it in {guess_count} tries!");
                }
            }

            Console.WriteLine("");
            Console.Write("Would you like to play again? ");
            response = Console.ReadLine();

        } while (response == "yes");
        
    }
}