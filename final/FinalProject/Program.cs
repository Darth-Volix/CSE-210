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
            Console.WriteLine("\nMain Menu");
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
                    Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    accountManager.OpenLoanAccount();
                    Console.Clear();
                    break;
                case "3":
                    string depositChoice = "";

                    while (depositChoice != "5")
                    {
                        Console.Clear();
                        accountManager.DisplayDepositAccounts();

                        Console.WriteLine("\nDepisit Account Options:");
                        Console.WriteLine("     1. Make a deposit");
                        Console.WriteLine("     2. Make a withdrawal");
                        Console.WriteLine("     3. Display Transactions");
                        Console.WriteLine("     4. Add Interest");
                        Console.WriteLine("     5. Reset Withdrawals");
                        Console.WriteLine("     6. Close Account");
                        Console.WriteLine("     7. Return to main menu");
                        Console.Write("Enter your choice: ");
                        depositChoice = Console.ReadLine();

                        switch (depositChoice)
                        {
                            case "1":
                                Console.Clear();
                                accountManager.MakeDeposit();
                                break;
                            case "2":
                                Console.Clear();
                                accountManager.MakeWithdrawal();
                                break;
                            case "3":
                                Console.Clear();
                                accountManager.DisplayDepositTransactions();
                                break;
                            case "4":
                                Console.Clear();
                                accountManager.AddMonthlyInterest();
                                break;
                            case "5":
                                Console.Clear();
                                accountManager.ResetSavingsWithdrawals();
                                break;
                            case "6":
                                Console.Clear();
                                accountManager.CloseDepositAccount();
                                break;
                            case "7":
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("\nInvalid selection. Please try again.");
                                break;
                        }
                    }
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