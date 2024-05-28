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
}