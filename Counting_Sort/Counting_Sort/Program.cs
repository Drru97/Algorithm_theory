﻿using System;

namespace Counting_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input numbers quantity: ");
            int n = int.Parse(Console.ReadLine());
            Random rand = new Random();
            int[] array = new int[n];
            for (int i = 0; i < array.Length; i++)
            	array[i] = rand.Next(100);
            Console.WriteLine("Input array: ");
            foreach (int el in array)
                Console.Write(el + "\t");
            array = CountingSort.Sort(array);
            Console.WriteLine("\nOutput array: ");
            foreach (int el in array)
                Console.Write(el + "\t");
            Console.ReadKey();
        }
    }
}
