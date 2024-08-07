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
                _transactions.Add(new Transaction(withdrawalAmount, "Withdrawal", DateTime.Now));
                Console.WriteLine($"\nWithdrawal of ${withdrawalAmount:F2} made on {DateTime.Now}");
                Console.WriteLine($"New balance: ${_balance:F2}");

                _withdrawalsThisMonth++;

                Console.Write("\nPress any key to return to the Deposit Accounts menu: ");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nInsufficient funds.");
                Console.Write("\nPress any key to return to the Deposit Accounts menu: ");
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine("\nYou have reached the maximum number of withdrawals for this month.");
            Console.Write("\nPress any key to return to the Deposit Accounts menu: ");
            Console.ReadKey();
        }
    }

    public override void CloseAccount()
    {
        if (_balance > 0)
        {
            if (_canWithdraw)
            {
                Console.Write($"\nWould you like to withdraw the remaining balance of ${_balance:F2}? (Y/N): ");
                string withdrawResponse = Console.ReadLine().ToUpper();

                if (withdrawResponse == "Y")
                {
                    _transactions.Add(new Transaction(_balance, "Withdrawal", DateTime.Now));
                    Console.WriteLine($"\nWithdrawal of ${_balance:F2} made on {DateTime.Now}");
                    _balance = 0;
                    _isClosed = true;
                    _closeDate = DateTime.Now;
                    Console.WriteLine("\nAccount closed.");
                    Console.Write("\nPress any key to return to the Deposit Accounts menu: ");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("\nYou must withdraw the remaining balance before closing the account.");
                Console.Write("\nPress any key to return to the Deposit Accounts menu: ");
                Console.ReadKey();
            }
        }
        else
        {
            _isClosed = true;
            _closeDate = DateTime.Now;
            Console.WriteLine("\nAccount closed.");
            Console.Write("\nPress any key to return to the Deposit Accounts menu: ");
            Console.ReadKey();
        }
    }

    public void ResetWithdrawals()
    {
        if (DateTime.Now.Day == 1)
        {
            _withdrawalsThisMonth = 0;
            Console.WriteLine("\nWithdrawal count has been reset.");
            Console.Write("\nPress any key to return to the Deposit Accounts menu: ");
            Console.ReadKey();
        }
        else 
        {
            Console.WriteLine("\nWithdrawal count has not been reset as it must be the first of the month.");
        }
    }
}