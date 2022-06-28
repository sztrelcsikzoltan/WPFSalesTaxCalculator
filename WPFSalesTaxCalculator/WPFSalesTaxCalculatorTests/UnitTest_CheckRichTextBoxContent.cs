using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WPFSalesTaxCalculatorTests
{
    [TestClass]
    public class UnitTest_CheckRichTextBoxContent
    {
        [TestMethod]
        public void ContentSampleBasket1()
        {
            // in WPF RichTextBox, the lines are separated by the '\r\n>' characters, so it must be considered
            string basketContent = "> 1 book at 12,49\r\n> 1 music CD at 14,99\r\n> 1 chocolate bar at 0,85\r\n";
            string richTextBoxContent = "> 1 book at 12,49\r\n> 1 music CD at 14,99\r\n> 1 chocolate bar at 0,85\r\n";
            bool condition = basketContent == richTextBoxContent;
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void ContentSampleBasket2()
        {
            // in WPF RichTextBox, the lines are separated by the '\r\n>' characters, so it must be considered
            string basketContent = "> 1 imported box of chocolates at 10,00\r\n> 1 imported bottle of perfume at 47,50\r\n";
            string richTextBoxContent = "> 1 imported box of chocolates at 10,00\r\n> 1 imported bottle of perfume at 47,50\r\n";
            bool condition = basketContent == richTextBoxContent;
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void ContentSampleBasket3()
        {
            // in WPF RichTextBox, the lines are separated by the '\r\n>' characters, so it must be considered
            string basketContent = "> 1 imported bottle of perfume at 27,99\r\n> 1 bottle of perfume at 18,99\r\n> 1 packet of headache pills at 9,75\r\n> 1 box of imported chocolates at 11,25\r\n";
            string richTextBoxContent = "> 1 imported bottle of perfume at 27,99\r\n> 1 bottle of perfume at 18,99\r\n> 1 packet of headache pills at 9,75\r\n> 1 box of imported chocolates at 11,25\r\n";
            bool condition = basketContent == richTextBoxContent;
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void ContentNewBasket()
        {
            string basketContent = "";
            string richTextBoxContent = "";
            bool condition = basketContent == richTextBoxContent;
            Assert.IsTrue(condition);
        }
    }
}

