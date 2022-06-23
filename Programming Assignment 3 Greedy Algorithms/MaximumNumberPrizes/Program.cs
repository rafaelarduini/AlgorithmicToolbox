using System;
using System.Collections.Generic;

namespace MaximumNumberPrizes
{
	class Program
	{
		static void Main(string[] args)
		{
			long n = long.Parse(Console.ReadLine());
			var summands = OptimalSummands(n);
			Console.WriteLine(summands.Count);

			foreach (var summand in summands)
			{
				Console.Write(summand + " ");
			}
		}

		private static List<long> OptimalSummands(long n)
		{
			var summands = new List<long>();

			long total = 0;

			for (long i = 1; i <= n; i++)
			{
				if (total + i <= n)
				{
					summands.Add(i);
					total += i;
				}
				else 
				{
					summands[summands.Count - 1] += n - total;
					break;
				}
			}

			return summands;
		}
	}
}
