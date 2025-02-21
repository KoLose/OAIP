using System;
using System.Linq;

public class Methods
{
    // --- Этап 1: Calcul (2 числа) ---
    public static (double plus, double minus, double product, string chastnoeMessage) Calcul(double a, double b)
    {
        double plus = a + b;
        double minus = a - b;
        double product = a * b;
        string chastnoeMessage;
        double chastnoe;

        if (b == 0)
        {
            chastnoe = 0;
            chastnoeMessage = "Деление на 0 недопустимо!";
        }
        else
        {
            chastnoe = a / b;
            chastnoeMessage = chastnoe.ToString();
        }

        return (plus, minus, product, chastnoeMessage);
    }

    // --- Этап 1.1: Calcul (3 числа) ---
    public static (double plus3, double product3, string chastnoeMessage3) Calcul(double a, double b, double c)
    {
        double plus3 = a + b + c;
        double product3 = a * b * c;
        string chastnoeMessage3;
        double chastnoe3;

        if (b == 0 || c == 0)
        {
            chastnoe3 = 0;
            chastnoeMessage3 = "Деление на 0 недопустимо!";
        }
        else
        {
            chastnoe3 = a / b / c;
            chastnoeMessage3 = chastnoe3.ToString();
        }

        return (plus3, product3, chastnoeMessage3);
    }

    // --- Этап 2: Min ---
    public static int Min(int chislo1, int chislo2)
    {
        if (chislo1 < chislo2)
        {
            return chislo1;
        }
        else
        {
            return chislo2;
        }
    }

    // --- Этап 3: Max ---
    public static int Max(int chislo1, int chislo2)
    {
        if (chislo1 > chislo2)
        {
            return chislo1;
        }
        else
        {
            return chislo2;
        }
    }

    // --- Этап 4: IsPalindrome ---
    public static bool IsPalindrome(string stroka)
    {
        string nizhniyRegistr = stroka.ToLower();
        bool result = nizhniyRegistr.SequenceEqual(nizhniyRegistr.Reverse());
        return result;
    }

    // --- Этап 5: Factorial ---
    public static long Factorial(int chislo)
    {
        if (chislo < 0)
        {
            return -1;
        }
        if (chislo == 0)
        {
            return 1;
        }

        long result = 1;
        for (int i = 1; i <= chislo; i++)
        {
            result *= i;
        }
        return result;
    }

    // --- Этап 6: Average ---
    public static double Average(int chislo1, int chislo2, int chislo3)
    {
        double result = (double)(chislo1 + chislo2 + chislo3) / 3;
        return result;
    }

    // --- Этап 7: FindChar ---
    public static int FindChar(string text, char simvol)
    {
        int result = text.IndexOf(simvol);
        return result;
    }

    // --- Этап 8: GeneratePassword ---
    public static string GeneratePassword(int dlina)
    {
        Random random = new Random();
        string parol = "";
        for (int i = 0; i < dlina; i++)
        {
            parol += random.Next(0, 10).ToString();
        }
        string result = parol;
        return result;
    }

    // --- Этап 9: CelsiusToFahrenheit ---
    public static double CelsiusToFahrenheit(double c)
    {
        double result = c * 9 / 5 + 32;
        return result;
    }

    // --- Этап 10: FahrenheitToCelsius ---
    public static double FahrenheitToCelsius(double f)
    {
        double result = (f - 32) * 5 / 9;
        return result;
    }

    // --- Этап 11: ReverseWords ---
    public static string ReverseWords(string predlozhenie)
    {
        string[] words = predlozhenie.Split(' ');
        Array.Reverse(words);
        string result = string.Join(" ", words);
        return result;
    }

    // --- Этап 12: MultiplicationTable ---
    public static void MultiplicationTable(int chislo)
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(chislo + " x " + i + " = " + (chislo * i));
        }
    }

    // --- Этап 13: Main ---
    public static void Main(string[] args)
    {
        Console.Write("Введите первое число: ");
        if (!double.TryParse(Console.ReadLine(), out double a))
        {
            Console.WriteLine("Некорректный ввод первого числа.");
            return;
        }

        Console.Write("Введите второе число: ");
        if (!double.TryParse(Console.ReadLine(), out double b))
        {
            Console.WriteLine("Некорректный ввод второго числа.");
            return;
        }

        (double plus, double minus, double product, string chastnoeMessage) result1 = Calcul(a, b);
        Console.WriteLine("Сумма: " + result1.plus + ", Разность: " + result1.minus + ", Произведение: " + result1.product + ", Частное: " + result1.chastnoeMessage);
        Console.WriteLine("________________");

        Console.Write("Введите третье число: ");
        if (!double.TryParse(Console.ReadLine(), out double c))
        {
            Console.WriteLine("Некорректный ввод третьего числа.");
            return;
        }

        (double plus3, double product3, string chastnoeMessage3) resultCalcul3 = Calcul(a, b, c);
        Console.WriteLine("Сумма 3 чисел: " + resultCalcul3.plus3 + ", Произведение 3 чисел: " + resultCalcul3.product3 + ", Частное 3 чисел: " + resultCalcul3.chastnoeMessage3);
        Console.WriteLine("________________");

        Console.Write("Введите первое число для сравнения: ");
        if (!int.TryParse(Console.ReadLine(), out int chislo1))
        {
            Console.WriteLine("Некорректный ввод первого числа для сравнения.");
            return;
        }

        Console.Write("Введите второе число для сравнения: ");
        if (!int.TryParse(Console.ReadLine(), out int chislo2))
        {
            Console.WriteLine("Некорректный ввод второго числа для сравнения.");
            return;
        }

        int minimum = Min(chislo1, chislo2);
        Console.WriteLine("Минимум из " + chislo1 + " и " + chislo2 + ": " + minimum);

        int maximum = Max(chislo1, chislo2);
        Console.WriteLine("Максимум из " + chislo1 + " и " + chislo2 + ": " + maximum);

        Console.WriteLine("________________");

        Console.WriteLine("Является ли 'level' палиндромом: " + IsPalindrome("level"));
        Console.WriteLine("Факториал числа 5: " + Factorial(5));

        Console.WriteLine("Среднее арифметическое 2, 4, 6: " + Average(2, 4, 6));

        Console.WriteLine("Индекс 'e' в 'hello': " + FindChar("hello", 'e'));

        Console.WriteLine("Случайный пароль длиной 8: " + GeneratePassword(8));

        Console.WriteLine("0 градусов Цельсия в Фаренгейтах: " + CelsiusToFahrenheit(0));
        Console.WriteLine("32 градуса Фаренгейта в Цельсиях: " + FahrenheitToCelsius(32));

        Console.WriteLine("Перестановка слов в 'Hello world!': " + ReverseWords("Hello world!"));

        Console.WriteLine("Таблица умножения для числа 5:");
        MultiplicationTable(5);
    }
}