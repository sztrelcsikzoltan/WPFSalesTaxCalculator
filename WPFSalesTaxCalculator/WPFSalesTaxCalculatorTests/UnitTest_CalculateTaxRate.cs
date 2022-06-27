using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WPFSalesTaxCalculator.Classes;

namespace WPFSalesTaxCalculatorTests
{
    [TestClass]
    public class UnitTest_CalculateTaxRate
    {
        Methods method = new Methods();
        [TestMethod]
        public void ExemptAndNotImported()
        {
            double expected = 0.00;
            // double actual = 0.00;
            double actual = method.CalculateTaxRate("book", false);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExemptAndImported()
        {
            double expected = 0.05;
            // double actual = 0.05;
            double actual = method.CalculateTaxRate("food", true);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultAndNotImported()
        {
            double expected = 0.10;
            // double actual = 0.10;
            double actual = method.CalculateTaxRate("default", false);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultAndImported()
        {
            double expected = 0.15;
            // double actual = 0.15;
            double actual = method.CalculateTaxRate("default", true);
            Assert.AreEqual(expected, actual);
        }

    }
}
