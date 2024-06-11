using System;
using System.Threading;

public class BreathingActivity : MindfulnessActivity
{
    // Constructor
    public BreathingActivity(string name, string description) : base(name, description)
    {
        _name = name;
        _description = description;
    }

    // Methods
    public void PracticeBreathing(int _duration)
    {
        int counter = 0;
        while (counter < _duration)
        {
            Console.WriteLine("");
            Console.Write("Breathe in...4");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write("3");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write("2");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write("1");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write("\nBreathe out...6");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write("5");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write("4");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write("3");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write("2");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write("1");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.WriteLine("");
            counter = counter + 10;    
        }
    }

    public void Run()
    {
        Start();
        PracticeBreathing(_duration);
        End();
    }
}