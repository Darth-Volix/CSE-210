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
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("");
        Console.WriteLine("Starting the activity: " + _name);
        PauseWithSpinner(3);
        Console.WriteLine("Description: " + _description);
        PauseWithSpinner(3);
        Console.WriteLine("Prepare to begin......");
        PauseWithSpinner(5);
        Console.Clear();
    }

    public void End()
    {
        Console.WriteLine("");
        Console.WriteLine("Well done!!");
        PauseWithSpinner(3);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        PauseWithSpinner(3);
        Console.Clear();
    }

    public void PauseWithSpinner(int seconds)
    {
        int counter = 0;
        while (counter < seconds)
        {
            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b \b");
            counter++;
        }
    }
}