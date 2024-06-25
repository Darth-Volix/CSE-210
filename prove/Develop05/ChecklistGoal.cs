using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _bonusPoints;
    private int _currentCount;

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints)
        : base(name, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = 0;
    }

    public override void SetCurrentCount(int count)
    {
        _currentCount = count;
        
        if (_currentCount >= _targetCount)
        {
            _completed = true;
        }
    }

    public override int RecordEvent()
    {
        _currentCount++;
        if (_currentCount >= _targetCount)
        {
            _completed = true;
            return _points + _bonusPoints;
        }
        return _points;
    }

    public override string Display()
    {
        string status = base.Display();
        return $"{status} Completed {_currentCount}/{_targetCount} times";
    }

    public override string ToDataString()
    {
        return $"ChecklistGoal,{_name},{_points},{_completed},{_targetCount},{_bonusPoints},{_currentCount}";
    }
}