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

        if (newDepositAccount != null)
        {
            _depositAccounts.Add(newDepositAccount);
        }

        Console.WriteLine("\nDeposit Account opened successfully.");
        Console.Write("\nPress any key to return to the main menu: ");
        Console.ReadKey();
    }

    public void OpenLoanAccount()
    {
       LoanAccount newLoanAccount = LoanAccount.OpenAccount();
       
       if (newLoanAccount != null)
        {
            _loanAccounts.Add(newLoanAccount);
        }

        Console.WriteLine("\nLoan Account opened successfully.");
        Console.Write("\nPress any key to return to the main menu: ");
        Console.ReadKey();
    }

    public int GetDepositAccountCount()
    {
        return _depositAccounts.Count;
    }

    public int GetLoanAccountCount()
    {
        return _loanAccounts.Count;
    }

    public void DisplayDepositAccounts()
    {
        if (_depositAccounts.Count == 0)
        {
            Console.WriteLine("There are no deposit accounts to display.");
        }
        else
        {
            Console.WriteLine("\nDeposit Accounts:");
            for (int i = 0; i < _depositAccounts.Count; i++)
            {
                Console.WriteLine($"\nAccount ID: 00{i + 1}");
                _depositAccounts[i].DisplayAccountInfo();
            }
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

    public void DisplayDepositTransactions()
    {
        Console.Write("\nEnter the account ID to display transactions: ");
        int accountID = Convert.ToInt32(Console.ReadLine()) - 1;

        if (accountID >= 0 && accountID < _depositAccounts.Count)
        {
            _depositAccounts[accountID].DisplayTransactions();

            Console.Write("\nPress any key to return to the Deposit Accounts menu: ");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("\nInvalid account ID.");
            Console.Write("\nPress any key to return to the Deposit Accounts menu: ");
            Console.ReadKey();
        }
    }

    public void DisplayLoanTransactions()
    {
        Console.Write("\nEnter the loan ID to display transactions: ");
        int loanID = Convert.ToInt32(Console.ReadLine()) - 1;

        if (loanID >= 0 && loanID < _loanAccounts.Count)
        {
            _loanAccounts[loanID].DisplayTransactions();

            Console.Write("\nPress any key to return to the Loan Accounts menu: ");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("\nInvalid loan ID.");
            Console.Write("\nPress any key to return to the Loan Accounts menu: ");
            Console.ReadKey();
        }
    }

    public void MakeDeposit()
    {
        Console.Write("\nEnter the account ID to make a deposit: ");
        int accountID = Convert.ToInt32(Console.ReadLine()) - 1;

        if (accountID >= 0 && accountID < _depositAccounts.Count)
        {
            if (_depositAccounts[accountID].IsAlreadyClosed())
            {
                Console.WriteLine("\nThis account is closed and cannot accept deposits.");
                Console.Write("\nPress any key to return to the Deposit Accounts menu: ");
                Console.ReadKey();
                return;
            }
            _depositAccounts[accountID].MakeDeposit();
        }
        else
        {
            Console.WriteLine("\nInvalid account ID.");
            Console.Write("\nPress any key to return to the Deposit Accounts menu: ");
            Console.ReadKey();
        }
    }

    public void MakeWithdrawal()
    {
        Console.Write("\nEnter the account ID to make a withdrawal: ");
        int accountID = Convert.ToInt32(Console.ReadLine()) - 1;

        if (accountID >= 0 && accountID < _depositAccounts.Count)
        {
            if (_depositAccounts[accountID].IsAlreadyClosed())
            {
                Console.WriteLine("\nThis account is closed and cannot accept withdrawals.");
                Console.Write("\nPress any key to return to the Deposit Accounts menu: ");
                Console.ReadKey();
                return;
            }
            _depositAccounts[accountID].MakeWithdrawal();
        }
        else
        {
            Console.WriteLine("\nInvalid account ID.");
            Console.Write("\nPress any key to return to the Deposit Accounts menu: ");
            Console.ReadKey();
        }
    }

    public void MakePayment()
    {
        Console.Write("\nEnter the loan ID to make a payment: ");
        int loanID = Convert.ToInt32(Console.ReadLine()) - 1;

        if (loanID >= 0 && loanID < _loanAccounts.Count)
        {
            if (_loanAccounts[loanID].IsAlreadyClosed())
            {
                Console.WriteLine("\nThis account is closed and cannot accept payments.");
                Console.Write("\nPress any key to return to the Loan Accounts menu: ");
                Console.ReadKey();
                return;
            }
            _loanAccounts[loanID].MakePayment();
        }
        else
        {
            Console.WriteLine("\nInvalid loan ID.");
            Console.Write("\nPress any key to return to the Loan Accounts menu: ");
            Console.ReadKey();
        }
    }

    public void AddMonthlyInterest()
    {
        Console.Write("\nEnter the account ID to add monthly interest: ");
        int accountID = Convert.ToInt32(Console.ReadLine()) - 1;

        if (accountID >= 0 && accountID < _depositAccounts.Count)
        {
            if (_depositAccounts[accountID].IsAlreadyClosed())
            {
                Console.WriteLine("\nThis account is closed and cannot accrue interest.");
                Console.Write("\nPress any key to return to the Deposit Accounts menu: ");
                Console.ReadKey();
                return;
            }
            _depositAccounts[accountID].AddInterest();
        }
        else
        {
            Console.WriteLine("\nInvalid account ID.");
            Console.Write("\nPress any key to return to the Deposit Accounts menu: ");
            Console.ReadKey();
        }
    }

    public void GetTenDayPayoff()
    {
        Console.Write("\nEnter the loan ID to get the ten day payoff: ");
        int loanID = Convert.ToInt32(Console.ReadLine()) - 1;

        if (loanID >= 0 && loanID < _loanAccounts.Count)
        {
            if (_loanAccounts[loanID].IsAlreadyClosed())
            {
                Console.WriteLine("\nThis account is closed and cannot provide a ten day payoff.");
                Console.Write("\nPress any key to return to the Loan Accounts menu: ");
                Console.ReadKey();
                return;
            }
            _loanAccounts[loanID].TenDayPayoff();
            Console.Write("\nPress any key to return to the Loan Accounts menu: ");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("\nInvalid loan ID.");
            Console.Write("\nPress any key to return to the Loan Accounts menu: ");
            Console.ReadKey();
        }
    }

    public void CloseDepositAccount()
    {
        Console.Write("\nEnter the account ID to close the account: ");
        int accountID = Convert.ToInt32(Console.ReadLine()) - 1;

        if (accountID >= 0 && accountID < _depositAccounts.Count)
        {
            if (_depositAccounts[accountID].IsAlreadyClosed())
            {
                Console.WriteLine("\nThis account is already closed.");
                Console.Write("\nPress any key to return to the Deposit Accounts menu: ");
                Console.ReadKey();
                return;
            }
            _depositAccounts[accountID].CloseAccount();
        }
        else
        {
            Console.WriteLine("\nInvalid account ID.");
            Console.Write("\nPress any key to return to the Deposit Accounts menu: ");
            Console.ReadKey();
        }
    }

    public void CloseLoanAccount()
    {
        Console.Write("\nEnter the loan ID to close the account: ");
        int loanID = Convert.ToInt32(Console.ReadLine()) - 1;

        if (loanID >= 0 && loanID < _loanAccounts.Count)
        {
            if (_loanAccounts[loanID].IsAlreadyClosed())
            {
                Console.WriteLine("\nThis account is already closed.");
                Console.Write("\nPress any key to return to the Loan Accounts menu: ");
                Console.ReadKey();
                return;
            }
            _loanAccounts[loanID].CloseAccount();
        }
        else
        {
            Console.WriteLine("\nInvalid loan ID.");
            Console.Write("\nPress any key to return to the Loan Accounts menu: ");
            Console.ReadKey();
        }
    }

    public void ResetSavingsWithdrawals()
    {
        for (int i = 0; i < _depositAccounts.Count; i++)
        {
           if (_depositAccounts[i] is SavingsAccount savingsAccount)
           {
                if (savingsAccount.IsAlreadyClosed())
                {
                    Console.WriteLine($"\nAccount ID 00{i+1} is closed and cannot reset withdrawals.");
                }

                if (!savingsAccount.IsAlreadyClosed())
                {
                    savingsAccount.ResetWithdrawals();
                }
           }
        }
        Console.Write("\nPress any key to return to the Deposit Accounts menu: ");
        Console.ReadKey();
    }
}