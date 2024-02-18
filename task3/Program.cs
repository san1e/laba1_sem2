using System;

public class Program
{
    public static void Main()
    {
        // Виклик методу для обчислення суми ряду 1 + 1/2 + 1/4 + 1/8 + 1/16 + ...
        double sum1 = CalculateSeriesSum(x => 1.0 / Math.Pow(2, x), 0.0001);
        Console.WriteLine($"Сума ряду 1 + 1/2 + 1/4 + 1/8 + 1/16 + ...: {sum1}");

        // Виклик методу для обчислення суми ряду 1 + 1/2! + 1/3! + 1/4! + 1/5! + ...
        double sum2 = CalculateSeriesSum(x => 1.0 / Factorial(x), 0.0001);
        Console.WriteLine($"Сума ряду 1 + 1/2! + 1/3! + 1/4! + 1/5! + ...: {sum2}");

        // Виклик методу для обчислення суми ряду –1 + 1/2 – 1/4 + 1/8 – 1/16 + ...
        double sum3 = CalculateSeriesSum(x => Math.Pow(-1, x) / Math.Pow(2, x), 0.0001);
        Console.WriteLine($"Сума ряду –1 + 1/2 – 1/4 + 1/8 – 1/16 + ...: {sum3}");
    }

    // Метод для обчислення факторіалу
    public static double Factorial(int n)
    {
        if (n == 0)
            return 1;
        return n * Factorial(n - 1);
    }

    // Універсальний статичний метод для обчислення суми ряду з заданою точністю
    public static double CalculateSeriesSum(Func<int, double> term, double precision)
    {
        double sum = 0;
        double currentTerm = 0;
        int n = 0;
        do
        {
            currentTerm = term(n);
            sum += currentTerm;
            n++;
        } while (Math.Abs(currentTerm) > precision);

        return sum;
    }
}