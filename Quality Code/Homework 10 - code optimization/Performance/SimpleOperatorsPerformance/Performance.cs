using System;
using System.Diagnostics;

namespace SimpleOperatorsPerformance
{
    static class Performance
    {
        const int Iterations = 1000000;

        // DISCLAIMER: This is very stupid implementation, but I think that any other solution would affect measurement performance and accuracy 
        static void Main(string[] args)
        {
            // Task 2
            Console.WriteLine("Simple math operators comparison of performance (in ticks)\n");
            Console.WriteLine("{0,10} {1,10} {2,10} {3,10} {4,10} {5,10}", "", "int","long","float","double","decimal");
            Console.WriteLine("{0,10:f6} {1,10:f6} {2,10:f6} {3,10:f6} {4,10:f6} {5,10:f6}", "Sum:", SumInt(), SumLong(), SumFloat(), SumDouble(), SumDecimal());
            Console.WriteLine("{0,10:f6} {1,10:f6} {2,10:f6} {3,10:f6} {4,10:f6} {5,10:f6}", "Subtract:", SubInt(), SubLong(), SubFloat(), SubDouble(), SubDecimal());
            Console.WriteLine("{0,10:f6} {1,10:f6} {2,10:f6} {3,10:f6} {4,10:f6} {5,10:f6}", "Increment:", IncInt(), IncLong(), IncFloat(), IncDouble(), IncDecimal());
            Console.WriteLine("{0,10:f6} {1,10:f6} {2,10:f6} {3,10:f6} {4,10:f6} {5,10:f6}", "Multiply:", MulInt(), MulLong(), MulFloat(), MulDouble(), MulDecimal());
            Console.WriteLine("{0,10:f6} {1,10:f6} {2,10:f6} {3,10:f6} {4,10:f6} {5,10:f6}\n", "Divide:", DivInt(), DivLong(), DivFloat(), DivDouble(), DivDecimal());
            
            // Task 3
            Console.WriteLine("{0,10} {1,10} {2,10:f6} {3,10:f6} {4,10:f6} {5,10:f6}", "SQRT:", "", "", SqrFloat(), SqrDouble(), SqrDecimal());
            Console.WriteLine("{0,10} {1,10} {2,10:f6} {3,10:f6} {4,10:f6} {5,10:f6}", "LN:", "", "", LogFloat(), LogDouble(), LogDecimal());
            Console.WriteLine("{0,10} {1,10} {2,10:f6} {3,10:f6} {4,10:f6} {5,10:f6}", "SIN:", "", "", SinFloat(), SinDouble(), SinDecimal());

            Console.WriteLine("\nPress Enter to Finish");
            Console.ReadLine();
        }

        // Sum
        static double SumInt()
        {
            int sum = 0;
            int number = 5;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = number + number;
            }
            counter.Stop();
            return (double)counter.ElapsedTicks/Iterations;
        }

        static double SumLong()
        {
            long sum = 0L;
            long number = 5L;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = number + number;
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        static double SumFloat()
        {
            float sum = 0.0f;
            float number = 5.0f;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = number + number;
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        static double SumDouble()
        {
            double sum = 0.0d;
            double number = 5.0d;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = number + number;
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        static double SumDecimal()
        {
            decimal sum = 0.0m;
            decimal number = 5.0m;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = number + number;
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        // Subtract
        static double SubInt()
        {
            int sum = 0;
            int number = 5;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = number - number;
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        static double SubLong()
        {
            long sum = 0L;
            long number = 5L;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = number - number;
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        static double SubFloat()
        {
            float sum = 0.0f;
            float number = 5.0f;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = number - number;
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        static double SubDouble()
        {
            double sum = 0.0d;
            double number = 5.0d;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = number - number;
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        static double SubDecimal()
        {
            decimal sum = 0.0m;
            decimal number = 5.0m;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = number - number;
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        // Increment
        static double IncInt()
        {
            int number = 5;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                number++;
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        static double IncLong()
        {
            long number = 5L;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                number++;
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        static double IncFloat()
        {
            float number = 5.0f;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                number++;
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        static double IncDouble()
        {
            double number = 5.0d;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                number++;
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        static double IncDecimal()
        {
            decimal number = 5.0m;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                number++;
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        // Multiply
        static double MulInt()
        {
            int sum = 0;
            int number = 5;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = number * number;
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        static double MulLong()
        {
            long sum = 0L;
            long number = 5L;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = number * number;
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        static double MulFloat()
        {
            float sum = 0.0f;
            float number = 5.0f;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = number * number;
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        static double MulDouble()
        {
            double sum = 0.0d;
            double number = 5.0d;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = number * number;
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        static double MulDecimal()
        {
            decimal sum = 0.0m;
            decimal number = 5.0m;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = number * number;
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        // Divide
        static double DivInt()
        {
            int sum = 0;
            int number = 5;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = number / number;
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        static double DivLong()
        {
            long sum = 0L;
            long number = 5L;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = number / number;
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        static double DivFloat()
        {
            float sum = 0.0f;
            float number = 5.0f;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = number / number;
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        static double DivDouble()
        {
            double sum = 0.0d;
            double number = 5.0d;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = number / number;
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        static double DivDecimal()
        {
            decimal sum = 0.0m;
            decimal number = 5.0m;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = number / number;
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        // Square root
        static double SqrFloat()
        {
            float sum = 0.0f;
            float number = 5.0f;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = (float)Math.Sqrt((double)number);
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        static double SqrDouble()
        {
            double sum = 0.0d;
            double number = 5.0d;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = Math.Sqrt(number);
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        static double SqrDecimal()
        {
            decimal sum = 0.0m;
            decimal number = 5.0m;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = (decimal)Math.Sqrt((double)number);
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        // Natural logarithm
        static double LogFloat()
        {
            float sum = 0.0f;
            float number = 5.0f;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = (float)Math.Log((double)number);
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        static double LogDouble()
        {
            double sum = 0.0d;
            double number = 5.0d;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = Math.Log(number);
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        static double LogDecimal()
        {
            decimal sum = 0.0m;
            decimal number = 5.0m;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = (decimal)Math.Log((double)number);
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        // Sinus
        static double SinFloat()
        {
            float sum = 0.0f;
            float number = 5.0f;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = (float)Math.Sin((double)number);
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        static double SinDouble()
        {
            double sum = 0.0d;
            double number = 5.0d;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = Math.Sin(number);
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }

        static double SinDecimal()
        {
            decimal sum = 0.0m;
            decimal number = 5.0m;
            Stopwatch counter = new Stopwatch();
            counter.Start();
            for (int i = 0; i < Iterations; i++)
            {
                sum = (decimal)Math.Sin((double)number);
            }
            counter.Stop();
            return (double)counter.ElapsedTicks / Iterations;
        }
    }
}
