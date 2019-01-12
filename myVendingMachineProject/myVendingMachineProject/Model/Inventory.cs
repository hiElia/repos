using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myVendingMachineProject.Model
{
    class Inventory
    {
        public List<Beverage> Blist { get; set; }
        public List<Snack> Slist { get; set; }
        public List<int> Pricelist = new List<int>();
        public string PurchaseItemString = " ";
        public User Purchaser = new User(30);
        public Inventory()
        {

            Blist = new List<Beverage>();
            Beverage Coca = new Beverage("Coca", 1, 2, 3);
            Beverage Pepsi = new Beverage("pepsi", 1, 2, 3);
            Beverage Fanta = new Beverage("Fanta", 2, 3, 4);
            Blist.Add(Coca);
            Blist.Add(Pepsi);
            Blist.Add(Fanta);

            Slist = new List<Snack>();
            Snack Chips = new Snack("Chips", 3);
            Snack Checolate = new Snack("Checolate", 4);
            Snack protienbar = new Snack("Protein Bar", 5);
            Slist.Add(Chips);
            Slist.Add(Checolate);
            Slist.Add(protienbar);


        }
        public void ShowMenu()
        {
            foreach (Snack item in Slist)
            {
                Console.WriteLine($"{item.Name}:\nPrice: {item.Price} $");
            }
            foreach (Beverage item in Blist)
            {
                Console.WriteLine($"{item._Name}:\nPrice for small:{item._Small} $\nPrice for medium:{item._Medium} $\nPrice for large:{item._Large} $\n");
            }
            //foreach (Snack item in Slist)
            //{
            //    Console.WriteLine($"Name: {item.Name}\n Size: Price: {item.Price}");

            //}
            //foreach (Beverage item in Blist)
            //{
            //    Console.WriteLine($"Name: {item.Name}\n Size: Small{item._Small}, Medium{item._Medium}, Large{item._Large}");
            //}



        }
        public void Buydrink(string name, int size)
        {
            int price = 0;
           // Beverage obj = bList.FirstOrDefault(x => x.Name.ToLower() == name);
            Beverage obj= Blist.FirstOrDefault(x => x._Name.ToLower() == name);
            if (size == 1)
            {
                price = obj._Small;
                Pricelist.Add(price);
                PurchaseItemString += $"{obj.Name}";
            }
            else if(size == 2)
            {

                price = obj._Medium;
                Pricelist.Add(price);
                PurchaseItemString += $"{obj._Medium}";

            }
            else if (size == 3)
            {
                price = obj._Large;
                Pricelist.Add(price);
                PurchaseItemString += $"{obj.Name}";


            }
            else
            {
                Console.WriteLine("error");
            }
        }
        public void BuySnack(string name)
        {
          Snack Slobj=  Slist.FirstOrDefault(x => x.Name.ToLower() == name);
            int price = Slobj.Price;
            Pricelist.Add(price);
            PurchaseItemString += $"{Slobj.Name}";



        }
        public void Checkout()
        {
            int Total = 0;
            int Balace = 0;

            foreach (int prices in Pricelist)
            {
                Total += prices;
            }
            Console.WriteLine($"Your balance is {Purchaser.Wallet}\n");
            Console.WriteLine($"Items will be purchase: {PurchaseItemString}\n Total cost for the items {Total}");
            Console.WriteLine("Confirm Purchse? 1 = Confirm 2 =cancel");
            int answer = Convert.ToInt32(Console.ReadLine());
            if (answer==1)
            {
                Console.WriteLine("Thanks ");
                Balace = Purchaser.SpendMoney(Total);
                PurchaseItemString = "";
            }
            else if(answer == 2)
            {
                Console.WriteLine("Go back to the menu");
                PurchaseItemString = "";
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }





    }




    }

