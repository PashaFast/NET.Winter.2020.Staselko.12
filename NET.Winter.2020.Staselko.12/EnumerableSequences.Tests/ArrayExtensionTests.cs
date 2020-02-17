using NUnit.Framework;
using Moq;
using NumberExtension;
using Helpers;

namespace EnumerableSequences.Tests
{
    [TestFixture]
    public class ArrayExtensionTests
    {
        private Mock<IPredicate<int>> mockPredicate;

        private IPredicate<int> predicate;

        [SetUp]
        public void Setup()
        {
            mockPredicate = new Mock<IPredicate<int>>();

            mockPredicate
                .Setup(p => p.IsMatch(It.Is<int>(i => new PredicateDigit { Digit = 5 }.ContainsKey(i))))
                .Returns(true);

            predicate = mockPredicate.Object;
        }
        [TestCase(55)]
        [TestCase(551)]
        [TestCase(-12551)]
        [TestCase(-90551)]
        public void IsMatchTests_Return_True(int value)
        {
            Assert.IsTrue(predicate.IsMatch(value));

            mockPredicate.Verify(p => p.IsMatch(It.IsAny<int>()), Times.Exactly(1));
        }

        [TestCase(109)]
        [TestCase(67632)]
        [TestCase(-120943)]
        [TestCase(-2113)]
        public void IsMatchTests_Return_False(int value)
        {
            Assert.IsFalse(predicate.IsMatch(value));

            mockPredicate.Verify(p => p.IsMatch(It.IsAny<int>()), Times.Exactly(1));
        }

        [Test]
        public void FilterByTests()
        {
            var source = new int[] { 12, 35, -65, 543, 23 };

            var expected = new int[] { 35, -65, 543 };

            var actual = source.FilterBy(predicate);

            CollectionAssert.AreEqual(actual, expected);

            mockPredicate.Verify(p => p.IsMatch(It.IsAny<int>()), Times.Exactly(5));
        }

        [Test]
        public void TransformTests()
        {
            var source = new double[] { -255.255, 255.255, 4294967295.0, double.MinValue, double.MaxValue, double.Epsilon };
            var expected = new string[] { "1100000001101111111010000010100011110101110000101000111101011100",
            "0100000001101111111010000010100011110101110000101000111101011100",
             "0100000111101111111111111111111111111111111000000000000000000000",
             "1111111111101111111111111111111111111111111111111111111111111111",
             "0111111111101111111111111111111111111111111111111111111111111111",
             "0000000000000000000000000000000000000000000000000000000000000001"
            };

            Assert.AreEqual(expected, source.Transform((new TransformerAdapty())));
        }

        [Test]
        public void OrderAccordingToTests()
        {
            var source = new string[] { "1", "12", "123", "2", "122343", "23" };

            var expected = new string[] { "1", "2", "12", "23", "123", "122343" };

            var actual = source.OrderAccordingTo(new StringComparer());

            CollectionAssert.AreEqual(actual, expected);

        }

        [Test]
        public void OrderAccordingToWithNullTest()
        {
            var source = new string[] { null, "12", "123", null, "2" };

            var expected = new string[] { "2", "12", "123", null, null };

            var actual = source.OrderAccordingTo(new StringComparer());

            CollectionAssert.AreEqual(actual, expected);

        }

        [Test]
        public void ReverseTests()
        {
            var source = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var actual = source.Reverse();

            CollectionAssert.AreEqual(actual, expected);
        }

        [Test]
        public void TypeOfTests()
        {
            var source = new object[] { 9, 5, 3, "ewwec", 'p', 54.35 };

            var expected = new int[] { 9, 5, 3 };

            var actual = source.TypeOf<int>();

            CollectionAssert.AreEqual(actual, expected);

        }
    }
}