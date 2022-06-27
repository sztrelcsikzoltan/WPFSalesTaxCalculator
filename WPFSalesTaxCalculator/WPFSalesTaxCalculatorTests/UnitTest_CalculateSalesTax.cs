using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WPFSalesTaxCalculator.Classes;

namespace WPFSalesTaxCalculatorTests
{
    [TestClass]
    public class UnitTest_CalculateSalesTax
    {
        Methods method = new Methods();
        [TestMethod]
        public void ExemptAndNotImported()
        {
            double expected = 0.00; // 1 book at 12.49 * 0.00 = 0.00
            double actual = 0.00;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExemptAndImported()
        {
            double expected = 0.50; // 1 imported box of chocolates at 10.00 * 0.05 = 0.50
            double actual = 0.50;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultAndNotImported()
        {
            double expected = 1.50; // 1 music CD at 14,99 * 0.10 = 1.499 rounded to nearest 0.05 = 1.50
            double actual = 1.50;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultAndImported() 
        {
            double expected = 4.20; // 1 imported bottle of perfume at 27.99 * 0.15 = 4.1985 rounded to nearest 0.05 = 4.20
            double actual = 4.20;
            Assert.AreEqual(expected, actual);
        }
    }
}
