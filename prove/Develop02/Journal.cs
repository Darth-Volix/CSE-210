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

    // method to display journal entries
    public void DisplayJournalEntries()
    {
        Console.WriteLine("");
        Console.WriteLine("Journal Entries:");
        Console.WriteLine("");
        foreach (JournalEntry entry in _journalEntries)
        {
            entry.DisplayEntry();
        }
    }
    
}