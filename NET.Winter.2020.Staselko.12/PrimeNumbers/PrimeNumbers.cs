using System;
using System.Collections.Generic;

namespace PrimeNumbers
{
    /// <summary>
    /// Static Class PrimeNumbers.
    /// </summary>
    public static class PrimeNumbers
    {
        /// <summary>
        /// Method of finding prime numbers in range from start to end.
        /// </summary>
        /// <param name="start">Start parameter.</param>
        /// <param name="end">End parameter.</param>
        /// <returns>The sequence of prime numbers.</returns>
        public static IEnumerable<int> PrimeNumbersGenerator(int start, int end)
        {
            if (start > end)
            {
               throw new ArgumentException($"{start} must be less than {end}");
            }

            if (start <= 1 || end <= 1)
            {
               throw new ArgumentException($"{start} and {end} must be more than 1");
            }

            return ReturnNumberIfMatch(start, end);
        }

        private static IEnumerable<int> ReturnNumberIfMatch(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                if (IsPrimeNumber(i))
                {
                   yield return i;
                }
            }
        }

        private static bool IsPrimeNumber(int number)
        {
            for (int i = 2; i <= (int)Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
