using System;
using System.Collections.Generic;

namespace MBank
{
    class Program
    {

        static List<Account> listAccounts = new List<Account>();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListAccount();
                        break;
                    case "2":
                        InsertAccount();
                        break;
                    case "3":
                        Transfer();
                        break;
                    case "4":
                        Withdraw();
                        break;
                    case "5":
                        Deposit();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();


                }

                userOption = GetUserOption();
            }

            Console.WriteLine("Thank you for use our services!");
            Console.ReadLine();
        }

        private static void ListAccount()
        {
            Console.WriteLine("Account List");

            if (listAccounts.Count == 0)
            {
                Console.WriteLine("There is no registered accounts yet.");
                return;
            }

            for (int i = 0; i < listAccounts.Count; i++)
            {
                Account account = listAccounts[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(account);
            }

        }

        private static void InsertAccount()
        {
            Console.WriteLine("Insert New Account");

            Console.Write("Write 1 for Personal or 2 for Business");
            int accountTypeInput = int.Parse(Console.ReadLine());

            Console.Write("Enter the client name: ");
            string nameInput = Console.ReadLine();

            Console.Write("Initial balance: ");
            double balanceInput = double.Parse(Console.ReadLine());

            Console.Write("Enter the credit: ");
            double creditInput = double.Parse(Console.ReadLine());

            Account newAccount = new Account(accountType: (AccountType)accountTypeInput,
                                                balance: balanceInput,
                                                credit: creditInput,
                                                name: nameInput);
            listAccounts.Add(newAccount);
        }



        private static string GetUserOption()
        {
            Console.WriteLine("");
            Console.WriteLine("Welcome to MBank!");
            Console.WriteLine("Please, choose the option you wish for");

            Console.WriteLine("1 - List Accounts");
            Console.WriteLine("2- Insert New Account");
            Console.WriteLine("3 - Transfer");
            Console.WriteLine("4 - Withdraw");
            Console.WriteLine("5 - Deposit");
            Console.WriteLine("C - Clear Screen");
            Console.WriteLine("X - Exit!");

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
            
        }

        private static void Withdraw()
        {
            Console.Write("Enter the account number: ");
            int accountNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter the desirable value to withdraw: ");
            double withdrawValue = double.Parse(Console.ReadLine());

            listAccounts[accountNumber].Withdraw(withdrawValue);
        }

        private static void Deposit()
        {
            Console.Write("Enter the account number: ");
            int accountNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter the desirable value to deposit: ");
            double depositValue = double.Parse(Console.ReadLine());

            listAccounts[accountNumber].Deposit(depositValue);
        }

        private static void Transfer()
        {
            Console.Write("Enter the account number that will transfer the money: ");
            int numberAccountFrom = int.Parse(Console.ReadLine());

            Console.Write("Enter the account number that will receive the money: ");
            int numberAccountTo = int.Parse(Console.ReadLine());

            Console.Write("Enter the value to be transfered: ");
            double transferValue = double.Parse(Console.ReadLine());

            listAccounts[numberAccountFrom].Transfer(transferValue, listAccounts[numberAccountTo]);
        }


        
    }
}
