using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Debit : Account
    {
        public double maxBalance = 1000000;
        private double dailyTransLimit = 20000;

        public Debit() : base()
        {

        }

        public Debit(string name, DateOfBirth DOB, string nominee, double balance) : base(name, DOB, nominee, balance)
        {

        }

        public override bool deposit(double amount)
        {
            this.amount = amount;
           if (amount > maxBalance)
            {
                Console.WriteLine("You can not deposit more than 1000000!");
                return false;
            }
            else
            {
               
                this.balance = balance + amount;
                Console.WriteLine("Your fund was deposited successfully, New Balance is: "+balance);
                return true;
            }
        }

        public override bool withdraw(double amount)
        {
            this.amount = amount;
            
            if (amount > dailyTransLimit)
            {
                Console.WriteLine("You can not withdraw more than 20000.");
                return false;

            }
            else if(amount > maxBalance)
            {
                Console.WriteLine("You can not withdraw that amount of money!");
                return false;
            }else if(balance - amount < 0)
            {
                Console.WriteLine("You don't have sufficient amount of money in your account");
                return false;
            }
            else
            {
                this.balance = balance - amount;
                Console.WriteLine("You withdrawal was successful. New Account Balance is: " + balance);
                return true;
            }
        }

        public override bool transfer(double amount)
        {
            this.amount = amount;

            if (amount > dailyTransLimit)
            {
                Console.WriteLine("You can not transfer more than 20000.");
                return false;

            }
            else if (amount > maxBalance)
            {
                Console.WriteLine("You can not transfer that amount of money!");
                return false;
            }
            else if (balance - amount < 0)
            {
                Console.WriteLine("You don't have sufficient amount of money in your account");
                return false;
            }
            else
            {
                this.balance = balance - amount;
                Console.WriteLine("You transfer was successful. New Account Balance is: " + balance);
                return true;
            }
        }


    }
}
