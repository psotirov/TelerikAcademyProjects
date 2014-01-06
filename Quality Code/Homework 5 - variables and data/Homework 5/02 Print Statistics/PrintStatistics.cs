using System;

namespace _02_Print_Statistics
{
    class PrintStatistics
    {
        public void PrintStatistics(double[] array)
        {
            if (array.Length == 0) return;
            double max = array[0];
            int count = array.Length;
            for (int i = 1; i < count; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            PrintMax(max);

            double min = array[0];
            for (int i = 1; i < count; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            PrintMin(min);
 
            double average = 0;
            for (int i = 0; i < count; i++)
            {
                average += array[i]; 
            }

            average /= count;

            PrintAverage(average);
        }

        public void PrintMax(double value)
        {
            throw new NotImplementedException();
        }

        public void PrintMin(double value)
        {
            throw new NotImplementedException();
        }

        public void PrintAverage(double value)
        {
            throw new NotImplementedException();
        }

        static void Main(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
