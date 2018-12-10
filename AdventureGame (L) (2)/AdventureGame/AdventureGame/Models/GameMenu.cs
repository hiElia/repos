using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models
{
    public class GameMenu
    {

        public static void StartProgram()
        {
            
            Console.WriteLine("Welcom to the Adventure game,what would  you like to do");
            Console.WriteLine("1.Fight monsters");
            Console.WriteLine("2.Go to store, to buy weapons");
            Console.WriteLine("3.Go to tavren,to get healed");
            Console.WriteLine("4.Quite the game");
            string usersAction = (Console.ReadLine());
           
            

            
            
                switch (usersAction)
                {
                    case "1":
                        Console.Clear();
                        Game.Charctername();
                        Game.PlayGame();                    
                       
                        break;

                    case "2":
                    Game.NotEnoughGold();
                        
                        break;

                    case "3":
                    Game.MaxHealth();
                        break;
                    case "4":
                    Console.WriteLine("press any key to exit");
                    Console.ReadKey();
                        break;
                     default:
                    Console.WriteLine("Invalid Input");
                    break;

            }

            




        }
    }
}
