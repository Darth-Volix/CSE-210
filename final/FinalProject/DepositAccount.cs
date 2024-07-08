using System;
using System.Collections.Generic;

public class DepositAccount
{
    // Attributes
    protected bool _isClosed;
    protected decimal _interestRate;
    protected decimal _balance;
    protected DateTime _openDate;
    protected DateTime _closeDate;
    protected List<Transaction> _transactions;

    // Methods
    public abstract DepositAccount OpenAccount();

    public static void CloseAccount()
    {
        _isClosed = true;
        _closeDate = DateTime.Now;
    }

    public virtual void MakeDeposit()
    {
        Console.Write("\nEnter the amount you would like to deposit: ");
        decimal depositAmount = Convert.ToDecimal(Console.ReadLine());

        _balance += depositAmount;
        _transactions.Add(new Transaction(depositAmount, "Deposit", DateTime.Now));
        Console.WriteLine($"\nDeposit of {depositAmount} made on {DateTime.Now}");
    }

    public virtual void MakeWithdrawal()
    {
        Console.Write("\nEnter the amount you would like to withdraw: ");
        decimal withdrawalAmount = Convert.ToDecimal(Console.ReadLine());

        _balance -= withdrawalAmount;
        _transactions.Add(new Transaction(withdrawalAmount, "Withdrawal", DateTime.Now));
        Console.WriteLine($"\nWithdrawal of {withdrawalAmount} made on {DateTime.Now}");
    }

    public static decimal CalculateMonthlyInterestRate()
    {
        decimal monthlyInterestRate = _interestRate / 12;

        return monthlyInterestRate;
    }

    public static void AddInterest()
    {
        decimal monthlyInterestRate = CalculateMonthlyInterestRate();
        decimal monthlyInterest = _balance * monthlyInterestRate;
        _balance += monthlyInterest;
        _transactions.Add(new Transaction(monthlyInterest, "Interest", DateTime.Now));
        Console.WriteLine($"\nInterest of {monthlyInterest} added on {DateTime.Now}");
    }
}