using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace AdventureGame.Models
{

    class Game
    {  
       
        
        static string characterName;
        static int characterAge;       
        static int amountOfDamage = 4;


        public static void Charctername()

        {
            Console.WriteLine("Welcom to the adventure game");
            Console.WriteLine("Enter your  name");
            characterName = Console.ReadLine();
            Console.WriteLine("Enter your age");
            characterAge = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine($"Awesome, your character is named {characterName} and you are {characterAge} years old");
            Console.Clear();
            Console.WriteLine("As you walk through the forest,the Monster appears from the shadows luckly a small one \n");
        }
      

        public static void PlayGame()
        {
            
            Player p = new Player(characterName, characterAge);
            Monster M = new Monster("M", 20, 5,80);
            //var player = new System.Media.SoundPlayer();
            //player.Stream = new MemoryStream(Propertie.Resources.gameMusic);
          
            do
            {
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("press A to attack, D to defend yourself, or  R to run>\n");
                string PlayersChoice = Console.ReadLine();
                Console.ResetColor();

                switch (PlayersChoice)
                {
                    case "a":
                        Console.ForegroundColor = ConsoleColor.Cyan;

                        try
                        {

                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "\\PUNCH.wav");
                            player.Play();
                            //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\PUNCH.wav");
                            //player.Play();

                        }
                        catch (Exception ex)
                        {
                            ex.ToString();

                            throw;
                        }

                        //SoundPlayer player = new SoundPlayer();
                        // player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory +@" \\c:\Users\source\repos\AdventureGame\AdventureGame\PUNCH.wav";
                        //player.SoundLocation = @"C:\Users\Desktop.wav";
                        // player.Play();
                       
                        Random r = new Random();
                        p.AmountOfDamage = amountOfDamage + r.Next(1, 7);
                        M.Health -= p.AmountOfDamage;
                        Console.WriteLine($"you have just attack the monster with your fist which deals {p.AmountOfDamage} amount of damage ");
                        Console.WriteLine($"The monster has  now a health level of  {M.Health}");
                        Random rand = new Random();
                        int monsterDamage = amountOfDamage + rand.Next(1, 4);
                        p.Health -= monsterDamage;
                        Console.WriteLine($"the monster fights back! you have now a health level of {p.Health}");
                        System.Threading.Thread.Sleep(700);
                        Console.ResetColor();
                        Console.ReadLine();
                        break;


                    case "d":
                        Random ran = new Random();
                        monsterDamage = (ran.Next(1, 2) * amountOfDamage);
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("The monster attacks you");
                        Console.WriteLine($" you  block the  attack with your  arms\n");
                        Console.ResetColor();                       
                        p.Health -= monsterDamage;
                        Console.WriteLine($"you have now a health level of { p.Health}");
                        Console.WriteLine($"the monster has a health level of { M.Health}");
                        Console.ReadLine();

                        break;
                    case "r":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(" says, 'LOL NOPE' and you must remain on the battlefield.\n");
                        Console.ResetColor();
                        Console.WriteLine("Ok, you can buy weapon then");
                        Console.ReadKey();
                        Console.Clear();
                        Game.BuyWeapons();
                        break;
                }

            }
            while (p.Health>0 && M.Health>0);
            
            if (p.Health<=0 && M.Health>0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($" you died  died! NO RE\n");
                Console.ResetColor();
                Console.WriteLine("press any key to play again");
                Console.ReadKey();
                Console.Clear();
                GameMenu.StartProgram();
            }
            else if (M.Health == 0 && p.Health == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("It was a tie!");
                Console.ResetColor();

            }
            else if (M.Health<=0 && p.Health>0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                p.TotalPlayerGold += M.Loot;
                Console.WriteLine($"Wow, you win the first level,Congratulations. You have now an option to Purchase a weapon\nYou have accumulated {p.TotalPlayerGold} amount gold");
                Console.ResetColor();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
                Game.BuyWeapons();

            }  
        }       

        public static void BuyWeapons()
        {
            
            Console.Clear();
            Console.WriteLine($"Hello {characterName} Welcom to the Store, you can choose a weapon to fight with");
            Console.WriteLine("which weapons would you like to purchase, press\n1.Sword\n2.Axe\n3.Mace\n4.To get healed ");
            string playersAnswer = Console.ReadLine();
            Console.Clear();
            switch (playersAnswer)
            {
                case "1":
                    Console.WriteLine("You chose to fight with an Sword, which  deals a maximum amount damage  upto 20");
                    Game.ShowSword();                    
                    Game.FightWithSword();                   
                    break;

                case "2":
                    Console.WriteLine("You chose to fight with an Axe, which  deals a maximum amount damage upto 30");
                    Game.ShowAxe();
                    Game.FightWithAxe();
                    break;

                case "3":
                    Console.WriteLine("You chose to fight with a mace,which can deal a maximum amount damage upto 50");
                    Game.ShowMace();
                    Game.FightWithMace();
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("you are at maximum health level right now");
                    Console.WriteLine("press any key to go back to the  store");
                    Console.ReadKey();
                    Console.Clear();
                    //Player.PlayerRest();
                    Game.BuyWeapons();
                    break;


            }
        }
        public static void FightWithSword()
        {
            Player p = new Player(characterName, characterAge);
            Monster MediumMonster = new Monster("M", 40, 5, 90);

            
            int swordAmountOfDamage = 20;
            
            
            Console.Write("As you walk through the forest ,the Monster appears from the shadows this time a medium one ");
            do
            {
                Console.WriteLine($" you have now health level of { p.Health}");
                Console.WriteLine($"The monster has health level of { MediumMonster.Health}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("press A to attack, D to defend yourself, or  R to run>\n");
                string PlayersChoice = Console.ReadLine();
                Console.ResetColor();
                switch (PlayersChoice)
                {
                    case "a":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                       

                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "\\swordecho.wav");
                        player.Play();
                        Random r = new Random();
                        p.AmountOfDamage= swordAmountOfDamage + r.Next(1, 5);
                        MediumMonster.Health -= p.AmountOfDamage;
                        Console.WriteLine($"you have just attack the monster with a sword which deals {p.AmountOfDamage} amount of damage ");
                        Console.WriteLine($"The monster has  now a health level of  {MediumMonster.Health}");
                        Random rand = new Random();
                        int monsterDamage = amountOfDamage + rand.Next(5, 12);
                        p.Health -= monsterDamage;
                        p.TotalPlayerGold += MediumMonster.Loot;
                        Console.WriteLine($"the monster fights back! you have now a\nhealth level of {p.Health}\nTotal amount of gold:{p.TotalPlayerGold}");
                        System.Threading.Thread.Sleep(700);
                        Console.ResetColor();
                        Console.ReadLine();

                        break;


                    case "d":
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("The monster attacks you");
                        Console.WriteLine($" you  block the  attack with your  arms\n");
                        Console.ResetColor();
                        Random ran = new Random();
                        monsterDamage = (ran.Next(1, 4) * amountOfDamage);
                        p.Health -= monsterDamage;                        
                        Console.WriteLine($"you have now a health level of { p.Health}");
                        Console.WriteLine($"the monster has a health level of { MediumMonster.Health}");
                        Console.ReadLine();

                        break;
                    case "r":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(" says, 'LOL NOPE' and you must remain on the battlefield.\n");
                        Console.ResetColor();
                        Console.WriteLine("Ok, you can buy weapon then");
                        Console.ReadKey();
                        Console.Clear();
                        Game.BuyWeapons();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;

                }

            }
            while (p.Health > 0 && MediumMonster.Health > 0);
            if (p.Health <= 0 && MediumMonster.Health> 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($" you died  died! GG NO RE\n");
                p.TotalPlayerGold -= MediumMonster.Loot;
                Console.ResetColor();
                Console.WriteLine("press any key to play again");
                Console.ReadKey();
                Console.Clear();
                GameMenu.StartProgram();
            }
            else if (MediumMonster.Health == 0 && p.Health == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("It was a tie!");
                Console.ResetColor();

            }
            else if (MediumMonster.Health <= 0 && (p.Health > 0))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Wow, you win the second level,Congratulations. ");
                Console.WriteLine($"you have now {p.TotalPlayerGold} total gold and {p.Health} health level");
                Console.ResetColor();
                Console.WriteLine("press any key to fight larger monster");
                Console.ReadKey();
                Console.Clear();
                Game.FightLargeMonster();

            }
           
        }
        public static void FightWithAxe()
        {
            Player p = new Player(characterName, characterAge);
            Monster MediumMonster = new Monster("M", 40, 7, 100);
          
            int axeAmountOfDamage = 30;
            
            Console.Write("As you walk through the forest ,the Monster appears from the shadows this time a medium one ");
            do
            {
                Console.WriteLine($" you have now health level of { p.Health}");
                Console.WriteLine($"The monster has health level of { MediumMonster.Health}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("press A to attack, D to defend yourself, or  R to run>\n");
                string PlayersChoice = Console.ReadLine();
                Console.ResetColor();
                switch (PlayersChoice)
                {
                    case "a":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "\\swordecho.wav");
                        player.Play();
                        Random r = new Random();
                        p.AmountOfDamage = axeAmountOfDamage + r.Next(1, 2);
                        MediumMonster.Health -= p.AmountOfDamage;
                        Console.WriteLine($"you have just attack the monster with an exe which deals {p.AmountOfDamage} amount of damage ");
                        Console.WriteLine($"The monster has  now a health level of  {MediumMonster.Health}");
                        Random rand = new Random();
                        int monsterDamage = amountOfDamage + rand.Next(5, 12);
                        p.Health -= monsterDamage;
                        Console.WriteLine($"the monster fights back! you have now a health level of {p.Health}");
                        System.Threading.Thread.Sleep(700);
                        Console.ResetColor();
                        Console.ReadLine();
                        break;


                    case "d":
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("The monster attacks you");
                        Console.WriteLine($" you  block the  attack with your  arms\n");
                        Console.ResetColor();
                        Random ran = new Random();
                        monsterDamage = (ran.Next(1, 4) * amountOfDamage);
                        p.Health -= monsterDamage;
                        Console.WriteLine($"you have now a health level of { p.Health}");
                        Console.WriteLine($"the monster has a health level of { MediumMonster.Health}");
                        Console.ReadLine();

                        break;
                    case "r":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(" says, 'LOL NOPE' and you must remain on the battlefield.\n");
                        Console.ResetColor();
                        Console.WriteLine("Ok, you can buy weapon then");
                        Console.ReadKey();
                        Console.Clear();
                        Game.BuyWeapons();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;

                }

            }
            while (p.Health > 0 && MediumMonster.Health > 0);
            if (p.Health <= 0 && MediumMonster.Health > 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($" you died  died! GG NO RE\n");
                p.TotalPlayerGold -= MediumMonster.Loot;
                Console.ResetColor();
                Console.WriteLine("press any key to play again");
                Console.ReadKey();
                Console.Clear();
                GameMenu.StartProgram();
            }
            else if (MediumMonster.Health == 0 && p.Health == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("It was a tie!");
                Console.ResetColor();

            }
            else if (MediumMonster.Health <= 0 && (p.Health > 0))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Wow, you win the second level,Congratulations. ");
                Console.WriteLine($"you have now {p.Health} health level and {p.TotalPlayerGold} total gold");
                p.TotalPlayerGold += MediumMonster.Loot;
                Console.ResetColor();
                Console.WriteLine("press any key to fight the larger monster");
                Console.ReadKey();
                Console.Clear();
                Game.FightLargeMonsterAxe();
            }
          
        }

        public static void FightWithMace()
        {
            Player p = new Player(characterName, characterAge);
            Monster MediumMonster = new Monster("M", 40, 7, 90);

            int maceAmountOfDamage = 50;
           
            Console.Write("As you walk through the forest ,the Monster appears from the shadows this time a medium one ");
            do
            {
                Console.WriteLine($"you have now health level of { p.Health}");
                Console.WriteLine($"The monster has health level of { MediumMonster.Health}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("press A to attack, D to defend yourself, or  R to run>\n");
                string PlayersChoice = Console.ReadLine();
                Console.ResetColor();
                switch (PlayersChoice)
                {
                    case "a":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "\\swordecho.wav");
                        player.Play();
                        Random r = new Random();
                        p.AmountOfDamage = maceAmountOfDamage + r.Next(1, 7);
                        MediumMonster.Health -= p.AmountOfDamage;
                        Console.WriteLine($"you have just attack the monster with Mace which deals {p.AmountOfDamage} amount of damage ");
                        Console.WriteLine($"The monster has  now a health level of  {MediumMonster.Health}");
                        Random rand = new Random();
                        int monsterDamage = amountOfDamage + rand.Next(5, 12);
                        p.Health -= monsterDamage;
                        Console.WriteLine($"the monster fights back! you have now a health level of {p.Health}");
                        System.Threading.Thread.Sleep(700);
                        Console.ResetColor();
                        Console.ReadLine();
                        break;


                    case "d":
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("The monster attacks you");
                        Console.WriteLine($" you  block the  attack with your  arms\n");
                        Console.ResetColor();
                        Random ran = new Random();
                        monsterDamage = (ran.Next(1, 4) * amountOfDamage);
                        p.Health -= monsterDamage;
                        Console.WriteLine($"you have now a health level of { p.Health}");
                        Console.WriteLine($"the monster has a health level of { MediumMonster.Health}");
                        Console.ReadLine();
                        break;

                    case "r":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(" says, 'LOL NOPE' and you must remain on the battlefield.\n");
                        Console.ResetColor();
                        Console.WriteLine("Ok, you can buy weapon then");
                        Console.ReadKey();
                        Console.Clear();
                        Game.BuyWeapons();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }

            }
            while (p.Health > 0 && MediumMonster.Health > 0);
            if (p.Health <= 0 && MediumMonster.Health > 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($" you died  died! GG NO RE\n");
                p.TotalPlayerGold-=MediumMonster.Loot;
                Console.ResetColor();
                Console.WriteLine("press any key to play again");
                Console.ReadKey();
                Console.Clear();
                GameMenu.StartProgram();
            }
            else if (MediumMonster.Health== 0 && p.Health == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("It was a tie!");
                Console.ResetColor();

            }
            else if (MediumMonster.Health<=0 && p.Health > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Wow, you win the second level,Congratulations. ");               
                Console.WriteLine($"you have now {p.Health} health level and {p.TotalPlayerGold} total gold");
                p.TotalPlayerGold += MediumMonster.Health;
                Console.ResetColor();
                //Console.Clear();
                Console.WriteLine("Press any key to fight larger monster");
                Console.ReadKey();
                Console.Clear();
                Game.FightLargeMonsterMace();
                Console.WriteLine("Press any key to play again");
                Console.ReadKey();
                Console.Clear();
                GameMenu.StartProgram();
            }

        }


        public static void NotEnoughGold()
        {
            Console.Clear();
            Console.WriteLine(" You don't have enough gold to purchase right now");            
            Console.WriteLine("press any key to go to menu");
            Console.ReadKey();
            Console.Clear();
            GameMenu.StartProgram();
        }
        public static void MaxHealth()
        {
            Console.Clear();
            Console.WriteLine("you don't  have enough gold to get healed");
            Console.WriteLine("Press any key to go to main menu");
            Console.ReadKey();
            Console.Clear();
            GameMenu.StartProgram();
        }    

        

        public static void ShowSword()
        {
            Console.WriteLine("Showing Weapons");
            Console.WriteLine($"you chose a weapon type:{WeaponType.Sword}\nAmount of damage--------: {20}\nprice-----------------:{25} ");
            Console.WriteLine("Press any key to Continue");
            Console.ReadKey();
            Console.Clear();
            
          
        }
        public static void ShowAxe()
        {
            Console.WriteLine("Showing Weapons");
            Console.WriteLine($"you chose a weapon type:{WeaponType.Axe}\nAmount of damage--------: {30}\nprice-----------------:{50} ");
            Console.WriteLine("Press any key to Continue");
            Console.ReadKey();
            Console.Clear();

        }
        public static void ShowMace()
        {
            Console.WriteLine("Showing Weapons");
            Console.WriteLine($"you chose a weapon type:{WeaponType.Mace}\nAmount of damage--------: {50}\nprice-----------------:{75} ");
            Console.WriteLine("Press any key to Continue");
            Console.ReadKey();
            Console.Clear();
        }


        public static void FightLargeMonster()
        {
            Player p = new Player(characterName, characterAge);
            Monster lMonster = new Monster("M", 150, 9, 120);
            int swordAmountOfDamage = 20;
            Console.Write("As you walk through the forest ,the Monster appears from the shadows this time a larger one ");
            do
            {
                Console.WriteLine($"you have now health level of { p.Health}");
                Console.WriteLine($"The monster has health level of { lMonster.Health}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("press A to attack, D to defend yourself, or  R to run>\n");
                string PlayersChoice = Console.ReadLine();
                Console.ResetColor();
                switch (PlayersChoice)
                {
                    case "a":
                        Console.ForegroundColor = ConsoleColor.Cyan;                        
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "\\swordecho.wav");
                        player.Play();
                        Random r = new Random();
                        p.AmountOfDamage = swordAmountOfDamage + r.Next(5, 13);
                        lMonster.Health -= p.AmountOfDamage;
                        Console.WriteLine($"you have just attack the monster with a sword which deals {p.AmountOfDamage} amount of damage ");
                        Console.WriteLine($"The monster has  now a health level of  {lMonster.Health}");
                        Random rand = new Random();
                        int monsterDamage = amountOfDamage + rand.Next(5, 6);
                        p.Health -= monsterDamage;
                        p.TotalPlayerGold += lMonster.Loot;
                        Console.WriteLine($"the monster fights back! you have now a\nhealth level of {p.Health}\nTotal amount of gold:{p.TotalPlayerGold}");
                        System.Threading.Thread.Sleep(700);
                        Console.ResetColor();
                        Console.ReadLine();

                        break;


                    case "d":
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("The monster attacks you");
                        Console.WriteLine($" you  block the  attack with your  arms\n");
                        Console.ResetColor();
                        Random ran = new Random();
                        monsterDamage = (ran.Next(1, 6) * amountOfDamage);
                        p.Health -= monsterDamage;
                        Console.WriteLine($"you have now a health level of { p.Health}");
                        Console.WriteLine($"the monster has a health level of { lMonster.Health}");
                        Console.ReadLine();

                        break;
                    case "r":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(" says, 'LOL NOPE' and you must remain on the battlefield.\n");
                        Console.ResetColor();
                        Console.WriteLine("Ok, you can buy weapon then");
                        Console.ReadKey();
                        Console.Clear();
                        Game.BuyWeapons();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;

                }

            }
            while (p.Health > 0 && lMonster.Health > 0);
            if (p.Health <= 0 && lMonster.Health > 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($" you died  died! GG NO RE\n");
                p.TotalPlayerGold -= lMonster.Loot;
                Console.ResetColor();
                Console.WriteLine("press any key to play again");
                Console.ReadKey();
                Console.Clear();
                GameMenu.StartProgram();
            }
            else if (lMonster.Health == 0 && p.Health == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("It was a tie!");
                Console.ResetColor();

            }
            else if (lMonster.Health <= 0 && (p.Health > 0))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Wow,You have nailed it!!! you win the final level,Congratulations. ");
                Console.WriteLine($"you have now {p.TotalPlayerGold} total gold and {p.Health} health level");
                Console.ResetColor();
                //Console.ReadKey();
                Console.WriteLine("press any key to play again");
                Console.ReadKey();
                Console.Clear();
                GameMenu.StartProgram();

               
                

            }

        }

        public static void FightLargeMonsterAxe()
        {
            Player p = new Player(characterName, characterAge);
            Monster lMonster = new Monster("M", 150, 9, 120);
            int AxeAmountOfDamage = 30;
            Console.Write("As you walk through the forest,the Monster appears from the shadows this time a larger one ");
            do
            {
                Console.WriteLine($" you have now health level of { p.Health}");
                Console.WriteLine($"The monster has health level of { lMonster.Health}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("press A to attack, D to defend yourself, or  R to run>\n");
                string PlayersChoice = Console.ReadLine();
                Console.ResetColor();
                switch (PlayersChoice)
                {
                    case "a":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                       
                        Random r = new Random();
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "\\swordecho.wav");
                        player.Play();
                        p.AmountOfDamage = AxeAmountOfDamage + r.Next(5, 14);
                        lMonster.Health -= p.AmountOfDamage;
                        Console.WriteLine($"you have just attack the monster with a sword which deals {AxeAmountOfDamage} amount of damage ");
                        Console.WriteLine($"The monster has  now a health level of  {lMonster.Health}");
                        Random rand = new Random();
                        int monsterDamage = amountOfDamage + rand.Next(3, 5);
                        p.Health -= monsterDamage;
                        p.TotalPlayerGold += lMonster.Loot;
                        Console.WriteLine($"the monster fights back! you have now a\nhealth level of {p.Health}\nTotal amount of gold:{p.TotalPlayerGold}");
                        System.Threading.Thread.Sleep(700);
                        Console.ResetColor();
                        Console.ReadLine();

                        break;


                    case "d":
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("The monster attacks you");
                        Console.WriteLine($" you  block the  attack with your  arms\n");
                        Console.ResetColor();
                        Random ran = new Random();
                        monsterDamage = (ran.Next(1, 6) * amountOfDamage);
                        p.Health -= monsterDamage;
                        Console.WriteLine($"you have now a health level of { p.Health}");
                        Console.WriteLine($"the monster has a health level of { lMonster.Health}");
                        Console.ReadLine();

                        break;
                    case "r":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(" says, 'LOL NOPE' and you must remain on the battlefield.\n");
                        Console.ResetColor();
                        Console.WriteLine("Ok, you can buy weapon then");
                        Console.ReadKey();
                        Console.Clear();
                        Game.BuyWeapons();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;

                }

            }
            while (p.Health > 0 && lMonster.Health > 0);
            if (p.Health <= 0 && lMonster.Health > 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($" you died  died! GG NO RE\n");
                p.TotalPlayerGold -= lMonster.Loot;
                Console.ResetColor();
                Console.WriteLine("press any key to play again");
                Console.ReadKey();
                Console.Clear();
                GameMenu.StartProgram();
            }
            else if (lMonster.Health == 0 && p.Health == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("It was a tie!");
                Console.ResetColor();

            }
            else if (lMonster.Health <= 0 && (p.Health > 0))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Wow,You have nailed it!!! you win the final level,Congratulations. ");
                Console.WriteLine($"you have now {p.TotalPlayerGold} total gold and {p.Health} health level");
                Console.ResetColor();               
                Console.WriteLine("press any key to play again");
                Console.ReadKey();
                Console.Clear();
                GameMenu.StartProgram();

            }

        }

        public static void FightLargeMonsterMace()
        {
            Player p = new Player(characterName, characterAge);
            Monster lMonster = new Monster("M", 150, 9, 120);
            int MaceAmountOfDamage= 50;
            Console.Write("As you walk through the forest ,the Monster appears from the shadows this time a larger one");
            do
            {
                Console.WriteLine($"you have now health level of { p.Health}");
                Console.WriteLine($"The monster has health level of { lMonster.Health}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("press A to attack, D to defend yourself, or  R to run>\n");
                string PlayersChoice = Console.ReadLine();
                Console.ResetColor();
                switch (PlayersChoice)
                {
                    case "a":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                       
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "\\swordecho.wav");
                        player.Play();
                        Random r = new Random();
                        p.AmountOfDamage = MaceAmountOfDamage + r.Next(4, 12);
                        lMonster.Health -= p.AmountOfDamage;
                        Console.WriteLine($"you have just attack the monster with a sword which deals {p.AmountOfDamage} amount of damage ");
                        Console.WriteLine($"The monster has  now a health level of  {lMonster.Health}");
                        Random rand = new Random();
                        int monsterDamage = amountOfDamage + rand.Next(4, 8);
                        p.Health -= monsterDamage;
                        p.TotalPlayerGold += lMonster.Loot;
                        Console.WriteLine($"the monster fights back! you have now a\nhealth level of {p.Health}\nTotal amount of gold:{p.TotalPlayerGold}");
                        System.Threading.Thread.Sleep(700);
                        Console.ResetColor();
                        Console.ReadLine();

                        break;


                    case "d":
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("The monster attacks you");
                        Console.WriteLine($" you  block the  attack with your  arms\n");
                        Console.ResetColor();
                        Random ran = new Random();
                        monsterDamage = (ran.Next(1, 6) * amountOfDamage);
                        p.Health -= monsterDamage;
                        Console.WriteLine($"you have now a health level of { p.Health}");
                        Console.WriteLine($"the monster has a health level of { lMonster.Health}");
                        Console.ReadLine();

                        break;
                    case "r":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(" says, 'LOL NOPE' and you must remain on the battlefield.\n");
                        Console.ResetColor();
                        Console.WriteLine("Ok, you can buy weapon then");
                        Console.ReadKey();
                        Console.Clear();
                        Game.BuyWeapons();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;

                }

            }
            while (p.Health > 0 && lMonster.Health > 0);
            if (p.Health <= 0 && lMonster.Health > 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($" you died  died! GG NO RE\n");
                p.TotalPlayerGold -= lMonster.Loot;
                Console.ResetColor();
            }
            else if (lMonster.Health == 0 && p.Health == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("It was a tie!");
                Console.ResetColor();

            }
            else if (lMonster.Health <= 0 && (p.Health > 0))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Wow,You have nailed it!!! you win the final level,Congratulations. ");
                Console.WriteLine($"you have now {p.TotalPlayerGold} total gold and {p.Health} health level");
                Console.ResetColor();
                Console.WriteLine("press any key to play again");
                Console.ReadKey();
                Console.Clear();              
                GameMenu.StartProgram();
               


            }




        }

        


      

      

       
      

    }
}







