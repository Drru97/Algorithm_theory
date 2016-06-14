using System;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input n: ");
            int n = 0;
            int[] array = null;
            try
            {
                n = int.Parse(Console.ReadLine());
                array = new int[n];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Main(args);
            }
            Random rand = new Random();
            for (int i = 0; i < n; i++)
                array[i] = rand.Next(1, 200);
            Console.WriteLine("Input array: ");
            foreach (int x in array)
                Console.Write(x + "\t");
            MergeSort.Merge_Sort(array, 0, n - 1);
            Console.WriteLine("Output array: ");
            foreach (int x in array)
                Console.Write(x + "\t");
            Console.ReadKey();
        }
    }
}
