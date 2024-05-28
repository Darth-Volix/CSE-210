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
        // initialize the variables for the HideWords method
        int wordsHidden = 0;
        int hiddenWords = 0;
        int totalWords = _verse.Count;
        int wordsRemaining;

        // count the number of hidden words
        foreach (Word word in _verse)
        {
            if (word.IsWordHidden())
            {
                hiddenWords++;
            }
        }

        // calculate the number of words remaining
        wordsRemaining = totalWords - hiddenWords;

        // hide the words in the scripture
        if (wordsRemaining >= 3)
        {
            while (wordsHidden < 3)
            {
                Random random = new Random();
                int hiddenWord = random.Next(0, _verse.Count);
                if (!_verse[hiddenWord].IsWordHidden())
                {
                    _verse[hiddenWord].HideWord();
                    wordsHidden++;
                }
            }   
        }
        else
        {
            foreach (Word word in _verse)
            {
                if (!word.IsWordHidden())
                {
                    word.HideWord();
                }
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
    public void DisplayScripture()
    {
        // clear the console
        Console.Clear();

        // display the reference 
        Console.Write($"{_reference.DisplayReference()} - ");

        // display the verse 
        foreach (Word word in _verse)
        {
            word.DisplayWord();
        }
    }
}