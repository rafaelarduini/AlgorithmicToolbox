using System;

namespace LeastCommonMultiple
{
	class Program
	{
		static void Main(string[] args)
		{
			var numbersString = Console.ReadLine().Split(' ');

			long a = long.Parse(numbersString[0]);
			long b = long.Parse(numbersString[1]);

			//long a = 761457;
			//long b = 614573;

			Console.WriteLine(LeastCommonMultipleFast(a, b));
		}

		private static long LeastCommonMultipleNaive(long a, long b)
		{
			for (long l = 1; l <= a * b; ++l)
				if (l % a == 0 && l % b == 0)
					return l;

			return a * b;
		}

		private static long LeastCommonMultipleFast(long a, long b)
		{
			return b * (a / GcdFast(a,b));
		}

		private static long GcdFast(long a, long b)
		{
			if (b == 0)
			{
				return a;
			}

			long remainder = a % b;

			return GcdFast(b, remainder);
		}
	}
}
