using System;
using System.Diagnostics;

namespace SortingAlgorithms
{
    delegate void SortingMethod(int[] arr);
    delegate int[] ArrayGenerator(int length);

    class Program
    {
        static void Main(string[] args)
        {
            ArrayGenerator randomArrayGenerator = GenerateRandomArray;
            int[] input = randomArrayGenerator(100);
            CompareSortingMethods(Sort.SelectionSort, StudentSort.MySelectionSort, input);
            CompareSortingMethods(Sort.CocktailSort, StudentSort.MyCocktailSort, input);
        }

        public static void CompareSortingMethods(SortingMethod method1, SortingMethod method2, int[] input)
        {
            int[] arr1 = (int[])input.Clone();
            int[] arr2 = (int[])input.Clone();

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            method1(arr1);
            stopwatch.Stop();
            long teta = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            method2(arr2);
            stopwatch.Stop();
            long tstud = stopwatch.ElapsedMilliseconds;

            bool success = true;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    success = false;
                    break;
                }
            }

            if (success && Math.Max(0, teta / 5 - 200) <= tstud && tstud <= 5 * teta + 200)
            {
                Console.WriteLine("The method works correctly.");
            }
            else
            {
                Console.WriteLine("The method does not work correctly.");
            }
        }

        public static int[] GenerateRandomArray(int length)
        {
            Random random = new Random();
            int[] arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = random.Next(-100,100);
            }
            return arr;
        }


        public static void SaveArrayToFile(int[] arr, string fileName)
        {
            File.WriteAllLines(fileName, Array.ConvertAll(arr, x => x.ToString()));
        }
    }
}

