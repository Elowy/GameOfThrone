using System;
using System.ComponentModel;


namespace GameOfTheThrone.Game
{
    class GameOne
    {
        public static double Armor;
        public static double Shield;
        static double PlayerHealth;
        static double EnemyHealth;
        public static double SwordLevel;
        public static double Money;
        public static double Experience;
        public static double ExperienceReqUired = 350;
        public static int Level;
        static string EnemyName;
        static double EnemyArmor;
        static int PlayerStance;
        static int EnemyStance;
        static int HitsDone = 0;
        static int EnemyHitsDone = 0;
        static double MaxEnemyHealth;
        static int EnemyLevel;
        static double MaxPlayerHealth;
        public static int HealthPotion;
        public static int ResurrectionStone;

        public static void Set_Up_Data()
        {
            Armor = 0;
            SwordLevel = 1;
            Money = 10;
            Experience = 0;
            Level = 1;
            HitsDone = 0;
            Program.Pre_Main_Menu();
        }

        public static void GameStart()
        {
            Console.Clear();
            if (Program.Alive == true)
            {
                GameOne.NameGeneration();
            }
            else
            {
                Program.Pre_Main_Menu();
            }
        }

        private static void NameGeneration()
        {
            string[] enemyNames =
            {
                "Tondak'h Valdo",
                "Prequar Felix",
                "Miss Taylor",
                "Ork Savager",
                "Millin Grayhoof",
                "Granduk Hel'Do",
                "Dothar",
                "The Chest",
                "The Mighty Hunter",
                "Ork Warrior",
                "Ork Hunter",
                "Sea-Monster",
                "Cecyl the Night Hunter",
                "Fenrir the Howler",
                "Ork Leader",
                "Ork Rogue",
                "Wolf of the Night",
                "Bambaalian Tiger",
                "Ernand the Hero",
                "Miss Grando",
                "Xelophil the Wich",
                "The Chest",
                "The Loot Box",
                "The Mystical Sachel"
            };
            var rnd = new Random();
            EnemyName = enemyNames[rnd.Next(0, enemyNames.Length - 1)];
            Console.Clear();
            GameOne.EnemyGeneration();
        }

        private static void EnemyGeneration()
        {
            var rnd = new Random();
            var enemyArmorA1 = new double[5] {0.01, 0.02, 0.03, 0.04, 0.05};
            var enemyArmorA2 = new double[5] {0.06, 0.07, 0.08, 0.09, 0.1};
            var enemyArmorA3 = new double[5] {0.11, 0.12, 0.13, 0.14, 0.15};
            var enemyArmorA4 = new double[5] {0.16, 0.17, 0.18, 0.19, 0.2};
            var enemyArmorA5 = new double[5] {0.21, 0.22, 0.23, 0.24, 0.25};

            if (Level == 1)
            {
                EnemyArmor = enemyArmorA1[rnd.Next(0, enemyArmorA1.Length - 1)];
            }
            else if (Level == 2)
            {
                EnemyArmor = enemyArmorA2[rnd.Next(0, enemyArmorA2.Length - 1)];
            }
            else if (Level == 3)
            {
                EnemyArmor = enemyArmorA3[rnd.Next(0, enemyArmorA3.Length - 1)];
            }
            else if (Level == 4)
            {
                EnemyArmor = enemyArmorA4[rnd.Next(0, enemyArmorA4.Length - 1)];
            }
            else if (Level == 5)
            {
                EnemyArmor = enemyArmorA5[rnd.Next(0, enemyArmorA5.Length - 1)];
            }
            else
            {
                EnemyArmor = enemyArmorA5[rnd.Next(0, enemyArmorA1.Length - 1)] * 2 * Level;
            }

            EnemyHealth = Level*10*SwordLevel;
            PlayerHealth = Level*10*SwordLevel;
            MaxEnemyHealth = EnemyHealth;
            MaxPlayerHealth = PlayerHealth;
            EnemyLevel = Level;
            Console.WriteLine("The Current enemy is {0} who has got {1} Health prepare yourself!", EnemyName, EnemyHealth);
            System.Threading.Thread.Sleep(3000);
            GameOne.Player_Turn();
        }

