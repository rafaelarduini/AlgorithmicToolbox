using System;
using System.Diagnostics;

namespace MaxPairwiseProduct
{
	class Program
	{
		static void Main(string[] args)
		{
			var arraySize = int.Parse(Console.ReadLine());

			var numbersString = Console.ReadLine().Split(' ');

			long[] numbers = new long[arraySize];

			for (int i = 0; i < arraySize; i++)
			{
				numbers[i] = int.Parse(numbersString[i]);
			}

			Console.WriteLine(GetMaxPairwiseProduct2(numbers, arraySize));

			//while (true)
			//{
			//	Random randNum = new();

			//	long[] numbers = new long[randNum.Next(2, 100000)];

			//	for (int i = 0; i < numbers.Length; i++)
			//	{
			//		numbers[i] = randNum.Next(1, 100000);
			//	}

			//	foreach (var number in numbers)
			//	{
			//		Console.Write(number + " ");
			//	}

			//	Console.WriteLine();

			//	var sw = new Stopwatch();

			//	sw.Start();

			//	long result1 = GetMaxPairwiseProduct(numbers, numbers.Length);
			//	Console.WriteLine(result1);

			//	sw.Stop();
			//	Console.WriteLine("Tempo gasto : " + sw.ElapsedMilliseconds.ToString() + " milisegundos");

			//	sw.Reset();

			//	sw.Start();

			//	long result2 = GetMaxPairwiseProduct2(numbers, numbers.Length);
			//	Console.WriteLine(result2);

			//	sw.Stop();
			//	Console.WriteLine("Tempo gasto : " + sw.ElapsedMilliseconds.ToString() + " milisegundos");

			//	if (result1 != result2)
			//	{
			//		break;
			//	}
			//}
		}

		private static long GetMaxPairwiseProduct2(long[] numbers, int arraySize)
		{
			long maxIndex1 = -1;

			for (int i = 0; i < arraySize; i++)
			{
				if (maxIndex1 == -1 || numbers[i] > numbers[maxIndex1])
				{
					maxIndex1 = i;
				}
			}

			long maxIndex2 = -1;

			for (int j = 0; j < arraySize; j++)
			{
				if ((maxIndex2 == -1 || numbers[j] > numbers[maxIndex2] ) && j != maxIndex1)
				{
					maxIndex2 = j;
				}
			}

			return numbers[maxIndex1] * numbers[maxIndex2];
		}
		private static long GetMaxPairwiseProduct(long[] numbers, int arraySize)
		{
			long result = 0;

			for (int i = 0; i < arraySize; i++)
			{
				for (int j = i + 1; j < arraySize; j++)
				{
					if ((numbers[i] * numbers[j]) > result)
					{
						result = numbers[i] * numbers[j];
					}
				}
			}

			return result;
		}
	}
}
