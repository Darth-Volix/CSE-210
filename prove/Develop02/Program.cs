using System;
using System.IO;

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

    // Method to save journal to a text file 
    public static void SaveToFile(Journal journal);
    {
        try
        {
            // Prompt the user for a file name
            Console.WriteLine("Enter the name of the file to save to: ");
            string fileName = Console.ReadLine();

        
            // Write the journal entries to the file
            using (StreamWriter sw = File.CreateText(fileName))
            {
                foreach (JournalEntry entry in journal._journalEntries)
                {
                    sw.WriteLine($"{entry._entryDateTime}\\{entry._entryPrompt}\\{entry._entry}");
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
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
            Console.WriteLine("Enter the name of the file to load: ");
            string fileName = Console.ReadLine();

            // Read the file into an array of strings
            string[] lines = System.IO.File.ReadAllLines(fileName);

            // Create a new journal entry for each entry in the file
            JournalEntry entry = new JournalEntry();
            foreach (string line in lines)
            {
                string[] parts = line.Split('\\');
                entry._entryDateTime = parts[0];
                entry._entryPrompt = parts[1];
                entry._entry = parts[2];
                journal.StoreJournalEntry(entry);
            }
            return journal;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
            return null;
        }
    }

}