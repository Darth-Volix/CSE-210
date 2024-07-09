using System;
using System.Collections.Generic;

public class MoneyMarket : Deposit Account
{
    // Attributes
    decimal _minimumBalance;
    int _interestRateTier;

    // Constructor
    public MoneyMarket(decimal minimumBalance, int interestRateTier, string accountName, bool isClosed, double interestRate, decimal balance, DateTime openDate, DateTime? closeDate, List<Transaction> transactions) : base(accountName, isClosed, interestRate, balance, openDate, closeDate, transactions)
    {
        _minimumBalance = minimumBalance;
        _interestRateTier = interestRateTier;
        _accountName = accountName;
        _isClosed = isClosed;
        _interestRate = interestRate;
        _balance = balance;
        _openDate = openDate;
        _closeDate = closeDate;
        _transactions = transactions;
    }
}


// COME BACK AND CORRECT CONSTRUCTOR AND CONVERT LOAN INTEREST RATE TO DOUBLE