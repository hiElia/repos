using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myVendingMachineProject.Model
{
    class User
    {
        //it has a property wallet
        public int Wallet { get; set; }
        // a constructor to creat a user and fill a wallet
        public User (int money)
        {
           this.Wallet+= money;

        }
        //a method to spend money
        public int SpendMoney(int money)
        {

            Wallet -= money;
            return Wallet;
        }
        public string GetInfo()
        {
            string Info = $"{Wallet}:Amount remain to spend";
            return Info;
        }
        public void FillWallet(int money)
        {

            Wallet+= money;
        }


    }
}