        static void Player_Turn()
        {
            Console.Clear();
            Console.WriteLine("{4} health: {0}/{1} | {5} health: {2}/{3}", PlayerHealth, MaxPlayerHealth, EnemyHealth, MaxEnemyHealth, Program.HeroName, EnemyName);
            //Declaring things.
            double rdamage = 0;
            double damage = 0;
            double stance_DamageReduction = 0;
            var damageCategory = 0;
            #region Damage Numbers and estetical
            //damage numbers separated by the level of the Hero
            var damageNumbers = new double[6, 5]
            {
                {0.1, 0.15, 0.2, 0.25, 0.3}, // 1-5
                {0.4, 0.45, 0.5, 0.55, 0.6}, // 6-10
                {0.7, 0.75, 0.8, 0.85, 0.9}, // 10-13
                {1, 1.1, 1.2, 1.3, 1.4},     // 10-15
                {1.5, 1.6, 1.7, 1.8, 1.9},   // 16-17
                {2, 2.25, 2.5, 2.75, 3}      // 18
            };
            var stanceDamageReduction = new double[2, 5]
            {
                {0.01, 0.02, 0.03, 0.04, 0.05},
                {0.06, 0.07, 0.08, 0.09, 0.1 }
            };
            //Point demage this is just for the look a like.
            string[] damagepointer =
            {
                "brutally in the head.",
                "hardly in the head.",
                "strongly in the head.",
                "in the head.",
                "brutally in the face.",
                "hardly in the face.",
                "strongly in the face.",
                "in the face.",
                "brutally in the chest.",
                "hardly in the chest.",
                "strongly in the chest.",
                "in the chest.",
                "brutally in the body.",
                "hardly in the body.",
                "strongly in the body.",
                "in the body.",
                "where it hurts so much.",
                "where nobody hits.",
                "in the ass.",
                "to the legs.",
                "to the ankles.",
                "to the foot.",
                "to the arms",
                "to the shoulders"
            };
            #endregion
            #region Calculate-and-separate
            var rnd = new Random();
            //Damage pointer roll-out & Estetical.
            var damagepoint = damagepointer[rnd.Next(0, damagepointer.Length - 1)];
            //The Numbers of the 3x6 Cubes.
            var cub1 = rnd.Next(1, 7);
            var cub2 = rnd.Next(1, 7);
            var cub3 = rnd.Next(1, 7);
            //Final Result of the sum the 3x6 Cubes.
            var fin = cub1 + cub2 + cub3;
            //Enemy Stance roll-out.
            var maxenemyhalfhealth = MaxEnemyHealth/2;
            EnemyStance = EnemyHealth <= maxenemyhalfhealth ? 1 : rnd.Next(1, 3);
            //Def or Attack Stance.
            if (EnemyStance == 1)
            {
                Console.WriteLine("The Enemy has taken Defensive Stance.");
                System.Threading.Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("The Enemy has taken Attack Stance.");
                System.Threading.Thread.Sleep(1500);
            }
            //Damage Category separation.
            if (fin == 3) {damageCategory=13; }
            else if (fin <= 5 && EnemyStance == 1) {damageCategory=1; }
            else if (fin <= 10 && EnemyStance == 1) {damageCategory = 2; }
            else if (fin <= 13 && EnemyStance == 1) {damageCategory = 3; }
            else if (fin <= 15 && EnemyStance == 1) {damageCategory = 4; }
            else if (fin <= 17 && EnemyStance == 1) {damageCategory = 5; }
            else if (fin == 18 && EnemyStance == 1) {damageCategory = 6;}
            else if (fin <= 5) {damageCategory = 7; }
            else if (fin <= 10) {damageCategory = 8; }
            else if (fin <= 13) {damageCategory = 9; }
            else if (fin <= 15) {damageCategory = 10; }
            else if (fin <= 17) {damageCategory = 11; }
            else if (fin == 18) {damageCategory = 12; }
            else
            {
                Console.WriteLine("There is an error occured you will be returned to the beginning...");
                System.Threading.Thread.Sleep(2000);
                Program.Pre_Main_Menu();
            }
            #endregion
            #region Damage Calculation
            switch (damageCategory)
            {
                case 1:
                    stance_DamageReduction = stanceDamageReduction[0, rnd.Next(1, 5)];
                    rdamage = damageNumbers[0, rnd.Next(0, 5)];
                    damage = rdamage - stance_DamageReduction - EnemyArmor;
                    EnemyHealth -= damage * SwordLevel;
                    Console.WriteLine("{0} Suffered {1} damage ({2}) blocked, You hit {3}",EnemyName, damage, EnemyArmor + stance_DamageReduction, damagepoint);
                    Console.WriteLine("Damage Calculation method:\n Damage = ({0}(Damage) - {1}(Enemy armor) - {2} (Stance Damage Reduction) ) * {3} (Sword Level)"
                        , rdamage, EnemyArmor, stance_DamageReduction, SwordLevel);
                    HitsDone++;
                    System.Threading.Thread.Sleep(2000);
                        break;
                case 2:
                    stance_DamageReduction = stanceDamageReduction[0, rnd.Next(1, 5)];
                    rdamage = damageNumbers[1, rnd.Next(0, 5)];
                    damage = rdamage - stance_DamageReduction - EnemyArmor;
                    EnemyHealth -= damage * SwordLevel;
                    Console.WriteLine("{0} Suffered {1} damage ({2}) blocked, You hit {3}", EnemyName, damage, EnemyArmor+stance_DamageReduction, damagepoint);
                    Console.WriteLine("Damage Calculation method:\nDamage = ({0}(Damage) - {1}(Enemy armor) - {2} (Stance Damage Reduction) ) * {3} (Sword Level)"
                        , rdamage, EnemyArmor, stance_DamageReduction, SwordLevel);
                    System.Threading.Thread.Sleep(2000);
                    HitsDone++;
                        break;
                case 3:
                    stance_DamageReduction = stanceDamageReduction[0, rnd.Next(0, 5)];
                    rdamage = damageNumbers[2, rnd.Next(0, 5)];
                    damage = rdamage - stance_DamageReduction - EnemyArmor;
                    EnemyHealth -= damage * SwordLevel;
                    Console.WriteLine("{0} Suffered {1} damage ({2}) blocked, You hit {3}", EnemyName, damage, EnemyArmor + stance_DamageReduction, damagepoint);
                    Console.WriteLine("Damage Calculation method:\nDamage = ({0}(Damage) - {1}(Enemy armor) - {2} (Stance Damage Reduction) ) * {3} (Sword Level)"
                        , rdamage, EnemyArmor, stance_DamageReduction, SwordLevel);
                    System.Threading.Thread.Sleep(2000);
                    HitsDone++;
                        break;
                case 4:
                    stance_DamageReduction = stanceDamageReduction[0, rnd.Next(0, 5)];
                    rdamage = damageNumbers[3, rnd.Next(0, 5)];
                    damage = rdamage - stance_DamageReduction - EnemyArmor;
                    EnemyHealth -= damage * SwordLevel;
                    Console.WriteLine("{0} Suffered {1} damage ({2}) blocked, You hit {3}", EnemyName, damage, EnemyArmor + stance_DamageReduction, damagepoint);
                    Console.WriteLine("Damage Calculation method:\nDamage = ({0}(Damage) - {1}(Enemy armor) - {2} (Stance Damage Reduction) ) * {3} (Sword Level)"
                        , rdamage, EnemyArmor, stance_DamageReduction, SwordLevel);
                    System.Threading.Thread.Sleep(2000);
                    HitsDone++;
                        break;
                case 5:
                    stance_DamageReduction = stanceDamageReduction[0, rnd.Next(0, 5)];
                    rdamage = damageNumbers[4, rnd.Next(0, 5)];
                    damage = rdamage - stance_DamageReduction - EnemyArmor;
                    EnemyHealth -= damage * SwordLevel;
                    Console.WriteLine("{0} Suffered {1} damage ({2}) blocked, You hit {3}", EnemyName, damage, EnemyArmor + stance_DamageReduction, damagepoint);
                    Console.WriteLine("Damage Calculation method:\nDamage = ({0}(Damage) - {1}(Enemy armor) - {2} (Stance Damage Reduction) ) * {3} (Sword Level)"
                        , rdamage, EnemyArmor, stance_DamageReduction, SwordLevel);
                    System.Threading.Thread.Sleep(2000);
                    HitsDone++;
                        break;
                case 6:
                    stance_DamageReduction = stanceDamageReduction[0, rnd.Next(0, 5)];
                    rdamage = damageNumbers[5, rnd.Next(0, 5)];
                    damage = rdamage - stance_DamageReduction - EnemyArmor;
                    EnemyHealth -= damage * SwordLevel;
                    Console.WriteLine("{0} Suffered {1} damage ({2}) blocked, You hit {3}", EnemyName, damage, EnemyArmor + stance_DamageReduction, damagepoint);
                    Console.WriteLine("Damage Calculation method:\nDamage = ({0}(Damage) - {1}(Enemy armor) - {2} (Stance Damage Reduction) ) * {3} (Sword Level)"
                        , damage, EnemyArmor, stance_DamageReduction, SwordLevel);
                    Experience += 2 * Level;
                    Console.WriteLine("Experience added " + 2 * Level + ".\n Now you have {0} and {1} needed to the next level.", Experience, ExperienceReqUired - Experience);
                    System.Threading.Thread.Sleep(2000);
                    HitsDone++;
                        break;
                case 7:
                    rdamage = damageNumbers[0, rnd.Next(0, 5)];
                    damage = rdamage - EnemyArmor;
                    EnemyHealth -= damage * SwordLevel;
                    Console.WriteLine("{0} Suffered {1} damage ({2}) blocked, You hit {3}", EnemyName, damage, EnemyArmor, damagepoint);
                    Console.WriteLine("Damage Calculation method:\nDamage = ({0}(Damage) - {1}(Enemy armor)) * {2} (Sword Level)"
                        , rdamage, EnemyArmor, SwordLevel);
                    System.Threading.Thread.Sleep(2000);
                    HitsDone++;
                        break;
                case 8:
                    rdamage = damageNumbers[1, rnd.Next(0, 5)];
                    damage = rdamage - EnemyArmor;
                    EnemyHealth -= damage * SwordLevel;
                    Console.WriteLine("{0} Suffered {1} damage ({2}) blocked, You hit {3}", EnemyName, damage, EnemyArmor, damagepoint);
                    Console.WriteLine("Damage Calculation method:\nDamage = ({0}(Damage) - {1}(Enemy armor)) * {2} (Sword Level)"
                        , rdamage, EnemyArmor, SwordLevel);
                    System.Threading.Thread.Sleep(2000);
                    HitsDone++;
                        break;
                case 9:
                    rdamage = damageNumbers[2, rnd.Next(0, 5)];
                    damage = rdamage - EnemyArmor;
                    EnemyHealth -= damage * SwordLevel;
                    Console.WriteLine("{0} Suffered {1} damage ({2}) blocked, You hit {3}", EnemyName, damage, EnemyArmor, damagepoint);
                    Console.WriteLine("Damage Calculation method:\nDamage = ({0}(Damage) - {1}(Enemy armor)) * {2} (Sword Level)"
                        , rdamage, EnemyArmor, SwordLevel);
                    System.Threading.Thread.Sleep(2000);
                    HitsDone++;
                        break;
                case 10:
                    rdamage = damageNumbers[3, rnd.Next(0, 5)];
                    damage = rdamage - EnemyArmor;
                    EnemyHealth -= damage * SwordLevel;
                    Console.WriteLine("{0} Suffered {1} damage ({2}) blocked, You hit {3}", EnemyName, damage, EnemyArmor, damagepoint);
                    Console.WriteLine("Damage Calculation method:\nDamage = ({0}(Damage) - {1}(Enemy armor)) * {2} (Sword Level)"
                        , rdamage, EnemyArmor, SwordLevel);
                    System.Threading.Thread.Sleep(2000);
                    HitsDone++;
                        break;
                case 11:
                    rdamage = damageNumbers[4, rnd.Next(0, 5)];
                    damage = rdamage - EnemyArmor;
                    EnemyHealth -= damage * SwordLevel;
                    Console.WriteLine("{0} Suffered {1} damage ({2}) blocked, You hit {3}", EnemyName, damage, EnemyArmor, damagepoint);
                    Console.WriteLine("Damage Calculation method:\nDamage = ({0}(Damage) - {1}(Enemy armor)) * {2} (Sword Level)"
                        , rdamage, EnemyArmor, SwordLevel);
                    System.Threading.Thread.Sleep(2000);
                    HitsDone++;
                        break;
                case 12:
                    rdamage = damageNumbers[5, rnd.Next(0, 5)];
                    damage = rdamage - EnemyArmor;
                    EnemyHealth -= damage * SwordLevel;
                    Console.WriteLine("{0} Suffered {1} damage ({2}) blocked, You hit {3}", EnemyName, damage, EnemyArmor, damagepoint);
                    Console.WriteLine("Damage Calculation method:\nDamage = ({0}(Damage) - {1}(Enemy armor)) * {2} (Sword Level)"
                        , rdamage, EnemyArmor, SwordLevel);
                    Experience += 2 * Level;
                    Console.WriteLine("Experience added " + 2 * Level + ".\n Now you have {0} and {1} needed to the next level.", Experience, ExperienceReqUired - Experience);
                    System.Threading.Thread.Sleep(2000);
                    HitsDone++;
                        break;
                case 13:
                    Console.WriteLine("{0} have throw: {1}, {2}, {3} what means this is a miss hit.",Program.HeroName, cub1, cub2, cub3);
                    System.Threading.Thread.Sleep(2000);
                        break;
            }
            #endregion
            #region Final things - Statistic.

            if (EnemyHealth <= 0)
            {
                System.Threading.Thread.Sleep(2000);
                GameOne.Win_Screen();
            }
            
            Console.WriteLine("To view this round statistic: 'S'.\nTo choose your stance for the next round 'Space'\nTo use a Health Potion 'H'.");
            var info = Console.ReadKey();
            switch (info.Key)
            {
                case ConsoleKey.S:
                    Console.Clear();
                    Console.WriteLine("{0} have got {1}/{2} health.", Program.HeroName, PlayerHealth, MaxPlayerHealth);
                    Console.WriteLine("{0} have got {1}/{2} health.", EnemyName, EnemyHealth, MaxEnemyHealth);
                    Console.WriteLine("{0} deal {1} damage to {2} into the {3}.", Program.HeroName, damage, EnemyName, damagepoint);
                    Console.WriteLine("In this match {0} has hit {1} times and {2} has hit {3} times.", Program.HeroName, HitsDone, EnemyName, EnemyHitsDone);
                    Console.WriteLine("The first throw: {0}, Second Throw: {1}, Third throw: {2}. Sum of throws: {3}", cub1, cub2, cub3, fin);
                    Console.WriteLine("");
                    Console.WriteLine("{0} have got {1}/{2} Experience to the Next Level.", Program.HeroName, Experience, ExperienceReqUired);
                    Console.WriteLine("{0} have got {1} Gold.", Program.HeroName, Money);
                    System.Threading.Thread.Sleep(4000);
                    Console.WriteLine("Press 'Space' to choose your stance.");
                    var ninfo = Console.ReadKey();
                    if (ninfo.Key == ConsoleKey.Spacebar)
                    {
                        Console.Clear();
                        GameOne.Player_Stance();
                    }
                    else
                    {
                        Console.Clear();
                        GameOne.Player_Stance();
                    }
                    break;
                case ConsoleKey.Spacebar:
                    Console.Clear();
                    GameOne.Player_Stance();
                    break;
                case ConsoleKey.H:
                    double overPlayerHealth = PlayerHealth + (MaxPlayerHealth/4);
                    if (HealthPotion >= 1 && overPlayerHealth <= PlayerHealth)
                    {
                        Console.WriteLine(
                            "You are about to use a health Potion what will add {0} Health to your Hero.",
                            MaxPlayerHealth/4);
                        HealthPotion--;
                        PlayerHealth += MaxPlayerHealth/4;
                        Console.WriteLine("Your Health is now: {0}/{1}", PlayerHealth,MaxPlayerHealth);
                        System.Threading.Thread.Sleep(4000);
                        GameOne.Player_Stance();
                    }
                    else if (overPlayerHealth > PlayerHealth)
                    {
                        Console.WriteLine("You can not use a Health Potion because your health will be over the Maximum Health.");
                        System.Threading.Thread.Sleep(4000);
                        GameOne.Player_Stance();
                    }
                    else
                    {
                        Console.WriteLine("You can not use a Health Potion because dont have any.");
                        System.Threading.Thread.Sleep(4000);
                        GameOne.Player_Stance();
                    }
                    break;
                default:
                    Console.Clear();
                    GameOne.Player_Stance();
                    break;
            }

            #endregion
        }

