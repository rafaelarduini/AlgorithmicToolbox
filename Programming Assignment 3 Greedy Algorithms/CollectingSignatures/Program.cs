using System;

namespace CollectingSignatures
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Segment[] segments = new Segment[n];

            for (int i = 0; i < n; i++)
            {
                var numbersString = Console.ReadLine().Split(' ');

                long start, end;
                start = long.Parse(numbersString[0]);
                end = long.Parse(numbersString[1]);
                segments[i] = new Segment(start, end);
            }

            long[] points = optimalPoints(segments);
            Console.WriteLine(points.Length);

            foreach (var point in points)
            {
                Console.Write(point + " ");
            }
        }

        private static long[] optimalPoints(Segment[] segments)
        {

            long[] endPoints = new long[segments.Length];

            for (int i = 0; i < segments.Length; i++)
            {
                endPoints[i] = segments[i].End;
            }
            long[] points = new long[segments.Length];
            long count = 0;

            Array.Sort(endPoints, segments);

			for (int i = 0; i < segments.Length; i++)
			{
				if (segments[i].End != long.MinValue)
				{
                    for (int j = 0; j < segments.Length; j++)
                    {
                        if (segments[i].End != long.MinValue && i != j)
                        {
                            if (segments[i].End >= segments[j].Start && segments[i].End <= segments[j].End)
                            {
                                segments[j].Start = long.MinValue;
                                segments[j].End = long.MinValue;
                            }
                        }
                    }

                    points[count] = segments[i].End;
                    count++;

                    segments[i].Start = long.MinValue;
                    segments[i].End = long.MinValue;
                }
            }

            long[] result = new long[count];

			for (int i = 0; i < result.Length; i++)
			{
                result[i] = points[i];
            }

            return result;
        }

        private class Segment
        {
            public long Start { get; set; }
            public long End { get; set; }

            public Segment(long start, long end)
            {
                Start = start;
                End = end;
            }
        }
    }
}
