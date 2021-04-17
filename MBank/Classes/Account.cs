using System;

namespace MBank
{
    public class Account
    {

        private AccountType AccountType { get; set; }
        private double Balance { get; set; }
        private double Credit { get; set; }
        private string Name { get; set; }

        public Account(AccountType accountType, double balance, double credit, string name)
        {
            this.AccountType = accountType;
            this.Balance = balance;
            this.Credit = credit;
            this.Name = name;
        }

        public bool Withdraw(double withdrawValue)
        {
            if (this.Balance - withdrawValue < (this.Credit * -1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }

            this.Balance -= withdrawValue;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Name, this.Balance);
            return true;
        }

        public void Deposit(double depositValue)
        {
            this.Balance += depositValue;

            Console.WriteLine("Current {0} account balance is {1}", this.Name, this.Balance);
        }

        public void Transfer(double transferValue, Account contaDestino)
        {
            if (this.Withdraw(transferValue))
            {
                contaDestino.Deposit(transferValue);
            }
        }

        public override string ToString()
        {
            string default_text = " ";
            default_text += "Account Type " + this.AccountType + " | ";
            default_text += "Name " + this.Name + " | ";
            default_text += "Balance " + this.Balance + " | ";
            default_text += "Credit " + this.Credit + " | ";

            return default_text;
        }

    }
}