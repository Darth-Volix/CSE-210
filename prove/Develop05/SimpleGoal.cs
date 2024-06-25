using System;

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override int RecordEvent()
    {
        _completed = true;
        return _points;
    }

    public override string ToDataString()
    {
        return $"SimpleGoal,{_name},{_points},{_completed}";
    }
}