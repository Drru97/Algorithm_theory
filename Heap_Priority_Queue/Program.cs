using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap_Priority_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input quantity of elements:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] A = new int[n];
            Random r = new Random();
            for (int i = 0; i < A.Length; i++)
                A[i] = r.Next(1, 99);

            Heap.Build_Heap(A);
            Console.WriteLine("Heap:");
            for (int i = 0; i < A.Length; i++)
                Console.WriteLine(A[i]);

            for (;;)
            {
                Console.WriteLine("Choose:");
                Console.WriteLine(" 1 - heap_Maximum");
                Console.WriteLine(" 2 - heap_Extract_Max");
                Console.WriteLine(" 3 - heap_Increase_Key");
                Console.WriteLine(" 4 - max_Heap_Insert");
                int p = Convert.ToInt32(Console.ReadLine());
                switch (p)
                {
                    case 1:
                        int y = Heap.heap_Maximum(A);
                        Console.WriteLine("Maximum: " + y);
                        break;

                    case 2:
                        Console.WriteLine("Heap:");
                        if (A.Length < 0)
                            Console.WriteLine("Queue is empty");
                        int max = A[0];
                        A[0] = A[A.Length - 1];
                        Array.Resize(ref A, A.Length - 1);
                        Heap.Max_Heapify(A, 0, A.Length);
                        for (int w = 0; w < A.Length; w++)
                            Console.WriteLine(A[w]);
                        Console.WriteLine("Maximum: " + max);
                        break;

                    case 3:
                        Console.WriteLine("Input index:");
                        int j = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Input key:");
                        int key = Convert.ToInt32(Console.ReadLine());
                        Heap.heap_Increase_Key(A, j, key);
                        Console.WriteLine("Heap:");
                        for (int t = 0; t < A.Length; t++)
                            Console.WriteLine(A[t]);
                        break;

                    case 4:
                        Console.WriteLine("Input key:");
                        int key2 = Convert.ToInt32(Console.ReadLine());
                        Array.Resize(ref A, A.Length + 1);
                        A[A.Length - 1] = -100;
                        Heap.heap_Increase_Key(A, A.Length - 1, key2);
                        Console.WriteLine("New heap:");
                        for (int a = 0; a < A.Length; a++)
                            Console.WriteLine(A[a]);
                        break;
                }
            }
            Console.ReadKey();

        }
    }
}