        private static void Enemy_Turn()
        {
            Console.Clear();
            Console.WriteLine("{4} health: {0}/{1} | {5} health: {2}/{3}", PlayerHealth, MaxPlayerHealth, EnemyHealth, MaxEnemyHealth, Program.HeroName, EnemyName);
            //Declaring variables.
            double rdamage = 0;
            double damage = 0;
            double stance_DamageReduction = 0;
            var damageCategory = 0;
            #region Damage Numbers and estetical
            //damage numbers separated by the level of the Hero
            var damageNumbers = new double[6, 5]
            {
                {0.1, 0.15, 0.2, 0.25, 0.3}, // 1-5
                {0.4, 0.45, 0.5, 0.55, 0.6}, // 6-10
                {0.7, 0.75, 0.8, 0.85, 0.9}, // 10-13
                {1, 1.1, 1.2, 1.3, 1.4},     // 10-15
                {1.5, 1.6, 1.7, 1.8, 1.9},   // 16-17
                {2, 2.25, 2.5, 2.75, 3}      // 18
            };
            var stanceDamageReduction = new double[2, 5]
            {
                {0.01, 0.02, 0.03, 0.04, 0.05},
                {0.06, 0.07, 0.08, 0.09, 0.1 }
            };
            //Point demage this is just for the look a like.
            string[] damagepointer =
            {
                "brutally in the head.",
                "hardly in the head.",
                "strongly in the head.",
                "in the head.",
                "brutally in the face.",
                "hardly in the face.",
                "strongly in the face.",
                "in the face.",
                "brutally in the chest.",
                "hardly in the chest.",
                "strongly in the chest.",
                "in the chest.",
                "brutally in the body.",
                "hardly in the body.",
                "strongly in the body.",
                "in the body.",
                "where it hurts so much.",
                "where nobody hits.",
                "in the ass.",
                "to the legs.",
                "to the ankles.",
                "to the foot.",
                "to the arms",
                "to the shoulders"
            };
            #endregion
            #region Calculate-and-separate
            var rnd = new Random();
            //Damage pointer roll-out & Estetical.
            var damagepoint = damagepointer[rnd.Next(0, damagepointer.Length - 1)];
            if (PlayerStance == 1)
            {
                Console.WriteLine("{0} has taken Defensive Stance.", Program.HeroName);
            }
            else
            {
                Console.WriteLine("{0} has taken Attack Stance", Program.HeroName);
            }
            //The Numbers of the 3x6 Cubes.
            var cub1 = rnd.Next(1, 7);
            var cub2 = rnd.Next(1, 7);
            var cub3 = rnd.Next(1, 7);
            //Final Result of the sum the 3x6 Cubes.
            var fin = cub1 + cub2 + cub3;
            //Damage Category separation.
            if (fin ==3) { damageCategory=13;}
            else if (fin <= 5 && PlayerStance == 1) { damageCategory = 1; }
            else if (fin <= 10 && PlayerStance == 1) { damageCategory = 2; }
            else if (fin <= 13 && PlayerStance == 1) { damageCategory = 3; }
            else if (fin <= 15 && PlayerStance == 1) { damageCategory = 4; }
            else if (fin <= 17 && PlayerStance == 1) { damageCategory = 5; }
            else if (fin == 18 && PlayerStance == 1) { damageCategory = 6; }
            else if (fin <= 5) { damageCategory = 7; }
            else if (fin <= 10) { damageCategory = 8; }
            else if (fin <= 13) { damageCategory = 9; }
            else if (fin <= 15) { damageCategory = 10; }
            else if (fin <= 17) { damageCategory = 11; }
            else if (fin == 18) { damageCategory = 12; }
            else
            {
                Console.WriteLine("There is an error occured you will be returned to the beginning...");
                System.Threading.Thread.Sleep(2000);
                Program.Pre_Main_Menu();
            }
            #endregion
            #region Damage Calculation
            switch (damageCategory)
            {
                case 1:
                    stance_DamageReduction = stanceDamageReduction[0, rnd.Next(0, 5)];
                    rdamage = damageNumbers[0, rnd.Next(0, 5)];
                    damage = (rdamage - Armor - stance_DamageReduction)*EnemyLevel;
                    PlayerHealth -= damage;
                    Console.WriteLine("{0} Suffered {1} damage ({2}) blocked, {3} hit {4}", Program.HeroName, damage, Armor+stance_DamageReduction, EnemyName, damagepoint);
                    Console.WriteLine("Damage Calculation method:\nDamage = ({0}(Damage) - {1}(Player Armor) - {2} (Stance Damage Reduction) ) * {3} (Enemy Level)"
                        , rdamage, Armor, stance_DamageReduction, EnemyLevel);
                    System.Threading.Thread.Sleep(2000);
                    EnemyHitsDone++;
                    break;
                case 2:
                    stance_DamageReduction = stanceDamageReduction[0, rnd.Next(0, 5)];
                    rdamage = damageNumbers[1, rnd.Next(0, 5)];
                    damage = (rdamage - Armor - stance_DamageReduction) * EnemyLevel;
                    PlayerHealth -= damage;
                    Console.WriteLine("{0} Suffered {1} damage ({2}) blocked, {3} hit {4}", Program.HeroName, damage, Armor + stance_DamageReduction, EnemyName, damagepoint);
                    Console.WriteLine("Damage Calculation method:\nDamage = ({0}(Damage) - {1}(Player Armor) - {2} (Stance Damage Reduction) ) * {3} (Enemy Level)"
                        , rdamage, Armor, stance_DamageReduction, EnemyLevel);
                    System.Threading.Thread.Sleep(2000);
                    EnemyHitsDone++;
                    break;
                case 3:
                    stance_DamageReduction = stanceDamageReduction[0, rnd.Next(0, 5)];
                    rdamage = damageNumbers[2, rnd.Next(0, 5)];
                    damage = (rdamage - Armor - stance_DamageReduction) * EnemyLevel;
                    PlayerHealth -= damage;
                    Console.WriteLine("{0} Suffered {1} damage ({2}) blocked, {3} hit {4}", Program.HeroName, damage, Armor + stance_DamageReduction, EnemyName, damagepoint);
                    Console.WriteLine("Damage Calculation method:\nDamage = ({0}(Damage) - {1}(Player Armor) - {2} (Stance Damage Reduction) ) * {3} (Enemy Level)"
                        , rdamage, Armor, stance_DamageReduction, EnemyLevel);
                    System.Threading.Thread.Sleep(2000);
                    EnemyHitsDone++;
                    break;
                case 4:
                    stance_DamageReduction = stanceDamageReduction[0, rnd.Next(0, 5)];
                    rdamage = damageNumbers[3, rnd.Next(0, 5)];
                    damage = (rdamage - Armor - stance_DamageReduction) * EnemyLevel;
                    PlayerHealth -= damage;
                    Console.WriteLine("{0} Suffered {1} damage ({2}) blocked, {3} hit {4}", Program.HeroName, damage, Armor + stance_DamageReduction, EnemyName, damagepoint);
                    Console.WriteLine("Damage Calculation method:\nDamage = ({0}(Damage) - {1}(Player Armor) - {2} (Stance Damage Reduction) ) * {3} (Enemy Level)"
                        , rdamage, Armor, stance_DamageReduction, EnemyLevel);
                    System.Threading.Thread.Sleep(2000);
                    EnemyHitsDone++;
                    break;
                case 5:
                    stance_DamageReduction = stanceDamageReduction[0, rnd.Next(0, 5)];
                    rdamage = damageNumbers[4, rnd.Next(0, 5)];
                    damage = (rdamage - Armor - stance_DamageReduction) * EnemyLevel;
                    PlayerHealth -= damage;
                    Console.WriteLine("{0} Suffered {1} damage ({2}) blocked, {3} hit {4}", Program.HeroName, damage, Armor + stance_DamageReduction, EnemyName, damagepoint);
                    Console.WriteLine("Damage Calculation method:\nDamage = ({0}(Damage) - {1}(Player Armor) - {2} (Stance Damage Reduction) ) * {3} (Enemy Level)"
                        , rdamage, Armor, stance_DamageReduction, EnemyLevel);
                    System.Threading.Thread.Sleep(2000);
                    EnemyHitsDone++;
                    break;
                case 6:
                    stance_DamageReduction = stanceDamageReduction[0, rnd.Next(0, 5)];
                    rdamage = damageNumbers[5, rnd.Next(0, 5)];
                    damage = (rdamage - Armor - stance_DamageReduction) * EnemyLevel;
                    PlayerHealth -= damage;
                    Console.WriteLine("{0} Suffered {1} damage ({2}) blocked, {3} hit {4}", Program.HeroName, damage, Armor + stance_DamageReduction, EnemyName, damagepoint);
                    Console.WriteLine("Damage Calculation method:\nDamage = ({0}(Damage) - {1}(Player Armor) - {2} (Stance Damage Reduction) ) * {3} (Enemy Level)"
                        , rdamage, Armor, stance_DamageReduction, EnemyLevel);
                    System.Threading.Thread.Sleep(2000);
                    EnemyHitsDone++;
                    break;
                case 7:
                    rdamage = damageNumbers[0, rnd.Next(0, 5)];
                    damage = (rdamage - Armor) * EnemyLevel;
                    PlayerHealth -= damage;
                    Console.WriteLine("{0} Suffered {1} damage ({2}) blocked, {3} hit {4}", Program.HeroName, damage, Armor, EnemyName, damagepoint);
                    Console.WriteLine("Damage Calculation method:\nDamage = ({0}(Damage) - {1}(Player Armor) ) * {2} (Enemy Level)"
                        , rdamage, Armor, EnemyLevel);
                    System.Threading.Thread.Sleep(2000);
                    EnemyHitsDone++;
                    break;
                case 8:
                    rdamage = damageNumbers[1, rnd.Next(0, 5)];
                    damage = (rdamage - Armor) * EnemyLevel;
                    PlayerHealth -= damage;
                    Console.WriteLine("{0} Suffered {1} damage ({2}) blocked, {3} hit {4}", Program.HeroName, damage, Armor, EnemyName, damagepoint);
                    Console.WriteLine("Damage Calculation method:\nDamage = ({0}(Damage) - {1}(Player Armor) ) * {2} (Enemy Level)"
                        , rdamage, Armor, EnemyLevel);
                    System.Threading.Thread.Sleep(2000);
                    EnemyHitsDone++;
                    break;
                case 9:
                    rdamage = damageNumbers[2, rnd.Next(0, 5)];
                    damage = (rdamage - Armor) * EnemyLevel;
                    PlayerHealth -= damage;
                    Console.WriteLine("{0} Suffered {1} damage ({2}) blocked, {3} hit {4}", Program.HeroName, damage, Armor, EnemyName, damagepoint);
                    Console.WriteLine("Damage Calculation method:\nDamage = ({0}(Damage) - {1}(Player Armor) ) * {2} (Enemy Level)"
                        , rdamage, Armor, EnemyLevel);
                    System.Threading.Thread.Sleep(2000);
                    EnemyHitsDone++;
                    break;
                case 10:
                    rdamage = damageNumbers[3, rnd.Next(0, 5)];
                    damage = (rdamage - Armor) * EnemyLevel;
                    PlayerHealth -= damage;
                    Console.WriteLine("{0} Suffered {1} damage ({2}) blocked, {3} hit {4}", Program.HeroName, damage, Armor, EnemyName, damagepoint);
                    Console.WriteLine("Damage Calculation method:\nDamage = ({0}(Damage) - {1}(Player Armor) ) * {2} (Enemy Level)"
                        , rdamage, Armor, EnemyLevel);
                    System.Threading.Thread.Sleep(2000);
                    EnemyHitsDone++;
                    break;
                case 11:
                    rdamage = damageNumbers[4, rnd.Next(0, 5)];
                    damage = (rdamage - Armor) * EnemyLevel;
                    PlayerHealth -= damage;
                    Console.WriteLine("{0} Suffered {1} damage ({2}) blocked, {3} hit {4}", Program.HeroName, damage, Armor, EnemyName, damagepoint);
                    Console.WriteLine("Damage Calculation method:\nDamage = ({0}(Damage) - {1}(Player Armor) ) * {2} (Enemy Level)"
                        , rdamage, Armor, EnemyLevel);
                    System.Threading.Thread.Sleep(2000);
                    EnemyHitsDone++;
                    break;
                case 12:
                    rdamage = damageNumbers[5, rnd.Next(0, 5)];
                    damage = (rdamage - Armor) * EnemyLevel;
                    PlayerHealth -= damage;
                    Console.WriteLine("{0} Suffered {1} damage ({2}) blocked, {3} hit {4}", Program.HeroName, damage, Armor, EnemyName, damagepoint);
                    Console.WriteLine("Damage Calculation method:\nDamage = ({0}(Damage) - {1}(Player Armor) ) * {2} (Enemy Level)"
                        , damage, Armor, EnemyLevel);
                    System.Threading.Thread.Sleep(2000);
                    EnemyHitsDone++;
                    break;
                case 13:
                    Console.WriteLine("{0} have throw: {1}, {2}, {3} what means this is a miss hit.",EnemyName, cub1, cub2, cub3);
                    System.Threading.Thread.Sleep(2000);
                    break;
            }
            #endregion
            #region The final things of the round.
            if (PlayerHealth <= 0)
            {
                Lose_Screen();
            }
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("To view statistic of this round Press 'S'\nTo Start Your turn Press 'Space'.");
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.S)
            {
                Console.WriteLine("{0} have got {1}/{2} health.", Program.HeroName, PlayerHealth, MaxPlayerHealth);
                Console.WriteLine("{0} have got {1}/{2} health.", EnemyName, EnemyHealth, MaxEnemyHealth);
                Console.WriteLine("{0} deal {1} damage to {2} into the {3}.", EnemyName, damage, Program.HeroName, damagepoint);
                Console.WriteLine("In this match {0} has hit {1} times and {2} has hit {3} times.", Program.HeroName, HitsDone, EnemyName, EnemyHitsDone);
                Console.WriteLine("{0} have got {1}/{2} Experience to the Next Level.", Program.HeroName, Experience, ExperienceReqUired);
                Console.WriteLine("{0} have got {1} Gold.", Program.HeroName, Money);
                ConsoleKeyInfo ninfo = Console.ReadKey();
                if (ninfo.Key == ConsoleKey.Spacebar)
                {
                    Player_Turn();
                }
                else
                {
                    Player_Turn();
                }
            }
            else
            {
                Player_Turn();
            }
            #endregion
        }

