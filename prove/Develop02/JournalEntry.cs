using System;

public class JournalEntry
{
    // variable to store the date and time
    public string _entryDateTime = "";

    // variable to store the prompt
    public string _entryPrompt = "";

    // variable to store the entry
    public string _entry = "";


    // method to get the random prompt and set it to the entry
    public void SetPrompt()
    {
        Prompt prompt = new Prompt();
        _entryPrompt = prompt.SelectRandomPrompt();
    }

    // method to get the date and time
    public void SetDateTime()
    {
        Console.WriteLine("Enter the date and time of the entry: ");
        _entryDateTime = Console.ReadLine();
    }

    // method to get the entry from the user
    public void SetEntry()
    {
        Console.WriteLine("Today's Prompt:");
        Console.WriteLine(_entryPrompt);
        Console.WriteLine("Enter your entry:")
        Console.WriteLine("");
        _entry = Console.ReadLine();
    }

    // method to display the entry
    public void DisplayEntry()
    {
        Console.WriteLine("");
        Console.WriteLine("==================================================================================");
        Console.WriteLine(_entryDateTime);
        Console.WriteLine("");
        Console.WriteLine("Prompt: " + _entryPrompt);
        Console.WriteLine("");
        Console.WriteLine("Entry: " + _entry);
        Console.WriteLine("==================================================================================");
    }
}