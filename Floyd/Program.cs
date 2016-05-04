using System;

namespace Floyd
{
	class MainClass
	{
		const int inf = 999;
		const int n = 4;
		static int[,] weight = { { 0, -2, 3, -3 }, { inf, 0, 2, inf }, { inf, inf, 0, -3 }, { 4, 5, 5, 0 } };
		static int[,] path = { { 0, 1, 1, 1 }, { 2, 0, 2, 2 }, { 3, 3, 0, 3 }, { 4, 4, 4, 0 } };

		public static void Main (string[] args)
		{
			Floyd ();
		}

		static void Floyd ()
		{
			PrintMatrix (path);

			for (int k = 0; k < n; k++) {
				for (int i = 0; i < n; i++) {
					for (int j = 0; j < n; j++) {
						if (weight [i, j] > weight [i, k] + weight [k, j]) {
							weight [i, j] = weight [i, k] + weight [k, j];
						}
						if (path [i, j] == path [i, k] + path [k, j]) {
							path [i, j] = path [k, j];
						}
					}	
				}
				PrintMatrix (path);
			}
				
		}

		static void PrintMatrix (int[,] weight)
		{
			Console.Write ("\n");
			for (int i = 0; i < n; i++) {
				for (int j = 0; j < n; j++)
					Console.Write (weight [i, j] + "\t");
				Console.Write ("\n");
			}
		}
	}
}
