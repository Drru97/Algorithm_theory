using System;

namespace Heapsort
{
	static class Heap
	{
		static int Left (int i)
		{
			return 2 * i;
		}

		static int Right (int i)
		{
			return 2 * i + 1;
		}

		static int Parent (int i)
		{
			return i / 2;
		}

		static void MaxHeapify (int[] array, int heapSize, int index)
		{
			int left = Left (index);
			int right = Right (index);
			int largest = 0;

			if (left < heapSize && array [left] > array [index])
				largest = left;
			else
				largest = index;

			if (right < heapSize && array [right] > array [largest])
				largest = right;

			if (largest != index) {
				Temp.Swap (ref array [index], ref array [largest]);
				MaxHeapify (array, heapSize, largest);
			}
		}

		static void BulidMaxHeap (int[] array)
		{
			int heapSize = array.Length;

			for (int p = Parent (heapSize - 1); p >= 0; p--)
				MaxHeapify (array, heapSize, p);
		}

		public static void Heapsort (int[] array)
		{
			int heapSize = array.Length;

			BulidMaxHeap (array);

			for (int i = array.Length - 1; i > 0; i--) {
				Temp.Swap (ref array [i], ref array [0]);
				heapSize--;
				MaxHeapify (array, heapSize, 0);
			}
		}
	}
}

