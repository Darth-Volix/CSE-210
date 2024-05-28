using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        try 
        {
            bool running = true;
            while (running)
            {
                // introduction
                Console.WriteLine("");
                Console.WriteLine("Welcome to the Scripture Memory App!");
                Console.WriteLine("");

                // display the menu
                Console.WriteLine("Please choose from the following options: ");
                Console.WriteLine("    1. Use Pre-Saved Scripture");
                Console.WriteLine("    2. Enter Custom Scripture");
                Console.WriteLine("    3. Exit");

                // get the user's choice
                Console.Write("Enter the number of your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // create the reference
                        Reference reference = new Reference("John", 3, 16);

                        // create the words
                        List<Word> verse = new List<Word>();
                        verse.Add(new Word("For"));
                        verse.Add(new Word("God"));
                        verse.Add(new Word("so"));
                        verse.Add(new Word("loved"));
                        verse.Add(new Word("the"));
                        verse.Add(new Word("world,"));
                        verse.Add(new Word("that"));
                        verse.Add(new Word("he"));
                        verse.Add(new Word("gave"));
                        verse.Add(new Word("his"));
                        verse.Add(new Word("only"));
                        verse.Add(new Word("Son,"));
                        verse.Add(new Word("that"));
                        verse.Add(new Word("whoever"));
                        verse.Add(new Word("believes"));
                        verse.Add(new Word("in"));
                        verse.Add(new Word("him"));
                        verse.Add(new Word("should"));
                        verse.Add(new Word("not"));
                        verse.Add(new Word("perish"));
                        verse.Add(new Word("but"));
                        verse.Add(new Word("have"));
                        verse.Add(new Word("eternal"));
                        verse.Add(new Word("life."));

                        // create the scripture
                        Scripture scripture = new Scripture(reference, verse);

                        bool continueMemorizing = true;
                        while (continueMemorizing)
                        {
                            // display the scripture
                            scripture.DisplayScripture();

                            // Give the user the option to hide the words
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.Write("Hit Enter to hide words or tyoe 'quit' to exit: ");
                            string input = Console.ReadLine();

                            if (input == "quit" || scripture.AreAllWordsHidden())
                            {
                                continueMemorizing = false;
                                Console.WriteLine("");
                                Console.WriteLine("Good job memorizing the scripture!");
                                Console.WriteLine("Returning to the main menu...");
                            }
                            else
                            {
                                scripture.HideWords();
                            }
                        }

                        break;

                    case 2:
                        // ask if there are multiple verses
                        Console.Write("Are there multiple verses? (yes/no): ");
                        string multipleVerses = Console.ReadLine();

                        if (multipleVerses == "yes")
                        {
                            // get the book
                            Console.Write("Enter the book: ");
                            string book = Console.ReadLine();

                            // get the chapter
                            Console.Write("Enter the chapter: ");
                            int chapter = int.Parse(Console.ReadLine());

                            // get the start verse
                            Console.Write("Enter the starting verse number: ");
                            int startVerse = int.Parse(Console.ReadLine());

                            // get the end verse
                            Console.Write("Enter the ending verse number: ");
                            int endVerse = int.Parse(Console.ReadLine());

                            // create the reference
                            Reference reference2 = new Reference(book, chapter, startVerse, endVerse);

                            // have the user type in the verse
                            Console.WriteLine("Please type in words of the verses: ");
                            string verseText = Console.ReadLine();

                            // split the verse into words
                            string[] words = verseText.Split(" ");

                            // create a list to hold our words in the verse
                            List<Word> verse2 = new List<Word>();

                            foreach (string word in words)
                            {
                                verse2.Add(new Word(word));
                            }

                            // create the scripture
                            Scripture scripture2 = new Scripture(reference2, verse2);

                            bool continueMemorizing2 = true;
                            while (continueMemorizing2)
                            {
                                // display the scripture
                                scripture2.DisplayScripture();

                                // Give the user the option to hide the words
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.Write("Hit Enter to hide words or type 'quit' to exit: ");
                                string input = Console.ReadLine();

                                if (input == "quit" || scripture2.AreAllWordsHidden())
                                {
                                    continueMemorizing2 = false;
                                    Console.WriteLine("");
                                    Console.WriteLine("Good job memorizing the scripture!");
                                    Console.WriteLine("Returning to the main menu...");
                                }
                                else
                                {
                                    scripture2.HideWords();
                                }
                            }

                        }
                        else
                        {
                            // get the book
                            Console.Write("Enter the book: ");
                            string book = Console.ReadLine();

                            // get the chapter
                            Console.Write("Enter the chapter: ");
                            int chapter = int.Parse(Console.ReadLine());

                            // get the verse
                            Console.Write("Enter the verse number: ");
                            int verseNumber = int.Parse(Console.ReadLine());

                            // create the reference
                            Reference reference3 = new Reference(book, chapter, verseNumber);

                            // have the user type in the verse
                            Console.WriteLine("Please type in words of the verse: ");
                            string verseText = Console.ReadLine();

                            // split the verse into words
                            string[] words = verseText.Split(" ");

                            // create a list to hold our words in the verse
                            List<Word> verse3 = new List<Word>();
                            
                            foreach (string word in words)
                            {
                                verse3.Add(new Word(word));
                            }

                            // create the scripture
                            Scripture scripture3 = new Scripture(reference3, verse3);

                            bool continueMemorizing3 = true;
                            while (continueMemorizing3)
                            {
                                // display the scripture
                                scripture3.DisplayScripture();

                                // Give the user the option to hide the words
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.Write("Hit Enter to hide words or type 'quit' to exit: ");
                                string input = Console.ReadLine();

                                if (input == "quit" || scripture3.AreAllWordsHidden())
                                {
                                    continueMemorizing3 = false;
                                    Console.WriteLine("");
                                    Console.WriteLine("Good job memorizing the scripture!");
                                    Console.WriteLine("Returning to the main menu...");
                                }
                                else
                                {
                                    scripture3.HideWords();
                                }
                            }
                        }

                        break;

                    case 3:
                        // set running to false to exit the program
                        running = false;

                        break;

                    default:
                        // display an error message if the user's choice is not valid
                        Console.WriteLine("");
                        Console.WriteLine("Invalid choice. Please try again.");

                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }   
}