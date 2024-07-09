using System;
using System.Collections.Generic;

public class SavingsAccount : DepositAccount
{
    // Attributes
    private int _maxWithdrawalsPerMonth;
    private int _withdrawalsThisMonth;
    private bool _canWithdraw;

    // Constructor
    public SavingsAccount(int maxWithdrawalsPerMonth, int withdrawalsThisMonth, bool canWithdraw, string accountName, bool isClosed, double interestRate, decimal balance, DateTime openDate, DateTime? closeDate, List<Transaction> transactions) : base(accountName, isClosed, interestRate, balance, openDate, closeDate, transactions)
    {
        _maxWithdrawalsPerMonth = maxWithdrawalsPerMonth;
        _withdrawalsThisMonth = withdrawalsThisMonth;
        _canWithdraw = canWithdraw;
        _accountName = accountName;
        _isClosed = isClosed;
        _interestRate = interestRate;
        _balance = balance;
        _openDate = openDate;
        _closeDate = closeDate;
        _transactions = transactions;
    }

    // Methods
    public override void MakeWithdrawal()
    {
        if (_withdrawalsThisMonth < _maxWithdrawalsPerMonth)
        {
            Console.Write("\nEnter the amount you would like to withdraw: $");
            decimal withdrawalAmount = Convert.ToDecimal(Console.ReadLine());

            if (withdrawalAmount <= _balance)
            {
                _balance -= withdrawalAmount;
                _transactions.Add(new Transaction(-withdrawalAmount, "Withdrawal", DateTime.Now));
                Console.WriteLine($"\nWithdrawal of ${withdrawalAmount} made on {DateTime.Now}");

                _withdrawalsThisMonth++;
            }
            else
            {
                Console.WriteLine("\nInsufficient funds.");
            }
        }
        else
        {
            Console.WriteLine("\nYou have reached the maximum number of withdrawals for this month.");
        }
    }

    public override void CloseAccount()
    {
        if (_balance > 0)
        {
            if (_canWithdraw)
            {
                Console.Write($"\nWould you like to withdraw the remaining balance of ${_balance}? (Y/N): ");
                string withdrawResponse = Console.ReadLine().ToUpper();

                if (withdrawResponse == "Y")
                {
                    _transactions.Add(new Transaction(-_balance, "Withdrawal", DateTime.Now));
                    Console.WriteLine($"\nWithdrawal of ${_balance} made on {DateTime.Now}");
                    _balance = 0;
                }
            }
            else
            {
                Console.WriteLine("\nYou must withdraw the remaining balance before closing the account.");
            }
        }

    }

    public void ResetWithdrawals()
    {
        if (DateTime.Now.Day == 1)
        {
            _withdrawalsThisMonth = 0;
            Console.WriteLine("\nWithdrawal count has been reset.");
        }
        else 
        {
            Console.WriteLine("\nWithdrawal count has not been reset as it must be the first of the month.");
        }
    }
}