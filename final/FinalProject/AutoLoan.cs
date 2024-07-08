using System;
using System.Collections.Generic;

public class AutoLoan : LoanAccount
{
    // Attributes
    private string _make;
    private string _model;
    private int _year;
    private string _titleType;

    // Constructor
    public AutoLoan(string make, string model, int year, string titleType) : base(string loanName, bool isClosed, int term, decimal interestRate, decimal loanAmount, decimal monthlyPayment, decimal balance, int dueDate, DateTime openDate, DateTime? closeDate, List<Transaction> transactions)
    {
        _make = make;
        _model = model;
        _year = year;
        _titleType = titleType;
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

}