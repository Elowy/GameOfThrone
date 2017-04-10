using System;
using GameOfTheThrone.Game;

namespace GameOfTheThrone.Tutorial
{
    class TutorialFight
    {
        static double T_PlayerHealth = 10;
        static double T_EnemyHealth = 10;
        static int T_PlayerStance = 0;
        static int T_EnemyStance = 0;
        public void TutorialInformation()
        {
            Console.Clear();
            Console.WriteLine("You have got health if it reaches 0 you die.\nAlso the Enemy got health too what reaches 0 the enemy dies, and you win.");
            Console.WriteLine("You can change the Stance what you are using in each round. There are two Stances: Attack, and Defensive.");
            Console.WriteLine("If you or the enemy using Defensive Stance while the other uses Attack Stance the damage is only 50% than usual.");
            Console.WriteLine("You have 3 original Throwing Cube and the higher number means the more damage.");
            Console.WriteLine("The damage list can be accessed any time while you fighting or in the Main Menu.");
            Console.WriteLine("We have set up the First Enemy: 'Training Dummy'\nPress 'Space' for Fight!");
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                var player = new TutorialFight();
                player.TutorialBattle_0();
            }
        }
        public void TutorialBattle_0()
        {
            T_PlayerHealth = 10;
            T_EnemyHealth = 10;
            Console.WriteLine("This fight is simple. Press 'Space' to start the Battle.");
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                var player = new TutorialFight();
                player.TutorialBattle_1();
            }
            else
            {
                Console.Clear();
                var player = new TutorialFight();
                player.TutorialBattle_1();
            }
        }
        public void TutorialBattle_1()
        {//Player Round.
            var damageNumbers = new double[2, 3]
                {
                    { 0.25, 0.5, 0.75 },
                    { 0.5, 1 , 1.5 }
                };
            /*
            Pthrow 
            1  - 6      0.5     Damage
            7  - 12     1       Damage
            13 - 18     1.5     Damage
            */
            /*
            DamageCategory:

            Enemy Defensive

            Cat 1. = 0.25   Dmg    (1-6)
            Cat 2. = 0.5    Dmg    (7-12)
            Cat 3. = 0.75   Dmg    (13-18)

            Enemy Attack

            Cat 4. = 0.5    Dmg    (1-6)
            Cat 5. = 1      Dmg    (7-12)
            Cat 6. = 1.5    Dmg    (13-18)
            */
            int damageCategory = 0;
            double damageDeal = 0;

            T_EnemyStance = new Random().Next(1, 3);

            if (T_EnemyStance == 1)
            {
                Console.WriteLine("The Enemy has taken Defensive Stance.");
                System.Threading.Thread.Sleep(2500);
            }
            else
            {
                Console.WriteLine("The Enemy has taken Attack Stance.");
                System.Threading.Thread.Sleep(2500);
            }

            var pcub1 = new Random().Next(1, 7);
            var pcub2 = new Random().Next(1, 7);
            var pcub3 = new Random().Next(1, 7);
            int pthrow = pcub1 + pcub2 + pcub3;

            if (pthrow <= 6 && T_EnemyStance == 1) { damageCategory = 1; }
            else if (pthrow <= 12 && T_EnemyStance == 1) { damageCategory = 2; }
            else if (pthrow <= 18 && T_EnemyStance == 1) { damageCategory = 3; }
            else if (pthrow <= 6) { damageCategory = 4; }
            else if (pthrow <= 12) { damageCategory = 5; }
            else if (pthrow <= 18) { damageCategory = 6; }

            switch (damageCategory)
            {
                case 1:
                    damageDeal = damageNumbers[0, 0];
                    TutorialFight.T_EnemyHealth -= damageDeal;
                    Console.WriteLine("You hit to the Training Dummy body and he suffered " + damageDeal + " Damage. His health is now: {0}", T_EnemyHealth);
                    System.Threading.Thread.Sleep(2500);
                    break;
                case 2:
                    damageDeal = damageNumbers[0, 1];
                    TutorialFight.T_EnemyHealth -= damageDeal;
                    Console.WriteLine("You hit strongly to the Training Dummy body and he suffered " + damageDeal + " Damage. His health is now: {0}", T_EnemyHealth);
                    System.Threading.Thread.Sleep(2500);
                    break;
                case 3:
                    damageDeal = damageNumbers[0, 2];
                    TutorialFight.T_EnemyHealth -= damageDeal;
                    Console.WriteLine("You hit hard to the Training Dummy head and he suffered " + damageDeal + " Damage. His health is now: {0}", T_EnemyHealth);
                    System.Threading.Thread.Sleep(2500);
                    break;
                case 4:
                    damageDeal = damageNumbers[1, 0];
                    TutorialFight.T_EnemyHealth -= damageDeal;
                    Console.WriteLine("You hit to the Training Dummy body and he suffered " + damageDeal + " Damage. His health is now: {0}", T_EnemyHealth);
                    System.Threading.Thread.Sleep(2500);
                    break;
                case 5:
                    damageDeal = damageNumbers[1, 1];
                    TutorialFight.T_EnemyHealth -= damageDeal;
                    Console.WriteLine("You hit strongly to the Training Dummy body and he suffered " + damageDeal + " Damage. His health is now: {0}", T_EnemyHealth);
                    System.Threading.Thread.Sleep(2500);
                    break;
                case 6:
                    damageDeal = damageNumbers[1, 2];
                    TutorialFight.T_EnemyHealth -= damageDeal;
                    Console.WriteLine("You hit hard to the Training Dummy head and he suffered " + damageDeal + " Damage. His health is now: {0}", T_EnemyHealth);
                    System.Threading.Thread.Sleep(2500);
                    break;
            }

            Console.WriteLine("Hero Health: {0} ---- Training Dummy Health: {1}", T_PlayerHealth, T_EnemyHealth);
            Console.WriteLine("You have thrown '{0}' what is {1} damage to the Training Dummy.", pthrow, damageDeal);
            Console.WriteLine("Your Turn is over now. You can choose a stance.");
            Console.WriteLine("Press D for Defensive Stance or Press A for Attack Stance");
            var player = new TutorialFight();
            if (T_EnemyHealth <= 0) { player.WinFight(); }
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.D)
            {
                Console.Clear();
                T_PlayerStance = 1;
                player.TutorialBattle_2();
            }
            else if (info.Key == ConsoleKey.A)
            {
                Console.Clear();
                T_PlayerStance = 2;
                player.TutorialBattle_2();
            }
            else
            {
                Console.Clear();
                T_PlayerStance = 1;
                player.TutorialBattle_2();
            }
        }
        public void TutorialBattle_2()
        {
            //Player Round.
            var damageNumbers = new double[2, 3]
                {
                    { 0.15, 0.25, 0.50 },
                    { 0.50, 0.75 , 1 }
                };
            /*
            Pthrow 
            1  - 6      0.5     Damage * Swordlevel
            7  - 12     1       Damage * Swordlevel
            13 - 18     1.5     Damage * Swordlevel
            */
            int pthrow;
            /*
            DamageCategory:

            Enemy Defensive

            Cat 1. = 0.25   Dmg    (1-6)
            Cat 2. = 0.5    Dmg    (7-12)
            Cat 3. = 0.75   Dmg    (13-18)

            Enemy Attack

            Cat 4. = 0.5    Dmg    (1-6)
            Cat 5. = 1      Dmg    (7-12)
            Cat 6. = 1.5    Dmg    (13-18)
            */
            int damageCategory = 0;
            double damageDeal = 0;

            var pcub1 = new Random().Next(1, 7);
            var pcub2 = new Random().Next(1, 7);
            var pcub3 = new Random().Next(1, 7);
            pthrow = pcub1 + pcub2 + pcub3;

            if (pthrow <= 6 && T_PlayerStance == 1) { damageCategory = 1; }
            else if (pthrow <= 12 && T_PlayerStance == 1) { damageCategory = 2; }
            else if (pthrow <= 18 && T_PlayerStance == 1) { damageCategory = 3; }
            else if (pthrow <= 6) { damageCategory = 4; }
            else if (pthrow <= 12) { damageCategory = 5; }
            else if (pthrow <= 18) { damageCategory = 6; }

            switch (damageCategory)
            {
                case 1:
                    damageDeal = damageNumbers[0, 0];
                    TutorialFight.T_PlayerHealth -= damageDeal;
                    Console.WriteLine("Training Dummy hit to the Hero body and he suffered " + damageDeal + " Damage. Hero health is now: {0}", T_PlayerHealth);
                    System.Threading.Thread.Sleep(1500);
                    break;
                case 2:
                    damageDeal = damageNumbers[0, 1];
                    TutorialFight.T_PlayerHealth -= damageDeal;
                    Console.WriteLine("Training Dummy hit strongly to the Hero body and he suffered " + damageDeal + " Damage. Hero health is now: {0}", T_PlayerHealth);
                    System.Threading.Thread.Sleep(1500);
                    break;
                case 3:
                    damageDeal = damageNumbers[0, 2];
                    TutorialFight.T_PlayerHealth -= damageDeal;
                    Console.WriteLine("Training Dummy hit hard to the Hero head and he suffered " + damageDeal + " Damage. Hero health is now: {0}", T_PlayerHealth);
                    System.Threading.Thread.Sleep(1500);
                    break;
                case 4:
                    damageDeal = damageNumbers[1, 0];
                    TutorialFight.T_PlayerHealth -= damageDeal;
                    Console.WriteLine("Training Dummy hit to the Hero body and he suffered " + damageDeal + " Damage. Hero health is now: {0}", T_PlayerHealth);
                    System.Threading.Thread.Sleep(1500);
                    break;
                case 5:
                    damageDeal = damageNumbers[1, 1];
                    TutorialFight.T_PlayerHealth -= damageDeal;
                    Console.WriteLine("Training Dummy hit strongly to the Hero body and he suffered " + damageDeal + " Damage. Hero health is now: {0}", T_PlayerHealth);
                    System.Threading.Thread.Sleep(1500);
                    break;
                case 6:
                    damageDeal = damageNumbers[1, 2];
                    TutorialFight.T_PlayerHealth -= damageDeal;
                    Console.WriteLine("Training Dummy hit hard to the Hero head and he suffered " + damageDeal + " Damage. Hero health is now: {0}", T_PlayerHealth);
                    System.Threading.Thread.Sleep(1500);
                    break;
            }
            Console.WriteLine("Hero Health: {0} ---- Training Dummy Health: {1}", T_PlayerHealth, T_EnemyHealth);
            Console.WriteLine("The Training Dummy have thrown '{0}' what is {1} damage to the Hero.", pthrow, damageDeal);
            Console.WriteLine("Training Dummy's Turn is over now. \nPress 'Space' to continue.");
            var player = new TutorialFight();
            if (T_PlayerHealth <= 0) { player.LoseFight(); }
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                player.TutorialBattle_1();
            }
            else
            {
                Console.Clear();
                player.TutorialBattle_1();
            }

        }
        void LoseFight()
        {
            Console.WriteLine("You have losed the fight against the Training Dummy.");
            Console.WriteLine("Press Space to start again.");
            var player = new TutorialFight();
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                player.TutorialBattle_0();
            }
            else
            {
                Console.Clear();
                player.TutorialBattle_0();
            }
        }
        void WinFight()
        {
            Console.WriteLine("You have win the fight against the Training Dummy.");
            Console.WriteLine("Press 'Space' to start your adventure.");
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                Program.Pre_Main_Menu();
            }
            else
            {
                Console.Clear();
                Program.Pre_Main_Menu();
            }
        }
    }
}
