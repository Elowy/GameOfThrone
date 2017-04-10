using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfTheThrone.Game
{
    class LootBox
    {
        public static void Pre_LootBox_Screen()
        {
            Console.Clear();
            string[] tips =
            {
                "Open your Loot Box and see the surprises inside.",
                "What can be found in a loot box? Open it and find out.",
                "The Loot Boxes can be bought or can be claimed after fights.",
                "Each loot box has limited 1 item inside!"
            };
            LootBox_Separating_Screen();
        }

        private static void LootBox_Separating_Screen()
        {
            if (Program.LootBox >= 1)
            {
                Console.WriteLine(
                    "You have got {0} Loot Box Avaliable. Press Space for open it, or Escape to Quit Main Menu.");
                var info = Console.ReadKey();
                switch (info.Key)
                {
                    case ConsoleKey.Spacebar:
                        Console.Clear();
                        LootBox_Opening_Screen();
                        break;
                    default:
                        Console.Clear();
                        Program.Pre_Main_Menu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("You does not have any Loot Box avaliable.\nFight in Quick Play to Obtain or buy some in the Store.");
                System.Threading.Thread.Sleep(4000);
                Console.Clear();
                Program.Pre_Main_Menu();
            }
        }

        private static void LootBox_Opening_Screen()
        {
            Console.WriteLine("The Loot Box contains:");
            Program.LootBox--;
            var rnd = new Random();
            int cub1 = rnd.Next(1, 11);
            int cub2 = rnd.Next(1, 11);
            int cub3 = rnd.Next(1, 11);
            int fin = cub1 + cub2 + cub3;
            int RarityOfChest = 0;
            if (fin <= 10)
            {
                Console.WriteLine("This Loot Box is Empty.");
                System.Threading.Thread.Sleep(4000);
                Console.Clear();
                Program.Pre_Main_Menu();
            }
            else if (fin <= 20) {RarityOfChest =1;}
            else if (fin <= 29) {RarityOfChest =2;}
            else if (fin == 30) {RarityOfChest =3;}
            /*
             * 1. Loot Box
             * 2. Shield
             * 3. Resurrection Stone
             * 4. Health Potion
             * 5. Experience (0-50)
             */
            for (var i = 0; i <= RarityOfChest; i++)
            {
                Console.WriteLine();
            }
    
        }
    }
}
