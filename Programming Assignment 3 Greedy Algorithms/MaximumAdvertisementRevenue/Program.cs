using System;

namespace MaximumAdvertisementRevenue
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			int[] a = new int[n];
			var numbersString = Console.ReadLine().Split(' ');
			for (int i = 0; i < n; i++)
			{
				a[i] = int.Parse(numbersString[i]);
			}

			int[] b = new int[n];
			numbersString = Console.ReadLine().Split(' ');
			for (int i = 0; i < n; i++)
			{
				b[i] = int.Parse(numbersString[i]);
			}

			Console.WriteLine(MaxDotProduct(a, b));
		}

		private static long MaxDotProduct(int[] a, int[] b)
		{
			long result = 0;

			Array.Sort(a);
			Array.Reverse(a);

			for (int i = 0; i < a.Length; i++)
			{
				long maxRevenue = int.MinValue;
				long indexMaxRevenueB = -1;

				for (int j = 0; j < b.Length; j++)
				{
					if (b[j] != int.MinValue)
					{
						long tempResult = (long)a[i] * (long)b[j];

						if (tempResult > maxRevenue)
						{
							maxRevenue = tempResult;
							indexMaxRevenueB = j;
						}
					}
				}

				result += maxRevenue;
				b[indexMaxRevenueB] = int.MinValue;
			}

			return result;
		}
	}
}
