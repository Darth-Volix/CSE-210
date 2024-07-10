using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\nWelcome to the Bank Account Simulator!");
       
        AccountManager accountManager = new AccountManager();

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("     1. Open a deposit account");
            Console.WriteLine("     2. Open a loan account");
            Console.WriteLine("     3. Display deposit accounts");
            Console.WriteLine("     4. Display loan accounts");
            Console.WriteLine("     5. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    accountManager.OpenDepositAccount();
                    break;
                case "2":
                    Console.Clear();
                    accountManager.OpenLoanAccount();
                    break;
                case "3":
                    Console.Clear();
                    accountManager.DisplayDepositAccounts();
                    break;
                case "4":
                    Console.Clear();
                    accountManager.DisplayLoanAccounts();
                    break;
                case "5":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("\nInvalid selection. Please try again.");
                    break;
            }
        }
    }
}