using System;

public class Reference
{
    // initialize the private variables for the reference class 
    private string _book;
    private string _chapter;
    private string _startVerse;
    private string _endVerse;

    // create a constructor for the reference class where there is only one verse
    public Reference(string book, string chapter, string verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }

    // create a constructor for the reference class where there is a range of verses
    public Reference(string book, string chapter, string startVerse, string endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }  

    // method to get single verse reference input from the user
    public static Reference SingleVerseReferenceInput()
    {
         // get the book
        Console.Write("Enter the book: ");
        string book = Console.ReadLine();

        // get the chapter
        Console.Write("Enter the chapter: ");
        string chapter = Console.ReadLine();

        // get the verse
        Console.Write("Enter the verse number: ");
        string verseNumber = Console.ReadLine();

        // create a reference object
        Reference reference = new Reference(book, chapter, verseNumber);

        return reference;
    }

    // method to get multi verse reference input from the user
    public static Reference MultiVerseReferenceInput()
    {
        // get the book
        Console.Write("Enter the book: ");
        string book = Console.ReadLine();

        // get the chapter
        Console.Write("Enter the chapter: ");
        string chapter = Console.ReadLine();

        // get the start verse
        Console.Write("Enter the start verse number: ");
        string startVerse = Console.ReadLine();

        // get the end verse
        Console.Write("Enter the end verse number: ");
        string endVerse = Console.ReadLine();

        // create a reference object
        Reference reference = new Reference(book, chapter, startVerse, endVerse);

        return reference;
    }

    // method to display the reference
    public string DisplayReference()
    {
        if (_startVerse == _endVerse)
        {
            string displayedReference = $"{_book} {_chapter}:{_startVerse}";
            return displayedReference;
        }    
        else
        {
            string displayedReference = $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
            return displayedReference;
        }
    }

}