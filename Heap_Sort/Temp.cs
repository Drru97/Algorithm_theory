using System;

namespace Heapsort
{
	static class Temp
	{
		public static void Swap(ref int a, ref int b)
		{
			int temp = a;
			a = b;
			b = temp;
		}
	}
}

