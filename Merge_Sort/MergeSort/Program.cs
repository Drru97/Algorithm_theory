using System;
using System.Linq;

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
                Console.Write(x + "  ");
            int left = 0, right = 0;
            try
            {
                Console.Write("\nSort from: ");
                left = int.Parse(Console.ReadLine());
                Console.Write("Sort to: ");
                right = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Main(args);
            }
            MergeSort.Merge_Sort(array, left - 1, right - 1);
            Console.WriteLine("Output array: ");
            foreach (int x in array)
                Console.Write(x + "  ");
            Console.ReadKey();
        }
    }

    public static class MergeSort
    {
        static void Merge(int[] array, int left, int mid, int right)
        {
            int[] temp = new int[array.Length];
            int i, left_end, num_elements, tmp_pos;
            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (array[left] <= array[mid])
                    temp[tmp_pos++] = array[left++];
                else
                    temp[tmp_pos++] = array[mid++];
            }

            while (left <= left_end)
                temp[tmp_pos++] = array[left++];

            while (mid <= right)
                temp[tmp_pos++] = array[mid++];

            for (i = 0; i < num_elements; i++)
            {
                array[right] = temp[right];
                right--;
            }
        }

        public static void Merge_Sort(int[] array, int left, int right)
        {
            int mid;
            if (array.Length == 1)
                return;
            if (right > left)
            {
                mid = (left + right) / 2;
                Merge_Sort(array, left, mid);
                Merge_Sort(array, mid + 1, right);
                Merge(array, left, mid + 1, right);
            }
        }
    }
}
