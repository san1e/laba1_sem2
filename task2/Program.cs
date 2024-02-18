using System;

public delegate bool MyPredicate(int x);

class Program
{
    static void Main()
    {
        int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int k = 3;

        Func<int, bool> isMultipleOfK0 = x => x % k == 0;
        MyPredicate isMultipleOfK = x => x % k == 0;

        int[] filteredArray0 = FilterArrayWhere(array, isMultipleOfK0);

        int[] filteredArray1 = FilterArray(array, isMultipleOfK);

        Console.WriteLine(string.Join(", ", filteredArray0));
        Console.WriteLine(string.Join(", ", filteredArray1));
    }

    static int[] FilterArrayWhere(int[] array, Func<int,bool> predicate)
    {
        return array.Where(predicate).ToArray();
    }

    static int[] FilterArray(int[] array, MyPredicate predicate)
    {
        int count = 0;

        foreach (int item in array)
        {
            if (predicate(item))
            {
                count++;
            }
        }

        int[] result = new int[count];
        count = 0;

        foreach (int item in array)
        {
            if (predicate(item))
            {
                result[count++] = item;
            }
        }

        return result;
    }
}