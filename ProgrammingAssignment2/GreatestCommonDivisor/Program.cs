using System;

namespace GreatestCommonDivisor
{
	class Program
	{
		static void Main(string[] args)
		{
			var numbersString = Console.ReadLine().Split(' ');

			long a = long.Parse(numbersString[0]);
			long b = long.Parse(numbersString[1]);

			//long a = 3918848;
			//long b = 1653264;

			Console.WriteLine(GcdFast(a, b));
		}

		private static long GcdNaive(long a, long b)
		{
			long currentGcd = 1;

			for (long d = 2; d <= a && d <= b; ++d)
			{
				if (a % d == 0 && b % d == 0)
				{
					if (d > currentGcd)
					{
						currentGcd = d;
					}
				}
			}

			return currentGcd;
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
