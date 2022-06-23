using System;

namespace MaximumValueLoot
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbersString = Console.ReadLine().Split(' ');

            int n = int.Parse(numbersString[0]);
            double capacity = double.Parse(numbersString[1]);

            double[] values = new double[n];
            double[] weights = new double[n];

            for (int i = 0; i < n; i++)
            {
                numbersString = Console.ReadLine().Split(' ');

                values[i] = double.Parse(numbersString[0]);
                weights[i] = double.Parse(numbersString[1]);
            }
            Console.WriteLine(Math.Round(GetOptimalValue(capacity, values, weights), 4));
        }

        private static double GetOptimalValue(double capacity, double[] values, double[] weights)
        {
            double value = 0;
            double maxValue = 0;
            int indexMaxValue = -1;

            if (capacity == 0)
            {
                return 0;
            }

            for (int i = 0; i < values.Length; i++)
            {
                double tempValue = values[i] / weights[i];

                if (tempValue > maxValue)
                {
                    maxValue = tempValue;
                    indexMaxValue = i;
                }
            }

            if (indexMaxValue == -1)
            {
                return 0;
            }

            double amount = Math.Min(capacity, weights[indexMaxValue]);
            value += amount * values[indexMaxValue] / weights[indexMaxValue];
            capacity -= amount;
            values[indexMaxValue] = 0;

            return value + GetOptimalValue(capacity, values, weights);
        }
    }
}
