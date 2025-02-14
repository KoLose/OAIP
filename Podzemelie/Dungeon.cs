using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;

namespace Podzemelie
{
    internal class Dungeon
    {
        // Характеристики игрока
        static int playerHealth = 100;
        static int potions = 3;
        static int gold = 0;
        static int arrows = 5;
        static bool hasSword = true;
        static bool hasBow = true;

        // Уровень и опыт
        static int playerLevel = 1;
        static int playerExperience = 0;
        static int experienceToNextLevel = 100;

        // Инвентарь игрока (массив на 5 предметов)
        static string[] inventory = new string[5];

        static Random random = new Random(); // Создаем экземпляр Random только один раз

        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в подземелье!");
            int level = 1;
            string[] dungeonMap = new string[10];

            while (level <= 10 && playerHealth > 0) // Игра заканчивается если уровень > 10 или здоровье <= 0
            {
                Console.WriteLine(); // Пустая строка между уровнями
                Console.WriteLine($"Ваш уровень: {level}, Здоровье: {playerHealth}, Золото: {gold}, Стрелы: {arrows}, Зелья: {potions}, Уровень игрока: {playerLevel}, Опыт: {playerExperience}/{experienceToNextLevel}");

                string roomName = "";

                // В 10-й комнате всегда босс
                if (level == 10)
                {
                    roomName = "Комната с БОССОМ";
                    Console.WriteLine("Вы вошли в: " + roomName);
                    roomName = Boss();

                    if (roomName == "Комната с ПОБЕЖДЕННЫМ БОССОМ")
                    {
                        dungeonMap[level - 1] = roomName;
                        Console.WriteLine("Вы прошли комнату!");
                        Console.WriteLine("Вы прошли подземелье!"); // Сообщаем о прохождении

                        // Выводим карту подземелья
                        Console.WriteLine("\nКарта подземелья:");
                        for (int i = 0; i < dungeonMap.Length; i++)
                        {
                            if (dungeonMap[i] != null)
                            {
                                Console.WriteLine($"Уровень {i + 1}: {dungeonMap[i]}");
                            }
                            else
                            {
                                Console.WriteLine($"Уровень {i + 1}: Не исследовано");
                            }
                        }

                        Console.ReadKey();
                        return; // Завершаем игру после победы над боссом
                    }
                }
                else
                {
                    int NumberOfTheRoom = random.Next(1, 6);
                    switch (NumberOfTheRoom)
                    {
                        case 1:
                            roomName = "Комната с ящиком";
                            Console.WriteLine("Вы вошли в: " + roomName);
                            Box();
                            break;

                        case 2:
                            roomName = "Пустая комната";
                            Console.WriteLine("Вы вошли в: " + roomName);
                            EmptyRoom();
                            break;

                        case 3:
                            roomName = "Комната с монстром";
                            Console.WriteLine("Вы вошли в: " + roomName);
                            roomName = Monster(level); // Передаем уровень для определения сложности монстра
                            break;

                        case 4:
                            roomName = "Комната с ловушкой";
                            Console.WriteLine("Вы вошли в: " + roomName);
                            Trap();
                            break;

                        case 5:
                            roomName = "Комната с торговцем";
                            Console.WriteLine("Вы вошли в: " + roomName);
                            Dealer();
                            break;
                    }
                }

                dungeonMap[level - 1] = roomName;
                Console.WriteLine("Вы прошли комнату!");

                while (true)
                {
                    Console.WriteLine("Что вы хотите сделать дальше?");
                    Console.WriteLine("1. Пройти в следующую комнату");
                    Console.WriteLine("2. Открыть инвентарь");

                    string choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        level++;
                        break; // Переходим к следующей комнате
                    }
                    else if (choice == "2")
                    {
                        UsePotion();
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод. Пожалуйста, выберите 1 или 2.");
                    }
                }

