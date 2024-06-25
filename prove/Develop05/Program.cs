using System;

public class Program
{
    public static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.LoadGoals("goals.txt");

        while (true)
        {
            Console.WriteLine("1. Add new goal");
            Console.WriteLine("2. Mark goal complete");
            Console.WriteLine("3. Display goals");
            Console.WriteLine("4. Display score");
            Console.WriteLine("5. Save and exit");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    manager.AddNewGoal();
                    break;
                case 2:
                    manager.MarkGoalComplete();
                    break;
                case 3:
                    manager.DisplayGoals();
                    break;
                case 4:
                    Console.WriteLine($"Total Score: {manager.GetScore()}");
                    break;
                case 5:
                    manager.SaveGoals("goals.txt");
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}