using System;
using System.Collections.Generic;

public class Journal
{
    // list to hold the journal entries
    public List<JournalEntry> _journalEntries = new List<JournalEntry>();

    // method to store the journal entry
    public void StoreJournalEntry(JournalEntry entry)
    {
        _journalEntries.Add(entry);
    }

    // method to delete the last journal entry
    public void DeleteLastEntry()
    {
        if (_journalEntries.Count > 0)
        {
            _journalEntries.RemoveAt(_journalEntries.Count - 1);
            Console.WriteLine("");
            Console.WriteLine("Last entry deleted.");
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("No entries to delete.");
            Console.WriteLine("");
        }
    }

    // method to display journal entries
    public void DisplayJournalEntries()
    {
        if (_journalEntries.Count == 0)
        {
            Console.WriteLine("");
            Console.WriteLine("No entries to display.");
            Console.WriteLine("");
            return;
        }
        else 
        {
            Console.WriteLine("");
            Console.WriteLine("Journal Entries:");
            foreach (JournalEntry entry in _journalEntries)
            {
                entry.DisplayEntry();
            }
        }
    }

    // Method to save journal to a text file 
    public static void SaveToFile(Journal journal)
    {
        // Prompt the user for a file name
        Console.Write("Enter the name of the file to save to: ");
        string fileName = Console.ReadLine();
        // Write the journal entries to the file
        using (StreamWriter sw = File.CreateText(fileName))
        {
            foreach (JournalEntry entry in journal._journalEntries)
            {
                sw.WriteLine($"{entry._entryDateTime}^{entry._entryPrompt}^{entry._entry}");
            }
        }
    }

    // Method to load journal from a text file
    public static Journal LoadFromFile()
    {
        try
        {
            // Create a new journal object
            Journal journal = new Journal();

            // Prompt the user for a file name
            Console.Write("Enter the name of the file to load: ");
            string fileName = Console.ReadLine();

            // Read the file into an array of strings
            string[] lines = System.IO.File.ReadAllLines(fileName);

            // Create a new journal entry for each entry in the file
            foreach (string line in lines)
            {
                JournalEntry entry = new JournalEntry();
                string[] parts = line.Split('^');
                entry._entryDateTime = parts[0];
                entry._entryPrompt = parts[1];
                entry._entry = parts[2];
                journal.StoreJournalEntry(entry);
            }
            return journal;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("");
            Console.WriteLine("File not found.");
            Console.WriteLine("");
            return null;
        }
    }
    
}