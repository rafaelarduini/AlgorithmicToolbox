using System;

namespace MoneyChange
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			Console.WriteLine(getChange(n));
		}

		private static int getChange(int value)
		{
			int coins = 0;

			while (value > 0)
			{
				if (value >= 10)
				{
					value -= 10;
				}
				else if (value >= 5)
				{
					value -= 5;
				}
				else if (value >= 1)
				{
					value -= 1;
				}
				coins++;
			}

			return coins;
		}
	}
}
