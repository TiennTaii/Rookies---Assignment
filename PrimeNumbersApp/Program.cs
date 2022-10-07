public class Program
{
    public static void Main(String[] args)
    {
        Task.WhenAll(GetPrimeNumbers(0, 100));

        Console.ReadKey();
    }

    static async Task GetPrimeNumbers(int minimum, int maximum)
    {
        await Task.Run(() =>
        {
            for (int i = minimum; i <= maximum; i++)
            {
                if (IsPrimeNumber(i))
                {
                    Console.WriteLine(" " + i);
                }
            }
        });
    }

    static bool IsPrimeNumber(int number)
    {
        int i;

        for (i = 2; i <= number - 1; i++)
        {
            if (number % i == 0)
                return false;
        }

        if (number == i)
            return true;

        return false;
    }
}

