using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ChangeCalculator.UnitTest
{
    public class CalculatorUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void When_PurchasePrice_Equals_TenderedAmount_Then_Should_Throw_NoChange_Exception()
        {
            var ex = Assert.Throws<Exception>(() => Calculator.CalculateChange(5, 5));
            Assert.That(ex.Message, Is.EqualTo("No change is required"));
        }

        [Test]
        public void When_PurchasePrice_Is_Greater_Than_TenderedAmount_Then_Should_Throw_InsufficientFunds_Exception()
        {
            var ex = Assert.Throws<Exception>(() => Calculator.CalculateChange(50, 25));
            Assert.That(ex.Message, Is.EqualTo("Insufficient funds to complete transaction"));
        }

        [TestCaseSource("TestCases")]
        public void When_PurchasePrice_And_TenderedAmount_Are_Valid_Then_Should_Calculate_Correct_Change(decimal purchasePrice, decimal tenderedAmount, List<Tuple<Denominations, int>> expected)
        {
            var result = Calculator.CalculateChange(purchasePrice, tenderedAmount);
            CollectionAssert.AreEquivalent(expected, result);

        }

        private static readonly object[] TestCases =
        {
            new object[]
            {
                (decimal)25,
                (decimal)50,
                new List<Tuple<Denominations, int>>
                {
                    new Tuple<Denominations, int>(Denominations.FivePound, 1),
                    new Tuple<Denominations, int>(Denominations.TwentyPound, 1)
                }
            },
            new object[]
            {
                (decimal)156.43,
                (decimal)195.50,
                new List<Tuple<Denominations, int>>
                {
                    new Tuple<Denominations, int>(Denominations.TwoPence, 1),
                    new Tuple<Denominations, int>(Denominations.FivePence, 1),
                    new Tuple<Denominations, int>(Denominations.TwoPound, 2),
                    new Tuple<Denominations, int>(Denominations.FivePound, 1),
                    new Tuple<Denominations, int>(Denominations.TenPound, 1),
                    new Tuple<Denominations, int>(Denominations.TwentyPound, 1)
                }
            },
            new object[]
            {
                (decimal)1467.43,
                (decimal)2923.56,
                new List<Tuple<Denominations, int>>
                {
                    new Tuple<Denominations, int>(Denominations.OnePence, 1),
                    new Tuple<Denominations, int>(Denominations.TwoPence, 1),
                    new Tuple<Denominations, int>(Denominations.TenPence, 1),
                    new Tuple<Denominations, int>(Denominations.OnePound, 1),
                    new Tuple<Denominations, int>(Denominations.FivePound, 1),
                    new Tuple<Denominations, int>(Denominations.FiftyPound, 29)
                }
            },
            new object[]
            {
                (decimal)176.89,
                (decimal)206.87,
                new List<Tuple<Denominations, int>>
                {
                    new Tuple<Denominations, int>(Denominations.OnePence, 1),
                    new Tuple<Denominations, int>(Denominations.TwoPence, 1),
                    new Tuple<Denominations, int>(Denominations.FivePence, 1),
                    new Tuple<Denominations, int>(Denominations.TwentyPence, 2),
                    new Tuple<Denominations, int>(Denominations.FiftyPence, 1),
                    new Tuple<Denominations, int>(Denominations.TwoPound, 2),
                    new Tuple<Denominations, int>(Denominations.FivePound, 1),
                    new Tuple<Denominations, int>(Denominations.TwentyPound, 1)
                }
            },
        };
    }
}