using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myVendingMachineProject.Model
{
    class MenuItem
    {
        public string Name { get; set; }
        public int price{ get; set; }

      public virtual string PrintToScreen()
        {

            string print = $"{Name}";
            return print;
        }
    }
}
