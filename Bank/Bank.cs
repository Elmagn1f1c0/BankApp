using System;
using System.Linq;

namespace Bank
{
    public class Bank 
    {
      
        string id;//hold generated id  from idgenerator and add string
        string acctNumber;
        public int idnum = 0;//index number for id


        //hold separated id in separated index
        public string[] myId = new string[100];
        public string[] myName = new string[100];
        public string[] myAccType = new string[100];
        public string[] myDob = new string[100];
        public string[] myNominee = new string[100];
        public double[] myBalance = new double[100];
        public string[] myAcctNo = new string[100];


        
        IDGENERATOR id1 = new IDGENERATOR();
        DateOfBirth dob = new DateOfBirth();
        Savings sv = new Savings();
        Debit db = new Debit();
        Current cr = new Current();
        //AcctName actN = new AcctName(); 
       
        
        //see in create account
        public bool val = true;
        public bool debval = true;

        //id storing
        public void GetAcc(string ID)
        {
            ID = this.id; 
            myId[idnum] = ID;
            idnum++;
           
        }

        //THIS METHOD PRINTS OUT TO THE CONSOLE THE DETAILS OF ALL CREATED ACCOUNTS
        public void showAll()
        {
            Console.WriteLine("All registerd accounts are:\n\n");
            Console.WriteLine("|---------------------|------------------|--------------------|--------------------|----------------|");
            Console.WriteLine("|   Acct Name         |    Acct No       |    Acct id         |     Acct type      |  Acct balance  |");
            Console.WriteLine("|---------------------|------------------|--------------------|--------------------|----------------|");
            for (int i = 0;i < idnum; i++)
            {
             Console.WriteLine(" " + myName[i] + "\t\t" + myAcctNo[i] + "\t\t" + myId[i] + "\t\t " + myAccType[i] +"\t\t" + myBalance[i]);
             Console.WriteLine("|---------------------------------------------------------------------------------------------------|");
            }
        }

        
        //THIS METHOD PRINTS TO THE CONSOLE INFORMATION ABOUT A SPECIFIC ACOUNT ID
        public void showInfo()
        {
            int indexNum;  //specific index for showing information
            string inId = Convert.ToString(Console.ReadLine());
          
            
            if (myId.Contains(inId))
            {
                indexNum = Array.IndexOf(myId,inId);
                //find out array number
                Console.WriteLine("Your Account details are: ");
                Console.WriteLine("|---------------------|------------------|--------------------|--------------------|------------------|");
                Console.WriteLine("|   Acct Name         |    Acct No       |    Acct id         |     Acct type      |  Acct balance    |");
                Console.WriteLine("|---------------------|------------------|--------------------|--------------------|------------------|");
                Console.Write("  " + myName[indexNum] + "\t");
                Console.Write("\t" + myAcctNo[idnum] + " ");
                Console.Write("\t" +myId[indexNum] + "\t");
                Console.Write("\t" + myAccType[indexNum]);
                Console.Write("\t" + myBalance[indexNum]);
               
               
            }
            else
            {
                Console.WriteLine("You entered a wrong Id!");
            }
           

        }
        string FirstName;
        string LastName;

