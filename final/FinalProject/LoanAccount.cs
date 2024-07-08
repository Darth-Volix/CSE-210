using System;
using System.Collections.Generic;

public abstract class LoanAccount 
{
    // Attributes
    protected bool _isClosed;
    protected int _term;
    protected decimal _interestRate;
    protected decimal _loanAmount;
    protected decimal _monthlyPayment;
    protected decimal _balance;
    protected int _dueDate;
    protected DateTime _openDate;
    protected DateTime _closeDate;
    protected List<Transaction> _transactions;

    // Methods
    public abstract void OpenAccount();
    
    public static void CloseAccount()
    {
        _isClosed = true;
        _closeDate = DateTime.Now;
    }

    public static decimal CalculateMonthlyPayment(_term, _loanAmount, _interestRate)
    {
        int numberOfPayments = _term * 12;
        decimal monthlyInterestRate = _interestRate / 12;
        decimal monthlyPayment = (_loanAmount * monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, numberOfPayments)) / (Math.Pow(1 + monthlyInterestRate, numberOfPayments) - 1);

        return monthlyPayment;
    }
}