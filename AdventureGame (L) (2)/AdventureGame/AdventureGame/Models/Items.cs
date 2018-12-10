using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models
{
    public class Items
    {
        public string Name { get; set; }
        public int AmountOfDamage { get; set; }        
        public int Price{ get; set; }

        public int DefenseAdded { get; set; }

        public virtual string PrintToScreen()
        {
            string print = $"Name:{Name} Amount of damage:{AmountOfDamage} price:{Price}";
            return print;
        }
       

      
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        //public Items(string name, int amountOfDamage, int price)
        //{
        //    this.Name = name;
        //    this.AmountOfDamage = amountOfDamage;
        //    this.Price = price;
        //}
        //public static List<Items> ItemList()
        //{
        //    var Items = new List<Items>();
        //    Items Sword1 = new Weapon("xyz", 100, 50);
        //    Items Sword2 = new Weapon("abc", 150, 60);
        //    Items sword3 = new Weapon("srt", 160, 70);

        //    Items Axe1 = new Axe("Fido", 120, 75);
        //    Items Axe2 = new Axe("Dido", 130, 80);
        //    Items Axe3 = new Axe("Axi", 140, 85);

        //    Items Mace1 = new Mace("mac", 160, 90);
        //    Items mace2 = new Mace("maki", 165, 95);
        //    Items mace3 = new Mace("mas", 170, 100);

        //    Items.Add(Sword1);
        //    Items.Add(Sword2);
        //    Items.Add(sword3);
        //    Items.Add(Axe1);
        //    Items.Add(Axe2);
        //    Items.Add(Axe3);
        //    Items.Add(Mace1);
        //    Items.Add(mace2);
        //    Items.Add(mace3);
        //    return Items;

    }

    //internal static void ShowItems()
    //{
    //    throw new NotImplementedException();
    //}

    //public static void ShowItems(List<Items>list)
    //{
    //    foreach (Items i in list)
    //    {
    //        Console.WriteLine($"Name: {i.Name} can caused amount of damage:{i.AmountOfDamage} price:{i.Price} ");
    //    }
    //}

    //public Items() { }

    //public List<Items> Inventory { get; set; }

    // public List<Sword> SList { get; set; }
    //  public List<Axe> aList { get; set; }
    //  public List<Mace> mList { get; set; }
    // public List<int> priceList = new List<int>();





    //public class Sword
    //{
    //    int Price { get; set; }
    //    int AmountOfDamage { get; set; }
    //}
    //public Sword(string name, int amountOfDamage, int price)
    //{
    //    this.Name = name;
    //    this.Price = price;
    //    this.AmountOfDamage = amountOfDamage;
    //}





    //public List<Sword> Slist
    //public override string PrintToScreen()
    //{
    //    return base.PrintToScreen() + $"Amount of damage: {Sword}, Axe's Amount of damage:{Axe},Mace's Amount of damage{Mace}";
    //}
    //public class Inventory
    //{
    //    public List<Sword> SList { get; set; }
    //}
}

