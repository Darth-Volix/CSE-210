using System;
using System.IO;

class Program
{
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
                Journal.SaveToFile(activeJournal);
            }
            else if (choice == "4")
            {
                activeJournal = Journal.LoadFromFile();
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