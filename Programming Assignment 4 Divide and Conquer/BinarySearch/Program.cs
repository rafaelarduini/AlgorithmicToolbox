using System;

namespace BinarySearch
{
	class Program
	{
		static void Main(string[] args)
		{
            int n = int.Parse(Console.ReadLine());
            //n = 5;
            int[] a = new int[n];
            var stringNumbersArray = Console.ReadLine().Split(' ');
            //stringNumbersArray = new string[] { "1", "5", "8", "12", "13" };
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(stringNumbersArray[i]);
            }
            int m = int.Parse(Console.ReadLine());
            //m = 5;
            int[] b = new int[m];
            stringNumbersArray = Console.ReadLine().Split(' ');
            //stringNumbersArray = new string[] { "8", "1", "23", "1", "11" };
            for (int i = 0; i < m; i++)
            {
                b[i] = int.Parse(stringNumbersArray[i]);
            }
            for (int i = 0; i < m; i++)
            {
                Console.Write(BinarySearch(a, 0, a.Length - 1, b[i]) + " ");
                //Console.Write(LinearSearch(a, b[i]) + " ");
            }
        }

        static int BinarySearch(int[] a, int low, int high, int key)
        {
            if (high < low)
                return - 1;

            int mid = low + ((high - low) / 2);

            if (key == a[mid])
                return mid;

            else if (key < a[mid])
                return BinarySearch(a, low, mid - 1, key);

            else
                return BinarySearch(a, mid + 1, high, key);
        }

        static int LinearSearch(int[] a, int x)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == x) return i;
            }
            return -1;
        }
    }
}
