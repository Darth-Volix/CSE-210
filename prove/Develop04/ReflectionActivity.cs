using System;
using System.Threading;

public class ReflectionActivity : MindfulnessActivity
{
    // Attributes
    private List<string> _prompts;
    private List<string> _questions;

    // Constructor
    public ReflectionActivity(string name, string description) : base(name, description)
    {
        _name = name;
        _description = description;
        _prompts = new List<string>  {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        _questions = new List<string> {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    // Methods
    public void PractceReflecting(int _duration)
    {
        Random rnd = new Random();
        int _promptIndex = rnd.Next(_prompts.Count);
        string _randomPrompt = _prompts[_promptIndex];

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine("");
        Console.WriteLine($" --- {_randomPrompt} --- ");
        Console.WriteLine("");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now, ponder on each of the following questions as they related to this experience.");
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
        Console.Clear();
        
        int counter = 0;
        while (counter < _duration)
        {
            Random random = new Random();
            int _questionIndex = random.Next(_questions.Count);
            string _randomQuestion = _questions[_questionIndex];

            Console.Write($"> {_randomQuestion} ");
            PauseWithSpinner(15);
            Console.WriteLine("");
            counter = counter + 15;
        }
    }

    public void Run()
    {
        Start();
        PractceReflecting(_duration);
        End();
    }
}