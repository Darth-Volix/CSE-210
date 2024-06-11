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
        Console.Write("Enter the desired duration of your session in seconds: ");
        _duration = int.Parse(Console.Readline());
        Console.WriteLine("");
        Console.WriteLine("Starting the activity: " + _name);
        Console.WriteLine("");
        PauseWithSpinner(2);
        Console.WriteLine("Description: " + _description);
        Console.WriteLine("");
        PauseWithSpinner(2);
        Console.WriteLine("Prepare to begin......");
        Console.WriteLine("");
        PauseWithSpinner(5);
    }

    public void End()
    {
        Console.WriteLine("");
        Console.WriteLine("Well done!!");
        PauseWithSpinner(2);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
    }
}