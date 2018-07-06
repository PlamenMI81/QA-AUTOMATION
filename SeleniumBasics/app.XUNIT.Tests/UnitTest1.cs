using System;
using Xunit;

namespace app.XUNIT.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ThrowExceptionWithNegativeValue()
        {
            BankAcount acount;
            Assert.Throws<ArgumentException>(() => acount = new BankAcount(-1m));
        }
        [Fact]
        public void Withdraw5percentFee()
        {
            BankAcount acount = new BankAcount(2000m);
            acount.Withdraw(999);

            Assert.Equal(951.05m, acount.Amount);
        }
        [Fact]
        public void Withdraw2percentFee()
        {
            BankAcount acount = new BankAcount(2000m);
            acount.Withdraw(1000);

            Assert.Equal(980m, acount.Amount);
        }

        [Fact]
        public void WithdrawWithZero()
        {
            var initial = 100m;
            BankAcount acount = new BankAcount(initial);
            acount.Withdraw(0m);

            Assert.True(acount.Amount == initial);
        }
        [Fact]
        public void WithdrawWithNegativeValue()
        {
            //In this test I catch a BUGG :), we must cant withdrow with negative ammount of sum
            //but the code isnt throw an error and ammount is increesed and ofcourse test is failed
            var initial = 100m;
            BankAcount acount = new BankAcount(initial);
            Assert.Throws<ArgumentException>(() => acount.Withdraw(-1m));
        }
        [Fact]
        public void DepositWithZero()
        {
            var initial = 100m;
            BankAcount acount = new BankAcount(initial);
            acount.Deposit(0m);

            Assert.True(acount.Amount == initial);
        }
        [Fact]
        public void DepositWithPositiveSum()
        {
            var initial = 100m;
            BankAcount acount = new BankAcount(initial);
            acount.Deposit(100m);

            Assert.False(acount.Amount == initial);
        }
        [Fact]
        public void DepositWithNegativeSum()
        {
            var message = "";
            var initial = 100m;
            BankAcount acount = new BankAcount(initial);
            try
            {
                acount.Deposit(-100m);
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            Assert.StartsWith("Deposit can not be negative", message);
        }

    }
}
