using System;

// To exceed requirements for this assignment, I added code that keeps a log of how many times the user has done each activity.

class Program
{
    static void Main(string[] args)
    {
        try
        {
            int breathingCount = 0;
            int reflectionCount = 0;
            int listingCount = 0;

            int userChoice = 0;
            while (userChoice != 4)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Mindfulness App!");
                Console.WriteLine("");
                Console.WriteLine("Menu Options: ");
                Console.WriteLine("   1. Start breathing activity");
                Console.WriteLine("   2. Start reflecting activity");
                Console.WriteLine("   3. Start listing activity");
                Console.WriteLine("   4. Exit");
                Console.WriteLine("Number of times you have done each activity:");
                Console.WriteLine($"   Breathing: {breathingCount}");
                Console.WriteLine($"   Reflecting: {reflectionCount}");
                Console.WriteLine($"   Listing: {listingCount}");
                Console.Write("Select a choice of activity from the menu: ");
                userChoice = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (userChoice)
                {
                    case 1:
                        BreathingActivity breathingActivity = new BreathingActivity("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
                        breathingActivity.Run();
                        breathingCount++;
                        break;
                    case 2:
                        ReflectionActivity reflectionActivity = new ReflectionActivity("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
                        reflectionActivity.Run();
                        reflectionCount++;
                        break;
                    case 3:
                        ListingActivity listingActivity = new ListingActivity("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
                        listingActivity.Run();
                        listingCount++;
                        break;
                    case 4:
                        Console.WriteLine("");
                        Console.WriteLine("Thank you for using the Mindfulness App!");
                        Console.WriteLine("Goodbye!");
                        Console.WriteLine("");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
        }
    }
}