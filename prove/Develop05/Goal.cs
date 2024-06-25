using System;

public abstract class Goal
{
    protected string _name;
    protected int _points;
    protected bool _completed;

    public Goal(string name, int points)
    {
        _name = name;
        _points = points;
        _completed = false;
    }

    public abstract int RecordEvent();
    public abstract string ToDataString();

    public bool IsCompleted()
    {
        return _completed;
    }

    public virtual string Display()
    {
        string status = _completed ? "[X]" : "[ ]";
        return $"{status} {_name}";
    }

      public virtual void SetCurrentCount(int count)
    {
        throw new NotImplementedException();
    }

    public string GetName()
    {
        return _name;
    }

    public void SetCompleted(bool completed)
    {
        _completed = completed;
    }

    public int GetPoints()
    {
        return _points;
    }
}