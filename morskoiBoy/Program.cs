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
        static string[,] ArrangePlayerArray(string[,] array, Dictionary<string, int> playerShips, bool playerArrange, bool mode)
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

            Console.WriteLine("РАССТАВЬТЕ ВАШИ КОРАБЛИ: В ПОРЯДКЕ ОТ 4 ДО 1");

            while (counterShips != 20)
            {
                if (playerArrange)
                {
                    CheckPlayerArray(array, coordinateI, coordinateJ, playerShips, mode);
                    movement = Console.ReadLine();
                }
                else
                {
                    if (counter == 0 || counter == 1 || maxCounter == 2)
                    {
                        if (counter == 0)
                        {
                            CheckPlayerArray(array, coordinateI, coordinateJ, playerShips, mode);
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
                            CheckPlayerArray(array, coordinateI, coordinateJ, playerShips, mode);
                            Random random = new Random();
                            int nextMovement = random.Next(1, 8);
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
                    }
                    else
                    {
                        movement = direction;
                    }
                }
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
                        if (counter != 0)
                        {

                            break;
                        }
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
                        }
                        else
                        {
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
                        }
                        else
                        {
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
                        }
                        else
                        {
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
                        }
                        else
                        {
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
            return value1;
        }
        public static void Fight(string[,] playerArray, string[,] botArray,
                       Dictionary<string, int> playerShips, bool mode)
        {
            int coordinateI = 0;
            int coordinateJ = 0;
            string movement;
            string[,] combinedArray = CombineArrays(playerArray, botArray);
            bool playerTurn = true;

            while (true)
            {
                if (playerTurn)
                {
                    CheckCombinedArray(combinedArray, coordinateI, coordinateJ, playerShips, mode);
                    movement = Console.ReadLine();

                    switch (movement.ToLower())
                    {
                        case ("w"):
                            if (coordinateI > 0) coordinateI--;
                            break;
                        case ("a"):
                            if (coordinateJ > 0) coordinateJ--;
                            break;
                        case ("s"):
                            if (coordinateI < 9) coordinateI++;
                            break;
                        case ("d"):
                            if (coordinateJ < 9) coordinateJ++;
                            break;
                        case (""):
                            playerTurn = ProcessShot(combinedArray, coordinateI, coordinateJ);
                            break;
                    }
                }
                else
                {
                    playerTurn = BotTurn(combinedArray);
                }
            }
        }

        static bool ProcessShot(string[,] array, int i, int j)
        {
            if (array[i, j + 11] == "-")
            {
                array[i, j + 11] = "+";
            }
            else if (array[i, j + 11] == "*" || array[i, j + 11] == "#")
            {
                array[i, j + 11] = "=";
            }
            return false;
        }

        static bool BotTurn(string[,] array)
        {
            Random rand = new Random();
            int i, j;

            do
            {
                i = rand.Next(0, 10);
                j = rand.Next(0, 10);
            }
            while (array[i, j] == "+" || array[i, j] == "=");

            if (array[i, j] == "-")
            {
                array[i, j] = "+";
            }
            else
            {
                array[i, j] = "=";
            }

            return true;
        }

        static string[,] CombineArrays(string[,] playerArray, string[,] botArray)
        {
            int rows = playerArray.GetLength(0);
            int totalCols = 21;

            string[,] combinedArray = new string[rows, totalCols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    combinedArray[i, j] = playerArray[i, j];
                }
            }

            for (int i = 0; i < rows; i++)
            {
                combinedArray[i, 10] = " ";
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    combinedArray[i, j + 11] = botArray[i, j];
                }
            }

            return combinedArray;
        }

        static void CheckCombinedArray(string[,] combinedArray, int cursorI, int cursorJ,
                       Dictionary<string, int> playerShips, bool mode)
        {
            Console.Clear();

            Console.WriteLine("     Ваше поле            Поле противника");
            Console.WriteLine("   A B C D E F G H I J   A B C D E F G H I J");
            Console.WriteLine("-------------------------------------------------");

            for (int i = 0; i < combinedArray.GetLength(0); i++)
            {
                Console.ResetColor();
                Console.Write(i < 9 ? $" {i + 1} " : $"{i + 1} ");

                // Левая часть - поле игрока (0-9)
                for (int j = 0; j < 10; j++)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;

                    if (combinedArray[i, j] == "-")
                    {
                        if (mode)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.BackgroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Green;
                        }
                    }
                    else if (combinedArray[i, j] == "+")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        if (mode)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                        }
                    }
                    else if (combinedArray[i, j] == "=")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        if (mode)
                        {
                            Console.BackgroundColor = ConsoleColor.Cyan;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                        }
                    }
                    else
                    {
                        if (mode)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    Console.Write(combinedArray[i, j] + " ");
                    Console.ResetColor();
                }

                Console.ResetColor();
                Console.Write("  ");

                // Правая часть - поле бота (11-20)
                for (int j = 11; j < 21; j++)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;

                    if (i == cursorI && j == cursorJ + 11)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else if (combinedArray[i, j] == "-")
                    {
                        if (mode)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Green;
                        }
                    }
                    else if (combinedArray[i, j] == "+")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        if (mode)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                        }
                    }
                    else if (combinedArray[i, j] == "=")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        if (mode)
                        {
                            Console.BackgroundColor = ConsoleColor.Cyan;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                        }
                    }
                    else
                    {
                        if (mode)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    Console.Write(combinedArray[i, j] + " ");
                    Console.ResetColor();
                }

                Console.ResetColor();
                Console.Write($"  {i + 1}");
                Console.WriteLine();
            }

            Console.ResetColor();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("   A B C D E F G H I J   A B C D E F G H I J");
        }

        //ВЫВОДИМ МАССИВ ИГРОКА ПРИ ЕГО ЗАПОЛНЕНИИ
        static void CheckPlayerArray(string[,] array, int coordinateI, int coordinateJ, Dictionary<string, int> playerShips, bool mode)
        {
            Console.Clear();
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
                if (!mode)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
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
                        if (!mode)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
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
                    if (!mode)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                Console.ResetColor();
                Console.WriteLine("  " + (i + 1));
            }
            Console.ResetColor();
            Console.WriteLine("----------------------------");
        }

        //ВЫБИРАЕМ РЕЖИМ
        static bool Mode()
        {
            while (true)
            {
                Console.WriteLine("Выберите режим игры: \n1. Классический \n2. Режим разработчика ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case ("1"):
                        return true;
                    case ("2"):
                        return false;
                    default:
                        Console.WriteLine("Введите корректное значение");
                        break;
                }
            }
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
            bool mode = Mode();
            ArrangePlayerArray(playerArray, playerShips, false, mode);
            ArrangePlayerArray(botArray, botShips, false, mode);

            CheckPlayerArray(botArray, -1, -1, playerShips, mode);
            string[,] combinedArray = CombineArrays(playerArray, botArray);

            Fight(playerArray, botArray, playerShips, mode);
            while (true)
            {
                Console.ReadKey();
            }
        }
    }
}