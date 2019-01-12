using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myVendingMachineProject.Model
{
    class Snack : MenuItem
    {
        public int Price { get; set; }
        public Snack(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }
        public override string PrintToScreen()
        {
            Console.WriteLine("Snack");
            return base.PrintToScreen() + $"Price:{price}\n";
        }
    }
}
