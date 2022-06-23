using System;

namespace LastDigitSumFibonacciNumbersAgain
{
	class Program
	{
		static void Main(string[] args)
		{
            var numbersString = Console.ReadLine().Split(' ');

            ulong  from = ulong .Parse(numbersString[0]);
            ulong  to = ulong .Parse(numbersString[1]);

            //Console.WriteLine(GetFibonacciPartialSumNaive(from, to));
            Console.WriteLine(GetFibonacciLastDigitFast(from, to));
        }

        private static ulong  GetFibonacciPartialSumNaive(ulong  from, ulong  to)
        {
            ulong  sum = 0;

            ulong  current = 0;
            ulong  next = 1;

            for (ulong  i = 0; i <= to; ++i)
            {
                if (i >= from)
                {
                    sum += current;
                }

                ulong  new_current = next;
                next = next + current;
                current = new_current;
            }

            return sum % 10;
        }

        private static ulong  Pisano(ulong  m)
        {
            ulong  prev = 0;
            ulong  curr = 1;
            ulong  res = 0;

            for (ulong  i = 0; i < m * m; i++)
            {
                ulong  temp = curr;
                curr = (prev + curr) % m;
                prev = temp;

                if (prev == 0 && curr == 1)
                    res = i + 1;
            }
            return res;
        }

        public static ulong  GetFibonacciLastDigitFast(ulong  from, ulong  to)
        {
            ulong  sum = 0;

            if (from == to)
                return GetFibonacciFast(from);

            ulong  numeroRepeticoes = (to - from) / 60;
            ulong  sobra = (to - from) % 60;

            ulong  n = sobra;

            if (numeroRepeticoes > 0)
                sum = numeroRepeticoes * 280 % 10;

            ulong  current = GetFibonacciFast(from);
            ulong  next = GetFibonacciFast(from + 1);

            for (ulong  i = 1; i <= n + 1; ++i)
            {
                sum += current;
                ulong  new_current = next;
                next = (next + current) % 10;
                current = new_current;
            }

            return sum % 10;
        }

        private static ulong GetFibonacciFast(ulong number, ulong m = 10)
        {
            ulong pisanoPeriod = Pisano(m);

            number %= pisanoPeriod;

            ulong previus = 0;
            ulong current = 1;

            if (number <= 1)
                return number;

            for (ulong i = 1; i < number; i++)
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
