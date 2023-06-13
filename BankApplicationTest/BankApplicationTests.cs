using Bank;

namespace BankApplicationTest
{

    public class BankApplicationTest
    {
        [Test]
        public void IdGeneratorTest()
        {

            //ARRANGE
            IDGENERATOR newID = new IDGENERATOR();
            string result = DateTime.Now.ToString("yyyyMM") + "2";

            //ACT
            string actual = newID.generate();

            //ASSERT
            Assert.That(actual, Is.EqualTo(result));
        }
        [Test]
        public void ValidDOBTest()
        {

            //ARRANGE
            DateOfBirth dob = new DateOfBirth();
            dob.set(12, 10, 2010);

            //ACT
            bool result = dob.checkDate();

            //ASSERT
            Assert.IsTrue(result);
        }
        [Test]
        public void InValidValidDOBTest()
        {

            //ARRANGE
            DateOfBirth dob = new DateOfBirth();
            dob.set(32, 15, 2010);
            string res = "Invalid date of birth";
            //ACT
            bool result = dob.checkDate();

            //ASSERT
            Assert.That(result, Is.False);
        }

        [Test]
        public void PrintDateTest()
        {
            //ARRANGE
            DateOfBirth dob = new DateOfBirth();
            //dob.day = 22; dob.month = 5; dob.year = 1990;
            dob.set(22, 3, 2001);
            // string result = "Date is : " + dob.day + "-" + dob.month + "-" + dob.year;



            //ACT
            bool result = dob.printDate();


            //ASSERT
            Assert.IsFalse(result);
        }
        [Test]
        public void InValidPrintDateTest()
        {
            //ARRANGE
            DateOfBirth dob = new DateOfBirth();
            //dob.day = 22; dob.month = 5; dob.year = 1990;
            dob.set(35, 3, 2001);
            string res = "Invalid Date";



            //ACT
            bool result = dob.printDate();


            //ASSERT
            Assert.IsTrue(result);
        }
            [Test]
        public void DateOfBirthTest()
        {
            //Arrange
            DateOfBirth checkDate = new DateOfBirth();
            checkDate.set(30, 11, 2015);

            //Act
            string actual = DateTime.Now.ToString();


            //Assert
            Assert.False(actual.Equals(checkDate));
        
        }
        [Test]
        public void DebitDepositTest()
        {
            //Arrange
            Debit money = new Debit();
            money.balance = 1000;

            //Act
            money.deposit(100);

            //Assert
            Assert.That(money.balance, Is.EqualTo(1100));
        }
        [Test]
        public void DebitTransferTest()
        {
            //Arrange 
            Debit money = new Debit();
            money.balance = 5000;

            //Act
            money.transfer(1000);

            //Assert
            Assert.That(money.balance, Is.EqualTo(4000));
        }
        [Test]
        public void DebitWithdrawTest()
        {
            //Arrange
            Debit money = new Debit();
            money.balance = 10000;

            //Act
            money.withdraw(5000);

            //Assert
            Assert.That(money.balance, Is.EqualTo(5000));
        }
        [Test]
        public void SavingsDepositTest()
        {
            //Arrange
            Savings amount = new Savings();
            amount.balance = 5000;

            //Act
            amount.deposit(1000);

            //Assert
            Assert.That(amount.balance, Is.EqualTo(6000));
        }
            [Test]
        public void SavingsWithdrawTest()
        {
            //Arrange
            Savings amount = new Savings();
            amount.balance = (5000);

            //Act
            amount.withdraw(4000);

            //Assert
            Assert.That(amount.balance, Is.EqualTo(1000));

        }
        [Test]
        public void InvalidSavingsWithdrawTest()
        {
            //Arrange
            Savings amount = new Savings();
            amount.balance = (500);

            //Act
            amount.withdraw(1000);

            //Assert
            Assert.That(amount.balance, Is.EqualTo(500));
        }
            [Test]

        public void SavingsTransferTest()
        {
            //Arrange
            Savings amount = new Savings();
            amount.balance = 5000;

            //Act
            amount.transfer(1000);

            //Assert
            Assert.That(amount.balance, Is.EqualTo(4000));
        }
        [Test]

        public void CurrentDepositTest()
        {
            //Arrange
            Current amount = new Current();
            amount.balance = 1000;

            //Act
            amount.deposit(5000);

            //Assert
            Assert.That(amount.balance, Is.EqualTo(6000));

        }
        [Test]
        public void CurrentTransferTest()
        {
            //Arrange
            Current amount = new Current();
            amount.balance = 6000;

            //Act
            amount.transfer(1000);

            //Assert
            Assert.IsTrue(amount.balance == 5000);
        }
        [Test]

        public void CurrentWithdrawTest()
        {
            //Arrange
            Current amount = new Current();
            amount.balance = 10000;

            //Act
            amount.withdraw(4000);

            //Assert
            Assert.That(amount.balance, Is.EqualTo(6000));

        }
        
    }
}
