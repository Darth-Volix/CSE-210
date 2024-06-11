using System;
using System.Threading;

public class ListingActivity : MindfulnessActivity 
{
    // Attributes 
    private List<string> _prompts = new List<string>();

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

    public void Run()
    {
        Start();
        PracticeListing(_duration);
        End();
    }
}