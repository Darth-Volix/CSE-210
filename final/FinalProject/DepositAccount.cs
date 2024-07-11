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
            double interestRate = 0.005;
            DateTime openDate = DateTime.Now;
            DateTime? closeDate = null;
            bool isClosed = false;
            bool canWithdraw = true;
            int maxWithdrawalsPerMonth = 6;
            int withdrawalsThisMonth = 0;
            List<Transaction> transactions = new List<Transaction>();

            Transaction transaction = new Transaction(balance, "Deposit", openDate);
            transactions.Add(transaction);

            return new SavingsAccount(maxWithdrawalsPerMonth, withdrawalsThisMonth, canWithdraw, accountName, isClosed, interestRate, balance, openDate, closeDate, transactions);
        }
        else if (accountType == "2")
        {
            Console.Write("\nEnter the amount of your opening deposit: $");
            decimal balance = Convert.ToDecimal(Console.ReadLine());
            
            if (balance < 2500)
            {
                Console.WriteLine("\nA minimum deposit of $2500 is required to open a Money Market account.");
                return null;
            }

            string accountName = "Money Market Account";
            double interestRate = 0.01;
            DateTime openDate = DateTime.Now;
            DateTime? closeDate = null;
            bool isClosed = false;
            List<Transaction> transactions = new List<Transaction>();
            decimal minimumBalance = 2500;
            int interestRateTier = 1;

            Transaction transaction = new Transaction(balance, "Deposit", openDate);
            transactions.Add(transaction);

            return new MoneyMarket(minimumBalance, interestRateTier, accountName, isClosed, interestRate, balance, openDate, closeDate, transactions);
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
                Console.WriteLine($"\nWithdrawal of ${_balance:F2} made on {DateTime.Now}");
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

    public bool IsAlreadyClosed()
    {
        return _isClosed;
    }

    public void MakeDeposit()
    {
        Console.Write("\nEnter the amount you would like to deposit: $");
        decimal depositAmount = Convert.ToDecimal(Console.ReadLine());

        _balance += depositAmount;
        _transactions.Add(new Transaction(depositAmount, "Deposit", DateTime.Now));
        Console.WriteLine($"\nDeposit of ${depositAmount:F2} made on {DateTime.Now}");
    }

    public virtual void MakeWithdrawal()
    {
        Console.Write("Enter the amount you would like to withdraw: $");
        decimal withdrawalAmount = Convert.ToDecimal(Console.ReadLine());

        if (withdrawalAmount <= _balance)
        {
            _balance -= withdrawalAmount;
            _transactions.Add(new Transaction(withdrawalAmount, "Withdrawal", DateTime.Now));
            Console.WriteLine($"\nWithdrawal of ${withdrawalAmount:F2} made on {DateTime.Now}");
            Console.WriteLine($"\nNew balance: ${_balance:F2}");
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
            Console.WriteLine($"\nInterest of ${monthlyInterest:F2} added on {DateTime.Now}");
            Console.WriteLine($"\nNew balance: ${_balance:F2}");
            Console.Write("\nPress any key to return to the Deposit Accounts menu: ");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("\nInterest can only be added on the first of the month.");
            Console.Write("\nPress any key to return to the Deposit Accounts menu: ");
            Console.ReadKey();
        }
    }

    public virtual void DisplayAccountInfo()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Account Name: {_accountName}");
        Console.WriteLine($"Current Balance: ${_balance:F2}");
        Console.WriteLine($"Interest Rate: {_interestRate * 100:F2}%");
        Console.WriteLine($"Open Date: {_openDate}");
        if (_isClosed)
        {
            Console.WriteLine($"Close Date: {_closeDate}");
        }
        Console.WriteLine("---------------------------------");
    }

    public void DisplayTransactions()
    {
        Console.WriteLine("\n---------------------------------");
        Console.WriteLine($"Transactions for {_accountName}");
        Console.WriteLine("---------------------------------");

        foreach (Transaction transaction in _transactions)
        {
            transaction.DisplayTransaction();
        }
    }
}