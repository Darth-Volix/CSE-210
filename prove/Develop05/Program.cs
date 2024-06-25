using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("");
        Console.WriteLine("Welcome to the Goal Tracker!");

        GoalManager manager = new GoalManager();

        Console.WriteLine("");
        Console.Write("After how many points should the player level up?: ");
        int levelThreshold = int.Parse(Console.ReadLine());
        manager.SetLevelThreshold(levelThreshold);

        bool running = true;

        while (running)
        {
            Console.WriteLine("");
            Console.WriteLine("Current level: " + manager.GetPlayerLevel());
            Console.WriteLine("Current score: " + manager.GetScore());
            Console.WriteLine("");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("     1. Load goals from file");
            Console.WriteLine("     2. Add new goal");
            Console.WriteLine("     3. Mark goal complete");
            Console.WriteLine("     4. Display goals");
            Console.WriteLine("     5. Save and exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());
            
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.Write("Enter the name of the file: ");
                    string filename = Console.ReadLine();
                    manager.PauseWithSpinner(3);
                    manager.LoadGoals(filename);
                    Console.WriteLine("");
                    Console.Write("Returning to main menu... ");
                    manager.PauseWithSpinner(3);
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    manager.AddNewGoal();
                    Console.WriteLine("");
                    Console.Write("Adding goal... ");
                    manager.PauseWithSpinner(3);
                    Console.WriteLine("");
                    Console.WriteLine("Goal added!");
                    Console.Write("Returning to main menu... ");
                    manager.PauseWithSpinner(3);
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    manager.MarkGoalComplete();
                    Console.Write("Returning to main menu... ");
                    manager.PauseWithSpinner(3);
                    Console.Clear();
                    break;
                case 4:
                    Console.WriteLine("");
                    Console.WriteLine("Your goals:");
                    manager.DisplayGoals();
                    break;
                case 5:
                    Console.WriteLine("");
                    Console.Write("Enter the name of the file to save to: ");
                    string saveFilename = Console.ReadLine();
                    manager.SaveGoals(saveFilename);
                    Console.WriteLine("");
                    Console.Write("Saving goals... ");
                    manager.PauseWithSpinner(3);
                    Console.WriteLine("");
                    Console.WriteLine("Goals saved. Goodbye!");
                    Console.WriteLine("");
                    running = false;
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Invalid choice.");
                    Console.WriteLine("");
                    break;
            }
        }
    }
}