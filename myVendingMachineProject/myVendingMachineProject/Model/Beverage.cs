using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myVendingMachineProject.Model
{
    class Beverage : MenuItem
    {
        public int _Small { get; set; }
        public int _Medium { get; set; }
        public int _Large { get; set; }
        public string _Name { get; set; }


        public Beverage(string Name,int Small, int Medium, int Large)
        {
            this._Name = Name;
            this._Small = Small;
            this._Medium = Medium;
            this._Large = Large;

        }
        public override string PrintToScreen()
        {
            return base.PrintToScreen() + $" Name: {_Name}Small size: {_Small}\n Medium Size: {_Medium}\n Large Size: {_Large}";    
        }
    }
}
