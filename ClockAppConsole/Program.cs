using System;
using System.Timers;

namespace ClockAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            Console.ReadKey();

            timer.Stop();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine(DateTime.Now);
        }
    }
}
