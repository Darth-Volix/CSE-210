using System;
using System.Collections.Generic;

public class Scripture 
{
    // initialize the variables for the scripture class
    private List<Word> _verse;
    private Reference _reference;

    // constructor for the scripture class
    public Scripture(Reference reference, List<Word> verse)
    {
        _reference = reference;
        _verse = verse;
    }

    // method to hide words in the scripture
    public void HideWords()
    {
        while wordsHidden < 3
        {
            Random random = new Random()
            int hiddenWord = random.Next(0, _verse.Count);
            if (!_verse[hiddenWord].IsWordHidden())
            {
                _verse[hiddenWord].HideWord();
                wordsHidden++;
            }
        }
    }

    // method to check if all words are hidden
    public bool AreAllWordsHidden()
    {
        foreach (Word word in _verse)
        {
            if (!word.IsWordHidden())
            {
                return false;
            }
        }
        return true;
    }

    //method to display the scripture
    public void display()
    {
        // clear the console
        Console.Clear();

        // display the reference 
        Console.WriteLine($"{_reference._book} {_reference._chapter}:{_reference._startVerse}-{_reference._endVerse}");
    }
}