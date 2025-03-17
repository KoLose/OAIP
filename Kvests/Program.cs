using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_практика
{
    internal class Program
    {
        #region 
        static Random rd = new Random();
        static int health = 0;
        static int maxHealth = 0;
        static int gold = 0;
        static int potions = 0;
        static int arrows = 0;
        static int damege = 0;
        static int damegeMin = 10;
        static int damegeMax = 20;
        static bool isWin = false;
        static int monsterHP = 0;
        static int monsterAttack = 0;
        static int monsterAttackMin = 8;
        static int monsterAttackMax = 20;
        static bool boss = false;
        #endregion 
        static void Main(string[] args)
        {
            int roomNumber = 0;
            InitializeGame();
            for (int i = 1; i < 14; i++)
            {
                roomNumber = rd.Next();
                ProcessRoom(roomNumber);
            }
            FightBoss();
        }
        public static void ProcessRoom(int roomNumber)
        {
            switch (roomNumber)
            {
                case 1:
                    Console.WriteLine($"Вы зашли в комнату с монстром у него {monsterHP = rd.Next(20, 50)}");
                    FightMonster(monsterHP, monsterAttack);
                    break;
                case 2:
                    OpenChest();
                    break;
                case 3:
                    VisitAltar();
                    break;
                case 4:
                    VisitMerchant();
                    break;
                case 5:
                    MeetDarkMage();
                    break;
            }
        }
        public static void InitializeGame()
        {
            health = 100;
            maxHealth = 100;
            gold = 10;
            potions = 2;
            arrows = 5;
        }
        public static void FightMonster(int monsterHP, int monsterAttack)
        {
            int count = 0;
            while (health >= 0 && monsterHP >= 0)
            {
                ShowStats();

                Console.WriteLine("Выберите действие: (1) Меч, (2) Лук, (3) Зелье");
                string action = Console.ReadLine();
                switch (action)
                {
                    case "1":
                        Console.WriteLine($"Вы нанесли {damege = rd.Next(damegeMin, damegeMax)}, а монстр вам {monsterAttack = rd.Next(monsterAttackMin, monsterAttackMax)}, теперь у монстра {monsterHP = monsterHP - damege}");
                        health = health - monsterAttack;
                        if (boss == true && rd.Next(0, 4) == 4)
                        {
                            Console.WriteLine($"У босса сработала особая атака он нанес {monsterAttack = rd.Next(monsterAttackMin, monsterAttackMax)}");
                            health = health - monsterAttack;
                            count++;
                            if (count == 3)
                            {
                                count = 0;
                                if (rd.Next(1, 2) == 2)
                                    Console.WriteLine($"Босс востановил 10 HP теперь у него {monsterHP = monsterHP + 10}");
                            }
                        }
                        monsterHP = monsterHP - damege;
                        break;

                    case "2":
                        if (arrows > 0)
                        {
                            Console.WriteLine($"Вы нанесли {damege = rd.Next(5, 15)}, а монстр вам {monsterAttack = rd.Next(monsterAttackMin, monsterAttackMax)}, теперь у монстра {monsterHP = monsterHP - damege}");
                            health = health - monsterAttack;
                            monsterHP = monsterHP - damege;
                            arrows--;
                        }
                        else
                        {
                            Console.WriteLine("У вас нет стрел!");
                            continue;
                        }
                        break;

                    case "3":
                        UsePotion();
                        break;
                }
            }
            if (monsterHP > 0)
                Console.WriteLine("Вы одалели монстра!");
            else
            { EndGame(isWin); }
        }
        public static void OpenChest()
        {
            int sunduk = rd.Next(1, 4);
            Console.WriteLine($"Вы зашли в комнату с сундуком ");
            if (sunduk == 1) { potions++; Console.WriteLine("В сундуке было зелье"); }
            if (sunduk == 2) { gold = gold + 15; Console.WriteLine("В сундуке были монеты"); }
            if (sunduk == 3) { arrows++; Console.WriteLine("В сундуке были стрелы"); }
            if (sunduk == 4) { maxHealth -= 10; Console.WriteLine($"Cундук был проклятым теперь у вас {maxHealth} максимального HP"); }
        }
        public static void VisitMerchant()
        {
            bool bOOL = true;
            if (gold > 4)
            {
                while (bOOL)
                {
                    int torg = 0;
                    Console.WriteLine($"Вы попали к торговцу.\n Нажмите 2 если хотите преобрести зелье.\n 1 если хотите преобрестиесли стрелы.\n 0 если не хотите ничего преобретать.");
                    torg = Convert.ToInt32(Console.ReadLine());
                    if (torg == 2)
                    {
                        gold -= 10;
                        potions++;
                        Console.WriteLine($"Вы успешно преобрели зелье у вас {potions} зелий и {gold} золота");
                    }
                    if (torg == 1)
                    {
                        gold += 5;
                        arrows += 3;
                        Console.WriteLine($"Вы успешно преобрели 3 стрелы у вас {arrows} стрел и {gold} золота");
                    }
                    if (torg == 0)
                        bOOL = false;
                }
            }
            else { Console.WriteLine($"Вы попали к торговцу, но у вас нет денег или места."); }
        }
        public static void VisitAltar()
        {
            Console.Write("Вы попали к алтарю");
            if (gold >= 10)
            {
                Console.WriteLine("Вы можете пожертвовать 10 золота и получить\n - Увеличить урон меча на 5 \n - Восстановить 20 HP.\n Если хотите пожертвовать нажмите 1 если не хотите нажмите 0");
                int vibor = Convert.ToInt32(Console.ReadLine());
                if (vibor == 1)
                {
                    gold -= 10;
                    damegeMax += 5;
                    damegeMin += 5;
                    if (health <= maxHealth - 20)
                        health += 20;
                    else
                        health = maxHealth;
                }
            }
            else
                Console.WriteLine("У вас нет денег Вы бомж Идите работать");
        }
        public static void MeetDarkMage()
        {
            Console.WriteLine("Вы попали к магу и он предлагает сделку: жертвуй 10 HP, чтобы получить 2 зелья и 5 стрел.\n Нажмите 1 если согласны если нет то 0");
            int vibor = Convert.ToInt32(Console.ReadLine());
            if (vibor == 1 && health > 10)
            {
                health -= 10;
                potions += 2;
                arrows += 5;
            }
            else if (vibor == 1 && health <= 10)
                Console.WriteLine("У вас не достаточно HP Маг изчез");
        }
        public static void UsePotion()
        {
            if (potions > 0)
            {
                health = health + 30;
                potions = potions - 1;
            }
            if (potions == 0)
                Console.WriteLine("Не хватило зелий");
        }
        public static void ShowStats()
        {
            Console.WriteLine($"\nВаше здоровье: {health}\n Стрелы: {arrows}\n Зелья: {potions}\n Золота: {gold}\n Максимум здоровья: {maxHealth}\n Максимум урон мечём: {damegeMax}\n Минимум урон мечём: {damegeMin}");
        }
        public static void FightBoss()
        {
            Console.WriteLine($"Вы зашли в комнату с Босом у него {monsterHP = 100}");
            Console.WriteLine($"У вас {health} здоровья и {potions} зелий. ");
            monsterAttackMax = 25;
            monsterAttackMin = 15;
            boss = true;
            FightMonster(monsterHP, monsterAttack);
        }
        public static void EndGame(bool isWin)
        {
            if (isWin == true)
                Console.WriteLine("Поздравляю вы победили");
            else
                Console.WriteLine("Вы проиграли");
        }
    }
}