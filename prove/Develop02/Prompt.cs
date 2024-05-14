using System;
using System.Collections.Generic;

public class Prompt
{
    // List of prompts to be used in the program
    public List<string> _promptsList = new List<string>() {"Who was the most interesting person I interacted with today?", "What was the best part of my day?", 
    "How did I see the hand of the Lord in my life today?", "What was the strongest emotion I felt today?", "If I had one thing I could do over today, what would it be?"};

    // Random object to select a random prompt
    public Random _randomSelector = new Random();

    // Index of the prompt to be used
    public int _promptIndex = 0;

    // Method to select a random prompt
    public string SelectRandomPrompt()
    {
        _promptIndex = _randomSelector.Next(0, _promptsList.Count);
        return _promptsList[_promptIndex];
    }

}
