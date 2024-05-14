using System;

class Program
{
    // Metod to create a new journal entry
    public static JournalEntry CreateJournalEntry()
    {
        JournalEntry entry = new JournalEntry();
        entry.SetPrompt();
        entry.SetDateTime();
        entry.SetEntry();
        entry.DisplayEntry();

        return entry;
    }


}