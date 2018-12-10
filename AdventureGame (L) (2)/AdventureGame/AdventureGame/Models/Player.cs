using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
namespace AdventureGame.Models
{
    class Player
    {
        //internal object PlayerHealth;
       // internal readonly object PlayerMaxHealth;

        public string Name { get; set; }
        public int Health { get; set; }
        public int Age{ get; set; }
        public int AmountOfDamage { get; set; }
        public int TotalPlayerGold { get; set; }
        public Player( string name,int age)
        {
            this.Name = name;
            this.Age = age;
            this.Health = 100;
            this.AmountOfDamage = 7;
            
        }

        public static void PlayerRest(Player player)
        {
            player.Health = 100; 
        }

        internal static void PlayerRest()
        {
            PlayerRest();
        }

        




    }
    

    
}
