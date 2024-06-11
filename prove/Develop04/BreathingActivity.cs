using System;
using System.Threading;

public class BreathingActivity : MindfulnessActivity
{
    // Constructor
    public BreathingActivity(string _name, string _description) : base(_name, _description)
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
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