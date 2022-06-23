using System;

namespace FibonacciNumber
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			Console.WriteLine(CalcFiboFast(n));
		}

		private static long CalcFibo(int n)
		{
			if (n <= 1)
				return n;

			return CalcFibo(n - 1) + CalcFibo(n - 2);
		}

		private static long CalcFiboFast(int number)
		{
			var numbers = new long[number + 1];

			if (number <= 1)
				return number;

			numbers[0] = 0;
			numbers[1] = 1;

			int i;

			for (i = 2; i <= number; i++)
			{
				numbers[i] = numbers[i - 1] + numbers[i - 2];
			}

			return numbers[number];
		}
	}
}
