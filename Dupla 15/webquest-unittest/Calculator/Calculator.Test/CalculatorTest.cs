using System;
using NUnit.Framework;

namespace Calculator.Test
{
    [TestFixture]
    public class CalculatorTest
    {
        ICalculator sut;

        [OneTimeSetUp]
        public void TestSetup()
        {
            sut = new Calculator();
        }

        [Test]
        [Ignore("Ignore teste")]
        public void ShouldNotMulTwoNumbers()
        {

            int expectedResult = sut.Mul(7, 8);
            Assert.That(expectedResult, Is.EqualTo(15));
        }

        [Test]
        public void ShouldAddTwoNumbers()
        {

            int expectedResult = sut.Add(7, 8);
            Assert.That(expectedResult, Is.EqualTo(15));
        }

        [Test]
        public void ShouldMulTwoNumbers()
        {

            int expectedResult = sut.Mul(7, 8);
            Assert.That(expectedResult, Is.EqualTo(56));
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            sut = null;
        }

    }
}
