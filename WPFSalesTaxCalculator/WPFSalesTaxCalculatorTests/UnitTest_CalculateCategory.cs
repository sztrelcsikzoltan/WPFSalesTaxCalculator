using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WPFSalesTaxCalculatorTests
{
    [TestClass]
    public class UnitTest_CalculateCategory
    {
        [TestMethod]
        public void ExemptCategoryBook()
        {
            string expected = "book";
            string actual = "book";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExemptCategoryChocolateBar()
        {
            string expected = "food";
            string actual = "food";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExemptCategoryBoxOfChocolates()
        {
            string expected = "food";
            string actual = "food";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExemptCategoryHeadachePills()
        {
            string expected = "medical";
            string actual = "medical";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OtherCategoryMusicCD()
        {
            string expected = "other";
            string actual = "other";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OtherCategoryBottleOfParfume()
        {
            string expected = "other";
            string actual = "other";
            Assert.AreEqual(expected, actual);
        }
    }
}
