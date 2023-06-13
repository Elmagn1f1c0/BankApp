using System;

namespace Bank
{

    //This class handles the current account withdrawals and deposits
    //This is a child of the Account class and inherits some of the properties of the parent class 
    public class Current : Account
    {
        public Current() : base()
        {
        }


        //Deposit to current account method
        public override bool deposit(double amount)
        {
            this.amount = amount;
            this.balance = balance + amount;
            Console.WriteLine("Your funds has been deposited successfully, New Balance is: " + balance);
            return true;
        }


        ////Withdraw from current account method
        public override bool withdraw(double amount)
        {
            this.amount = amount;     //set amount to withdraw equals to amount variable
            
            if (amount > balance)   //if set amount(amount to withdraw is greater than account balance)
            {
                Console.WriteLine("You don't have sufficient amount of money in your account!");
                return false;
            }
            else if (balance - amount < 0)   //if the available balance minus the amount will equate to a negative value
            {
                Console.WriteLine("You don't have sufficient amount of money in your account");
                return false;
            }
            else
            {
                //if available balance is more than the amount to withdraw
                this.balance = balance - amount;
                Console.WriteLine("Your withdrawal was successful. New account Balance is: " + balance);
                return true;
            }
        }

       public override bool transfer(double amount)
        {
            this.amount = amount;     //set amount to withdraw equals to amount variable

            if (amount > balance)   //if set amount(amount to withdraw is greater than account balance)
            {
               // Console.WriteLine("You don't have sufficient amount of money in your account!");
                return false;
            }
            else
            {
                //if available balance is more than the amount to withdraw
                this.balance = balance - amount;
                Console.WriteLine("Your transfer was successful");
                return true;
            }
        }
    }
}
