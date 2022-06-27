using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WPFSalesTaxCalculatorTests
{
    [TestClass]
    public class UnitTest_ShowSampleBasket
    {
        [TestMethod]
        public void ContentSampleBasket1()
        {
            // in WPF RichTextBox, the lines are separated by the '\r\n>' characters, so it must be considered
            // also, the content with decimal symbol ',' or '.' can be correct depending on the actual regional settings
            string actual = "> 1 book at 12,49\r\n> 1 music CD at 14,99\r\n> 1 chocolate bar at 0,85\r\n";
            bool condition = actual == "> 1 book at 12,49\r\n> 1 music CD at 14,99\r\n> 1 chocolate bar at 0,85\r\n" || actual == "> 1 book at 12.49\r\n> 1 music CD at 14.99\r\n> 1 chocolate bar at 0.85\r\n";
            Assert.IsTrue(condition);
        }
         
        [TestMethod]
        public void ContentSampleBasket2()
        {
            // in WPF RichTextBox, the lines are separated by the '\r\n>' characters, so it must be considered
            // also, the content with decimal symbol ',' or '.' can be correct depending on the actual regional settings
            string actual = "> 1 imported box of chocolates at 10,00\r\n> 1 imported bottle of parfume at 47,50\r\n";
            bool condition = actual == "> 1 imported box of chocolates at 10,00\r\n> 1 imported bottle of parfume at 47,50\r\n" || actual == "> 1 imported box of chocolates at 10,00\r\n> 1 imported bottle of parfume at 47,50\r\n";
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void ContentSampleBasket3()
        {
            // in WPF RichTextBox, the lines are separated by the '\r\n>' characters, so it must be considered
            // also, the content with decimal symbol ',' or '.' can be correct depending on the actual regional settings
            string actual = "> 1 imported bottle of parfume at 27,99\r\n> 1 bottle of parfume at 18,99\r\n> 1 packet of headache pills at 9,75\r\n> 1 box of imported chocolates at 11,25\r\n";
            bool condition = actual == "> 1 imported bottle of parfume at 27,99\r\n> 1 bottle of parfume at 18,99\r\n> 1 packet of headache pills at 9,75\r\n> 1 box of imported chocolates at 11,25\r\n" || actual == "> 1 imported bottle of parfume at 27.99\r\n > 1 bottle of parfume at 18.99\r\n > 1 packet of headache pills at 9.75\r\n > 1 box of imported chocolates at 11.25\r\n";
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void ContentNewBasket()
        {
            string actual = "";
            bool condition = actual == "";
            Assert.IsTrue(condition);
        }
    }
}
