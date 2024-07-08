using System;

public class Transaction
{
    // Attributes
    private decimal _amount;
    private string _transactionType;
    private DateTime _date;

    // Constructor
    public Transaction(decimal amount, string transactionType, DateTime date)
    {
        _amount = amount;
        _transactionType = transactionType;
        _date = date;
    }

    // Methods
    public void DisplayTransaction()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Transaction Date: {_date}");
        Console.WriteLine($"Transaction Amount: {_amount}");
        Console.WriteLine($"Transaction Type: {_transactionType}");
        Console.WriteLine("---------------------------------");
    }
}