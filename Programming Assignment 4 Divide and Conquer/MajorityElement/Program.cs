using System;

namespace MajorityElement
{
    class Program
    {
        private static int GetMajorityElement(int[] a, int left, int right)
        {
            Array.Sort(a);

            int candidate = int.MinValue;

            int count = 0;

            if (a.Length == 1)
            {
                return 1;
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (candidate == a[i])
                {
                    count++;

                    if (count > a.Length / 2)
                        return 1;
                }
                else
                {
                    candidate = a[i];
                    count = 1;
                }
            }

            return -1;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] a = new int[n];

            string input = Console.ReadLine();
            var tokens = input.Split(' ');

            for (int i = 0; i < n; i++)
                a[i] = int.Parse(tokens[i]);

            if (GetMajorityElement(a, 0, a.Length) != -1)
                Console.WriteLine(1);
            else
                Console.WriteLine(0);
        }
    }
}
