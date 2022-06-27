using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WPFSalesTaxCalculator.Classes;

namespace WPFSalesTaxCalculatorTests
{
    [TestClass]
    public class UnitTest_CalculateCategory
    {
        Methods method = new Methods();
        [TestMethod]
        public void ExemptCategoryBook()
        {
            string expected = "book";
            // string actual = "book";
            string actual = method.CalculateCategory("book");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExemptCategoryChocolateBar()
        {
            string expected = "food";
            // string actual = "food";
            string actual = method.CalculateCategory("chocolate bar");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExemptCategoryBoxOfChocolates()
        {
            string expected = "food";
            // string actual = "food";
            string actual = method.CalculateCategory("box of chocolates");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExemptCategoryHeadachePills()
        {
            string expected = "medical";
            // string actual = "medical";
            string actual = method.CalculateCategory("packet of headache pills");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OtherCategoryMusicCD()
        {
            string expected = "other";
            // string actual = "other";
            string actual = method.CalculateCategory("music CD");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OtherCategoryBottleOfPerfume()
        {
            string expected = "other";
            // string actual = "other";
            string actual = method.CalculateCategory("bottle of perfume");
            Assert.AreEqual(expected, actual);
        }
    }
}
