using System;

namespace Heapsort
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.Write ("Input quantity of elements: ");
			int n = int.Parse (Console.ReadLine ());
			int[] array = new int[n];
			Random random = new Random ();
			for (int i = 0; i < n; i++)
				array [i] = random.Next (0, 100);
			Console.WriteLine ("Input array: ");
			foreach (int x in array)
				Console.Write (x + "\t");
			Heap.Heapsort (array);
			Console.WriteLine ("\nOutput array: ");
			foreach (int x in array)
				Console.Write (x + "\t");
            Console.ReadKey();
		}
	}
}
