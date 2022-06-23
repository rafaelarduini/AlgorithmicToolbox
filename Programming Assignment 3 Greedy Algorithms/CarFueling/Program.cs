using System;

namespace CarFueling
{
	class Program
	{
		static void Main(string[] args)
		{
            int dist = int.Parse(Console.ReadLine());
            int tank = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            var stops = new int[n];
            var numbersString = Console.ReadLine().Split(' ');

            for (int i = 0; i < n; i++)
            {
                stops[i] = int.Parse(numbersString[i]);
            }

            int retorno = ComputeMinRefills(dist, tank, stops);
            Console.WriteLine(retorno < 0 ? -1 : retorno);
        }
        static int ComputeMinRefills(int dist, int tank, int[] stops, int location = 0, int index = 0)
        {
			if (location + tank >= dist)
			{
                return 0;
			}

			if (index >= stops.Length || stops[index] - location > tank)
			{
                return -1000000;
			}

            int lastStop = location;

            int i;

            for (i = index; i < stops.Length; i++)
			{
                if (stops[i] - location <= tank)
                {
                    lastStop = stops[i];
                }
                else
                {
                    break;
                }
			}

            return 1 + ComputeMinRefills(dist, tank, stops, lastStop, i);
        }
    }
}
