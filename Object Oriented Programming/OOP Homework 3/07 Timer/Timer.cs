using System;
using System.Linq;
using System.Threading;

namespace _07_Timer
{
    // DISCLAIMER: even the good practice is to put each class in a separate file
    // here we are using a single file due to the task simplicity
    public class Timer
    {
        public delegate void OnTimeElapsed();

        private int count; // number of iterations - if it is negative it means an infinite loop (see below in constructor)
        private readonly int intervalSeconds; // interval in seconds
        private readonly OnTimeElapsed doWork; // method that must be invoked

        public Timer(OnTimeElapsed method, int interval, int count = -1)
        {
            if (interval <= 0) throw new ArgumentOutOfRangeException(); // interval cannot be negative or zero
            // initializes parameters
            this.count = count;
            this.intervalSeconds = interval;
            this.doWork = method;

            // creates separate thread that loops until it has been executed "count" number of times 
            Thread run = new Thread(delegate()
                {
                    while (this.count != 0)
                    {
                        Thread.Sleep(this.intervalSeconds * 1000); // waits some interval of seconds
                        if (this.count > 0) this.count--; // counts down only if positive, otherwise it results to infinite loop 
                        this.doWork();
                    }
                });
            run.Start(); // the thread must be started explicitly
        }
    }

    class TimerTest
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 07 - Timer");

            Timer aTimer = new Timer(delegate() { Console.WriteLine("Hello Timer! - 5 x 2 sec"); }, 2 , 5);
            // if you put comments around last parameter (/*, 10*/) then the timer will be infinite

            Console.WriteLine("Main thread - prints 200 dots in 100 msec interval each");
            for (int i = 0; i < 200; i++)
            {
                Console.Write("."); // do somethig - prints dot on each 100 msec
                Thread.Sleep(100);
            }
            
            Console.WriteLine("That's all folks\r\nPress Enter to finish");
            Console.ReadLine();
        }
    }
}
