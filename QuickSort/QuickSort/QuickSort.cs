namespace QuickSort
{
    class QuickSort
    {
        public static void Sort(int[] array, int left, int right)
        {
            int i = left, j = right;
            int middle = array[(left + right) / 2];
            while (i <= j)
            {
                while (array[i].CompareTo(middle) < 0)
                    i++;
                while (array[j].CompareTo(middle) > 0)
                    j--;
                if (i <= j)
                {
                    swap(ref array[i], ref array[j]);
                    i++;
                    j--;
                }
            }
            if (left < j)
                Sort(array, left, j);
            if (i < right)
                Sort(array, i, right);
        }

        static void swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
