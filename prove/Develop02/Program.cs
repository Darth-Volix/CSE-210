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
            Console.WriteLine("3. Delete Last Entry");
            Console.WriteLine("4. Save journal to a file");
            Console.WriteLine("5. Load journal from a file");
            Console.WriteLine("6. Exit");
            Console.WriteLine("");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            // Perform the selected action
            switch (choice)
            {
                case "1":
                    // Create a new journal entry
                    JournalEntry newEntry = JournalEntry.CreateJournalEntry();
                    activeJournal.StoreJournalEntry(newEntry);
                    break;
                case "2":
                    // Display all journal entries
                    activeJournal.DisplayJournalEntries();
                    break;
                case "3":
                    // Delete last journal entry
                    activeJournal.DeleteLastEntry();
                    break;
                case "4":
                    // Save journal to a file
                    Journal.SaveToFile(activeJournal);
                    break;
                case "5":
                    // Load journal from a file
                    activeJournal = Journal.LoadFromFile();
                    break;
                case "6":
                    // Exit the program
                    running = false;
                    break;
                default:
                    // Invalid choice
                    Console.WriteLine("");
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine("");
                    break;
            }
        }
    }

    public static void Main()
    {
        Menu();
    }

}