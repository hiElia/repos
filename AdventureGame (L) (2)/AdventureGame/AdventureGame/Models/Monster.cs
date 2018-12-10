using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models
{
    class Monster
    {
        public string Name { get; set; }
        public int Health{ get; set; }
        public int AmountOfDamage { get; set; }
        public int Loot { get; set; }
        public Monster(string name, int health, int amountOfDamge,int loot)
        {
            this.Name = name;
            this.Health = health;
            this.AmountOfDamage = amountOfDamge;
            this.Loot= loot;
        }
        public void Damage(Player player)
        {
            Random rand = new Random();
            int monsterDamage = 0;
            monsterDamage= this.AmountOfDamage + rand.Next(10, 15);
            player.Health -= monsterDamage;

            
        }
       
      
    }
}

