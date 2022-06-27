using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WPFSalesTaxCalculatorTests
{
    [TestClass]
    public class UnitTest_CalculateTaxRate
    {
        [TestMethod]
        public void ExemptAndNotImported()
        {
            double expected = 0.00;
            double actual = 0.00;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExemptAndImported()
        {
            double expected = 0.05;
            double actual = 0.05;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultAndNotImported()
        {
            double expected = 0.10;
            double actual = 0.10;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultAndImported()
        {
            double expected = 0.15;
            double actual = 0.15;
            Assert.AreEqual(expected, actual);
        }

    }
}
