using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfTheThrone.Game
{
    class StoreMain
    {
        private static bool FreeResurrection = false;
        private static double ShieldCost = 8;
        private static double ArmorCost = 10;
        private static double SwordCost = 20;
        private static double ResurrectionStoneCost = 2*GameOne.Level;
        private static double HealthPotionCost = 30;
        private static string Tipquote;
        private static double LootBoxCost = 150;

        public static void Pre_Store_Screen()
        {
            Console.Clear();
            string[] tips =
            {
                "Spend your Gold wisely to armor don't level up your Sword fast.",
                "Always save some gold for future Resurrections!",
                "Open Loot Box often to get awesome Goods.",
                "Fight often in Quick Play to get a lot of gold.",
                "Experience boundle is worth but it cost a lot of Gold.",
                "If you have some money in your pocket buy Resurrection Stone.",
                "Gold can be obtained from Quick Play, Story mode, and from chests.",
                "Buy Shield only if you have to face aganist a boss!",
                "Bosses are stronger than usual enemies.",
                "Health Potion is only once can be activated in a fight."
            };
            var rnd = new Random();
            Tipquote = tips[rnd.Next(0, tips.Length - 1)];
            Store_Screen();
        }

        private static void Store_Screen()
        {
            Console.Clear();
            Console.WriteLine("Tip: '{0}'\n", Tipquote);
            Console.WriteLine("Gold: {0} | Exp: {1}/{2}. Current Level: {3}.\n", GameOne.Money, GameOne.Experience, GameOne.ExperienceReqUired, GameOne.Level);
            Console.WriteLine("Purchase Armor              - A - Costs: {0}{1}", ArmorCost, Program.g);
            Console.WriteLine("Purchase Shield             - S - Costs: {0}{1}", ShieldCost, Program.g);
            Console.WriteLine("Purchase Sword              - R - Costs: {0}{1}", SwordCost, Program.g);
            Console.WriteLine("Purchase Health Potion      - H - Costs: {0}{1}", HealthPotionCost, Program.g);
            Console.WriteLine("Purchase Resurrection Stone - E - Costs: {0}{1}", ResurrectionStoneCost, Program.g);
            Console.WriteLine("Purchase Loot Box           - L - Costs: {0}{1}", LootBoxCost, Program.g);
            if (FreeResurrection == false && Program.Alive == false)
            {
                Console.WriteLine("Free Resurrection           - B");
            }
            Console.WriteLine("Return Main Menu            - M");
            ConsoleKeyInfo info = Console.ReadKey();
            switch (info.Key)
            {
                #region Armor
                case ConsoleKey.A:
                    Console.Clear();
                    Console.WriteLine("You currently have: {0} Armor.", GameOne.Armor);
                    Console.WriteLine("Next Armor Level Costs: {0} Gold, and Gives {1} Armor.", ArmorCost, 0.1*GameOne.Level);
                    Console.WriteLine("Press 'Space' for Purchase or Press 'Escape' to Return Shop Menu.");
                    var ninfo = Console.ReadKey();
                    if (GameOne.Money >= ArmorCost && ninfo.Key == ConsoleKey.Spacebar)
                    {
                        GameOne.Money -= ArmorCost;
                        GameOne.Armor += 0.1*GameOne.Level;
                        Console.WriteLine("You have purchased {0} Armor for {1}{2}.", 0.1 * GameOne.Level, ArmorCost, Program.g);
                        ArmorCost = (ArmorCost*1.3)*GameOne.Level;
                        System.Threading.Thread.Sleep(4000);
                        Pre_Store_Screen();
                    }
                    else if (GameOne.Money < ArmorCost && ninfo.Key == ConsoleKey.Spacebar)
                    {
                        Console.Clear();
                        Console.WriteLine("You dont have enough Gold.");
                        Console.WriteLine("You currently have: {0}{1}. Price for Level Up: {2}{3}.", GameOne.Money, Program.g, ArmorCost, Program.g);
                        System.Threading.Thread.Sleep(4000);
                        Pre_Store_Screen();
                    }
                    else
                    {
                        Pre_Store_Screen();
                    }
                    break;
                #endregion
                #region Shield
                case ConsoleKey.S:
                    Console.Clear();
                    Console.WriteLine("You currently have: {0} Shield.", GameOne.Shield);
                    Console.WriteLine("Next Shield Costs: {0} Gold, and Gives {1} Shield.", ShieldCost, 3 * GameOne.Level);
                    Console.WriteLine("Press 'Space' for Purchase or Press 'Escape' to Return Shop Menu.");
                    var qinfo = Console.ReadKey();
                    if (GameOne.Money >= ShieldCost && qinfo.Key == ConsoleKey.Spacebar)
                    {
                        GameOne.Money -= ShieldCost;
                        GameOne.Shield += 3 * GameOne.Level;
                        Console.WriteLine("You have purchased {0} Shield for {1}{2}.", 3 * GameOne.Level, ShieldCost, Program.g);
                        ShieldCost = (ShieldCost*1.1) * GameOne.Level;
                        System.Threading.Thread.Sleep(4000);
                        Pre_Store_Screen();
                    }
                    else if (GameOne.Money < ShieldCost && qinfo.Key == ConsoleKey.Spacebar)
                    {
                        Console.Clear();
                        Console.WriteLine("You dont have enough Gold.");
                        Console.WriteLine("You currently have: {0}{1}. Price for Level Up: {2}{3}.", GameOne.Money, Program.g, ShieldCost, Program.g);
                        System.Threading.Thread.Sleep(4000);
                        Pre_Store_Screen();
                    }
                    else
                    {
                        Pre_Store_Screen();
                    }
                    break;
                #endregion
                #region Sword
                case ConsoleKey.R:
                    Console.Clear();
                    Console.WriteLine("Your Sword is now at Level: {0}", GameOne.SwordLevel);
                    Console.WriteLine("Next Sword Level Costs {0} Gold, and Gives 1 Sword Level.", SwordCost);
                    Console.WriteLine("Press 'Space' for Purchase or Press 'Escape' to Return Shop Menu.");
                    var winfo = Console.ReadKey();
                    if (GameOne.Money >= SwordCost && winfo.Key == ConsoleKey.Spacebar)
                    {
                        GameOne.Money -= SwordCost;
                        GameOne.SwordLevel++;
                        Console.WriteLine("You have purchased Sword Level {0} for {1}{2}.",GameOne.SwordLevel, SwordCost, Program.g);
                        SwordCost = (SwordCost*1.5)*GameOne.Level;
                        System.Threading.Thread.Sleep(4000);
                        Pre_Store_Screen();
                    }
                    else if (GameOne.Money < SwordCost && winfo.Key == ConsoleKey.Spacebar)
                    {
                        Console.Clear();
                        Console.WriteLine("You dont have enough Gold.");
                        Console.WriteLine("You currently have: {0}{1}. Price for Level Up: {2}{3}.", GameOne.Money, Program.g, SwordCost, Program.g);
                        System.Threading.Thread.Sleep(4000);
                        Pre_Store_Screen();
                    }
                    else
                    {
                        Pre_Store_Screen();
                    }
                    break;
                #endregion
                #region HealthPotion
                case ConsoleKey.H:
                    Console.Clear();
                    Console.WriteLine("You currently Have {0} Health Potion.", GameOne.HealthPotion);
                    Console.WriteLine("Purchasing a Health Potion costs {0}{1}", HealthPotionCost, Program.g);
                    Console.WriteLine("Press 'Space' for Purchase or Press 'Escape' to Return Shop Menu.");
                    var einfo = Console.ReadKey();
                    if (GameOne.Money >= HealthPotionCost && einfo.Key == ConsoleKey.Spacebar)
                    {
                        GameOne.Money -= HealthPotionCost;
                        GameOne.HealthPotion++;
                        Console.WriteLine("You have purchased Health Potion 1x for {0}{1}.", HealthPotionCost, Program.g);
                        HealthPotionCost = (HealthPotionCost*1.1)*GameOne.Level;
                        System.Threading.Thread.Sleep(4000);
                        Pre_Store_Screen();
                    }
                    else if (GameOne.Money < HealthPotionCost && einfo.Key == ConsoleKey.Spacebar)
                    {
                        Console.Clear();
                        Console.WriteLine("You dont have enough Gold.");
                        Console.WriteLine("You currently have: {0}{1}. Price of an Health Potion: {2}{3}.", GameOne.Money, Program.g, HealthPotionCost, Program.g);
                        System.Threading.Thread.Sleep(4000);
                        Pre_Store_Screen();
                    }
                    else
                    {
                        Pre_Store_Screen();
                    }
                    break;
                #endregion
                #region ResurrectionStone
                case ConsoleKey.E:
                    Console.Clear();
                    Console.WriteLine("You currently Have {0} Resurrection Stone.", GameOne.ResurrectionStone);
                    Console.WriteLine("Purchasing a Resurrection Stone costs {0}{1}", ResurrectionStoneCost, Program.g);
                    Console.WriteLine("Press 'Space' for Purchase or Press 'Escape' to Return Shop Menu.");
                    var rinfo = Console.ReadKey();
                    if (GameOne.Money >= ResurrectionStoneCost && rinfo.Key == ConsoleKey.Spacebar)
                    {
                        GameOne.Money -= ResurrectionStoneCost;
                        GameOne.ResurrectionStone++;
                        Console.WriteLine("You have purchased Resurrection Stone 1x for {0}{1}.", ResurrectionStoneCost, Program.g);
                        ResurrectionStoneCost = 2*GameOne.Level;
                        System.Threading.Thread.Sleep(4000);
                        Pre_Store_Screen();
                    }
                    else if (GameOne.Money < HealthPotionCost && rinfo.Key == ConsoleKey.Spacebar)
                    {
                        Console.Clear();
                        Console.WriteLine("You dont have enough Gold.");
                        Console.WriteLine("You currently have: {0}{1}. Price of a Resorrection Stone: {2}{3}.", GameOne.Money, Program.g, ResurrectionStoneCost, Program.g);
                        System.Threading.Thread.Sleep(4000);
                        Pre_Store_Screen();
                    }
                    else
                    {
                        Pre_Store_Screen();
                    }
                    break;
                #endregion
                #region LootBox
                case ConsoleKey.L:
                    Console.Clear();
                    Console.WriteLine("You currently Have {0} Loot Box.", Program.LootBox);
                    Console.WriteLine("Purchasing a Loot Box costs {0}{1}", LootBoxCost, Program.g);
                    Console.WriteLine("Press 'Space' for Purchase or Press 'Escape' to Return Shop Menu.");
                    var tinfo = Console.ReadKey();
                    if (GameOne.Money >= LootBoxCost && tinfo.Key == ConsoleKey.Spacebar)
                    {
                        GameOne.Money -= LootBoxCost;
                        Program.LootBox++;
                        Console.WriteLine("You have purchased Loot Box 1x for {0}{1}.", LootBoxCost, Program.g);
                        LootBoxCost = 1.5*LootBoxCost;
                        System.Threading.Thread.Sleep(4000);
                        Pre_Store_Screen();
                    }
                    else if (GameOne.Money < LootBoxCost && tinfo.Key == ConsoleKey.Spacebar)
                    {
                        Console.Clear();
                        Console.WriteLine("You dont have enough Gold.");
                        Console.WriteLine("You currently have: {0}{1}. Price of a Loot Box: {2}{3}.", GameOne.Money, Program.g, LootBoxCost, Program.g);
                        System.Threading.Thread.Sleep(4000);
                        Pre_Store_Screen();
                    }
                    else
                    {
                        Pre_Store_Screen();
                    }
                    break;
                #endregion
                #region ExitMenu
                case ConsoleKey.M:
                    Console.Clear();
                    Program.Pre_Main_Menu();
                    break;
                #endregion
                #region Freeresurrection
                case ConsoleKey.B:
                    Console.WriteLine("You will be resurrected Soon, please hold on. This feature can not be used after this resurrection.");
                    Program.Alive = true;
                    FreeResurrection = true;
                    System.Threading.Thread.Sleep(4000);
                    Pre_Store_Screen();
                    break;
                #endregion
                default:
                    Console.Clear();
                    Pre_Store_Screen();
                    break;
            }
        }
    }
}
