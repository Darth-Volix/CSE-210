using System;

public class Word
{
    // initialize the variables for the word class
    private string _text;
    private bool _isHidden;

    // constructor for the word class
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // method to hide the word
    public void HideWord()
    {
        _isHidden = true;
    }

    // method to check if the word is hidden
    public bool IsWordHidden()
    {
        return _isHidden;
    }

    // method to display the word
    public void DisplayWord()
    {
        if (_isHidden)
        {
            for (int i = 0; i < _text.Length; i++)
            {
                Console.Write("_");
            }
            Console.Write(" ");
        }
        else
        {
            Console.Write($"{_text} ");
        }
    }
}