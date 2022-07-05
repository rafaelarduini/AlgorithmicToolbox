using System;

namespace MoneyChangeAgain
{
	class Program
	{
		static void Main(string[] args)
		{
			int m = int.Parse(Console.ReadLine());

			int[] coins = new int[] { 1, 3, 4 };

			Console.WriteLine(GetChange(m, coins));
		}

		private static int GetChange(int money, int[] coins)
		{
			int[] minNumCoins = new int[money + 1];

			minNumCoins[0] = 0;

			for (int m = 1; m <= money; m++)
			{
				minNumCoins[m] = int.MaxValue;

				for (int i = 0; i < coins.Length; i++)
				{
					if (m >= coins[i])
					{
						int numCoins = minNumCoins[m - coins[i]] + 1;

						if (numCoins < minNumCoins[m])
						{
							minNumCoins[m] = numCoins;
						}
					}
				}
			}

			return minNumCoins[money];
		}

		private static int GetChangeRecursive(int money, int[] coins) 
		{
			if (money == 0)
			{
				return 0;
			}

			int minNumCoins = int.MaxValue;

			for (int i = 0; i < coins.Length; i++)
			{
				if (money >= coins[i])
				{
					int numCoins = GetChangeRecursive(money - coins[i], coins);

					if (numCoins + 1 < minNumCoins)
					{
						minNumCoins = numCoins + 1;
					}
				}
			}

			return minNumCoins;
		}
	}
}
