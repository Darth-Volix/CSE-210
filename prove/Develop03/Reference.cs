using System;

public class Reference
{
    // initialize the private variables for the reference class 
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    // create a constructor for the reference class where there is only one verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }

    // create a constructor for the reference class where there is a range of verses
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }  

}