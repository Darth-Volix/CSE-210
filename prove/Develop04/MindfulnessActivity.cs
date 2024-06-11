using System;

public class MindfulnessActvity
{
    // Properties
    protected string _name;
    protected string _description;
    protected int _duration;

    // Constructor
    public MindfulnessActvity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Methods
    public void Start()
    {
        Console.WriteLine("");
        Console.Write("Enter the desired duration of the activity in seconds: ");
        _duration = int.Parse(Console.Readline());
        Console.WriteLine("");
        Console.WriteLine("Starting the activity: " + _name);
        PauseWithSpinner(2);
        Console.WriteLine("Description: " + _description);
        PauseWithSpinner(2);
        Console.WriteLine("Prepare to begin......");
        PauseWithSpinner(5);
    }

    public void End()
    {
        
    }
}