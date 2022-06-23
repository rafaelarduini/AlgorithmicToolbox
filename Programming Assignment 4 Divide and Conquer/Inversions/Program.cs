using System;

namespace Inversions
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
            Console.WriteLine(GetNumberOfInversions(a, 0, a.Length - 1));
        }

		private static long GetNumberOfInversions(int[] a, int left, int right)
        {
            long numberOfInversions = 0;

            if (left >= right)
            {
                return numberOfInversions;
            }

            int mid = (left + right) / 2;

            numberOfInversions += GetNumberOfInversions(a, left, mid);
            numberOfInversions += GetNumberOfInversions(a, mid + 1, right);

            numberOfInversions += GetNumberOfInversionsMerge(a, left, mid + 1, right);

            return numberOfInversions;
        }

        private static long GetNumberOfInversionsMerge(int[] a, int left, int mid, int right)
        {
            int[] d = new int[right - left + 1];

            long numberOfInversions = 0;

            int aCount = left;
            int bCount = mid;
            int dIndex = 0;

            while ((aCount < mid) && (bCount <= right))
            {
                if (a[aCount] <= a[bCount])
                {
                    d[dIndex] = a[aCount];
                    aCount++;
                    dIndex++;
                }
                else
                {
                    d[dIndex] = a[bCount];
                    bCount++;
                    dIndex++;
                    numberOfInversions += (mid - aCount);
                }
            }

            if (aCount < mid && !(bCount <= right))
            {
                for (int i = aCount; i < mid; i++)
                {
                    d[dIndex] = a[i];
                    dIndex++;
                }
            }

            if (bCount <= right && !(aCount < mid))
            {
                for (int i = bCount; i <= right; i++)
                {
                    d[dIndex] = a[i];
                    dIndex++;
                }
            }

            for (int i = 0; i < d.Length; i++)
            {
				if (a[left + i] != d[i])
				{
                    a[left + i] = d[i];
                }
            }

            return numberOfInversions;
        }

        private static void MergeSort(int[] a, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int mid = (left + right) / 2;

            MergeSort(a, left, mid);
            MergeSort(a, mid + 1, right);

            Merge(a, left, mid + 1, right);
        }

        private static void Merge(int[] a, int left, int mid, int right)
		{
            int[] d = new int[right - left + 1];

            int aCount = left;
            int bCount = mid;
            int dIndex = 0;

            while (aCount < mid && bCount <= right)
			{
                if (a[aCount] <= a[bCount])
                {
                    d[dIndex] = a[aCount];
                    aCount++;
                    dIndex++;
                }
                else 
                {
                    d[dIndex] = a[bCount];
                    bCount++;
                    dIndex++;
                }
            }

			if (aCount < mid && !(bCount <= right))
			{
				for (int i = aCount; i < mid; i++)
				{
                    d[dIndex] = a[i];
                    dIndex++;
                }
			}

			if (bCount <= right && !(aCount < mid))
			{
                for (int i = bCount; i <= right; i++)
                {
                    d[dIndex] = a[i];
                    dIndex++;
                }
            }

			for (int i = 0; i < d.Length; i++)
			{
                a[left + i] = d[i];
			}
        }
	}
}
