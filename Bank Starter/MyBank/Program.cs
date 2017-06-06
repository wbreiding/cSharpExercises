using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// Sample bank code for 08120 Week 31 Lab work
// Manages account and bank details
// Rob Miles February 2014

namespace Bank
{
    class Account
    {
        private string name;
        private string address;
        private decimal balance;
        private int accountNumber;

        public int AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }

        public bool Save(TextWriter textOut)
        {
            try
            {
                textOut.WriteLine(accountNumber);
                textOut.WriteLine(name);
                textOut.WriteLine(address);
                textOut.WriteLine(balance);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void Save(string filename)
        {
            TextWriter textOut = null;
            try
            {
                textOut = new StreamWriter(File.OpenWrite(filename));
                Save(textOut);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (textOut != null) textOut.Dispose();
            }
        }

        public static Account Load(TextReader textIn)
        {
            int accountNumber = int.Parse(textIn.ReadLine());
            string nameText = textIn.ReadLine();
            string addressText = textIn.ReadLine();
            string balanceText = textIn.ReadLine();
            decimal balanceValue = decimal.Parse(balanceText);
            return new Account(nameText, addressText, balanceValue, accountNumber);
        }

        public static Account Load(string filename)
        {
            Account result;
            System.IO.TextReader textIn = null;
            try
            {
                textIn = new StreamReader(File.OpenWrite(filename));
                result = Load(textIn);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (textIn != null) textIn.Dispose();
            }
            return result;
        }

        public Account(string inName, string inAddress, decimal inBalance, int inAccountNumber)
        {
            name = inName;
            address = inAddress;
            balance = inBalance;
            accountNumber = inAccountNumber;
        }

        public override string ToString() 
        {
            string output = $"Name: {this.name}\n Address: {this.address}\n Balance: {this.balance}\n Account Number: {this.accountNumber}";
            return output;
        }

        public override bool Equals (object obj)
        {
            Account p = (Account)obj;
            if (name == p.name) {
                if (address == p.address)
                {
                    if (balance == p.balance)
                    {
                        if (accountNumber == p.accountNumber)
                        {
                            return true;
                        } else 
                        {
                            return false;
                        }
                    } else
                    {
                        return false;
                    }
                } else 
                {
                    return false;
                }
            } else {
                return false;
            }
        }

    }

    class Bank
    {
        // TODO: Need to add a ToString method and an Equals method to this class

        private string bankName;

        public string BankName
        {
            get
            {
                return bankName;
            }
        }

        private List<Account> bankAccounts;
        static int newAccountNumber = 1;

        public Bank(string newBankName)
        {
            bankName = newBankName;
            bankAccounts = new List<Account>();
        }

        public Account AddAccount(string inName, string inAddress, decimal inBalance)
        {
            Account result = new Account(inName, inAddress, inBalance, newAccountNumber);
            bankAccounts.Add(result);
            newAccountNumber = newAccountNumber + 1;
            return result;
        }
        public Account FindAccount(int searchNumber)
        {
            foreach (Account a in bankAccounts)
            {
                if (a.AccountNumber == searchNumber)
                    return a;
            }
            return null;
        }

        public bool DeleteAccount(int deleteNumber)
        {
            Account del = FindAccount(deleteNumber);
            if (del != null)
            {
                bankAccounts.Remove(del);
                return true;
            }
            return false;
        }

        public void Save(TextWriter textOut)
        {
            textOut.WriteLine(bankName);
            textOut.WriteLine(newAccountNumber);
            textOut.WriteLine(bankAccounts.Count);
            foreach (Account a in bankAccounts)
            {
                if (a != null)
                {
                    a.Save(textOut);
                }
            }
        }

        public void Save(string filename)
        {
            TextWriter textOut = null;

            try
            {
                textOut = new StreamWriter(File.OpenWrite(filename));
                Save(textOut);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (textOut != null) textOut.Dispose();
            }
        }

        public static Bank Load(TextReader textIn)
        {
            string bankName = textIn.ReadLine();
            Bank result = new Bank(bankName);
            newAccountNumber = int.Parse(textIn.ReadLine());
            int numberOfAccounts = int.Parse(textIn.ReadLine());
            for (int i = 0; i < numberOfAccounts; i++)
            {
                Account a = Account.Load(textIn);
                result.bankAccounts.Add(a);
            }
            return result;
        }

        public static Bank Load(string filename)
        {
            Bank result;
            TextReader textIn = null;
            try
            {
                textIn = new StreamReader(File.OpenWrite(filename));
                result = Load(textIn);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (textIn != null) textIn.Dispose();
            }
            return result;
        }

        public override string ToString() 
        {
            string output = $"Bank Name: {this.bankName}\nNumber of Accounts in the bank: {this.bankAccounts.Count}";
            return output;
        }

        public override bool Equals(object obj) 
        {
            Bank p = (Bank)obj;
            if (bankName == p.bankName)
            {
                if (bankAccounts.Count == p.bankAccounts.Count)
                {
                    foreach (Account a in bankAccounts) 
                    {
                        if (a.accountNumber == p.bankAccounts.FindAccount(a.accountNumber).accountNumber) {
                            if (a.name == p.bankAccounts.FindAccount(a.accountNumber).name) {
                                if (a.address == p.bankAccounts.FindAccount(a.accountNumber).address) 
                                {
                                    if (a.balance = p.bankAccounts.FindAccount(a.accountNumber).balance)
                                    {
                                        return true;
                                    }
                                } else 
                                {
                                    return false;
                                }
                            } else 
                            {
                                return false;
                            }
                        } else 
                        {
                            return false;
                        }
                    }
                } else
                {
                    return false;
                }
            } else
            {
                return false;
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Bank friendlyBank = new Bank("The Friendly Bank");

            // TODO: Need to add some code that will create a large number of "fake" accounts

            Account rob = friendlyBank.AddAccount("Rob", "Hull", 100);
            Console.WriteLine("Account created with account number: " + rob.AccountNumber);
            friendlyBank.Save("test.txt");

             Account a = friendlyBank.AddAccount("Rob", "Hull", 100);
             Account b = friendlyBank.AddAccount("Rob", "Hull", 100);
            if (a.Equals(b))
            {
                Console.WriteLine("Test passed");
            }
            else
            {
                Console.WriteLine("Test failed");
            }

            // TODO: Need to compare the loaded bank with the original to make sure they are the same

            //Bank loadedBank = Bank.Load("test.txt");
        }
    }
}
