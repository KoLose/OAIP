using System.Collections.Generic;
using System;
using System.Linq;

public static class Method2
{
    private static Dictionary<string, List<double>> tranzakcii = new Dictionary<string, List<double>>();

    private static void DobavitTranzakciyuIzVvoda()
    {
        Console.Write("Введите категорию (Доход, Продукты, Транспорт, Развлечения): ");
        string kategoriyaName = Console.ReadLine();
        Console.Write("Введите сумму: ");
        if (double.TryParse(Console.ReadLine(), out double tranzakciyaSumma))
        {
            DobavitTranzakciyu(kategoriyaName, tranzakciyaSumma);
        }
        else
        {
            Console.WriteLine("Некорректный ввод суммы.");
        }
    }

    public static void DobavitTranzakciyu(string kategoriyaName, double tranzakciyaSumma)
    {
        if (!tranzakcii.ContainsKey(kategoriyaName))
        {
            tranzakcii.Add(kategoriyaName, new List<double>());
        }
        tranzakcii[kategoriyaName].Add(tranzakciyaSumma);
        Console.WriteLine("Запись добавлена.");
    }

    public static void VivestiFinansoviyOtchet()
    {
        Console.WriteLine("Финансовый отчет:");
        foreach (var kategoriya in tranzakcii)
        {
            double obschayaSumma = kategoriya.Value.Sum();
            double okruglyonniyItog = Math.Round(obschayaSumma, 2, MidpointRounding.AwayFromZero);
            Console.WriteLine(kategoriya.Key + ": " + okruglyonniyItog.ToString() + " руб. - " + kategoriya.Value.Count + " операций");
        }
    }

    private static void RasschitatIPokazatBalans()
    {
        double obschiyBalans = RasschitatBalans();
        double okruglyonniyBalans = Math.Round(obschiyBalans, 2, MidpointRounding.AwayFromZero);
        Console.WriteLine("Текущий баланс: " + okruglyonniyBalans.ToString() + " руб.");
    }

    public static double RasschitatBalans()
    {
        double doxod = 0;
        double rashodi = 0;

        foreach (var kategoriya in tranzakcii)
        {
            if (kategoriya.Key.ToLower() == "доход")
            {
                doxod = kategoriya.Value.Sum();
            }
            else
            {
                rashodi += kategoriya.Value.Sum();
            }
        }

        return doxod - rashodi;
    }

    private static void SprognozirovatIPokazatRashodiNaSleduyuschiyMesyac()
    {
        double prognoziruemoeZnachenie = SprognozirovatRashodiNaSleduyuschiyMesyac();
        double okruglyonniyPrognoz = Math.Round(prognoziruemoeZnachenie, 2, MidpointRounding.AwayFromZero);
        Console.WriteLine("Прогнозируемые расходы на следующий месяц: " + okruglyonniyPrognoz.ToString() + " руб.");
    }

    public static double PoluchitSrednieRashodi(string kategoriyaName)
    {
        if (tranzakcii.ContainsKey(kategoriyaName) && tranzakcii[kategoriyaName].Count > 0)
        {
            return tranzakcii[kategoriyaName].Average();
        }
        return 0;
    }

    public static double SprognozirovatRashodiNaSleduyuschiyMesyac()
    {
        double obschiePrognoziruemieRashodi = 0;

        foreach (var kategoriya in tranzakcii.Keys)
        {
            if (kategoriya.ToLower() != "доход")
            {
                obschiePrognoziruemieRashodi += PoluchitSrednieRashodi(kategoriya) * 30;
            }
        }

        return obschiePrognoziruemieRashodi;
    }

    public static void VivestiStatistiku()
    {
        double summaVsehRashodov = 0;
        Dictionary<string, double> rashodiPoKategoriyam = new Dictionary<string, double>();
        Dictionary<string, int> chastotaKategoriy = new Dictionary<string, int>();

        foreach (var kategoriya in tranzakcii)
        {
            if (kategoriya.Key.ToLower() != "доход")
            {
                double itogPoKategorii = kategoriya.Value.Sum();
                summaVsehRashodov += itogPoKategorii;
                rashodiPoKategoriyam[kategoriya.Key] = itogPoKategorii;
                chastotaKategoriy[kategoriya.Key] = kategoriya.Value.Count;
            }
        }

        double okruglyonnayaSummaRashodov = Math.Round(summaVsehRashodov, 2, MidpointRounding.AwayFromZero);
        Console.WriteLine("Общая сумма расходов: " + okruglyonnayaSummaRashodov.ToString() + " руб.");

        if (rashodiPoKategoriyam.Count > 0)
        {
            string samayaZtratnayaKategoriya = rashodiPoKategoriyam.OrderByDescending(x => x.Value).First().Key;
            double okruglyonnayaSummaDlyaSamoyZtratnoy = Math.Round(rashodiPoKategoriyam[samayaZtratnayaKategoriya], 2, MidpointRounding.AwayFromZero);
            Console.WriteLine("Самая затратная категория: " + samayaZtratnayaKategoriya + " (" + okruglyonnayaSummaDlyaSamoyZtratnoy.ToString() + " руб.)");
        }
        else
        {
            Console.WriteLine("Нет данных о расходах.");
        }

        if (chastotaKategoriy.Count > 0)
        {
            string samayaChastayaKategoriya = chastotaKategoriy.OrderByDescending(x => x.Value).First().Key;
            Console.WriteLine("Самая частая категория: " + samayaChastayaKategoriya + " (" + chastotaKategoriy[samayaChastayaKategoriya] + " операций)");
        }
        else
        {
            Console.WriteLine("Нет данных о частоте расходов.");
        }

        Console.WriteLine("Процентное распределение расходов:");
        if (summaVsehRashodov > 0)
        {
            foreach (var kategoriya in rashodiPoKategoriyam)
            {
                double procentZnachenie = (kategoriya.Value / summaVsehRashodov) * 100;
                double okruglyonniyProcent = Math.Round(procentZnachenie, 2, MidpointRounding.AwayFromZero);
                double okruglyonnayaSummaKategorii = Math.Round(kategoriya.Value, 2, MidpointRounding.AwayFromZero);
                Console.WriteLine(kategoriya.Key + ": " + okruglyonnayaSummaKategorii.ToString() + " руб. (" + okruglyonniyProcent.ToString() + "%)");
            }
        }
        else
        {
            Console.WriteLine("Нет данных для расчета процентного распределения.");
        }
    }

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nДобро пожаловать в систему управления финансами!");
            Console.WriteLine("1. Добавить доход/расход");
            Console.WriteLine("2. Показать отчет");
            Console.WriteLine("3. Рассчитать баланс");
            Console.WriteLine("4. Прогноз на следующий месяц");
            Console.WriteLine("5. Статистика");
            Console.WriteLine("6. Выход");

            Console.Write("Выберите действие: ");
            string viborPolzovatelya = Console.ReadLine();

            switch (viborPolzovatelya)
            {
                case "1":
                    DobavitTranzakciyuIzVvoda();
                    break;
                case "2":
                    VivestiFinansoviyOtchet();
                    break;
                case "3":
                    RasschitatIPokazatBalans();
                    break;
                case "4":
                    SprognozirovatIPokazatRashodiNaSleduyuschiyMesyac();
                    break;
                case "5":
                    VivestiStatistiku();
                    break;
                case "6":
                    Console.WriteLine("Выход из программы.");
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, выберите действие от 1 до 6.");
                    break;
            }
        }
    }
}
