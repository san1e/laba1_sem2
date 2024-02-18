using System;

class Program
{
    // Оголошення делегата
    delegate double MathFunction(double x);

    static void Main(string[] args)
    {
        // Створення масиву лямбда-функцій
        MathFunction[] mathFunctions = new MathFunction[]
        {
            x => Math.Sqrt(Math.Abs(x)),
            x => x * x * x,
            x => x + 3.5
        };

        while (true)
        {
            try
            {
                Console.WriteLine("Введіть рядок вхідних даних у форматі: <індекс функції> <число>");
              ;

                // Розділення рядка на частини та перетворення їх у числа
                int[] parts = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

                // Перевірка чи введений рядок має потрібний формат
                if (parts.Length != 2)
                {
                    throw new FormatException("Невірний формат вхідних даних.");
                }

                // Виклик функції та виведення результату
                double result = mathFunctions[parts[0]](parts[1]);
                Console.WriteLine($"Результат: {result}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            } 
        }
    }
}