        private static void Player_Stance()
        {
            Console.WriteLine("Press 'D' for Defensive Stance or Press 'A' for Attack Stance.");
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.D)
            {
                PlayerStance = 1;
                Console.Clear();
                GameOne.Enemy_Turn();
            }
            else if (info.Key == ConsoleKey.A)
            {
                PlayerStance = 0;
                Console.Clear();
                GameOne.Enemy_Turn();
            }
            else
            {
                PlayerStance = 1;
                Console.Clear();
                GameOne.Enemy_Turn();
            }
        }

        private static void Win_Screen()
        {
            Console.WriteLine("You have beaten {0} and you survived with {1} hp / {2} hp.", EnemyName, PlayerHealth, MaxPlayerHealth);
            Console.WriteLine("Press 'Space' to continue...");
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                Flush_Experience();
            }
            else
            {
                Console.Clear();
                Flush_Experience();
            }
        }

        private static void Lose_Screen()
        {
            Console.WriteLine("You have been slained by {0} and {1} survived with {2} hp / {3} hp.", EnemyName, EnemyName, EnemyHealth, MaxEnemyHealth);
            Console.WriteLine("You are dead, you have to visit the resurrection screen in the Main Menu to revive.");
            Program.Alive = false;
            Program.Pre_Main_Menu();
        }

        private static void Flush_Experience()
        {
            Console.Clear();
            var baseExperience = new double[2, 5]
            {
                {5, 6, 7, 8, 9},
                {10, 11, 12, 13, 14}
            };
            var rnd = new Random();
            var basexp = baseExperience[rnd.Next(0, 2), rnd.Next(0, 6)];
            Console.WriteLine("Because you have slained {0} you are eligable to gain Experience.", EnemyName);
            System.Threading.Thread.Sleep(2000);
            double exp = (HitsDone/Level)*EnemyLevel*SwordLevel + basexp *Program.ExperienceMultiplier;
            Experience += exp;
            Console.WriteLine("You have gained {0} Experience for this fight.", exp);
            Console.WriteLine("Experience calculation: ({0} (Hits In this Round) / {1} Level) * {2} (Enemy Level) * {3} (Sword Level) + {4} (Base Experience) * {5} (Experience Multiplier)"
                , HitsDone, Level, EnemyLevel, SwordLevel, basexp, Program.ExperienceMultiplier);
            System.Threading.Thread.Sleep(4000);
            if (ExperienceReqUired <= Experience)
            {
                Level++;
                Experience = 0;
                ExperienceReqUired *= 1.5;
                Console.WriteLine(
                    "Congratulations you have leveled up! Old Level: {0} New Level: {1}.\n You have gained {2} Shield and {3} Armor.",
                    Level - 1, Level, Level*2, 0.1*Level);
                Shield += Level*2;
                Armor += 0.1*Level;
                System.Threading.Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("Experience {0} / Required Experience to the Next Level: {1}.", Experience, ExperienceReqUired);
                System.Threading.Thread.Sleep(4000);
            }
            Flush_Gold();
        }

        private static void Flush_Gold()
        {
            Console.Clear();
            #region BonusgoldByName
            var bonusgold = 0;
            if (EnemyName == "The Chest")
            {
                bonusgold += 10;
            }
            else if (EnemyName == "The Loot Box")
            {
                bonusgold += 10;
                Program.LootBox++;
            }
            else if (EnemyName == "The Mystical Sachel")
            {
                bonusgold += 10;
            }
            #endregion
            #region FlushGold-LootBox
            var baseGold = new double[2, 5]
            {
                {0.5, 1, 1.5, 2, 2.5},
                {3, 4, 5, 6, 7}
            };
            var rnd = new Random();
            var lootbox = rnd.Next(0, 11);
            if (lootbox >= 7)
            {
                Program.LootBox++;
            }
            double basegold = baseGold[rnd.Next(0, 2), rnd.Next(0, 5)];
            double gold = (HitsDone/2)*Level + basegold + bonusgold * Program.MoneyMultiplier;
            Console.WriteLine("You have gained gold for slaying {0}.\nYou currently have {1} Gold. And you have gained {2} Gold for this fight.", EnemyName, Money, gold);
            Money += gold;
            System.Threading.Thread.Sleep(5000);
            Set_Things();
            #endregion
        }

        private static void Set_Things()
        {

            PlayerHealth = 0;
            EnemyHealth = 0;
            EnemyName = null;
            EnemyArmor = 0;
            PlayerStance = 0;
            EnemyStance = 0;
            HitsDone = 0;
            EnemyHitsDone = 0;
            MaxEnemyHealth = 0;
            MaxPlayerHealth = 0;
            Program.Pre_Main_Menu();
        }
    }
}