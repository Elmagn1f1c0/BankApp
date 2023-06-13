using System;

namespace Bank
{

    public class DateOfBirth
    {
        //user's date of birth collection
        public int day;
        public int month;
        public int year;
        //Bank bn = new Bank();
        public void set(int d, int m, int y)
        {
            
                this.day = d;
                this.month = m;
                this.year = y;           
        }
        public bool checkDate()
        {
            if (day > 31 || month > 12 || year > 2023)
            {
                Console.WriteLine("Invalid date ");
                return false;

            }
            else
                return true;

        }
        public bool printDate()
        {
                if (checkDate() == true)
                {
                    Console.WriteLine("Date is : " + day + "-" + month + "-" + year);
                return false;
                }
                else
                    Console.WriteLine("please enter date again in the order => day, month, year");
            return true;                            
        }
    }
}
