using System;

namespace LastDigitSumFibonacciNumbers
{
	class Program
	{
		static void Main(string[] args)
		{
            ulong n = ulong.Parse(Console.ReadLine());

            //Console.WriteLine(GetFibonacciSumNaive(n));
            Console.WriteLine(GetFibonacciSumFast(n));
        }

        private static ulong GetFibonacciSumNaive(ulong n)
        {
            if (n <= 1)
                return n;

            ulong previous = 0;
            ulong current = 1;
            ulong sum = 1;

            for (ulong i = 0; i < n - 1; ++i)
            {
                ulong tmp_previous = previous;
                previous = current;
                current = tmp_previous + current;
                sum += current;
            }

            return sum % 10;
        }

        private static ulong Pisano(ulong m)
        {
            ulong prev = 0;
            ulong curr = 1;
            ulong res = 0;

            for (ulong i = 0; i < m * m; i++)
            {
                ulong temp = curr;
                curr = (prev + curr) % m;
                prev = temp;

                if (prev == 0 && curr == 1)
                    res = i + 1;
            }
            return res;
        }

        private static ulong GetFibonacciSumFast(ulong number, ulong m = 10)
        {
            ulong pisanoPeriod = Pisano(m);

            number %= pisanoPeriod;

            ulong previus = 0;
            ulong current = 1;

            ulong sum = 1;

            if (number <= 1)
                return number;

            for (ulong i = 1; i < number; i++)
            {
                ulong temp;
                temp = current;
                current = (previus + current) % m;
                previus = temp;
                sum += current;
            }

            return sum % m;
        }
    }
}
