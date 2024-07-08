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

    public virtual void MakeDeposit(decimal depositAmount)
    {
        _balance += depositAmount;
        _transactions.Add(new Transaction(depositAmount, "Deposit", DateTime.Now));
        Console.WriteLine($"\nDeposit of {depositAmount} made on {DateTime.Now}");
    }
}