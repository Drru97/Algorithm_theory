using System;

namespace Randomized_QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input quantity of numbers: ");
            int n = int.Parse(Console.ReadLine());
            Random random = new Random();
            int[] array = new int[n];
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(100);
            Console.WriteLine("Input array: ");
            foreach (int x in array)
                Console.Write(x + "\t");
            for (;;)
            {
                Console.Write("\nInput k: ");
                int k = int.Parse(Console.ReadLine());
                if (k == 999)
                    break;
                Console.WriteLine("Statistic of array: {0} element is {1}", k, Randomized_QuickSort.findOdrerStatictic(array, 1, array.Length - 1, k));
            }
            Console.Write("\nSort from: ");
            int left = int.Parse(Console.ReadLine());
            Console.Write("Sort to: ");
            int right = int.Parse(Console.ReadLine());
            Randomized_QuickSort.RandomizedQuickSort(array, left, right - 1);
            Console.WriteLine("\nOutput array: ");
            foreach (int x in array)
                Console.Write(x + "\t");
            // Console.WriteLine($"\nTotal memory {GC.GetTotalMemory(true) / 1024} KBytes");
            Console.ReadKey();
        }
    }
}
