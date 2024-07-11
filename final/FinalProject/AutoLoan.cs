using System;
using System.Collections.Generic;

public class AutoLoan : LoanAccount
{
    // Attributes
    private string _make;
    private string _model;
    private int _year;
    private string _titleType;
    private string _address;

    // Constructor
    public AutoLoan(string make, string model, int year, string titleType, string loanName, bool isClosed, int term, double interestRate, decimal loanAmount, decimal monthlyPayment, decimal balance, int dueDate, DateTime openDate, DateTime? closeDate, List<Transaction> transactions) : base(loanName, isClosed, term, interestRate, loanAmount, monthlyPayment, balance, dueDate, openDate, closeDate, transactions)
    {
        _make = make;
        _model = model;
        _year = year;
        _titleType = titleType;
        _loanName = loanName;
        _isClosed = isClosed;
        _term = term;
        _interestRate = interestRate;
        _loanAmount = loanAmount;
        _monthlyPayment = monthlyPayment;
        _balance = balance;
        _dueDate = dueDate;
        _openDate = openDate;
        _closeDate = closeDate;
        _transactions = transactions;
        _address = null;
    }

    // Methods
    public override void CloseAccount()
    {
        if (_balance > 0)
        {
            Console.WriteLine("\nYou must pay off the loan before closing the account.");
            Console.Write("\nWould you like to make a full payment now? (y/n)");
            string response = Console.ReadLine();

            if (response == "y")
            {
                _balance = 0;
                _isClosed = true;
                _closeDate = DateTime.Now;
                _transactions.Add(new Transaction(_loanAmount, "Payment", DateTime.Now));
                Console.WriteLine($"\nPayment of ${_loanAmount:F2} made on {DateTime.Now}");
               
                Console.Write($"\nEnter the address where the title should be sent: ");
                _address = Console.ReadLine();
                
                Console.WriteLine($"\n{_loanName} has been closed. The title will be sent to {_address}.");
                Console.Write("\nPress any key to return to the Loan Accounts menu: ");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("\nYou must pay off the loan before closing the account.");
                Console.Write("\nPress any key to return to the Loan Accounts menu: ");
                Console.ReadKey();
                return;
            }
        }
        else 
        {
            _isClosed = true;
            _closeDate = DateTime.Now;

            Console.Write($"\nEnter the address where the title should be sent: ");
            _address = Console.ReadLine();

            Console.WriteLine($"\n{_loanName} has been closed. The title will be sent to {_address}.");
            Console.Write("\nPress any key to return to the Loan Accounts menu: ");
            Console.ReadKey();
        }
    }

    public override void DisplayAccountInfo()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Loan Name: {_loanName}");
        Console.WriteLine($"Make: {_make}");
        Console.WriteLine($"Model: {_model}");
        Console.WriteLine($"Year: {_year}");
        Console.WriteLine($"Title Type: {_titleType}");
        Console.WriteLine($"Loan Amount: ${_loanAmount:F2}");
        Console.WriteLine($"Interest Rate: {_interestRate * 100:F2}%");
        Console.WriteLine($"Term: {_term} years");
        Console.WriteLine($"Monthly Payment: ${_monthlyPayment:F2}");
        Console.WriteLine($"Balance: ${_balance:F2}");
        Console.WriteLine($"Due Date: {_dueDate}");
        Console.WriteLine($"Open Date: {_openDate}");
        if (_isClosed)
        {
            Console.WriteLine($"Close Date: {_closeDate}");
        }
        Console.WriteLine("---------------------------------");
    }
}