        public void create_account()
        {
            string myAcctNum;
            string accType;
            string name;
            bool validName = false;
            int dd, mm, yr;
            string nominee;
            double balance;
            string input;
            //string FirstName;
            //string LastName;
            Console.WriteLine("\n");
            Console.WriteLine("0 => Debit Account");
            Console.WriteLine("1 => Savings Account");
            Console.WriteLine("2 => Current Account");
            object ob1 = Console.ReadLine();
            input = Convert.ToString(ob1);

            if (input == "0")
            {   
                    accType = "Debit";
                    myAccType[idnum] = accType;

                while (!validName)
                {
                    Console.Write("Enter First name: ");
                    string firstName = Console.ReadLine();
                    //string Fn = firstName.Substring(0, 1).Replace(firstName[0], char.ToUpper(firstName[0])) + firstName.Substring(1);

                    Console.Write("Enter Last name: ");
                    string lastName = Console.ReadLine();
                    // string Ln = lastName.Substring(0, 1).Replace(lastName[0], char.ToUpper(lastName[0])) + lastName.Substring(1);

                    if (char.IsDigit(firstName[0]) || char.IsDigit(lastName[0]))
                    {
                        Console.WriteLine("Name cannot begin with a number");

                    }else if(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName)) 
                    {
                        Console.WriteLine("Name cannot be empty. Please enter a valid name.");
                         
                    }
                    else
                    {
                        validName = true;
                        LastName = lastName.Substring(0, 1).Replace(lastName[0], char.ToUpper(lastName[0])) + lastName.Substring(1);
                        FirstName = firstName.Substring(0, 1).Replace(firstName[0], char.ToUpper(firstName[0])) + firstName.Substring(1);
                        Console.WriteLine("Hello, " + FirstName + " " + LastName);
                        name = FirstName + " " + LastName;
                    }  
                    
                }
                name = FirstName + " " + LastName;
                myName[idnum] = name;
                

                while (val == true)
                    {
                    //Take date of birth

                    try
                    {
                        Console.WriteLine("Enter day of birth: ");
                        dd = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter month of birth: ");
                        mm = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter year of birth: ");
                        yr = Convert.ToInt32(Console.ReadLine());

                        dob.set(dd, mm, yr);


                        if (dob.printDate() == false)
                        {
                            myDob[idnum] = Convert.ToString(dd + "-" + mm + "-" + yr);
                            val = false;
                        }
                        else val = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please Enter an integer value for date");
                    }
                   


                    
                }



                val = true;
                //debit,savings,current all used the same val
               
                //CHECKS TO MAKE SURE DEPOSIT AMOUNT MEETS THE REQUIREMENT
                while (debval == true)
                {
                    try
                    {
                        Console.WriteLine("Enter deposit amount: ");
                        balance = Convert.ToDouble(Console.ReadLine());
                        if (balance > db.maxBalance)
                        {
                            Console.WriteLine("Debit Account maximum deposit value is 1000000!");
                            debval = true;
                        }
                        else
                        {
                            myBalance[idnum] = balance;
                            debval = false;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid amount");
                        
                    }
                    
                }
                debval = true;
                //debit,credit using the same value

                Console.WriteLine("Debit account created successfully...! ");
                id =id1.generate();//collect id from id generator
                id = id + "Deb";//add string to that generated id
                myAcctNum = "001" + id1.generate();
                myAcctNo[idnum] = myAcctNum;
                Console.WriteLine("Your Account Id : "+id);
                Console.WriteLine("Your Account number : " + myAcctNum);
                GetAcc(id);//store id and increase the index number

            }
            else if (input == "1")
            {
                accType = "Savings";
                myAccType[idnum] = accType;

                while (!validName)
                {
                    Console.Write("Enter First name: ");
                    string firstName = Console.ReadLine();
                   
                    Console.Write("Enter Last name: ");
                    string lastName = Console.ReadLine();
                   
                    if (char.IsDigit(firstName[0]) || char.IsDigit(lastName[0]))
                    {
                        Console.WriteLine("Name cannot begin with a number");

                    }
                    else if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                    {
                        Console.WriteLine("Name cannot be empty. Please enter valid name.");

                    }
                    else
                    {
                        validName = true;
                        LastName = lastName.Substring(0, 1).Replace(lastName[0], char.ToUpper(lastName[0])) + lastName.Substring(1);
                        FirstName = firstName.Substring(0, 1).Replace(firstName[0], char.ToUpper(firstName[0])) + firstName.Substring(1);
                        Console.WriteLine("Hello, " + FirstName + " " + LastName);
                        name = FirstName + " " + LastName;
                    }

                }
                name = FirstName + " " + LastName;
                myName[idnum] = name;

                //if user input for date is wrong then it will take until the input is correct
                while (val == true)
                {
                    try
                    {
                        Console.WriteLine("Enter day of birth: ");
                        dd = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter month of birth: ");
                        mm = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter year of birth: ");
                        yr = Convert.ToInt32(Console.ReadLine());

                        dob.set(dd, mm, yr);

                        if (dob.printDate() == false)
                        {
                            myDob[idnum] = Convert.ToString(dd + "-" + mm + "-" + yr);
                            val = false;
                        }
                        else val = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please Enter an integer value for date");
                    }
                    
                    
                }

                //debit,credit,savings all used the same val
                val = true;

                //takes input until balance is correct
                while (debval == true)
                {
                    try
                    {
                        Console.WriteLine("Enter deposit amount: ");
                        balance = Convert.ToDouble(Console.ReadLine());
                        if (balance < sv.minBalance)
                        {
                            Console.WriteLine("Savings Account's min val is 1000!");
                            debval = true;
                        }
                        else
                        {
                            myBalance[idnum] = balance;
                            debval = false;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid amount");
                    }
                    
                }
                debval = true;//debit,credit using the same value
                Console.WriteLine("Savings account created  successfully...! ");
                id = id1.generate();//collect id from id generator
                id = id + "Sav";//add string to that generated id
                myAcctNum = "002" + id1.generate();
                myAcctNo[idnum] = myAcctNum;
                // Console.Write("Deb");
                Console.WriteLine("Your Account Id : " + id);
                Console.WriteLine("Your Account number : " + myAcctNum);
                GetAcc(id);

            }
            else if (input == "2")
            {
                accType = "Current";
                myAccType[idnum] = accType;

                while (!validName)
                {
                    Console.Write("Enter First name: ");
                    string firstName = Console.ReadLine();
                  
                    Console.Write("Enter Last name: ");
                    string lastName = Console.ReadLine();
                   
                    if (char.IsDigit(firstName[0]) || char.IsDigit(lastName[0]))
                    {
                        Console.WriteLine("Name cannot begin with a number");

                    }
                    else if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                    {
                        Console.WriteLine("Name cannot be empty. Please enter valid name.");

                    }
                    else
                    {
                        validName = true;
                        LastName = lastName.Substring(0, 1).Replace(lastName[0], char.ToUpper(lastName[0])) + lastName.Substring(1);
                        FirstName = firstName.Substring(0, 1).Replace(firstName[0], char.ToUpper(firstName[0])) + firstName.Substring(1);
                        Console.WriteLine("Hello, " + FirstName + " " + LastName);
                        name = FirstName + " " + LastName;
                    }

                }
                name = FirstName + " " + LastName;
                myName[idnum] = name;

                //if user input for date is wrong then it will take until the input is correct
                while (val == true)
                {

                    try
                        {
                            Console.WriteLine("Enter day of birth: ");
                            dd = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter month of birth: ");
                            mm = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter year of birth: ");
                            yr = Convert.ToInt32(Console.ReadLine());

                            dob.set(dd, mm, yr);
                            if (dob.printDate() == false)
                            {
                                myDob[idnum] = Convert.ToString(dd + "-" + mm + "-" + yr);
                                val = false;
                            }
                            else val = true;
                    }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please Enter an integer value for date");
                        }
                   
                }
                val = true;//debit,credit,savings all used the same val 
                Console.WriteLine("Enter referee's name: ");
                nominee = Convert.ToString(Console.ReadLine());
                myNominee[idnum] = nominee;
                while (debval == true)
                {
                    try
                    {
                        Console.WriteLine("Enter deposit amount: ");
                        balance = Convert.ToDouble(Console.ReadLine());
                        myBalance[idnum] = balance;
                        debval = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid amount");
                    }
                }
                debval = true;
                Console.WriteLine("Current account created successfully...! ");
                

                id = id1.generate();//collect id from id generator
                id = id + "Cur";//add string to that generated id
                myAcctNum = "003" + id1.generate();
                myAcctNo[idnum] = myAcctNum;
                // Console.Write("Deb");
                Console.WriteLine("Your Account Id : " + id);
                Console.WriteLine("Your Account number : " + myAcctNum);
                GetAcc(id);

            }
            
        }

