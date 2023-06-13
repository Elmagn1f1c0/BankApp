using System;

namespace Bank
{
    public class Savings : Account
    {
        //This class handles the Savings account withdrawals and deposits
        //This savings class is a child of the Account class and inherits some of the properties of the parent class

        public double minBalance = 1000;  //minimum required account balance
        private double dailyWithdrawLimit = 20000;  //withdrawal limit
        
      
        public Savings() : base()
        {
        }
        public Savings(string name, DateOfBirth DOB, string nominee, double balance) : base(name, DOB, nominee, balance)
        {

        }
       
        public override bool deposit(double amount)
        {
            this.amount = amount;
            this.balance = balance + amount;
            Console.WriteLine("Your funds was deposited successfully. New account Balance is: " + balance);
            return true;
        }
        public override bool withdraw(double amount)
        {
            this.amount = amount;

            if (amount > balance)
            {
                Console.WriteLine("You don't have sufficient amount of money in your account!");
                return false;
            }
            else if (amount > dailyWithdrawLimit)
            {
                Console.WriteLine("You cannot withdraw more than a daily amount of 20000.");
                return false;
            } else if (balance - amount < 1000)
            {
                Console.WriteLine("Sorry - You need a minimum of 1000 to keep your account open");
                return false;
            }
            else
            {
                this.balance = balance - amount;
                Console.WriteLine("Your withdrawal was successful. New account Balance is: " + balance);
                return true;
            }
        }

        public override bool transfer(double amount)
        {
            this.amount = amount;

            if (amount > balance)
            {
                //Console.WriteLine("You don't have sufficient amount of money in your account!");
                return false;
            }
 
            else
            {
                this.balance = balance - amount;
                Console.WriteLine("Your Transfer was successful");
                return true;
            }
        }
    }
}