                if (level > 10) break; // Предотвращаем переход на уровень 11
            }

            // Конец игры (если не победили босса)
            if (playerHealth <= 0)
            {
                Console.WriteLine("Вы погибли в подземелье!");
            }
            else
            {
                Console.WriteLine("Вы прошли подземелье!");
            }

            Console.WriteLine("\nКарта подземелья:");
            for (int i = 0; i < dungeonMap.Length; i++)
            {
                if (dungeonMap[i] != null)
                {
                    Console.WriteLine($"Уровень {i + 1}: {dungeonMap[i]}");
                }
                else
                {
                    Console.WriteLine($"Уровень {i + 1}: Не исследовано");
                }
            }

            Console.ReadKey();
        }

        // Метод для использования зелий из инвентаря
        static void UsePotion()
        {
            if (potions <= 0)
            {
                Console.WriteLine("У вас нет зелий.");
                return;
            }

            if (playerHealth == 100)
            {
                Console.WriteLine("Ваше здоровье уже максимально. Использовать зелье не требуется.");
                return;
            }

            int healthNeeded = 100 - playerHealth;
            double potionsNeededDouble = (double)healthNeeded / 30; // Зелье восстанавливает 30 здоровья
            int potionsNeeded = (potionsNeededDouble > 0) ? Convert.ToInt32(Math.Floor(potionsNeededDouble + 0.5)) : Convert.ToInt32(Math.Ceiling(potionsNeededDouble - 0.5));


            Console.WriteLine($"У вас {potions} зелий. Ваше здоровье {playerHealth}. Для полного восстановления нужно {potionsNeeded} зелий.");
            Console.WriteLine("Сколько вы хотите использовать?");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int potionsToUse))
            {
                if (potionsToUse <= 0)
                {
                    Console.WriteLine("Пожалуйста, введите положительное число.");
                }
                else if (potionsToUse > potions)
                {
                    Console.WriteLine("У вас недостаточно зелий.");
                }
                else if (potionsToUse > potionsNeeded)
                {
                    Console.WriteLine($"Вам не нужно столько зелий! Для полного восстановления достаточно {potionsNeeded} зелий.");
                }
                else
                {
                    potions -= potionsToUse;

                    for (int i = 0; i < potionsToUse; i++)
                    {
                        playerHealth += 30; // Зелье восстанавливает 30 здоровья
                        if (playerHealth > 100) playerHealth = 100;
                    }
                    Console.WriteLine($"Вы использовали {potionsToUse} зелий. Ваше здоровье: {playerHealth}");
                }
            }
            else
            {
                Console.WriteLine("Неверный ввод. Пожалуйста, введите число.");
            }
        }

        public static string Boss()
        {
            Console.WriteLine(); // Пустая строка для разделения

            int bossHealth = random.Next(50, 71); // Здоровье босса 
            Console.WriteLine($"Здоровье БОССА: {bossHealth}");

            while (playerHealth > 0 && bossHealth > 0)
            {
                Console.WriteLine("Выберите оружие: (1) Меч, (2) Лук");
                string weaponChoice = Console.ReadLine();
                try
                {
                    if (weaponChoice == "1" && hasSword) // Меч
                    {
                        int playerDamage = random.Next(10, 21); // Урон мечом
                        Console.WriteLine($"Вы атаковали мечом и нанесли {playerDamage} урона.");
                        bossHealth -= playerDamage; // Вычисляем здоровье босса после атаки игрока
                        Console.WriteLine($"Здоровье БОССА после атаки: {bossHealth}");
                    }
                    else if (weaponChoice == "2" && hasBow && arrows > 0) // Лук
                    {

                        arrows--;
                        int playerDamage = random.Next(5, 16); // Урон луком
                        Console.WriteLine($"Вы выстрелили из лука и нанесли {playerDamage} урона. Осталось стрел: {arrows}");
                        bossHealth -= playerDamage; // Вычисляем здоровье босса после атаки игрока
                        Console.WriteLine($"Здоровье БОССА после атаки: {bossHealth}");

                    }
                    else if (weaponChoice == "1" && !hasSword)
                    {
                        Console.WriteLine("У вас нет меча!");
                        continue;
                    }
                    else if (weaponChoice == "2" && !hasBow)
                    {
                        Console.WriteLine("У вас нет лука!");
                        continue;
                    }
                    else if (weaponChoice == "2" && arrows <= 0)
                    {
                        Console.WriteLine("У вас закончились стрелы! Вы не можете использовать лук.");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Неверный выбор оружия.");
                        continue;
                    }

                    if (bossHealth <= 0)
                    {
                        Console.WriteLine("Вы ПОБЕДИЛИ БОССА!");
                        playerExperience += 50; // Награда за босса
                        CheckLevelUp();
                        return "Комната с ПОБЕЖДЕННЫМ БОССОМ"; // Возвращаем новое название комнаты
                    }

                    // Ответный удар босса
                    int bossDamage = random.Next(5, 16); // Добавлен урон босса
                    playerHealth -= bossDamage;
                    Console.WriteLine($"БОСС атаковал вас и нанес {bossDamage} урона.");
                    Console.WriteLine($"Ваше здоровье: {playerHealth}");

                    if (playerHealth <= 0)
                    {
                        Console.WriteLine("Вы погибли от БОССА!");
                        return "Комната со смертью от БОССА"; // Возвращаем новое название комнаты
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Произошла ошибка при обработке вашего ответа.");
                }
            }

            return "Комната с БОССОМ (бой продолжается)"; // Добавлено для избежания ошибки компиляции
        }
        //Новые загадки

        public static void Box()
        {
            //Console.WriteLine(); // Пустая строка для разделения
            Console.WriteLine("Вы нашли сундук! Чтобы его открыть, решите загадку:");

            string riddle = "";
            string answer = "";

            // Выбираем случайную загадку
            int riddleIndex = random.Next(0, 5); // Всего 5 загадок
            switch (riddleIndex)
            {
                case 0:
                    riddle = "Что это такое: сидит на дереве, но не птица?";
                    answer = "лист";
                    break;
                case 1:
                    riddle = "Что это такое: без языка, а говорит?";
                    answer = "книга";
                    break;
                case 2:
                    riddle = "Что это такое: зимой и летом одним цветом?";
                    answer = "елка";
                    break;
                case 3:
                    riddle = "Что может путешествовать по миру, оставаясь в одном и том же углу?";
                    answer = "почтовая марка";
                    break;
                case 4:
                    riddle = "Что всегда идет, но никогда не приходит?";
                    answer = "время";
                    break;
            }

            Console.WriteLine(riddle);

            while (true)
            {
                string playerAnswer = Console.ReadLine();

                try
                {
                    // Проверяем, что игрок ввел текст, а не число
                    int temp;
                    if (int.TryParse(playerAnswer, out temp))
                    {
                        Console.WriteLine("Неверный ввод! Введите ответ словами, а не числами.");
                        continue; // Повторяем цикл
                    }

                    if (playerAnswer.ToLower() == answer)
                    {
                        Console.WriteLine("Верно! Вы открыли сундук!");

                        // Случайная награда из сундука
                        int rewardType = random.Next(1, 4); // 1 - зелье, 2 - золото, 3 - стрелы
                        switch (rewardType)
                        {
                            case 1:
                                Console.WriteLine("Вы нашли зелье здоровья!");
                                //AddToInventory("Зелье"); // Больше не добавляем зелье в инвентарь, а увеличиваем счетчик зелий
                                potions++;
                                break;
                            case 2:
                                int goldAmount = random.Next(20, 51); // Случайное количество золота
                                gold += goldAmount;
                                Console.WriteLine($"Вы нашли {goldAmount} золота!");
                                break;
                            case 3:
                                int arrowAmount = random.Next(5, 11); // Случайное количество стрел
                                arrows += arrowAmount;
                                Console.WriteLine($"Вы нашли {arrowAmount} стрел!");
                                break;
                        }
                        break; // Выходим из цикла, если ответ корректный
                    }
                    else
                    {
                        Console.WriteLine("Неверно! Сундук закрыт.");
                        break; // Выходим из цикла, если ответ неверный
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Произошла ошибка при обработке вашего ответа.");
                }
            }
        }

        public static void Dealer()
        {
            //Console.WriteLine(); // Пустая строка для разделения
            Console.WriteLine("Вы встретили торговца. Он предлагает зелье за 30 золота. Купить? (да/нет)");

            while (true) // Цикл для повторного запроса, пока не будет введен корректный ответ
            {
                string answer = Console.ReadLine();
                try
                {
                    if (answer.ToLower() == "да")
                    {
                        if (gold >= 30)
                        {
                            gold -= 30;
                            Console.WriteLine("Вы купили зелье здоровья.");
                            //AddToInventory("Зелье"); // Больше не добавляем зелье в инвентарь, а увеличиваем счетчик зелий
                            potions++;
                        }
                        else
                        {
                            Console.WriteLine("У вас недостаточно золота.");
                        }
                        break; // Выходим из цикла, если ответ корректный
                    }
                    else if (answer.ToLower() == "нет")
                    {
                        Console.WriteLine("Торговец ушел.");
                        break; // Выходим из цикла, если ответ корректный
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод. Пожалуйста, введите 'да' или 'нет'.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Произошла ошибка при обработке вашего ответа.");
                }
            }
        }

        public static void EmptyRoom()
        {
            //Console.WriteLine(); // Пустая строка для разделения
            Console.WriteLine("Вы вошли в пустую комнату. Здесь ничего нет.");
        }

        //Уровни сложности монстров

        public static string Monster(int level)
        {
            Console.WriteLine(); // Пустая строка для разделения

            int monsterHealth = 0;
            int monsterDamage = 0;
            int experienceReward = 0;

            // Настройка сложности в зависимости от уровня игрока
            if (level <= 3)
            {
                monsterHealth = random.Next(20, 31);
                monsterDamage = random.Next(5, 11);
                experienceReward = 20;
                Console.WriteLine("Вы встретили слабого монстра.");
            }
            else if (level <= 7)
            {
                monsterHealth = random.Next(30, 41);
                monsterDamage = random.Next(8, 14);
                experienceReward = 30;
                Console.WriteLine("Вы встретили обычного монстра.");
            }
            else
            {
                monsterHealth = random.Next(40, 51);
                monsterDamage = random.Next(11, 17);
                experienceReward = 40;
                Console.WriteLine("Вы встретили сильного монстра.");
            }

            Console.WriteLine($"Здоровье монстра: {monsterHealth}");

            while (playerHealth > 0 && monsterHealth > 0)
            {
                Console.WriteLine("Выберите оружие: (1) Меч, (2) Лук");
                string weaponChoice = Console.ReadLine();
                try
                {
                    if (weaponChoice == "1" && hasSword) // Меч
                    {
                        int playerDamage = random.Next(10, 21); // Урон мечом
                        Console.WriteLine($"Вы атаковали мечом и нанесли {playerDamage} урона.");
                        monsterHealth -= playerDamage; // Вычисляем здоровье монстра после атаки игрока
                        Console.WriteLine($"Здоровье монстра после атаки: {monsterHealth}");
                    }
                    else if (weaponChoice == "2" && hasBow && arrows > 0) // Лук
                    {

                        arrows--;
                        int playerDamage = random.Next(5, 16); // Урон луком
                        Console.WriteLine($"Вы выстрелили из лука и нанесли {playerDamage} урона. Осталось стрел: {arrows}");
                        monsterHealth -= playerDamage; // Вычисляем здоровье монстра после атаки игрока
                        Console.WriteLine($"Здоровье монстра после атаки: {monsterHealth}");

                    }
                    else if (weaponChoice == "1" && !hasSword)
                    {
                        Console.WriteLine("У вас нет меча!");
                        continue;
                    }
                    else if (weaponChoice == "2" && !hasBow)
                    {
                        Console.WriteLine("У вас нет лука!");
                        continue;
                    }
                    else if (weaponChoice == "2" && arrows <= 0)
                    {
                        Console.WriteLine("У вас закончились стрелы! Вы не можете использовать лук.");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Неверный выбор оружия.");
                        continue;
                    }

                    if (monsterHealth <= 0)
                    {
                        Console.WriteLine("Вы победили монстра!");
                        playerExperience += experienceReward; // Награда за победу
                        CheckLevelUp();
                        return "Комната с побежденным монстром"; // Возвращаем новое название комнаты
                    }

                    // Ответный удар монстра

                    playerHealth -= monsterDamage;
                    Console.WriteLine($"Монстр атаковал вас и нанес {monsterDamage} урона.");
                    Console.WriteLine($"Ваше здоровье: {playerHealth}");

                    if (playerHealth <= 0)
                    {
                        Console.WriteLine("Вы погибли от монстра!");
                        return "Комната со смертью"; // Возвращаем новое название комнаты
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Произошла ошибка при обработке вашего ответа.");
                }
            }

            return "Комната с монстром (бой продолжается)";
        }

        //Разные виды ловушек
        public static void Trap()
        {
            Console.WriteLine(); // Пустая строка для разделения
            Console.WriteLine("Вы попали в ловушку!");

            int trapType = random.Next(1, 3); // 1 - урон здоровью, 2 - потеря золота
            switch (trapType)
            {
                case 1: // Урон здоровью
                    int damage = random.Next(10, 21);
                    playerHealth -= damage;
                    Console.WriteLine($"Ловушка нанесла вам {damage} урона. Ваше здоровье: {playerHealth}");
                    break;
                case 2: // Потеря золота
                    int goldLoss = random.Next(5, 16);
                    if (gold >= goldLoss)
                    {
                        gold -= goldLoss;
                        Console.WriteLine($"Ловушка украла у вас {goldLoss} золота. Ваше золото: {gold}");
                    }
                    else
                    {
                        Console.WriteLine("У вас недостаточно золота, чтобы ловушка что-то украла.");
                    }
                    break;
            }

            if (playerHealth <= 0)
            {
                Console.WriteLine("Вы погибли в ловушке!");
            }
        }
        //Система опыта
        static void CheckLevelUp()
        {
            while (playerExperience >= experienceToNextLevel)
            {
                playerExperience -= experienceToNextLevel;
                playerLevel++;
                experienceToNextLevel = playerLevel * 100; // Увеличиваем необходимое количество опыта
                playerHealth = 100; // Восстанавливаем здоровье при повышении уровня
                Console.WriteLine($"Поздравляем! Вы достигли {playerLevel} уровня!");
                Console.WriteLine($"Здоровье полностью восстановлено.");
            }
        }
        public static void AddToInventory(string item)
        {
            //Console.WriteLine(); // Пустая строка для разделения
            // Поиск свободной ячейки в инвентаре
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == null)
                {
                    inventory[i] = item;
                    Console.WriteLine($"Вы добавили '{item}' в инвентарь.");
                    PrintInventory();
                    return;
                }
            }

            Console.WriteLine("Ваш инвентарь полон. Вы не можете взять больше предметов.");
        }

        public static void PrintInventory()
        {
            //Console.WriteLine(); // Пустая строка для разделения
            Console.WriteLine("Инвентарь:");
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] != null)
                {
                    Console.WriteLine($"- {inventory[i]}");
                }
            }
        }
    }
}