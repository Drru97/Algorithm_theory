using System;

namespace Counting_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input numbers quantity: ");
            int n = int.Parse(Console.ReadLine());
            KVEntry[] array = new KVEntry[n];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i].Value = rand.Next(100);
            Console.WriteLine("Input array: ");
            foreach (KVEntry el in array)
                Console.Write(el.Value + "\t");
            array = CountingSort.Sort(array);
            Console.WriteLine("\nOutput array: ");
            foreach (KVEntry el in array)
                Console.Write(el.Value + "\t");
            Console.ReadKey();
        }
    }
}
