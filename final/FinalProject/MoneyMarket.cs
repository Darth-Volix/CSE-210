using System;
using System.Collections.Generic;

public class MoneyMarket : DepositAccount
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

    // Methods
    public static int CalculateInterestRateTier(decimal _balance)
    {
        if (_balance >= 2500)
        {
            return 1;
        }
        else if (_balance >= 5000)
        {
            return 2;
        }
        else if (_balance >= 10000)
        {
            return 3;
        }
        else
        {
            return 4;
        }
    }

    public void DetermineInterestRate()
    {
        _interestRateTier = CalculateInterestRateTier(_balance);

        switch (_interestRateTier)
        {
            case 1:
                _interestRate = 0.01;
                break;
            case 2:
                _interestRate = 0.02;
                break;
            case 3:
                _interestRate = 0.03;
                break;
            case 4:
                _interestRate = 0.04;
                break;
        }
    }

    public override void DisplayAccountInfo()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Account Name: {_accountName}");
        Console.WriteLine($"Balance: ${_balance}");
        Console.WriteLine($"Minimum Balance: ${_minimumBalance:F2}");
        Console.WriteLine($"Interest Rate Tier: {_interestRateTier}");
        Console.WriteLine($"Interest Rate: {_interestRate * 100:F2}%");
        Console.WriteLine($"Open Date: {_openDate}");
        if (_isClosed)
        {
            Console.WriteLine($"Close Date: {_closeDate}");
        }
        Console.WriteLine("---------------------------------");
    }
}


// COME BACK AND CORRECT CONSTRUCTOR AND CONVERT LOAN INTEREST RATE TO DOUBLE