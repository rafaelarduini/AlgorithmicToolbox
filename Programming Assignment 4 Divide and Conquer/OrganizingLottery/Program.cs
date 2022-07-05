using System;

namespace OrganizingLottery
{
	class Program
	{
		static void Main(string[] args)
		{
            var stringNumbersArray = Console.ReadLine().Split(' ');

            int n = int.Parse(stringNumbersArray[0]);
            int m = int.Parse(stringNumbersArray[1]);

            int[] starts = new int[n];
            int[] ends = new int[n];
            int[] points = new int[m];

            stringNumbersArray = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                starts[i] = int.Parse(stringNumbersArray[0]);
                ends[i] = int.Parse(stringNumbersArray[1]);
            }

            stringNumbersArray = Console.ReadLine().Split(' ');
            for (int i = 0; i < m; i++)
            {
                points[i] = int.Parse(stringNumbersArray[i]);
            }

            //use fastCountSegments
            int[] cnt = NaiveCountSegments(starts, ends, points);

			foreach (var x in cnt)
			{
                Console.Write(x + " ");
            }
		}

        private static int[] FastCountSegments(int[] starts, int[] ends, int[] points)
        {
            int[] cnt = new int[points.Length];


            //write your code here
            return cnt;
        }

        private static int[] NaiveCountSegments(int[] starts, int[] ends, int[] points)
        {
            int[] cnt = new int[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = 0; j < starts.Length; j++)
                {
                    if (starts[j] <= points[i] && points[i] <= ends[j])
                    {
                        cnt[i]++;
                    }
                }
            }
            return cnt;
        }
    }
}
