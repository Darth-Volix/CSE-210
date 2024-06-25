using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override int RecordEvent()
    {
        return _points;
    }

    public override string ToDataString()
    {
        return $"EternalGoal,{_name},{_points},{_completed}";
    }
}
