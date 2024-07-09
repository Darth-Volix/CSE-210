using System;
using System.Collections.Generic;

public abstract class DepositAccount
{
    // Attributes
    protected string _accountName;
    protected bool _isClosed;
    protected double _interestRate;
    protected decimal _balance;
    protected DateTime _openDate;
    protected DateTime? _closeDate;
    protected List<Transaction> _transactions;

    // Constructor
    public DepositAccount(string accountName, bool isClosed, double interestRate, decimal balance, DateTime openDate, DateTime? closeDate, List<Transaction> transactions)
    {
        _accountName = accountName;
        _isClosed = isClosed;
        _interestRate = interestRate;
        _balance = balance;
        _openDate = openDate;
        _closeDate = closeDate;
        _transactions = transactions;
    }

    // Methods
    public static DepositAccount OpenAccount()
    {
        string accountType = "";

        while (accountType != "1" && accountType != "2")
        {
            Console.WriteLine("\nSelect the type of deposit account you would like to open:");
            Console.WriteLine("     1. Savings Account");
            Console.WriteLine("     2. MoneyMarket Account");
            Console.Write("Enter your selection (1 or 2): ");
            accountType = Console.ReadLine();

            if (accountType != "1" && accountType != "2")
            {
                Console.WriteLine("\nInvalid selection. Please try again.");
            }
        }

        if (accountType == "1")
        {
            Console.Write("\nEnter the amount of your opening deposit: $");
            decimal balance = Convert.ToDecimal(Console.ReadLine());
            string accountName = "Savings Account";
            double interestRate = 0.05;
            DateTime openDate = DateTime.Now;
            DateTime? closeDate = null;
            bool isClosed = false;
            List<Transaction> transactions = new List<Transaction>();
            bool canWithdraw = true;
            int maxWithdrawalsPerMonth = 6;
            int withdrawalsThisMonth = 0;

            return new SavingsAccount(maxWithdrawalsPerMonth, withdrawalsThisMonth, canWithdraw, accountName, isClosed, interestRate, balance, openDate, closeDate, transactions);
        }
        else if (accountType == "2")
        {
            return null;
        }
        // This should never be reached
        return null;
    }

    public virtual void CloseAccount()
    {
        if (_balance > 0)
        {
            Console.Write($"\nWould you like to withdraw the remaining balance of ${_balance}? (Y/N): ");
            string withdrawResponse = Console.ReadLine().ToUpper();

            if (withdrawResponse == "Y")
            {
                _transactions.Add(new Transaction(-_balance, "Withdrawal", DateTime.Now));
                Console.WriteLine($"\nWithdrawal of ${_balance} made on {DateTime.Now}");
                _balance = 0;
                _isClosed = true;
                _closeDate = DateTime.Now;
                Console.WriteLine("\nAccount closed.");
            }
            else
            {
                Console.WriteLine("\nYou must withdraw the remaining balance before closing the account.");
            }
        }
        else
        {
            _isClosed = true;
            _closeDate = DateTime.Now;
            Console.WriteLine("\nAccount closed.");
        }
    }

    public void MakeDeposit()
    {
        Console.Write("\nEnter the amount you would like to deposit: $");
        decimal depositAmount = Convert.ToDecimal(Console.ReadLine());

        _balance += depositAmount;
        _transactions.Add(new Transaction(depositAmount, "Deposit", DateTime.Now));
        Console.WriteLine($"\nDeposit of ${depositAmount} made on {DateTime.Now}");
    }

    public virtual void MakeWithdrawal()
    {
        Console.Write("\nEnter the amount you would like to withdraw: $");
        decimal withdrawalAmount = Convert.ToDecimal(Console.ReadLine());

        if (withdrawalAmount <= _balance)
        {
            _balance -= withdrawalAmount;
            _transactions.Add(new Transaction(withdrawalAmount, "Withdrawal", DateTime.Now));
            Console.WriteLine($"\nWithdrawal of ${withdrawalAmount} made on {DateTime.Now}");
        }
        else
        {
            Console.WriteLine("\nInsufficient funds.");
        }

    }

    public double CalculateMonthlyInterestRate()
    {
        double monthlyInterestRate = _interestRate / 12;

        return monthlyInterestRate;
    }

    public void AddInterest()
    {
        DateTime currentDate = DateTime.Now;
        int currentDay = currentDate.Day;

        if (currentDay == 1)
        {
            double monthlyInterestRate = CalculateMonthlyInterestRate();
            decimal monthlyInterest = _balance * (decimal)monthlyInterestRate;
            _balance += monthlyInterest;
            _transactions.Add(new Transaction(monthlyInterest, "Interest", DateTime.Now));
            Console.WriteLine($"\nInterest of ${monthlyInterest} added on {DateTime.Now}");
        }
        else
        {
            Console.WriteLine("\nInterest can only be added on the first of the month.");
        }
    }

    public virtual void DisplayAccountInfo()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Account Name: {_accountName}");
        Console.WriteLine($"Balance: ${_balance}");
        Console.WriteLine($"Interest Rate: {_interestRate * 100}%");
        Console.WriteLine($"Open Date: {_openDate}");
        if (_isClosed)
        {
            Console.WriteLine($"Close Date: {_closeDate}");
        }
        Console.WriteLine("---------------------------------");
    }
}