        public void deposit()
        {
            int indexNum;
            string inId = Convert.ToString(Console.ReadLine());
            if (myId.Contains(inId))
            {
                indexNum = Array.IndexOf(myId, inId);
                //passArrNum = indexNum;
                Console.WriteLine("Your Balance is: " + myBalance[indexNum]);
                Console.WriteLine("How much do you want to deposit: ");

                double depval = Convert.ToDouble(Console.ReadLine());

                if (myAccType[indexNum] == "Debit")
                {
                    db.balance = myBalance[indexNum];
                    db.deposit(depval);
                    myBalance[indexNum] = db.balance;
                }
                else if (myAccType[indexNum] == "Savings")
                {
                    sv.balance = myBalance[indexNum];
                    sv.deposit(depval);
                    myBalance[indexNum] = sv.balance;
                }
                else if (myAccType[indexNum] == "Current")
                {
                    cr.balance = myBalance[indexNum];
                    cr.deposit(depval);
                    myBalance[indexNum] = cr.balance;
                }
                
            }
                
            else
            {
                Console.WriteLine("Your id is wrong!");
            }

        }
        public void withdraw()
        {
            int indexNum;
            string inId = Convert.ToString(Console.ReadLine());
            if (myId.Contains(inId))
            {
                indexNum = Array.IndexOf(myId, inId);
                Console.WriteLine("Your Balance is: " + myBalance[indexNum]);
                Console.WriteLine("How much do you want to withdraw: ");
                double depval = Convert.ToDouble(Console.ReadLine());
                if (myAccType[indexNum] == "Debit")
                {
                    db.balance = myBalance[indexNum];
                    db.withdraw(depval);
                    myBalance[indexNum] = db.balance;
                }
                else if (myAccType[indexNum] == "Savings")
                {
                    sv.balance = myBalance[indexNum];
                    sv.withdraw(depval);
                    myBalance[indexNum] = sv.balance;
                }
                else if (myAccType[indexNum] == "Current")
                {
                    cr.balance = myBalance[indexNum];
                    cr.withdraw(depval);
                    myBalance[indexNum] = cr.balance;
                }

            }

            else
            {
                Console.WriteLine("Your id is wrong!");
            }
        }

