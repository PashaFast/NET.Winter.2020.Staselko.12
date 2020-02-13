using System;
using System.Collections.Generic;
using System.Numerics;

namespace FibonacciSequence
{
    public static class Fibonacci
    {
        public static IEnumerable<BigInteger> FibonacciGenerator(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException("cannot be zero or negative.");
            }

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