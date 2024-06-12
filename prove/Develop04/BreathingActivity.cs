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
            Console.Write("Breathe in...");
            for (int i = 4; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.Write("\nBreathe out...");
            for (int i = 6; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine("");
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