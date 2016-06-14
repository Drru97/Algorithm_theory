using System;
using System.Collections.Generic;
using System.Linq;

namespace Hash_Tables
{
    class Program
    {
        const int m = 10;
        private static string choice;

        static void Main(string[] args)
        {

            List<int>[] secList = new List<int>[m];
            for (int i = 0; i < m; i++)
            {
                secList[i] = new List<int>();
            }

            int item;
            do
            {
                Console.WriteLine("Select action:");
                Console.WriteLine("1 - add key ");
                Console.WriteLine("2 - search key ");
                Console.WriteLine("3 - delete key ");
                Console.WriteLine("4 - show table ");
                Console.WriteLine("5 - Exit ");
                Console.Write("Your choise is: ");
                choice = Console.ReadLine();
                if (choice.Equals("1"))
                {
                    Console.Write("Enter key: ");
                    item = Convert.ToInt32(Console.ReadLine());

                    int hk = h(item, m);
                    secList[hk].Add(item);

                    foreach (var node in secList)
                    {
                        if (node.Count == 0) { Console.WriteLine("Empty list "); continue; }
                        foreach (var ke in node)
                        {
                            Console.Write(ke + " ");
                        }
                        Console.WriteLine();
                    }
                }
                if (choice.Equals("2"))
                {
                    Console.Write("Enter key: ");
                    item = Convert.ToInt32(Console.ReadLine());

                    int hk = h(item, m);
                    List<int> data = secList[hk].Where(g => g == item).ToList<int>();
                    if (data.Count != 0) Console.WriteLine("Found key: " + data[0]);
                    else Console.WriteLine("Key not found!");
                }
                if (choice.Equals("3"))
                {
                    Console.Write("Enter key: ");
                    item = Convert.ToInt32(Console.ReadLine());
                    int hk = h(item, m);
                    secList[hk].Remove(item);

                    foreach (var node in secList)
                    {
                        if (node.Count == 0) { Console.WriteLine("Empty list "); continue; }
                        foreach (var ke in node)
                        {
                            Console.Write(ke + " ");
                        }
                        Console.WriteLine();
                    }
                }
                if (choice.Equals("4"))
                {
                    foreach (var node in secList)
                    {
                        if (node.Count == 0) { Console.WriteLine("Empty list "); continue; }
                        foreach (var ke in node)
                        {
                            Console.Write(ke + " ");
                        }
                        Console.WriteLine();
                    }
                }
                if (choice.Equals("5"))
                {
                    return;
                }
            } while (true);

        }

        static Int32 h(int k, int m)
        {
            return k % m;
        }
    }
}

