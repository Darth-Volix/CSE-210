using System;
using System.Threading;

public class ListingActivity : MindfulnessActivity 
{
    // Attributes 
    private List<string> _prompts;

    // Constructor
    public ListingActivity(string name, string description) : base(name, description)
    {
        _name = name;
        _description = description;
        _prompts = new List<string> {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    // Methods
    public void PracticeListing(int _duration)
    {
        Random rnd = new Random();
        int _promptIndex = rnd.Next(_prompts.Count);
        string _randomPrompt = _prompts[_promptIndex];

        Console.WriteLine("List as many responses as you can to the following prompt: ");
        Console.WriteLine($" --- {_randomPrompt} --- ");
        Console.Write("You may begin in: 5");
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

        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(_duration);

        DateTime currentTime = DateTime.Now;
        int listCount = 0;
        while (currentTime < end)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            listCount++;
            currentTime = DateTime.Now;
        }

        Console.WriteLine($"You listed {listCount} items!");
    }

    public void Run()
    {
        Start();
        PracticeListing(_duration);
        End();
    }
}