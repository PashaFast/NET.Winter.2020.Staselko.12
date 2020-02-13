using System;
using System.Collections.Generic;
using System.Numerics;

namespace FibonacciSequence
{
    /// <summary>
    /// Class Fibonacci.
    /// </summary>
    public static class Fibonacci
    {
        /// <summary>
        /// Fibonacci number sequence generator method
        /// that allows you to get the first count-numbers of the Fibonacci sequence.
        /// </summary>
        /// <param name="count">Input count.</param>
        /// <exception cref="ArgumentException">Throw when count is zero or negative.</exception>
        /// <returns>First count numbers of the Fibonacci sequence.</returns>
        public static IEnumerable<BigInteger> FibonacciGenerator(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException("cannot be zero or negative.");
            }

            return FibonacciGeneratorHelper(count);
        }

        private static IEnumerable<BigInteger> FibonacciGeneratorHelper(int count)
        {
            BigInteger current = -1;
            BigInteger next = 1;
            for (int i = 0; i < count; i++)
            {
                BigInteger temp = next;
                next += current;
                current = temp;
                yield return next;
            }
        }
    }
}