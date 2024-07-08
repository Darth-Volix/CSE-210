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
    
    public void CloseAccount()
    {
        _isClosed = true;
        _closeDate = DateTime.Now;
    }

    
}