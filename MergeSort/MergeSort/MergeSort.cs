namespace MergeSort
{
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
