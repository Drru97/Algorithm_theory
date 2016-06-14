using System;

namespace Heap_Priority_Queue
{
    public static class Heap
    {
        public static void Max_Heapify(int[] A, int i, int heapsize)
        {

            int l = 2 * i + 1;
            int r = 2 * i + 2;
            int c;
            int largest = i;
            if (l < heapsize && A[l] > A[i])
                largest = l;
            if (r < heapsize && A[r] > A[largest])
                largest = r;
            if (largest != i)
            {
                c = A[i];
                A[i] = A[largest];
                A[largest] = c;
                Max_Heapify(A, largest, heapsize);
            }
        }

        public static void Build_Heap(int[] A)
        {

            int p = (A.Length - 1) / 2;
            while (p >= 0)
            {
                Max_Heapify(A, p, A.Length);
                p--;
            }
        }

        public static int heap_Maximum(int[] A)
        {
            return A[0];
        }

        public static int heap_Extract_Max(int[] A, int heapsize)
        {
            if (A.Length < 0)
                Console.WriteLine("Черга пуста");
            int max = A[0];
            A[0] = A[heapsize - 1];
            heapsize--;
            Max_Heapify(A, 0, heapsize);
            return max;
        }

        public static int parent(int i)
        {
            return 2 * i;
        }

        public static void heap_Increase_Key(int[] A, int i, int key)
        {
            if (key < A[i])
                Console.WriteLine("Ключ є меншим вiд поточного");
            else
            {
                A[i] = key;
                Build_Heap(A);
            }
        }

        public static void max_Heap_Insert(int[] A, int key, int heapsize)
        {
            int newSize = heapsize + 1;
            Array.Resize(ref A, newSize);
            A[newSize - 1] = -100;
            heap_Increase_Key(A, newSize - 1, key);
        }
    }
}
