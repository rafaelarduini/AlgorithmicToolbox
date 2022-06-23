using System;

namespace FibonacciNumberAgain
{
	class Program
	{
		static void Main(string[] args)
		{
			var numbersString = Console.ReadLine().Split(' ');

			ulong  a = ulong .Parse(numbersString[0]);
			ulong  b = ulong .Parse(numbersString[1]);

            Console.WriteLine(ModuleFibonacci(a, b));
        }

        private static ulong  GetFibonacciHugeNaive(ulong  n, ulong  m)
        {
            if (n <= 1)
                return n;

            ulong  previous = 0;
            ulong  current = 1;

            for (ulong  i = 0; i < n - 1; ++i)
            {
                ulong  tmp_previous = previous;
                previous = current;
                current = tmp_previous + current;
            }

            return current % m;
        }

        private static ulong  Pisano(ulong  m)
        {
            ulong  prev = 0;
            ulong  curr = 1;
            ulong  res = 0;

            for (ulong i = 0; i < m * m; i++)
            {
				ulong  temp = curr;
				curr = (prev + curr) % m;
                prev = temp;

                if (prev == 0 && curr == 1) 
                    res = i + 1;
            }
            return res;
        }

        private static ulong ModuleFibonacci(ulong  number, ulong m)
        {
            ulong pisanoPeriod = Pisano(m);

            number %= pisanoPeriod;

            ulong  previus = 0;
            ulong  current = 1;

            if (number <= 1)
                return number;

            for (ulong i = 0; i < number - 1; i++)
            {
                ulong temp;
                temp = current;
                current = (previus + current) % m;
                previus = temp;
            }

            return current % m;
        }
    }
}
