using System;

namespace LastDigitOfLargeFibonacciNumber
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFibonacciLastDigitFast(n));
        }

        private static int GetFibonacciLastDigitNaive(int n)
        {
            if (n <= 1)
                return n;

            int previous = 0;
            int current = 1;

            for (int i = 0; i < n - 1; ++i)
            {
                int tmpPrevious = previous;
                previous = current;
                current = tmpPrevious + current;
            }

            return current % 10;
        }

        private static int GetFibonacciLastDigitFast(int number)
        {
            var numbers = new int[number + 1];

            numbers[0] = 0;
            numbers[1] = 1;

            int i;

            for (i = 2; i <= number; i++)
            {
                numbers[i] = (numbers[i - 1] % 10) + (numbers[i - 2] % 10);
            }

            return numbers[number] % 10;
        }
    }
}
