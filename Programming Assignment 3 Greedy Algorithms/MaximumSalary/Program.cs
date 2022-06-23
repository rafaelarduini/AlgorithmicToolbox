using System;
using System.Collections.Generic;

namespace MaximumSalary
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.ReadLine();
			String[] a = Console.ReadLine().Split(' ');

			var list = new List<string>();
			for (int i = 0; i < a.Length; i++)
			{
				list.Add(a[i]);
			}

			Console.WriteLine(LargestNumber(list));
		}

		private static String LargestNumber(List<string> digits)
		{
			String result = "";

			while (digits.Count > 0)
			{
				string maxDigit = "0";

				foreach (var digit in digits)
				{
					if (IsGreaterOrEqual(digit, maxDigit))
					{
						maxDigit = digit;
					}
				}

				result += maxDigit;
				digits.Remove(maxDigit);
			}

			return result;
		}

		private static bool IsGreaterOrEqual(string digit, string maxDigit)
		{
			int digitPlusMaxDigit = int.Parse(digit + maxDigit);
			int maxDigitPlusDigit = int.Parse(maxDigit + digit);

			return digitPlusMaxDigit > maxDigitPlusDigit;
		}
	}
}
