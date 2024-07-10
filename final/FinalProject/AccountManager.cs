using System;
using System.Collections.Generic;

public class AccountManager
{
    // Attributes
    private List<DepositAccount> _depositAccounts;
    private List<LoanAccount> _loanAccounts;

    // Constructor
    public AccountManager()
    {
        _depositAccounts = new List<DepositAccount>();
        _loanAccounts = new List<LoanAccount>();
    }

    // Methods
    public void OpenDepositAccount()
    {
        DepositAccount newDepositAccount = DepositAccount.OpenAccount();
        _depositAccounts.Add(newDepositAccount);
    }

    public void OpenLoanAccount()
    {
       LoanAccount newLoanAccount = LoanAccount.OpenAccount();
        _loanAccounts.Add(newLoanAccount);
    }

    public void DisplayDepositAccounts()
    {
        Console.WriteLine("\nDeposit Accounts:");
        for (int i = 0; i < _depositAccounts.Count; i++)
        {
            Console.WriteLine($"\nAccount ID: 00{i + 1}");
            _depositAccounts[i].DisplayAccountInfo();
        }
    }

    public void DisplayLoanAccounts()
    {
        Console.WriteLine("\nLoan Accounts:");
        for (int i = 0; i < _loanAccounts.Count; i++)
        {
            Console.WriteLine($"\nLoan ID: 00{i + 1}");
            _loanAccounts[i].DisplayAccountInfo();
        }
    }

    public void DisplayTransactions()
    {
        Console.WriteLine("\nTransactions:");
        for (int i = 0; i < _depositAccounts.Count; i++)
        {
            Console.WriteLine($"\nAccount ID: 00{i + 1}");
            _depositAccounts[i].DisplayTransactions();
        }
        
        for (int i = 0; i < _loanAccounts.Count; i++)
        {
            Console.WriteLine($"\nLoan ID: 00{i + 1}");
            _loanAccounts[i].DisplayTransactions();
        }
    }

    public void MakeDeposit()
    {
        Console.Write("\nEnter the account ID to make a deposit: ");
        int accountID = Convert.ToInt32(Console.ReadLine()) - 1;

        if (accountID >= 0 && accountID < _depositAccounts.Count)
        {
            _depositAccounts[accountID].MakeDeposit();
        }
        else
        {
            Console.WriteLine("\nInvalid account ID.");
        }
    }

    public void MakeWithdrawal()
    {
        Console.Write("\nEnter the account ID to make a withdrawal: ");
        int accountID = Convert.ToInt32(Console.ReadLine()) - 1;

        if (accountID >= 0 && accountID < _depositAccounts.Count)
        {
            _depositAccounts[accountID].MakeWithdrawal();
        }
        else
        {
            Console.WriteLine("\nInvalid account ID.");
        }
    }

    public void MakePayment()
    {
        Console.Write("\nEnter the loan ID to make a payment: ");
        int loanID = Convert.ToInt32(Console.ReadLine()) - 1;

        if (loanID >= 0 && loanID < _loanAccounts.Count)
        {
            _loanAccounts[loanID].MakePayment();
        }
        else
        {
            Console.WriteLine("\nInvalid loan ID.");
        }
    }

    public void AddMonthlyInterest()
    {
        Console.Write("\nEnter the account ID to add monthly interest: ");
        int accountID = Convert.ToInt32(Console.ReadLine()) - 1;

        if (accountID >= 0 && accountID < _depositAccounts.Count)
        {
            _depositAccounts[accountID].AddInterest();
        }
        else
        {
            Console.WriteLine("\nInvalid account ID.");
        }
    }

    public void GetTenDayPayoff()
    {
        Console.Write("\nEnter the loan ID to get the ten day payoff: ");
        int loanID = Convert.ToInt32(Console.ReadLine()) - 1;

        if (loanID >= 0 && loanID < _loanAccounts.Count)
        {
            _loanAccounts[loanID].TenDayPayoff();
        }
        else
        {
            Console.WriteLine("\nInvalid loan ID.");
        }
    }

    public void CloseAccount()
    {
        Console.Write("\nEnter the account ID to close the account: ");
        int accountID = Convert.ToInt32(Console.ReadLine()) - 1;

        if (accountID >= 0 && accountID < _depositAccounts.Count)
        {
            _depositAccounts[accountID].CloseAccount();
        }
        else
        {
            Console.WriteLine("\nInvalid account ID.");
        }
    }

    public void ResetSavingsWithdrawals()
    {
        for (int i = 0; i < _depositAccounts.Count; i++)
        {
           if (_depositAccounts[i] is SavingsAccount savingsAccount)
           {
                savingsAccount.ResetWithdrawals();
           }
        }
    }
}