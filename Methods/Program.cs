using System;
using System.Linq;
using System.Text;

public class Methods
{
    public static void Main(string[] args)
    {
        // 1. Сумма двух и трёх чисел
        Console.WriteLine("1. Сумма двух и трёх чисел:");
        Calcul(5, 3);

        // 2. Минимальное и максимальное значение
        Console.WriteLine("\n2. Минимальное и максимальное значение:");
        Console.WriteLine("Меньшее из 10 и 5: " + Min(10, 5));
        Console.WriteLine("Большее из 10 и 5: " + Max(10, 5));

        // 3. Проверка на палиндром
        Console.WriteLine("\n3. Проверка на палиндром:");
        Console.WriteLine("\"level\" - палиндром: " + IsPalindrome("level"));
        Console.WriteLine("\"hello\" - палиндром: " + IsPalindrome("hello"));

        // 4. Факториал числа
        Console.WriteLine("\n4. Факториал числа:");
        Console.WriteLine("Факториал 5: " + Factorial(5));

        // 5. Среднее арифметическое
        Console.WriteLine("\n5. Среднее арифметическое:");
        Console.WriteLine("Среднее арифметическое 2, 4, 6: " + Average(2, 4, 6));

        // 6. Поиск символа в строке
        Console.WriteLine("\n6. Поиск символа в строке:");
        Console.WriteLine("Индекс 'e' в \"hello\": " + FindChar("hello", 'e'));
        Console.WriteLine("Индекс 'a' в \"hello\": " + FindChar("hello", 'a'));

        // 7. Генерация случайного пароля (только цифры)
        Console.WriteLine("\n7. Генерация случайного пароля (только цифры):");
        Console.WriteLine("Случайный пароль длиной 6: " + GeneratePassword(6));

        // 8. Конвертация температуры
        Console.WriteLine("\n8. Конвертация температуры:");
        Console.WriteLine("0 градусов Цельсия в Фаренгейты: " + CelsiusToFahrenheit(0));
        Console.WriteLine("32 градуса Фаренгейта в Цельсии: " + FahrenheitToCelsius(32));

        // 9. Перестановка слов в предложении
        Console.WriteLine("\n9. Перестановка слов в предложении:");
        Console.WriteLine("Перестановка слов в \"Hello world!\": " + ReverseWords("Hello world!"));

        // 10. Таблица умножения для числа
        Console.WriteLine("\n10. Таблица умножения для числа:");
        MultiplicationTable(5);
    }

    // 1. Сумма двух и трёх чисел
    static void Calcul(int a, int b)
    {
        Console.WriteLine("Сумма: " + (a + b));
        Console.WriteLine("Разность: " + (a - b));
        Console.WriteLine("Произведение: " + (a * b));
        if (b != 0)
        {
            Console.WriteLine("Частное: " + ((double)a / b));
        }
        else
        {
            Console.WriteLine("Деление на ноль!");
        }
    }


    // 2. Минимальное и максимальное значение
    static int Min(int a, int b)
    {
        return a < b ? a : b;
    }

    static int Max(int a, int b)
    {
        return a > b ? a : b;
    }

    // 3. Проверка на палиндром
    static bool IsPalindrome(string str)
    {
        str = str.ToLower(); // Преобразуем строку в нижний регистр, чтобы не учитывать регистр
        string reversedStr = new string(str.ToCharArray().Reverse().ToArray());
        return str == reversedStr;
    }

    // 4. Факториал числа
    static long Factorial(int n)
    {
        if (n == 0)
        {
            return 1;
        }
        long result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    // 5. Среднее арифметическое
    static double Average(int a, int b, int c)
    {
        return (double)(a + b + c) / 3;
    }

    // 6. Поиск символа в строке
    static int FindChar(string text, char c)
    {
        return text.IndexOf(c);
    }

    // 7. Генерация случайного пароля (только цифры)
    static string GeneratePassword(int length)
    {
        Random random = new Random();
        StringBuilder password = new StringBuilder();
        for (int i = 0; i < length; i++)
        {
            password.Append(random.Next(0, 10)); // Добавляем случайную цифру от 0 до 9
        }
        return password.ToString();
    }

    // 8. Конвертация температуры
    static double CelsiusToFahrenheit(double c)
    {
        return c * 9 / 5 + 32;
    }

    static double FahrenheitToCelsius(double f)
    {
        return (f - 32) * 5 / 9;
    }

    // 9. Перестановка слов в предложении
    static string ReverseWords(string sentence)
    {
        string[] words = sentence.Split(' ');
        Array.Reverse(words);
        return string.Join(" ", words);
    }

    // 10. Таблица умножения для числа
    static void MultiplicationTable(int n)
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(n + " x " + i + " = " + (n * i));
        }
    }
}