using System;

namespace SeleniumBasicDemo
{
    internal class SeleniumFirstTry
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hey");
            BankAcount acount = new BankAcount(1m);
            acount.Deposit(100m);
            acount.Withdraw(500m);
        }
    }
}