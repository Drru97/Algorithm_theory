using System;

namespace QuickSort
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
            QuickSort.Sort(array, 0, array.Length - 1);
            Console.WriteLine("\nOutput array: ");
            foreach (int x in array)
                Console.Write(x + "\t");
         //    Console.WriteLine($"\nTotal memory {GC.GetTotalMemory(true) / 1024} KBytes");
            Console.ReadKey();
        }
    }
}
