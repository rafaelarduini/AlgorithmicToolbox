using System;

namespace ImprovingQuickSort
{
	class Program
	{
        static void Main(string[] args)
		{
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            var stringNumbersArray = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(stringNumbersArray[i]);
            }
            RandomizedQuickSort(a, 0, n - 1, new int[] { 0, 0 });
            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i] + " ");
            }
        }

        private static int[] Partition3(int[] a, int l, int r, int[] m)
        {
            int x = a[l];
            int m1 = l;
            int m2 = l;
            int t;
            for (int i = l + 1; i <= r; i++)
            {
                if (a[i] < x)
                {
                    m2++;
                    t = a[i];
                    a[i] = a[m2];
                    a[m1] = t;
                    a[m2] = x;
                    m1++;                    
                }
                else if (a[i] == x) 
                {
                    m2++;
                    t = a[i];
                    a[i] = a[m2];
                    a[m2] = t;
                }
            }

            return new int[] { m1, m2 };
        }

        private static int Partition2(int[] a, int l, int r, int[] m)
        {
            int x = a[l];
            int j = l;
            int t;
            for (int i = l + 1; i <= r; i++)
            {
                if (a[i] <= x)
                {
                    j++;
                    t = a[i];
                    a[i] = a[j];
                    a[j] = t;
                }
            }
            t = a[l];
            a[l] = a[j];
            a[j] = t;
            return j;
        }

        private static void RandomizedQuickSort(int[] a, int l, int r, int[] m)
        {
            if (l >= r)
            {
                return;
            }
            var rnd = new Random();
            int k = rnd.Next(r - l + 1) + l;
            int t = a[l];
            a[l] = a[k];
            a[k] = t;
            m = Partition3(a, l, r, m);
            RandomizedQuickSort(a, l, m[0] - 1, m);
            RandomizedQuickSort(a, m[1] + 1, r, m);
        }
    }
}
