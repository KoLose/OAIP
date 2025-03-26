using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace morskoiBoy
{
    internal class Program
    {
        //ЗАПОЛНЕНИЕ МАССИВОВ
        static string[,] FillArray(string[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    array[i, j] = "*";
                }
            }
            return array;
        }

        //ЗАПОЛНЕНИЕ СЛОВАРЕЙ
        static Dictionary<string, int> FillShips(Dictionary<string, int> dictionaryShips)
        {
            dictionaryShips.Add("4-х палубный", 1);
            dictionaryShips.Add("3-х палубный", 2);
            dictionaryShips.Add("2-х палубный", 3);
            dictionaryShips.Add("1 палубный", 4);

            return dictionaryShips;
        }

        //РАССТАНОВКА КОРАБЛЕЙ
        static string[,] ArrangePlayerArray(string[,] array, Dictionary<string, int>playerShips, bool playerArrange)
        {
            int coordinateI = 0;
            int coordinateJ = 0;
            int counter = 0;
            int maxCounter = 5;
            int counterShips = 0;
            bool value = false;
            bool value1 = true;
            string direction = "";
            string movement;

            Console.WriteLine("РАССТАВЬТЕ ВАШИ КОРАБЛИ: 4-ПАЛУБНЫЕ..3 И ПОПОРЯДКУ");

            while (counterShips != 20)
            {
                Console.WriteLine(playerArrange);
                if (playerArrange)
                {
                    CheckPlayerArray(array, coordinateI, coordinateJ, playerShips);
                    Console.WriteLine("counterships: " + counterShips);
                    movement = Console.ReadLine();
                }
                else
                {
                    if (counter == 0 || counter == 1 || maxCounter == 2)
                    {
                        Console.WriteLine("Количество кораблей в боте: " + counterShips);
                        CheckPlayerArray(array, coordinateI, coordinateJ, playerShips);
                        Random random = new Random();
                        int nextMovement = random.Next(1, 10);
                        if (nextMovement == 1 || nextMovement == 2)
                        {
                            movement = "w";
                        }
                        else if (nextMovement == 3 || nextMovement == 4)
                        {
                            movement = "a";
                        }
                        else if (nextMovement == 5 || nextMovement == 6)
                        {
                            movement = "s"; ;
                        }
                        else if (nextMovement == 7 || nextMovement == 8)
                        {
                            movement = "d";
                        }
                        else
                        {
                            movement = "";
                        }
                    }
                    else
                    {
                        movement = direction;
                    }
                }
                Console.WriteLine(movement);



                switch (movement.ToLower())
                {
                    case ("w"):
                        if (coordinateI > 0)
                        {
                            if (counter == 1)
                            {
                                value1 = SecondSecurityArrangeShips(value1, movement, maxCounter, coordinateI, coordinateJ, array);
                            }
                            if (value && value1 && (direction == "" || direction == "w") && counter + 1 <= maxCounter)
                            {
                                FirstSecurityArrangeShips(array, coordinateI, coordinateJ);
                                array[coordinateI, coordinateJ] = "-";
                                coordinateI--;
                                counter++;
                                counterShips++;
                                direction = "w";
                                if (counter + 1 == maxCounter)
                                {
                                    direction = "";
                                    value = false;
                                    array[coordinateI, coordinateJ] = "-";
                                    counterShips++;
                                }
                            }
                            else if (value1 == false && counter == 1)
                            {
                                array[coordinateI, coordinateJ] = "*";
                                value1 = true;
                            }
                            else if (direction != "" && direction != "w")
                            {
                            }
                            else
                            {
                                direction = "";
                                coordinateI--;
                            }
                        }
                        break;

                    case ("a"):
                        if (coordinateJ > 0)
                        {
                            if (counter == 1)
                            {
                                value1 = SecondSecurityArrangeShips(value1, movement, maxCounter, coordinateI, coordinateJ, array);
                            }
                            if (value && value1 && (direction == "" || direction == "a") && counter + 1 <= maxCounter)
                            {
                                FirstSecurityArrangeShips(array, coordinateI, coordinateJ);
                                array[coordinateI, coordinateJ] = "-";
                                coordinateJ--;
                                counter++;
                                counterShips++;
                                direction = "a";
                                if (counter + 1 == maxCounter)
                                {
                                    direction = "";
                                    value = false;
                                    array[coordinateI, coordinateJ] = "-";
                                    counterShips++;
                                }
                            }
                            else if (value1 == false && counter == 1)
                            {
                                array[coordinateI, coordinateJ] = "*";
                                value1 = true;
                            }
                            else if (direction != "" && direction != "a")
                            {
                            }
                            else
                            {
                                direction = "";
                                coordinateJ--;
                            }
                        }
                        break;

                    case ("s"):
                        if (coordinateI < 9)
                        {
                            if (counter == 1)
                            {
                                value1 = SecondSecurityArrangeShips(value1, movement, maxCounter, coordinateI, coordinateJ, array);
                            }
                            if (value && value1 && (direction == "" || direction == "s") && counter + 1 <= maxCounter)
                            {
                                FirstSecurityArrangeShips(array, coordinateI, coordinateJ);
                                array[coordinateI, coordinateJ] = "-";
                                coordinateI++;
                                counter++;
                                counterShips++;
                                direction = "s";
                                if (counter + 1 == maxCounter)
                                {
                                    direction = "";
                                    value = false;
                                    array[coordinateI, coordinateJ] = "-";
                                    counterShips++;
                                }
                            }
                            else if (value1 == false && counter == 1)
                            {
                                array[coordinateI, coordinateJ] = "*";
                                value1 = true;
                            }
                            else if (direction != "" && direction != "s")
                            {
                            }
                            else
                            {
                                direction = "";
                                coordinateI++;
                            }
                        }
                        break;

                    case ("d"):
                        if (coordinateJ < 9)
                        {
                            if (counter == 1)
                            {
                                value1 = SecondSecurityArrangeShips(value1, movement, maxCounter, coordinateI, coordinateJ, array);
                            }
                            if (value && value1 && (direction == "" || direction == "d") && counter + 1 <= maxCounter)
                            {
                                FirstSecurityArrangeShips(array, coordinateI, coordinateJ);
                                array[coordinateI, coordinateJ] = "-";
                                coordinateJ++;
                                counter++;
                                counterShips++;
                                direction = "d";
                                if (counter + 1 == maxCounter)
                                {
                                    direction = "";
                                    value = false;
                                    array[coordinateI, coordinateJ] = "-";
                                    counterShips++;
                                }
                            }
                            else if (value1 == false && counter == 1)
                            {
                                array[coordinateI, coordinateJ] = "*";
                                value1 = true;
                                counterShips++;
                            }
                            else if (direction != "" && direction != "d")
                            {
                            }
                            else
                            {
                                direction = "";
                                coordinateJ++;
                            }
                        }
                        break;
                    case (""):
                        value1 = SecondSecurityArrangeShips(value1, movement, maxCounter, coordinateI, coordinateJ, array);
                        if (array[coordinateI, coordinateJ] == "*" && value1 && counter == 0)
                        {
                            array[coordinateI, coordinateJ] = "-";
                            counter++;
                            value = true;
                        }
                        break;
                }

                if (counter + 1 == maxCounter)
                {
                    if (maxCounter == 5)
                    {
                        playerShips["4-х палубный"]--;
                    }
                    else if (maxCounter == 4)
                    {
                        playerShips["3-х палубный"]--;
                    }
                    else if (maxCounter == 3)
                    {
                        playerShips["2-х палубный"]--;
                    }
                    else if (maxCounter == 2)
                    {
                        counterShips++;
                        playerShips["1 палубный"]--;
                    }
                    FirstSecurityArrangeShips(array, coordinateI, coordinateJ);
                    direction = "";
                    value = false;
                    counter = 0;
                }
                if (playerShips["4-х палубный"] > 0)
                {
                    maxCounter = 5;
                }
                else if (playerShips["3-х палубный"] > 0)
                {
                    maxCounter = 4;
                }
                else if (playerShips["2-х палубный"] > 0)
                {
                    maxCounter = 3;
                }
                else if (playerShips["1 палубный"] > 0)
                {
                    maxCounter = 2;
                }
                foreach (var item in playerShips)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
                Console.WriteLine(counter);
                Console.WriteLine(maxCounter);
                Console.WriteLine("value1Number1 = " + value1);
            }
            return array;
        }

        //ЦЕЛОСТНОСТЬ РАССТАНОВКИ КОРАБЛЕЙ БЛИЗКО ДРУГ ДРУГУ
        static void FirstSecurityArrangeShips(string[,] array, int coordinateI, int coordinateJ)
        {
            try
            {
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        int newI = coordinateI + i;
                        int newJ = coordinateJ + j;

                        if (newI >= 0 && newI < 10 && newJ >= 0 && newJ < 10 && array[newI, newJ] == "*")
                        {
                            array[newI, newJ] = "#";
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
            }
        }

        //ЦЕЛОСТНОСТЬ РАССТАНОВКИ КОРАБЛЕЙ НА КРАЮ МАССИВА
        static bool SecondSecurityArrangeShips(bool value1, string movement, int maxCounter, int coordinateI, int coordinateJ, string[,] array)
        {
            int counter = 0;
            int maxCounter2 = 4;
            int newCoordinateI = coordinateI;
            int newCoordinateJ = coordinateJ;
            bool value2 = true;

            if (movement == "w" || movement == "a" || movement == "s" || movement == "d")
            {
                try
                {
                    if (movement == "w")
                    {
                        for (int i = 2; i < maxCounter; i++)
                        {
                            coordinateI--;
                            if (array[coordinateI, coordinateJ] == "#")
                            {
                                value1 = false;
                                break;
                            }
                        }
                    }
                    else if (movement == "a")
                    {
                        for (int i = 2; i < maxCounter; i++)
                        {
                            coordinateJ--;
                            if (array[coordinateI, coordinateJ] == "#")
                            {
                                value1 = false;
                                break;
                            }
                        }
                    }
                    else if (movement == "s")
                    {
                        for (int i = 2; i < maxCounter; i++)
                        {
                            coordinateI++;
                            if (array[coordinateI, coordinateJ] == "#")
                            {
                                value1 = false;
                                break;
                            }
                        }
                    }
                    else if (movement == "d")
                    {
                        for (int i = 2; i < maxCounter; i++)
                        {
                            coordinateJ++;
                            if (array[coordinateI, coordinateJ] == "#")
                            {
                                value1 = false;
                                break;
                            }
                        }
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    value2 = false;
                }
            }

            if (movement == "")
            {
                coordinateI = newCoordinateI;
                coordinateJ = newCoordinateJ;

                for (int i = 2; i < maxCounter; i++)
                {
                    try
                    {
                        coordinateI--;
                        if (array[coordinateI, coordinateJ] == "#")
                        {
                            counter++;
                            value1 = false;
                            Console.WriteLine("w");
                        }
                        else
                        {
                            Console.WriteLine("w+");
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        maxCounter2--;
                        break;
                    }
                }

                coordinateI = newCoordinateI;
                coordinateJ = newCoordinateJ;

                for (int i = 2; i < maxCounter; i++)
                {
                    try
                    {
                        coordinateJ--;
                        if (array[coordinateI, coordinateJ] == "#")
                        {
                            counter++;
                            value1 = false;
                            Console.WriteLine("a");
                        }
                        else
                        {
                            Console.WriteLine("a+");
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        maxCounter2--;
                        break;
                    }
                }

                coordinateI = newCoordinateI;
                coordinateJ = newCoordinateJ;

                for (int i = 2; i < maxCounter; i++)
                {
                    try
                    {
                        coordinateI++;
                        if (array[coordinateI, coordinateJ] == "#")
                        {
                            counter++;
                            value1 = false;
                            Console.WriteLine("s");
                        }
                        else
                        {
                            Console.WriteLine("s+");
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        maxCounter2--;
                        break;
                    }
                }

                coordinateI = newCoordinateI;
                coordinateJ = newCoordinateJ;

                for (int i = 2; i < maxCounter; i++)
                {
                    try
                    {
                        coordinateJ++;
                        if (array[coordinateI, coordinateJ] == "#")
                        {
                            counter++;
                            value1 = false;
                            Console.WriteLine("d");
                        }
                        else
                        {
                            Console.WriteLine("d+");
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        maxCounter2--;
                        break;
                    }
                }

                if (counter != maxCounter2)
                {
                    value1 = true;
                }
            }

            if (!value2)
            {
                value1 = false;
            }

            Console.WriteLine("value1 = " + value1);
            return value1;
        }
        public void Fight ()
        {

        }
        //ВЫВОДИМ МАССИВ ИГРОКА
        static void CheckPlayerArray(string[,] array, int coordinateI, int coordinateJ, Dictionary<string, int> playerShips)
        {
            //Console.Clear();
            Console.WriteLine("    A B C D E F G H I J\n----------------------------");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.ResetColor();
                if (i < 9)
                {
                    Console.Write(" " + (i + 1) + "  ");
                }
                else
                {
                    Console.Write((i + 1) + "  ");
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkBlue;

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i == coordinateI && j == coordinateJ)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(" ");
                    }
                    else if (array[i, j] == "-")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write("-");
                    }
                    else
                    {
                        Console.Write(array[i, j]);
                    }

                    if (j < array.GetLength(1) - 1)
                    {
                        Console.Write(" ");
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                Console.ResetColor();
                Console.WriteLine("  " + (i + 1));
            }
            Console.ResetColor();
            Console.WriteLine("----------------------------");
        }

        static void Main(string[] args)
        {
            //СОЗДАЁМ МАССИВЫ
            string[,] playerArray = new string[10, 11];
            string[,] botArray = new string[10, 11];

            //СОЗДАЁМ СЛОВАРИ
            Dictionary<string, int> playerShips = new Dictionary<string, int>();
            Dictionary<string, int> botShips = new Dictionary<string, int>();

            //ЗАПОЛНЯЕМ МАССИВЫ
            FillArray(playerArray);
            FillArray(botArray);

            //ЗАПОЛНЯЕМ СЛОВАРИ
            FillShips(playerShips);
            FillShips(botShips);

            //ИНИЦИАЛИЗАЦИЯ ИГРЫ
            Console.WriteLine("Добро пожаловать в игру morskoiBoy");
            ArrangePlayerArray(playerArray, playerShips, true);
            ArrangePlayerArray(botArray, botShips, false);
            Console.Clear();
            CheckPlayerArray(playerArray, 0, 0, playerShips);
            CheckPlayerArray(botArray, 0, 0, botShips);
            while (true)
            {
                Console.ReadKey();
            }
        }
    }
}