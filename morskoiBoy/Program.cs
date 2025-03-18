using System;
using System.Collections.Generic;
using System.Linq;
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
            int counterShips = 0;

            Console.WriteLine("РАССТАВЬТЕ ВАШИ КОРАБЛИ");

            while (counterShips != 20)
            {
                CheckPlayerArray(colorPlayerArray, coordinateI, coordinateJ);
                string movement = Console.ReadLine();
                switch (movement.ToLower())
                {
                    case ("w"):
                        if (coordinateI > 0)
                        {
                            coordinateI--;
                        }
                        break;
                    case ("a"):
                        if (coordinateJ > 0)
                        {
                            coordinateJ--;
                        }
                        break;
                    case ("s"):
                        if (coordinateI < 9)
                        {
                            coordinateI++;
                        }
                        break;
                    case ("d"):
                        if (coordinateJ < 9)
                        {
                            coordinateJ++;
                        }
                        break;
                    case (""):
                        if (colorPlayerArray[coordinateI, coordinateJ] != "-")
                        {
                            colorPlayerArray[coordinateI, coordinateJ] = "-";
                            counterShips++;
                            counter++;
                        }
                        break;
                }
            }
        }

        //ВЫВОДИМ ЦВЕТНОЙ МАССИВ ИГРОКА
        static void CheckPlayerArray(string[,] colorPlayerArray, int coordinateI, int coordinateJ)
        {
            Console.Clear();
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
            CheckPlayerArray(colorPlayerArray, 0, 0);
            Console.ReadKey();

        }

    }
}