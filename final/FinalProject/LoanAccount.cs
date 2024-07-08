using System;
using System.Collections.Generic;

public abstract class LoanAccount 
{
    // Attributes
    protected string _loanName;
    protected bool _isClosed;
    protected int _term;
    protected decimal _interestRate;
    protected decimal _loanAmount;
    protected decimal _monthlyPayment;
    protected decimal _balance;
    protected int _dueDate;
    protected DateTime _openDate;
    protected DateTime? _closeDate;
    protected List<Transaction> _transactions;

    // Methods
    public static LoanAccount OpenAccount();
    {
        while (accountType != "1" || accountType != "2")
        {
            Console.WriteLine("\nSelect the type of loan account you would like to open:");
            Console.WriteLine("     1. Auto Loan");
            Console.WriteLine("     2. Personal Loan");
            Console.Write("Enter your selection: ");
            accountType = Console.ReadLine();

            switch (accountType)
            {
                case "1":
                    Console.Write("Enter the make of the vehicle: ");
                    _make = Console.ReadLine();
                    Console.Write("Enter the model of the vehicle: ");
                    _model = Console.ReadLine();
                    Console.Write("Enter the year of the vehicle: ");
                    _year = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the title type (Clean, Salvaged, RB/RS, etc): ");
                    _titleType = Console.ReadLine();
                    _loanName = $"{_year} {_make} {_model}";
                    Console.Write("Enter the loan amount: $");
                    _loanAmount = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Enter the interest rate in format 0.XX (18% = 0.18): ");
                    _interestRate = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Enter the term in years: ");
                    _term = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the due date (1-28): ");
                    _dueDate = Convert.ToInt32(Console.ReadLine());
                    _openDate = DateTime.Now;
                    _closeDate = null;
                    _isClosed = false;
                    _balance = _loanAmount;
                    _transactions = new List<Transaction>();
                    _monthlyPayment = CalculateMonthlyPayment();
                    
                    AutoLoan autoLoan = new AutoLoan(_make, _model, _year, _titleType, _loanName, _isClosed, _term, _interestRate, _loanAmount, _monthlyPayment, _balance, _dueDate, _openDate, _closeDate, _transactions);
                    
                    return autoLoan;
                    break;
                
                default:
            }
        }
    }
    
    public virtual void CloseAccount()
    {
        _isClosed = true;
        _closeDate = DateTime.Now;
    }

    public static decimal CalculateMonthlyPayment()
    {
        int numberOfPayments = _term * 12;
        decimal monthlyInterestRate = _interestRate / 12;
        decimal monthlyPayment = (_loanAmount * monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, numberOfPayments)) / (Math.Pow(1 + monthlyInterestRate, numberOfPayments) - 1);

        return monthlyPayment;
    }

    public static decimal TenDayPayoff()
    {
        decimal dailyInterestRate = CalculateDailyInterestRate(_interestRate);
        decimal tenDayInterest = _balance * dailyInterestRate * 10;
        decimal tenDayPayoff = _balance + tenDayInterest;

        return tenDayPayoff;
    }

    public static decimal CalculateDailyInterestRate()
    {
        decimal dailyInterestRate = _interestRate / 365;
       
        return dailyInterestRate;
    }

    public static void MakePayment()
    {
        DateTime currentDate = DateTime.Now;
        int currentDay = currentDate.Day;

        if (currentDay == _dueDate)
        {
            _balance -= _monthlyPayment;
            _transactions.Add(new Transaction(_monthlyPayment, "Payment", DateTime.Now));
            Console.WriteLine($"\nPayment of ${_monthlyPayment} made on {DateTime.Now}");

            if (_balance == 0)
            {
                Console.WriteLine("\nLoan paid in full.");
                this.CloseAccount();
            }
        }
        else
        {
            Console.WriteLine("\nPayment not made. Today is not the due date.");
        }
    }
}