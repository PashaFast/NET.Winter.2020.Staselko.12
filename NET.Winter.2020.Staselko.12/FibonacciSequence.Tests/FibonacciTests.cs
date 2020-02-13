using NUnit.Framework;
using System;
using System.Numerics;

namespace FibonacciSequence.Tests
{
    public class FibonacciTests
    {
        [Test]
        public void FibonacciGenerator_WithPossitiveNumbers()
        {
            var expected = new BigInteger[] {0,1,1,2,3,5,8,13,21};

            var actual = Fibonacci.FibonacciGenerator(expected.Length);

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void FibonacciGenerator_WithNegativeCount() =>
            Assert.Throws<ArgumentException>(() => Fibonacci.FibonacciGenerator(-100),
                message: "cannot be zero or negative.");

        [Test]
        public void FibonacciGenerator_WithZeroCount() =>
            Assert.Throws<ArgumentException>(() => Fibonacci.FibonacciGenerator(0),
                message: "cannot be zero or negative.");
    }
}