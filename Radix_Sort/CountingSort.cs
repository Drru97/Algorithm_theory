using System;
using KV;

namespace Counting_Sort
{
    static class CountingSort
    {
		public static KVEntry[] Sort(KVEntry[] arrayA)
        {
			int[] arrayB = new int[MaxValue (arrayA) + 1];
			KVEntry[] arrayC = new KVEntry[arrayA.Length];

			for (int i = 0; i < arrayB.Length; i++)
				arrayB [i] = 0;

			for (int i = 0; i < arrayA.Length; i++)
				arrayB [arrayA [i].Value]++;

			for (int i = 1; i < arrayB.Length; i++)
				arrayB [i] += arrayB [i - 1];

			for (int i = arrayA.Length - 1; i >= 0; i--) {
				int value = arrayA [i].Value;
				int index = arrayB [value];

				arrayB [value]--;
				arrayC [index - 1] = new KVEntry ();
				arrayC [index - 1].Key = i;
				arrayC [index - 1].Value = value;
			}
			return arrayC;
        }

		static int MaxValue(KVEntry[] array)
		{
			int max = array [0].Value;
			for (int i = 1; i < array.Length; i++)
				if (array [i].Value > max)
					max = array [i].Value;
			return max;
		}
    }
}
