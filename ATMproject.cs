using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{

    internal class Program
    {
        class Account
        {
            public string Name { get; set; }
            public double Balance { get; set; }
            public int Pin { get; set; }

            public Account(string name, double balance, int pin)
            {
                Name = name;
                Balance = balance;
                Pin = pin;
            }
        }
        static void Main(string[] args)
        {
            int choice;
            int searchAccNo;
            double da;
            double wa;
            string continueChoice;
            Dictionary<int, Account> accounts = new Dictionary<int, Account>();
            accounts[1001] = new Account("Alice", 5000.00, 1234);
            accounts[1002] = new Account("Bob", 7000.50, 5678);
            accounts[1003] = new Account("Charlie", 3000.75, 9876);
            accounts[1004] = new Account("John", 4200.75, 4559);
            
            do
            {
                Console.WriteLine("-----Welcome To  The ATM----- \n Enter Your Choice.\n 1.Create New Account\n 2.Check Balance\n 3.Deposit\n 4.Withdraw\n 5.Display All Accounts.\n 6.Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                            Console.WriteLine("Enter New Account Number: ");
                            int newAccNo = Convert.ToInt32(Console.ReadLine());

                            if (accounts.ContainsKey(newAccNo))
                            {
                                Console.WriteLine("Account Number already exists! Try Another.");
                            }
                            else
                            {
                                Console.WriteLine("Create Account Holder Name: ");
                                string newName = Console.ReadLine();

                                Console.WriteLine("Add Initial Balance: ");
                                double newBalance = Convert.ToDouble(Console.ReadLine());

                                Console.WriteLine("Create  PIN: ");
                                int newPin = Convert.ToInt32(Console.ReadLine());
                                accounts[newAccNo] = new Account(newName, newBalance, newPin);
                                Console.WriteLine("Account Created Successfully\n Thank You for Choosing Our ATM");

                            }
                             break;

                    case 2:
                            Console.WriteLine("Enter the Account Number");
                            searchAccNo = Convert.ToInt32(Console.ReadLine());

                            if (accounts.ContainsKey(searchAccNo))
                            {
                                Console.WriteLine("Enter The Pin:");
                                int epin = Convert.ToInt32(Console.ReadLine());
                                Account foundAccount = accounts[searchAccNo];

                                if (epin == foundAccount.Pin)
                                {

                                    Console.WriteLine($"User Name: {foundAccount.Name} \n  Balance: {foundAccount.Balance}");
                                }
                                else
                                {
                                    Console.WriteLine("Incorrect Pin");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Account Not Found.");
                            }
                            break;
                    case 3:
                            Console.WriteLine("Enter the Account Number");
                            searchAccNo = Convert.ToInt32(Console.ReadLine());
                            if (accounts.ContainsKey(searchAccNo))
                            {
                                Console.WriteLine("Enter The Pin:");
                                int epin= Convert.ToInt32(Console.ReadLine());
                                Account foundAccount = accounts[searchAccNo];
                                if (epin == foundAccount.Pin)
                                {
                                    Console.WriteLine("-----Enter the amount to Deposit-----");
                                    da = Convert.ToDouble(Console.ReadLine());
                                    foundAccount.Balance += da;
                                    Console.WriteLine("Amount After Deposit");
                                    Console.WriteLine($"\n Account Name: {foundAccount.Name} \n -> Balance: {foundAccount.Balance}");
                                }
                                else
                                {
                                    Console.WriteLine("Incorrect Pin \n --Enter Valid Pin--");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Account Not Found!!.");
                            }
                            break;
                    case 4:
                            Console.WriteLine("Enter the Account Number");
                            searchAccNo = Convert.ToInt32(Console.ReadLine());
                            if (accounts.ContainsKey(searchAccNo))
                            {
                                Console.WriteLine("Enter The Pin:");
                                int epin = Convert.ToInt32(Console.ReadLine());
                                Account foundAccount = accounts[searchAccNo];
                            if (epin == foundAccount.Pin)
                            {
                                if (foundAccount.Balance == null)
                                {
                                    Console.WriteLine("No Balance in the Account");
                                }

                                else
                                {
                                    Console.WriteLine("-----Enter the amount to Withdraw-----");
                                    wa = Convert.ToDouble(Console.ReadLine());
                                    if(foundAccount.Balance<wa)
                                    {
                                        Console.WriteLine("Cannot Withdraw due to Low Balance");
                                    }
                                    else
                                    {
                                        foundAccount.Balance -= wa;
                                        Console.WriteLine("Amount After Withdraw");
                                        Console.WriteLine($"\n Account Number: {foundAccount.Name} \n -> Balance: {foundAccount.Balance}");

                                    }
                                       

                                }
                            }
                            }
                            else
                            {
                                Console.WriteLine("Account Not Found!!.");
                            }
                            break;
                    case 5:// Display all accounts
                            Console.WriteLine("    Account Number                User Name                   Balance                 PIN            ");
                            foreach (var pair in accounts)
                            {
                                Console.WriteLine($"Account No: {pair.Key}  ,   Name: {pair.Value.Name}  ,   Balance: {pair.Value.Balance}     ,      PIN: {pair.Value.Pin}");
                            }
                            break;

                    default: Console.WriteLine("Please select correct Choice");
                             break;
                }
                Console.Write("\nDo you want to continue? (y/n): ");
                continueChoice = Console.ReadLine().Trim().ToLower();

            }while (continueChoice == "y") ;

          
    }
    }
}
