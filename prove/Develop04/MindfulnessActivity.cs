using System;
using System.Threading;

public class MindfulnessActivity
{
    // Attributes
    protected string _name;
    protected string _description;
    protected int _duration;

    // Constructor
    public MindfulnessActivity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Methods
    public void Start()
    {
        Console.WriteLine("");
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine("");
        Console.WriteLine(_description);
        Console.WriteLine("");
        Console.Write("How long, in seconds, would you like for your session?: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("");
        Console.Clear();
        Console.WriteLine("Get Ready......");
        PauseWithSpinner(5);
        Console.WriteLine("");
    }

    public void End()
    {
        Console.WriteLine("");
        Console.WriteLine("Well done!!");
        PauseWithSpinner(3);
        Console.WriteLine("");
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        PauseWithSpinner(5);
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