            public void transfer()
            {
                int indexNum;
                string SenderId = Convert.ToString(Console.ReadLine());
                int senderindex = Array.IndexOf(myId, SenderId);
            if(senderindex == -1)
            {
                Console.WriteLine("Invalid id");
                return;
            }

            Console.WriteLine("Enter receiver's Account id");
            string receiverId = Convert.ToString(Console.ReadLine());
            int receiverIndex = Array.IndexOf(myId, receiverId);
            if(receiverIndex == -1)
            {
                Console.WriteLine("Invalid Account Id");
                return;
            }
           
            
            
            if (myId.Contains(SenderId))
            {
                indexNum = Array.IndexOf(myId, SenderId);
                Console.WriteLine("Your Balance is: " + myBalance[indexNum]);

                Console.WriteLine("How much do you want to transfer: ");
                double depval = Convert.ToDouble(Console.ReadLine());
               

                myBalance[receiverIndex] += depval;
                if (myAccType[receiverIndex] == "Debit")
                {
                    db.balance = myBalance[receiverIndex];
                    db.transfer(depval);
                }else if (myAccType[receiverIndex] == "Savings")
                {
                    sv.balance = myBalance[receiverIndex];
                    sv.transfer(depval);
                }else if (myAccType[receiverIndex] == "Current")
                {
                    cr.balance = myBalance[receiverIndex];
                    cr.transfer(depval);
                }

                myBalance[senderindex] -= depval;
                if (myAccType[receiverIndex] == "Debit")
                {
                    db.balance = myBalance[senderindex];
                    db.transfer(depval);
                }
                else if (myAccType[senderindex] == "Savings")
                {
                    sv.balance = myBalance[senderindex];
                    sv.transfer(depval);
                }
                else if (myAccType[senderindex] == "Current")
                {
                    cr.balance = myBalance[senderindex];
                    cr.transfer(depval);
                }

                Console.WriteLine("Transfer Successful");

            }
            



        }
    }
}
