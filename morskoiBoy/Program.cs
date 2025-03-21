﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace morskoiBoy
{
    internal class Program
    {

        //ЗАПОЛНЕНИЕ ЦВЕТНОГО МАССИВА ИГРОКА
        static string[,] FillColorPlayerArray(string[,] colorPlayerArray)
        {
            for(int i = 0;i < colorPlayerArray.GetLength(0); i++) {
                for (int j = 0; j < 10; j++) {
                    colorPlayerArray[i, j] = "*";
                }
            }
            return colorPlayerArray;
        }

        //ЗАПОЛНЕНИЕ МАССИВА БОТА
        static string[,] FillBotArray(string[,] botArray)
        {
            for (int i = 0; i < botArray.GetLength(0); i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    botArray[i, j] = "*";
                }
            }
            return botArray;
        }

        //ЗАПОЛНЕНИЕ СЛОВАРЯ КОРАБЛЕЙ ИГРОКА
        static Dictionary<string, int> FillPlayerShips(Dictionary<string, int> playerShips)
        {
            playerShips.Add("4-х палубный", 1);
            playerShips.Add("3-х палубный", 2);
            playerShips.Add("2-х палубный", 3);
            playerShips.Add("1 палубный", 4);
            
            return playerShips;
        }

        //ЗАПОЛНЕНИЕ СЛОВАРЯ КОРАБЛЕЙ БОТА
        static Dictionary<string, int> FillBotShips(Dictionary<string, int> botShips)
        {
            botShips.Add("4-х палубный", 1);
            botShips.Add("3-х палубный", 2);
            botShips.Add("2-х палубный", 3);
            botShips.Add("1 палубный", 4);

            return botShips;
        }

        //РАССТАНОВКА КОРАБЛЕЙ ИГРОКА
        static void ArrangePlayerArray(string[,] colorPlayerArray, Dictionary<string, int> playerShips)
        {
            int coordinateI = 0;
            int coordinateJ = 0;
            int counter = 0;
            int maxCounter = 5;
            int counterShips = 0;
            bool value = false;
            bool value1 = true;
            string direction = "";

            Console.WriteLine("РАССТАВЬТЕ ВАШИ КОРАБЛИ: 4-ПАЛУБНЫЕ..3 И ПОПОРЯДКУ");

            while (counterShips != 20)
            {
                CheckPlayerArray(colorPlayerArray, coordinateI, coordinateJ, playerShips);

                string movement = Console.ReadLine();
                switch (movement.ToLower())
                {
                    case ("w"):
                        if (coordinateI > 0)
                        {
                            if (value && value1 && (direction == "vertical" || direction == "") && counter <= maxCounter)
                            {
                                FirstSecurityArrangeShips(colorPlayerArray, coordinateI, coordinateJ);
                                colorPlayerArray[coordinateI, coordinateJ] = "-";
                                coordinateI--;
                                counter++;
                                counterShips++;
                                direction = "vertical";
                            }
                            else
                            {
                                coordinateI--;
                            }
                        }
                        break;

                    case ("a"):
                        if (coordinateJ > 0)
                        {
                          
                            if (value && value1 && (direction == "horizontal" || direction == "") && counter <= maxCounter)
                            {
                                FirstSecurityArrangeShips(colorPlayerArray, coordinateI, coordinateJ);

                                colorPlayerArray[coordinateI, coordinateJ] = "-";
                                coordinateJ--;
                                counter++;
                                counterShips++;
                                direction = "horizontal";
                            }
                            else
                            {
                                coordinateJ--;
                            }
                        }
                        break;

                    case ("s"):
                        if (coordinateI < 9)
                        {
                          
                            if (value && value1 && (direction == "vertical" || direction == "") && counter <= maxCounter)
                            {
                                FirstSecurityArrangeShips(colorPlayerArray, coordinateI, coordinateJ);

                                colorPlayerArray[coordinateI, coordinateJ] = "-";
                                coordinateI++;
                                counter++;
                                counterShips++;
                                direction = "vertical";
                            }
                            else
                            {
                                coordinateI++;
                            }
                        }
                        break;

                    case ("d"):
                        if (coordinateJ < 9)
                        {
                           
                            if (value && value1 && (direction == "horizontal" || direction == "") && counter <= maxCounter)
                            {
                                FirstSecurityArrangeShips(colorPlayerArray, coordinateI, coordinateJ);

                                colorPlayerArray[coordinateI, coordinateJ] = "-";
                                coordinateJ++;
                                counter++;
                                counterShips++;
                                direction = "horizontal";
                            }
                            else
                            {
                                coordinateJ++;
                            }
                        }
                        break;
                    case (""):
                        if (colorPlayerArray[coordinateI, coordinateJ] == "*" && value == false)
                        {
                            SecondSecurityArrangeShips(value1, movement, maxCounter, counter, coordinateI, coordinateJ, colorPlayerArray);
                            colorPlayerArray[coordinateI, coordinateJ] = "-";
                            counter++;
                            value = true;
                        }
                        break;
                }
                if (counter == maxCounter)
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
                        playerShips["1 палубный"]--;
                    }
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
                Console.WriteLine(counterShips);
                Console.WriteLine(value1);
            }
        }

        //ЦЕЛОСТНОСТЬ РАССТАНОВКИ КОРАБЛЕЙ БЛИЗКО ДРУГ ДРУГУ
        static void FirstSecurityArrangeShips(string[,] colorPlayerArray, int coordinateI, int coordinateJ)
        {
            try
            {
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        int newI = coordinateI + i;
                        int newJ = coordinateJ + j;

                        if (newI >= 0 && newI < 10 && newJ >= 0 && newJ < 10 && colorPlayerArray[newI, newJ] == "*")
                        {
                            colorPlayerArray[newI, newJ] = "#";
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
            }
        }

        //ЦЕЛОСТНОСТЬ РАССТАНОВКИ КОРАБЛЕЙ НА КРАЮ МАССИВА
        static bool SecondSecurityArrangeShips(bool value1, string movement, int maxCounter, int counter, int coordinateI, int coordinateJ, string[,] colorPlayerArray)
        {
                try
                {
                    if (movement == "w")
                    {
                        for (int i = 0; i < maxCounter - 1; i++)
                        {
                            coordinateI--;
                            if (colorPlayerArray[coordinateI, coordinateJ] == "#")
                            {
                                value1 = false;
                            }
                        }
                    }
                    else if (movement == "a")
                    {
                        for (int i = 0; i < maxCounter - 1; i++)
                        {
                            coordinateJ--;
                            if (colorPlayerArray[coordinateI, coordinateJ] == "#")
                            {
                                value1 = false;
                            }
                        }
                    }
                    else if (movement == "s")
                    {
                        for (int i = 0; i < maxCounter - 1; i++)
                        {
                            coordinateI++;
                            if (colorPlayerArray[coordinateI, coordinateJ] == "#")
                            {
                                value1 = false;
                            }
                        }
                    }
                    else if (movement == "d")
                    {
                        for (int i = 0; i < maxCounter - 1; i++)
                        {
                            coordinateJ++;
                            if (colorPlayerArray[coordinateI, coordinateJ] == "#")
                            {
                                value1 = false;
                            }
                        }
                    }
                }
                
                catch (IndexOutOfRangeException) { }
            Console.WriteLine(coordinateI + " " +coordinateJ);
            return value1;

        }
        //ВЫВОДИМ ЦВЕТНОЙ МАССИВ ИГРОКА
        static void CheckPlayerArray(string[,] colorPlayerArray, int coordinateI, int coordinateJ, Dictionary <string, int> playerShips)
        {
            //Console.Clear();
            Console.WriteLine("    A B C D E F G H J K\n----------------------------");
         
            for (int i = 0; i < colorPlayerArray.GetLength(0); i++) {
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

                for (int j = 0; j < colorPlayerArray.GetLength(1); j++)
                {
                    if (i == coordinateI && j == coordinateJ)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("X");
                    }
    
                    else
                    {
                        Console.Write(colorPlayerArray[i, j]);
                    }

                    if (j < colorPlayerArray.GetLength(1) - 1)
                    {
                        Console.Write(" ");
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                Console.ResetColor();
                Console.Write("  " + (i + 1));
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine();
            }
            Console.ResetColor();
            Console.WriteLine("----------------------------");
        }

        static void Main(string[] args)
        {   
            //СОЗДАЁМ МАССИВЫ
            string[,] colorPlayerArray = new string[10, 11];
            string[,] botArray = new string[10, 11];

            //СОЗДАЁМ СЛОВАРИ
            Dictionary<string, int> playerShips = new Dictionary<string, int>();
            Dictionary<string, int> botShips = new Dictionary<string, int>();

            //ЗАПОЛНЯЕМ МАССИВЫ
            FillColorPlayerArray(colorPlayerArray);
            FillBotArray(botArray);

            //ЗАПОЛНЯЕМ СЛОВАРИ
            FillPlayerShips(playerShips);
            FillBotShips(botShips);

            //ИНИЦИАЛИЗАЦИЯ ИГРЫ
            Console.WriteLine("Добро пожаловать в игру morskoiBoy");
            ArrangePlayerArray(colorPlayerArray, playerShips);
            CheckPlayerArray(colorPlayerArray, 0, 0, playerShips);
            Console.ReadKey();

        }

    }
}