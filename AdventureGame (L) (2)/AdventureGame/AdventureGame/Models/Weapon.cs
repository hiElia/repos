using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models
{
    public enum WeaponType
    {
        Sword = 1,
        Axe,
        Mace
    }
    class Weapon : Items
    {
        //public string Name { get; set; }
        //public int AmountOfDamage { get; set; }
        //public int Price { get; set; }


        public Weapon( WeaponType wType)
        {
            switch (wType)
            {
                case WeaponType.Sword:
                    {
                        Name = "Sword";
                        this.AmountOfDamage = 20;
                        this.Price = 25;
                    }
                    break;
                case WeaponType.Axe:
                    {
                        Name = "Axe";

                        this.AmountOfDamage = 30;
                        this.Price = 50;
                    }
                    break;

                case WeaponType.Mace:
                    {
                        Name = "Mace";

                        this.AmountOfDamage = 50;
                        this.Price = 75;
                    }
                    break;
                
            }
           
        }
        public override string PrintToScreen()
        {
            return base.PrintToScreen();
        }


        //public static void ShowWeapon(List<Weapon> list)
        //{
        //    foreach (Weapon w in list)
        //    {
        //        Console.WriteLine($"Name: {w.Name} can caused amount of damage:{w.AmountOfDamage} price:{w.Price} ");
        //    }
        //}

    }
    //class Axe : Items
    //{
    //    public Axe(string name, int amountofDamage, int price)
    //    {
    //        this.Name = name;
    //        this.AmountOfDamage = amountofDamage;
    //        this.Price = price;
    //    }

    //}
    //class Mace : Items
    //{
    //    public Mace(string name, int amountOfDamage, int price)
    //    {
    //        this.Name = name;
    //        this.AmountOfDamage = amountOfDamage;
    //        this.Price = price;
    //    }
    //}




    //class Inventory
    //{
    //// public List<Items> Inventory { get; set; }

    //public List<Sword> SList { get; set; }
    //public List<Axe> aList { get; set; }
    //public List<Mace> mList { get; set; }

    //public Inventory()
    //{
    //    SList = new List<Items>();
    //}
    // public List<int> priceList = new List<int>();
    // public Inventory()
    // {
    //     SList = new List<Sword>();
    //     SList = new Sword<>

    // }

    //public class Axe
    //{
    //    public List<Axe> aList { get; set; }
    //}
    //public class Mace
    //{
    //    public List<Mace> mList { get; set; }

    //}

}




        //public List<Axe> Alist { get; set; }


