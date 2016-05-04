using System;

namespace Randomized_QuickSort
{
    class Randomized_QuickSort
    {
        public static void RandomizedQuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int i = RandomizedPartition(array, left, right);
                RandomizedQuickSort(array, left, i - 1);
                RandomizedQuickSort(array, i + 1, right);
            }
        }

        static int RandomizedPartition(int[] array, int left, int right)
        {
            Random random = new Random();
            int i = random.Next(left, right);
            swap(ref array[i], ref array[right]);
            return Partition(array, left, right);
        }

        static int Partition(int[] array, int left, int right)
        {
            int temp = array[right];
            int i = left;
            for (int j = left; j < right; j++)
            {
                if (array[j] <= temp)
                {
                    swap(ref array[i], ref array[j]);
                    i++;
                }
            }
            array[right] = array[i];
            array[i] = temp;
            return i;
        }

        static void swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static int findOdrerStatictic(int[] array, int left, int right, int k)
        {
            int mid = RandomizedPartition(array, left, right);
            int temp = mid - left + 1;
          //  int i = left, j = right;

            if (k == temp)
                return array[mid];
            if (temp > k)
                return findOdrerStatictic(array, left, mid - 1, k);
            else
                return findOdrerStatictic(array, mid + 1, right, k - temp);
        }
    }
}
