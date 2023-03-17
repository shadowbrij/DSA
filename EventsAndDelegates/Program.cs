using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class Program
    {
        /// <summary>
        /// You have to make an application using E&D when debit account balance deducts 
        /// when credit account balance added.
        /// </summary>
        static void Main(string[] args)
        {
           // AccountTransactions ac = new AccountTransactions();
           // ac.BalanceUpdateEvent += ac.creditBalance;
           //// var p = delegate (x) { return x + 1};
           // ac.displayAccountBalance();


        }
    }

    //public class AccountTransactions
    //{

    //    public event BalanceUpdate BalanceUpdateEvent;
    //    int accoutbalace = 500;
    //    public void creditBalance(int x)
    //    {
    //        accoutbalace += x;
    //    }
    //    public void debitBalace(int y)
    //    {
    //        accoutbalace -= y;
    //    }
    //    public void displayAccountBalance()
    //    {
    //        BalanceUpdateEvent(50);
    //        Console.WriteLine("Balace in account:" + accoutbalace);
    //        Console.ReadLine();
    //    }
    //}
    //public class HaldlerMethods
    //{
    //    static void NotifyUserForAccountTransactions()
    //    {
    //        Console.WriteLine("You did transaction on ur account");
    //    }
    //}
}
