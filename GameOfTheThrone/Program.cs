using System;
using System.Security.Policy;
using GameOfTheThrone.Tutorial;
using GameOfTheThrone.Game;

namespace GameOfTheThrone
{
    internal class Program
    {
        public static string HeroName;
        public static int MoneyMultiplier = 1;
        public static int ExperienceMultiplier = 1;
        private static string HeroQuote;
        public static char g =  'g';
        public static bool Alive = true;
        public static int LootBox;
        private static string versionNumber = "0.1";
        private static string versionDescription = "Quick Play and Resurrection avaliable.";

        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome in the Game of Throne, please enter your Hero Name.\n");
            Console.Write("Name your Hero: ");
            HeroName = Convert.ToString(Console.ReadLine());
            //program.Start_Menu();
            GameOne.Set_Up_Data();
        }

        public void Start_Menu()
        {
            Console.WriteLine(
                "In this Game you have to conquer the throne.\nBe avare there are many strange enemyes to face!");
            Console.WriteLine("Press 'Space' to play the tutorial battle.");
            TutorialFight tutorial = new TutorialFight();
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.Spacebar)
            {
                tutorial.TutorialInformation();
            }
            else
            {
                tutorial.TutorialInformation();
            }
        }

        public static void Pre_Main_Menu()
        {
            //Takes to the Quote Generator to awoid Loops.
            var p = new Program();
            p.QuoteGenerator();
        }

        public static void Main_Menu()
        {
            var p = new TutorialFight();
            Console.WriteLine("Version: {0} | Version Details: {1}", versionNumber, versionDescription);
            Console.WriteLine("Quotes from the Past: '" + HeroQuote + "'\n");
            Console.WriteLine("Gold: {0} | Exp: {1}/{2}. Current Level: {3}.\n", GameOne.Money, GameOne.Experience, GameOne.ExperienceReqUired, GameOne.Level);
            Console.WriteLine("Story Mode   - 'S' -     Under Devlopment");
            Console.WriteLine("Quick Play   - 'Q' -     Accessable");
            Console.WriteLine("Shop         - 'B' -     Accessable");
            Console.WriteLine("Information  - 'I' -     Accessable");
            Console.WriteLine("Tutorial     - 'T' -     Accessable");
            Console.WriteLine("Stash        - 'Space' - Under Devlopment");
            if (Alive == false)
            {
                Console.WriteLine("Resurrection - 'R' -     Accessable");
            }
            Console.WriteLine("Settings     - 'U' -     Accessable");
            Console.WriteLine("Quit Game    - 'Tab' -   Accessable");
            ConsoleKeyInfo info = Console.ReadKey();
            switch (info.Key)
            {
                case ConsoleKey.U: //Settings
                    Console.Clear();
                    Program.Settings();
                    break;
                case ConsoleKey.T: //Tutorial
                    if (Alive == true)
                    {
                        Console.Clear();
                        p.TutorialInformation();
                    }
                    else
                    {
                        Console.Clear();
                        Pre_Main_Menu();
                    }
                    break;
                case ConsoleKey.Tab: //Quit
                    Console.Clear();
                    break;
                case ConsoleKey.Q: //Quick Play
                    if (Alive == true)
                    {
                        Console.Clear();
                        GameOne.GameStart();
                    }
                    else
                    {
                        Console.Clear();
                        Pre_Main_Menu();
                    }
                    break;
                case ConsoleKey.B: //Shop
                    Console.Clear();
                    StoreMain.Pre_Store_Screen();
                    break;
                case ConsoleKey.I: //Information
                    Console.Clear();
                    Program.Informations();
                    break;
                case ConsoleKey.S: //Story Mode
                    Console.Clear();
                    StoreMain.Pre_Store_Screen();
                    break;
                case ConsoleKey.Spacebar: //LootBox
                    Console.Clear();
                    Game.LootBox.Pre_LootBox_Screen();
                    break;
                default:
                    if (Alive == false && info.Key == ConsoleKey.R)
                    {
                        Resurrection();
                    }
                    else
                    {
                        Console.Clear();
                        Pre_Main_Menu();
                    }
                    break;
            }
        }

        private void QuoteGenerator()
        {
            string[] quotes =
            {
                "A good hero known as helping others with no requested goods.",
                "The Grand Wizard said once: If you please someone he'll actually help.",
                "The City of Nargalor always welcomes any hero who passes by it!",
                "The Heroes Stuedied at the Halls of Gremhlyr.",
                "The Greatest known Hero of Nargalor is Ragnar Vazellhall.",
                "The King of Nargalor is Knoghdar Helix the II.", "The Grand Library in Nargalor is the Pixen Loth'Brok",
                "Orcs, the greatest enemies of the Valkurn Empire.",
                "In Pixen Loth'Brok there are thousands of millions of books are stored.",
                "The Worlds of the Royal Brewery: Arise Beer Arise!"
            };
            var rnd = new Random();
            HeroQuote = quotes[rnd.Next(0, quotes.Length - 1)];
            Console.Clear();
            Program.Main_Menu();
        }

        private static void Settings()
        {
            Console.Clear();
            Console.Write("Hero Name: " + HeroName);
            Console.Write("\nMoney Multiplier: " + MoneyMultiplier);
            Console.Write("\nExperience Multiplier: " + ExperienceMultiplier);
            Console.Write("\nPlease Enter Hero Name: ");
            HeroName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Warning the maximum value of Money Multiplier is 5.");
            Console.Write("Please Enter Money Multiplier: ");
            MoneyMultiplier = Convert.ToInt32(Console.ReadLine());
            if (MoneyMultiplier > 5)
            {
                MoneyMultiplier = 5;
            }
            Console.WriteLine("Warning the maximum value of Experience Multiplier is 5.");
            Console.Write("Please Enter Experience Multiplier: ");
            ExperienceMultiplier = Convert.ToInt32(Console.ReadLine());
            if (ExperienceMultiplier > 5)
            {
                ExperienceMultiplier = 5;
            }
            Program.Pre_Main_Menu();
        }

        private static void Informations()
        {
            Console.WriteLine("About Armor - 'A'");
            Console.WriteLine("About Shield - 'S'");
            Console.WriteLine("About Sword - 'W'");
            Console.WriteLine("About Gold - 'M'");
            Console.WriteLine("About Experience - 'E'");
            Console.WriteLine("About Levels - 'L'");
            Console.WriteLine("Return to Main Menu - 'Escape'");
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.A)
            {
                Console.Clear();
                Program.Info_Armor();
            }
            else if (info.Key == ConsoleKey.S)
            {
                Console.Clear();
                Program.Info_Shield();
            }
            else if (info.Key == ConsoleKey.W)
            {
                Console.Clear();
                Program.Info_Sword();
            }
            else if (info.Key == ConsoleKey.M)
            {
                Console.Clear();
                Program.Info_Money();
            }
            else if (info.Key == ConsoleKey.E)
            {
                Console.Clear();
                Program.Info_Experience();
            }
            else if (info.Key == ConsoleKey.L)
            {
                Console.Clear();
                Program.Info_Level();
            }
            else if (info.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Program.Pre_Main_Menu();
            }
            else
            {
                Console.Clear();
                Program.Informations();
            }

        }

        private static void Info_Armor()
        {
            Console.WriteLine(
                "The armor reduces damage if you level this up, the armor will become stronger.\nLevel up armor in the store it will cost some Money. But it's worth!");
            Console.WriteLine("Press 'Space' to return Informations\nPress 'Escape' to return Main Menu");
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                Program.Informations();
            }
            else if (info.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Program.Pre_Main_Menu();
            }
            else
            {
                Console.Clear();
                Program.Info_Armor();
            }
        }

        private static void Info_Shield()
        {
            Console.WriteLine(
                "Shield is an extra Health Point and it can be bought in the store the maximum shield is 100. And can be obtained after fights.\nIf you have got shield it will be damaged first before Health Points.");
            Console.WriteLine("Press 'Space' to return Informations\nPress 'Escape' to return Main Menu");
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                Program.Informations();
            }
            else if (info.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Program.Pre_Main_Menu();
            }
            else
            {
                Console.Clear();
                Program.Info_Shield();

            }
        }

        private static void Info_Sword()
        {
            Console.WriteLine(
                "The sword determines how much damage you deal with your attacks, can be purchased higher sword levels in the Store.");
            Console.WriteLine("Press 'Space' to return Informations\nPress 'Escape' to return Main Menu");
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                Program.Informations();
            }
            else if (info.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Program.Pre_Main_Menu();
            }
            else
            {
                Console.Clear();
                Program.Info_Sword();

            }
        }

        private static void Info_Money()
        {
            Console.WriteLine("The Gold is gained from slaining enemies or opening loot boxes after slaining enemies.\nIt can be spend in the Store.");
            Console.WriteLine("Press 'Space' to return Informations\nPress 'Escape' to return Main Menu");
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                Program.Informations();
            }
            else if (info.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Program.Pre_Main_Menu();
            }
            else
            {
                Console.Clear();
                Program.Info_Money();

            }
        }

        private static void Info_Experience()
        {
            Console.WriteLine("Excperience is awarded after slaining enemies after you have gained enough you level up and your damage incrased!");
            Console.WriteLine("Press 'Space' to return Informations\nPress 'Escape' to return Main Menu");
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                Program.Informations();
            }
            else if (info.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Program.Pre_Main_Menu();
            }
            else
            {
                Console.Clear();
                Program.Info_Experience();

            }
        }

        private static void Info_Level()
        {
            Console.WriteLine("The levels is determined how far you have gotten inthis game, you gain levels after you have slained enough enemies.");
            Console.WriteLine("Press 'Space' to return Informations\nPress 'Escape' to return Main Menu");
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                Program.Informations();
            }
            else if (info.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Pre_Main_Menu();
            }
            else
            {
                Console.Clear();
                Program.Info_Level();

            }
        }

        private static void Resurrection()
        {
            string[] quotes =
            {
                "The spirit healer looks at you and your heart has started beat.",
                "You feel thousands of lost soul around you and you see the light...",
                "The light brings you home. 'A sound from beyond...'",
                "You have a work to do in the World Arise!",
                "The last thing you have remember is the final blow of the enemy.",
                "You found a dark corner of the universe or what is that?"
            };
            var rnd = new Random();
            var quote = quotes[rnd.Next(0, quotes.Length - 1)];
            Console.WriteLine(quote);
            Console.WriteLine("\nYou are dead, and you are not eligable to fight until you have resurrect!\nThe resurrection will cost {0} Gold.", 2*GameOne.Level);
            Console.WriteLine("Press 'Space' for Resurrection or Press 'Escape' to view Main Menu.");
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.Spacebar && GameOne.Money >= 2*GameOne.Level)
            {
                GameOne.Money -= 2*GameOne.Level;
                Console.Clear();
                Alive = true;
                Pre_Main_Menu();
            }
            else if (info.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Pre_Main_Menu();
            }
            else if (info.Key == ConsoleKey.Spacebar && GameOne.Money < 2*GameOne.Level)
            {
                Console.WriteLine("You does not have enough Gold for resurrection.");
                Console.WriteLine("Ask the shopmaster for free resurrection. (Only once this option is avaliable.)");
                System.Threading.Thread.Sleep(5000);
                Console.Clear();
                Pre_Main_Menu();
            }
            else
            {
                Console.Clear();
                Resurrection();
            }
        }
    }
}
