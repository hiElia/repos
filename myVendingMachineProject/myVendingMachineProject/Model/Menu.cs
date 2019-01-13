using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myVendingMachineProject.Model
{
    class Menu
    {
        public static void StartMenu()
        {

            Inventory inv = new Inventory();
            int userInput = 0;
            do
            {
                //Console.WriteLine($" Currently You have {inv.Purchaser.Wallet} dollars to spend\n");
                Console.WriteLine("1.Show Menu");
                Console.WriteLine("2.Buy Drink");
                Console.WriteLine("3.Buy Snack");
                Console.WriteLine("4.Check out");
                Console.WriteLine("5.Show balance");               
                Console.WriteLine("6.Quit");
                userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                { 
                    case 1:
                        Console.Clear();
                        inv.ShowMenu();
                        Console.WriteLine("press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Which drink do you want to buy");
                        string usersDChoice = Console.ReadLine();
                        Console.WriteLine("Which size do you want to buy 1= Small 2= Medium 3= Large");
                        int userDrinkSize = Convert.ToInt32(Console.ReadLine());
                        inv.Buydrink(usersDChoice, userDrinkSize);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Which Snack do you want to buy");
                        string usersChoice = Console.ReadLine();
                        inv.BuySnack(usersChoice);
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        inv.Checkout();
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine($" Wallet balance: {inv.Purchaser.Wallet} dollars.\n");
                        Console.ReadKey();
                        break;

                }
            }

            while (userInput != 6);
            



        }
    }
} 
