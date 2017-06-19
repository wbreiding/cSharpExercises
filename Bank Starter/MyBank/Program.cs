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
        private int overDraft;

        public int AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }

        public int OverDraft
        {
            get
            {
                return overDraft;
            }
            set 
            {
                overDraft = value;
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
                textOut.WriteLine(overDraft);
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
            int overDraft = int.Parse(textIn.ReadLine());
            return new Account(nameText, addressText, balanceValue, accountNumber, overDraft);
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

        public Account(string inName, string inAddress, decimal inBalance, int inAccountNumber, int overDraft=0)
        {
            name = inName;
            address = inAddress;
            balance = inBalance;
            accountNumber = inAccountNumber;
            this.overDraft = overDraft;
        }

        public override string ToString() 
        {
            string output = $"Name: {this.name}\n Address: {this.address}\n Balance: {this.balance}\n Account Number: {this.accountNumber}\n OverDraft: {this.overDraft}";
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
                            if (overDraft == p.overDraft)
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
                textIn = new StreamReader(File.Open(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite));
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
                        //TODO: check for matching account number first
                        if (a.Equals(p.FindAccount(a.AccountNumber))) 
                            {
                                continue;
                            }
                            else
                            {
                                return false;
                            }
                    }
                    return true;
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

            Bank testBank = new Bank("Test Bank");
            string[] firstNames = new string[] { "Rob", "Fred", "Jim", "Ethel", "Nigel", "Simon", "Gloria", "Evadne","Maxwell" };
            string[] surnames = new string[] { "Bloggs", "Smith", "Jones", "Thompson", "Wooster", "Brown", "Acaster", "Berry", "Ackerman" };
            Random r = new Random(1);

            string[] names = new string[80];
            Account[] accounts = new Account[80];
            int j = 0;

            foreach (string surname in surnames)
               {
               foreach (string firstName in firstNames)
                {
                    if (j<80) names[j] = $"{firstName} {surname}";
                    j++;
                }
            }
            j=0;
            for (int i=0; i<80; i++) {
                if (names[i] == "") j=0;
                accounts[i] = testBank.AddAccount(names[j], "Some Address", r.Next(-100,10000));
                //Console.WriteLine($"{accounts[i]}");
                j++;
            }

            testBank.Save("test.txt");

            // TODO: Need to compare the loaded bank with the original to make sure they are the same

            Bank loadedBank = Bank.Load("test.txt");

            if (loadedBank.Equals(testBank)) Console.WriteLine("Banks match!");
        }
    }
}
