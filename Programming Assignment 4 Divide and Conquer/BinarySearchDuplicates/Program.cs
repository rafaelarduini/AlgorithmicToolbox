using System;

namespace BinarySearchDuplicates
{
	class Program
	{
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //n = 7;
            int[] a = new int[n];
            var stringNumbersArray = Console.ReadLine().Split(' ');
            //stringNumbersArray = new string[] { "2", "4", "4", "4", "7", "7", "9" };
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(stringNumbersArray[i]);
            }
            int m = int.Parse(Console.ReadLine());
            //m = 4;
            int[] b = new int[m];
            stringNumbersArray = Console.ReadLine().Split(' ');
            //stringNumbersArray = new string[] { "9", "4", "5", "2" };
            for (int i = 0; i < m; i++)
            {
                b[i] = int.Parse(stringNumbersArray[i]);
            }
            for (int i = 0; i < m; i++)
            {
                Console.Write(BinarySearchWithDuplicates(a, 0, a.Length - 1, b[i]) + " ");
            }
        }

        static int BinarySearchWithDuplicates(int[] a, int low, int high, int key)
        {
            if (high < low)
                return -1;

            int mid = low + ((high - low) / 2);

			if (key == a[mid])
			{
				if (mid == 0 || a[mid - 1] != a[mid])
                    return mid;
                else
                    return BinarySearchWithDuplicates(a, low, mid - 1, key);
            }

            else if (key < a[mid])
                return BinarySearchWithDuplicates(a, low, mid - 1, key);

            else
                return BinarySearchWithDuplicates(a, mid + 1, high, key);
        }
    }
}
