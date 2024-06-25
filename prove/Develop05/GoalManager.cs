using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _playerLevel;
    private int _levelThreshold;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _playerLevel = 1;
        _levelThreshold = 0;
    }

    public int GetScore()
    {
        return _score;
    }

    public int GetPlayerLevel()
    {
        return _playerLevel;
    }

    public void SetLevelThreshold(int pointAmount)
    {
        _levelThreshold = pointAmount;
    }

    public void CheckLevelUp()
    {
        if (_score >= _levelThreshold)
        {
            while (_score >_levelThreshold)
            {
                _playerLevel++;
                _levelThreshold += _levelThreshold;
            } 
        }
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void AddNewGoal()
    {
        Console.WriteLine("");
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal points: ");
        int points = int.Parse(Console.ReadLine());
        Console.Write("Select goal type (1 - Simple, 2 - Eternal, 3 - Checklist): ");
        int type = int.Parse(Console.ReadLine());

        switch (type)
        {
            case 1:
                AddGoal(new SimpleGoal(name, points));
                break;
            case 2:
                Console.WriteLine("");
                Console.Write("Warning, Eternal Goals cannot truly be marked complete.\nMarking complete will only award points.... ");
                PauseWithSpinner(3);
                Console.WriteLine("");
                AddGoal(new EternalGoal(name, points));
                break;
            case 3:
                Console.Write("Enter target count: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                AddGoal(new ChecklistGoal(name, points, targetCount, bonusPoints));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    public void RecordEvent(string goalName)
    {
        if (_goals.Any(goal => goal.GetName() == goalName))
        {
            foreach (var goal in _goals)
            {   
                if (goal.GetName() == goalName)
                {
                    _score += goal.RecordEvent();

                    if (goal is EternalGoal)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Eternal goals cannot be marked complete.\nPoints awarded only.");
                    }
                    CheckLevelUp();
                    break;
                }
            } 
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("Goal not found.");
            Console.WriteLine("");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.Display());
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
                CheckLevelUp();
            }
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("File not found.");
        }
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

    public void MarkGoalComplete()
    {
        Console.Write("Enter goal name to mark complete: ");
        string goalName = Console.ReadLine();
        RecordEvent(goalName);
    }

    public void PauseWithSpinner(int seconds)
    {
        int counter = 0;
        while (counter < seconds)
        {
            char[] spinner = new char[] { '-', '\\', '|', '/' };          
            for (int i = 0; i < spinner.Length; i++)
            {
                Console.Write(spinner[i]);
                Thread.Sleep(250);
                Console.Write("\b \b");
            }
            counter++;
        }
    }
}