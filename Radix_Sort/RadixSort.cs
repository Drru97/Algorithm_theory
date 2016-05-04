using System;
using KV;
using Counting_Sort;

namespace RadixSort
{
	public static class RadixSort
	{
		public static int[] Sort(int[] array)
		{
			return Radix (array, 1);
		}

		static int[] Radix(int[] array, int digit)
		{
			bool empty = true;
			KVEntry[] digits = new KVEntry[array.Length];
			int[] sortedArray = new int[array.Length];

			for (int i = 0; i < array.Length; i++) {
				digits [i] = new KVEntry();
				digits [i].Key = i;
				digits [i].Value = (array [i] / digit) % 10;
				if (array [i] / digit != 0)
					empty = false;
			}

			if (empty)
				return array;

			KVEntry[] sortedDigits = CountingSort.Sort(digits);
			for (int i = 0; i < sortedArray.Length; i++)
				sortedArray [i] = array [sortedDigits [i].Key];
			return Radix (sortedArray, digit * 10);
		}
	}
}

