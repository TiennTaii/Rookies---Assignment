using System;

namespace PrimeNumbersApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPrime = true;
            int i, j;

            Console.WriteLine("Prime Numbers : ");

            for (i = 2; i <= 100; i++) // 0 and 1 not prime number!
            {
                for (j = 2; j <= 100; j++)
                {
                    if (i != j && i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    Console.WriteLine(i);
                }

                isPrime = true;
            }
        }
    }
}
