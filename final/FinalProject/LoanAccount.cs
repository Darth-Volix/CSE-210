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
    public abstract LoanAccount OpenAccount();
    
    public static void CloseAccount()
    {
        _isClosed = true;
        _closeDate = DateTime.Now;
    }

    public static decimal CalculateMonthlyPayment()
    {
        int numberOfPayments = _term * 12;
        decimal monthlyInterestRate = _interestRate / 12;
        decimal monthlyPayment = (_loanAmount * monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, numberOfPayments)) / (Math.Pow(1 + monthlyInterestRate, numberOfPayments) - 1);

        return monthlyPayment;
    }

    public static decimal TenDayPayoff()
    {
        decimal dailyInterestRate = CalculateDailyInterestRate(_interestRate);
        decimal tenDayInterest = _balance * dailyInterestRate * 10;
        decimal tenDayPayoff = _balance + tenDayInterest;

        return tenDayPayoff;
    }

    public static decimal CalculateDailyInterestRate()
    {
        decimal dailyInterestRate = _interestRate / 365;
       
        return dailyInterestRate;
    }

    public static void MakePayment()
    {
        _balance -= _monthlyPayment;
        _transactions.Add(new Transaction(_monthlyPayment, "Payment", DateTime.Now));
        Console.WriteLine($"\nPayment of {_monthlyPayment} made on {DateTime.Now}");
    }
}