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
                Console.Write("\nInput k or 999 to exit: ");
                int k = int.Parse(Console.ReadLine());
                if (k == 999)
                    break;
                Console.WriteLine("Statistic of array: {0} element is {1}", k, Randomized_QuickSort.findOdrerStatictic(array, 0, array.Length - 1, k + 1));
            }
            Randomized_QuickSort.RandomizedQuickSort(array, 0, n - 1);
            Console.WriteLine("\nOutput array: ");
            foreach (int x in array)
                Console.Write(x + "\t");
            Console.ReadKey();
        }
    }
}
