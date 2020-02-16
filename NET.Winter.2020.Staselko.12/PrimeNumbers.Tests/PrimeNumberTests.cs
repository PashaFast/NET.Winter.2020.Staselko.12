using NUnit.Framework;
using System;

namespace PrimeNumbers.Tests
{
    public class PrimeNumberTests
    {
        [TestCase(2, 2, new int[] { 2 })]
        [TestCase(2, 3, new int[] { 2, 3 })]
        [TestCase(2, 10, new int[] { 2, 3, 5, 7 })]
        [TestCase(30, 48, new int[] { 31, 37, 41, 43, 47 })]
        [TestCase(11, 97, new int[] { 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 })]
        [TestCase(180, 190, new int[] { 181 })]

        public void PrimeNumbersGenerator_SomeNumbers_ExpectedResult(int start, int end, int[] expected )
        {
            Assert.AreEqual(PrimeNumbers.PrimeNumbersGenerator(start, end), expected);
        }

        [Test]
        public void PrimeNumbersGenerator_NegativeStart_ArgumentException() =>
               Assert.Throws<ArgumentException>(() => PrimeNumbers.PrimeNumbersGenerator(-1, 100),
                   message: "cannot be null");

        [Test]
        public void PrimeNumbersGenerator_NegativeEnd_ArgumentException() =>
               Assert.Throws<ArgumentException>(() => PrimeNumbers.PrimeNumbersGenerator(10, -9),
                   message: "cannot be null");

        [Test]
        public void PrimeNumbersGenerator_NegativeEndAndStart_ArgumentException() =>
              Assert.Throws<ArgumentException>(() => PrimeNumbers.PrimeNumbersGenerator(-10, -9),
                  message: "cannot be null");

        [Test]
        public void PrimeNumbersGenerator_EndMoreTnanStart_ArgumentException() =>
              Assert.Throws<ArgumentException>(() => PrimeNumbers.PrimeNumbersGenerator(8, 6),
                  message: "cannot be null");





    }
}