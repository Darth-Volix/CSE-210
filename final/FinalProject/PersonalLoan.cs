using System;
using System.Collections.Generic;

public class PersonalLoan : LoanAccount
{
    // Attributes
    private string _loanPurpose;

    // Constructor
    public PersonalLoan(string loanPurpose, string loanName, bool isClosed, int term, double interestRate, decimal loanAmount, decimal monthlyPayment, decimal balance, int dueDate, DateTime openDate, DateTime? closeDate, List<Transaction> transactions) : base(loanName, isClosed, term, interestRate, loanAmount, monthlyPayment, balance, dueDate, openDate, closeDate, transactions)
    {
        _loanPurpose = loanPurpose;
        _loanName = loanName;
        _isClosed = isClosed;
        _term = term;
        _interestRate = interestRate;
        _loanAmount = loanAmount;
        _monthlyPayment = monthlyPayment;
        _balance = balance;
        _dueDate = dueDate;
        _openDate = openDate;
        _closeDate = closeDate;
        _transactions = transactions;
    }

    // Methods
    public override void DisplayAccountInfo()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Loan Name: {_loanName}");
        Console.WriteLine($"Loan Purpose: {_loanPurpose}");
        Console.WriteLine($"Original Loan Amount: ${_loanAmount:F2}");
        Console.WriteLine($"Interest Rate: {_interestRate * 100:F2}%");
        Console.WriteLine($"Term: {_term} years");
        Console.WriteLine($"Monthly Payment: ${_monthlyPayment:F2}");
        Console.WriteLine($"Current Balance: ${_balance:F2}");
        Console.WriteLine($"Due Date: {_dueDate}");
        Console.WriteLine($"Open Date: {_openDate}");
        if (_isClosed)
        {
            Console.WriteLine($"Close Date: {_closeDate}");
        }
        Console.WriteLine("---------------------------------");
    }
}