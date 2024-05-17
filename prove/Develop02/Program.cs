using System;
using System.IO;

class Program
{
    // Method to save journal to a text file 
    public static void SaveToFile(Journal journal)
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

    public static void Menu()
    {
        Console.WriteLine("");
        Console.WriteLine("Welcome to the Journal App!");
        Console.WriteLine("");

        // Create a new journal object
        Journal activeJournal = new Journal();
        bool running = true;

        // Main menu loop
        while (running)
        {
            // Display the menu options
            Console.WriteLine("Please choose from the following options (Type the number for your choice):");
            Console.WriteLine("");
            Console.WriteLine("1. Create a new journal entry");
            Console.WriteLine("2. Display journal entries");
            Console.WriteLine("3. Save journal to a file");
            Console.WriteLine("4. Load journal from a file");
            Console.WriteLine("5. Exit");
            Console.WriteLine("");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();


            // Perform the selected action
            if (choice == "1")
            {
                JournalEntry newEntry = JournalEntry.CreateJournalEntry();
                activeJournal.StoreJournalEntry(newEntry);
            }
            else if (choice == "2")
            {
                activeJournal.DisplayJournalEntries();
            }
            else if (choice == "3")
            {
                SaveToFile(activeJournal);
            }
            else if (choice == "4")
            {
                activeJournal = LoadFromFile();
            }
            else if (choice == "5")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }

    static void Main()
    {
        Menu();
    }

}