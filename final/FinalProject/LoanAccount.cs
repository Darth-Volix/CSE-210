using System;
using System.Collections.Generic;

public abstract class LoanAccount 
{
    // Attributes
    protected string _loanName;
    protected bool _isClosed;
    protected int _term;
    protected double _interestRate;
    protected decimal _loanAmount;
    protected decimal _monthlyPayment;
    protected decimal _balance;
    protected int _dueDate;
    protected DateTime _openDate;
    protected DateTime? _closeDate;
    protected List<Transaction> _transactions;

    // Constructor
    public LoanAccount(string loanName, bool isClosed, int term, double interestRate, decimal loanAmount, decimal monthlyPayment, decimal balance, int dueDate, DateTime openDate, DateTime? closeDate, List<Transaction> transactions)
    {
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
    }

    // Methods
    public static LoanAccount OpenAccount()
    {
        string accountType = "";
        
        while (accountType != "1" && accountType != "2")
        {
            Console.WriteLine("\nSelect the type of loan account you would like to open:");
            Console.WriteLine("     1. Auto Loan");
            Console.WriteLine("     2. Personal Loan");
            Console.Write("Enter your selection (1 or 2): ");
            accountType = Console.ReadLine();

            if (accountType != "1" && accountType != "2")
            {
                Console.WriteLine("\nInvalid selection. Please try again.");
            }
        }
        
        if (accountType == "1")
        {
            Console.Write("\nEnter the model year of the vehicle: ");
            int _year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the make of the vehicle: ");
            string _make = Console.ReadLine();
            Console.Write("Enter the model of the vehicle: ");
            string _model = Console.ReadLine();
            Console.Write("Enter the title type (Clean, Salvaged, RB/RS, etc): ");
            string _titleType = Console.ReadLine();
            string _loanName = $"{_year} {_make} {_model}";
            Console.Write("Enter the loan amount: $");
            decimal _loanAmount = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter the interest rate in format 0.XX (18% = 0.18): ");
            double _interestRate = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the term in years: ");
            int _term = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the due date (1-28): ");
            int _dueDate = Convert.ToInt32(Console.ReadLine());
            DateTime _openDate = DateTime.Now;
            DateTime? _closeDate = null;
            bool _isClosed = false;
            decimal _balance = _loanAmount;
            List<Transaction> _transactions = new List<Transaction>();
            decimal _monthlyPayment = CalculateMonthlyPayment(_term, _interestRate, _loanAmount);

            Transaction transaction = new Transaction(_loanAmount, "Loan Funding", DateTime.Now);
            _transactions.Add(transaction);
            
            AutoLoan autoLoan = new AutoLoan(_make, _model, _year, _titleType, _loanName, _isClosed, _term, _interestRate, _loanAmount, _monthlyPayment, _balance, _dueDate, _openDate, _closeDate, _transactions);
            
            return autoLoan;
        }
        else if (accountType == "2")
        {
            Console.Write("\nEnter the purpose of the loan: ");
            string _loanPurpose = Console.ReadLine();
            Console.Write("Enter the loan amount: $");
            decimal _loanAmount = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter the interest rate in format 0.XX (18% = 0.18): ");
            double _interestRate = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the term in years: ");
            int _term = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the due date (1-28): ");
            int _dueDate = Convert.ToInt32(Console.ReadLine());
            string _loanName = "Personal Loan";
            DateTime _openDate = DateTime.Now;
            DateTime? _closeDate = null;
            bool _isClosed = false;
            decimal _balance = _loanAmount;
            List<Transaction> _transactions = new List<Transaction>();
            decimal _monthlyPayment = CalculateMonthlyPayment(_term, _interestRate, _loanAmount);

            Transaction transaction = new Transaction(_loanAmount, "Loan Funding", DateTime.Now);
            _transactions.Add(transaction);
            
            PersonalLoan personalLoan = new PersonalLoan(_loanPurpose, _loanName, _isClosed, _term, _interestRate, _loanAmount, _monthlyPayment, _balance, _dueDate, _openDate, _closeDate, _transactions);
            
            return personalLoan;
        }
        // This return statement is unreachable, but it is necessary to avoid a compilation error.
        return null;
    }
    
    public virtual void CloseAccount()
    {
        if (_balance > 0)
        {
            Console.WriteLine("\nYou must pay off the loan before closing the account.");
            Console.Write("\nWould you like to make a full payment now? (Y/N): ");
            string response = Console.ReadLine().ToUpper();

            if (response == "Y")
            {
                _balance = 0;
                _isClosed = true;
                _closeDate = DateTime.Now;
                _transactions.Add(new Transaction(_loanAmount, "Payment", DateTime.Now));
                Console.WriteLine($"\nPayment of ${_loanAmount:F2} made on {DateTime.Now}");
                
                Console.WriteLine($"\n{_loanName} has been closed.");
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

            Console.WriteLine($"\n{_loanName} has been closed.");
            Console.Write("\nPress any key to return to the Loan Accounts menu: ");
            Console.ReadKey();
        }
    }

    public bool IsAlreadyClosed()
    {
        return _isClosed;
    }

    public static decimal CalculateMonthlyPayment(int _term, double _interestRate, decimal _loanAmount)
    {
        int numberOfPayments = _term * 12;
        double monthlyInterestRate = _interestRate / 12;
        double monthlyPayment = ((double)_loanAmount * monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, numberOfPayments)) / (Math.Pow(1 + monthlyInterestRate, numberOfPayments) - 1);
    
        return (decimal)monthlyPayment;
    }

    public void TenDayPayoff()
    {
        double dailyInterestRate = CalculateDailyInterestRate();
        decimal tenDayInterest = _balance * (decimal)dailyInterestRate * 10;
        decimal tenDayPayoff = _balance + tenDayInterest;

        Console.WriteLine($"\nTen day payoff amount: ${tenDayPayoff:F2} if paid by {DateTime.Now.AddDays(10):MM/dd/yyyy}");
    }

    public double CalculateDailyInterestRate()
    {
        double dailyInterestRate = _interestRate / 365;
       
        return dailyInterestRate;
    }

    public void MakePayment()
    {
        DateTime currentDate = DateTime.Now;
        int currentDay = currentDate.Day;

        if (currentDay == _dueDate)
        {
            _balance -= _monthlyPayment;
            _transactions.Add(new Transaction(_monthlyPayment, "Payment", DateTime.Now));
            Console.WriteLine($"\nPayment of ${_monthlyPayment:F2} made on {DateTime.Now}");

            if (_balance == 0)
            {
                Console.WriteLine("\nLoan paid in full.");
                this.CloseAccount();
            }
        }
        else
        {
            Console.WriteLine("\nPayment not made. Today is not the due date.");
            Console.Write("\nPress any key to return to the Loan Accounts menu: ");
            Console.ReadKey();
        }
    }

    public void DisplayTransactions()
    {
        Console.WriteLine("\n---------------------------------");
        Console.WriteLine($"Transactions for {_loanName}");
        Console.WriteLine("---------------------------------");
        
        foreach (Transaction transaction in _transactions)
        {
            transaction.DisplayTransaction();
        }
    }

    public abstract void DisplayAccountInfo();
}