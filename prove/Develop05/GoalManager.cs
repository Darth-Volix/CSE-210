using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        foreach (var goal in _goals)
        {
            if (goal.GetName() == goalName)
            {
                _score += goal.RecordEvent();
                break;
            }
        }
    }

    public void DisplayGoals()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.Display());
        }
    }

    public int GetScore()
    {
        return _score;
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter file = new StreamWriter(filename))
        {
            file.WriteLine(_score);
            foreach (var goal in _goals)
            {
                file.WriteLine(goal.ToDataString());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        if (File.Exists(filename))
        {
            using (StreamReader file = new StreamReader(filename))
            {
                _score = int.Parse(file.ReadLine());
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string goalType = parts[0];
                    string name = parts[1];
                    int points = int.Parse(parts[2]);
                    bool completed = bool.Parse(parts[3]);

                    Goal goal = null;
                    if (goalType == "SimpleGoal")
                    {
                        goal = new SimpleGoal(name, points);
                    }
                    else if (goalType == "EternalGoal")
                    {
                        goal = new EternalGoal(name, points);
                    }
                    else if (goalType == "ChecklistGoal")
                    {
                        int targetCount = int.Parse(parts[4]);
                        int bonusPoints = int.Parse(parts[5]);
                        int currentCount = int.Parse(parts[6]);
                        goal = new ChecklistGoal(name, points, targetCount, bonusPoints);
                        goal.SetCurrentCount(currentCount);
                    }
                    
                    goal.SetCompleted(completed);
                    AddGoal(goal);
                }
            }
        }
    }

    public void AddNewGoal()
    {
        Console.WriteLine("Enter goal name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter goal points:");
        int points = int.Parse(Console.ReadLine());
        Console.WriteLine("Select goal type (1 - Simple, 2 - Eternal, 3 - Checklist):");
        int type = int.Parse(Console.ReadLine());

        switch (type)
        {
            case 1:
                AddGoal(new SimpleGoal(name, points));
                break;
            case 2:
                AddGoal(new EternalGoal(name, points));
                break;
            case 3:
                Console.WriteLine("Enter target count:");
                int targetCount = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter bonus points:");
                int bonusPoints = int.Parse(Console.ReadLine());
                AddGoal(new ChecklistGoal(name, points, targetCount, bonusPoints));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    public void MarkGoalComplete()
    {
        Console.WriteLine("Enter goal name to mark complete:");
        string goalName = Console.ReadLine();
        RecordEvent(goalName);
    }
}