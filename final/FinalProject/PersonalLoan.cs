using System;
using System.Collections.Generic;

public class PersonalLoan : LoanAccount
{
    // Attributes
    private string _loanPurpose;

    // Constructor
    public PersonalLoan(string loanPurpose, string loanName, bool isClosed, int term, decimal interestRate, decimal loanAmount, decimal monthlyPayment, decimal balance, int dueDate, DateTime openDate, DateTime? closeDate, List<Transaction> transactions) : base(loanName, isClosed, term, interestRate, loanAmount, monthlyPayment, balance, dueDate, openDate, closeDate, transactions)
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
        Console.WriteLine($"Loan Amount: ${_loanAmount}");
        Console.WriteLine($"Interest Rate: {_interestRate * 100}%");
        Console.WriteLine($"Term: {_term} years");
        Console.WriteLine($"Monthly Payment: ${_monthlyPayment}");
        Console.WriteLine($"Balance: ${_balance}");
        Console.WriteLine($"Due Date: {_dueDate}");
        Console.WriteLine($"Open Date: {_openDate}");
        if (_isClosed)
        {
            Console.WriteLine($"Close Date: {_closeDate}");
        }
        Console.WriteLine("---------------------------------");
    }
}