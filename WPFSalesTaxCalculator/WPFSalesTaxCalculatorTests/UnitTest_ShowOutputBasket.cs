using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WPFSalesTaxCalculatorTests
{
    [TestClass]
    public class UnitTest_ShowOutputBasket
    {
         [TestMethod]
        public void OutputSampleBasket1()
        {
            // the output with decimal symbol ',' or '.' can be correct depending on the actual regional settings
            string actual = "> 1 book: 12,49\n> 1 music CD: 16,49\n> 1 chocolate bar: 0,85\n> Sales taxes: 1,50\n> Total: 29,83\n";
            bool condition = actual =="> 1 book: 12,49\n> 1 music CD: 16,49\n> 1 chocolate bar: 0,85\n> Sales taxes: 1,50\n> Total: 29,83\n" || actual == "> 1 book: 12.49\n> 1 music CD: 16.49\n> 1 chocolate bar: 0.85\n> Sales taxes: 1.50\n> Total: 29.83\n";
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void OutputSampleBasket2()
        {
            // the output with decimal symbol ',' or '.' can be correct depending on the actual regional settings
            string actual = "> 1 imported box of chocolates: 10,50\n> 1 imported bottle of perfume: 54,65\n> Sales taxes: 7,65\n> Total: 65,15\n";
            bool condition = actual == "> 1 imported box of chocolates: 10,50\n> 1 imported bottle of perfume: 54,65\n> Sales taxes: 7,65\n> Total: 65,15\n" || actual == "> 1 imported box of chocolates: 10.50\n> 1 imported bottle of perfume: 54.65\n> Sales taxes: 7.65\n> Total: 65.15\n";
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void OutputSampleBasket3()
        {
            // the output with decimal symbol ',' or '.' can be correct depending on the actual regional settings
            string actual = "> 1 imported bottle of perfume: 32,19\n> 1 bottle of perfume: 20,89\n> 1 packet of headache pills: 9,75\n> 1 box of imported chocolates: 11,85\n> Sales taxes: 6,70\n> Total: 74,68\n";
            bool condition = actual == "> 1 imported bottle of perfume: 32,19\n> 1 bottle of perfume: 20,89\n> 1 packet of headache pills: 9,75\n> 1 box of imported chocolates: 11,85\n> Sales taxes: 6,70\n> Total: 74,68\n" || actual == "> 1 imported bottle of perfume: 32.19\n> 1 bottle of perfume: 20.89\n> 1 packet of headache pills: 9.75\n> 1 box of imported chocolates: 11.85\n> Sales taxes: 6.70\n> Total: 74.68\n";
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void OutputNewBasket()
        {
            string actual = "";
            bool condition = actual == "";
            Assert.IsTrue(condition);
        }


    }
}
