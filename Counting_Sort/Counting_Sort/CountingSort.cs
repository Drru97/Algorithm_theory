using System.Linq;

namespace Counting_Sort
{
    class CountingSort
    {
        public static int[] Sort(int[] array)
        {
            int min = array.Min();
            int max = array.Max();
            int k = max - min + 1;

            int[] B = new int[array.Length];
            int[] C = new int[k + 1];

            for (int i = 0; i < k; i++)
                C[i] = 0;
            /* Задаємо значення count[i] як число елементів у масиві із значенням i+min-1 */
            for (int j = 0; j < array.Length; j++)
                C[array[j] + 1]++;
            /* Оновлюємо count[i] як номер елементів із значенням < i+min */
            for (int i = 1; i < k; i++)
                C[i] += C[i - 1];

            for (int i = (array.Length - 1); i >= 0; i--)
            {
                B[C[array[i]]] = array[i];
                C[array[i]]++;              
            }
            return B;
        }
    }
}
