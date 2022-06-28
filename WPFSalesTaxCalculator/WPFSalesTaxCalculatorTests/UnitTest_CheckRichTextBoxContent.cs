using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;
using WPFSalesTaxCalculator.Classes;

namespace WPFSalesTaxCalculatorTests
{
    [TestClass]
    public class UnitTest_CheckRichTextBoxContent
    {
        Methods method = new Methods();
        RichTextBox richTextBox = new RichTextBox();
        List<Item> itemsList1 = new List<Item>() { new Item(1, "book", 1, 12.49), new Item(2, "music CD", 1, 14.99), new Item(3, "chocolate bar", 1, 0.85) };
        List<Item> itemsList2 = new List<Item>() { new Item(1, "imported box of chocolates", 1, 10.00), new Item(2, "imported bottle of perfume", 1, 47.50) };
        List<Item> itemsList3 = new List<Item>() { new Item(1, "imported bottle of perfume", 1, 27.99), new Item(1, "bottle of perfume", 1, 18.99), new Item(2, "packet of headache pills", 1, 9.75), new Item(3, "box of imported chocolates", 1, 11.25) };
        List<Item> itemsListNew = new List<Item>();

        [TestMethod]
        public void ContentSampleBasket1()
        {
            // in WPF RichTextBox, the lines are separated by the '\r\n>' characters, so it must be considered
            // string basketContent = "> 1 book at 12,49\r\n> 1 music CD at 14,99\r\n> 1 chocolate bar at 0,85\r\n";
            // string richTextBoxContent = "> 1 book at 12,49\r\n> 1 music CD at 14,99\r\n> 1 chocolate bar at 0,85\r\n";
            string basketContent = method.ShowSampleBasket(richTextBox, itemsList1); // data written into richTextBox
            string richTextBoxContent = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text; // data read out from richTextBox
            bool condition = basketContent == richTextBoxContent;
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void ContentSampleBasket2()
        {
            // in WPF RichTextBox, the lines are separated by the '\r\n>' characters, so it must be considered
            // string basketContent = "> 1 imported box of chocolates at 10,00\r\n> 1 imported bottle of perfume at 47,50\r\n";
            // string richTextBoxContent = "> 1 imported box of chocolates at 10,00\r\n> 1 imported bottle of perfume at 47,50\r\n";
            string basketContent = method.ShowSampleBasket(richTextBox, itemsList2); // data written into richTextBox
            string richTextBoxContent = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text; // data read out from richTextBox
            bool condition = basketContent == richTextBoxContent;
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void ContentSampleBasket3()
        {
            // in WPF RichTextBox, the lines are separated by the '\r\n>' characters, so it must be considered
            // string basketContent = "> 1 imported bottle of perfume at 27,99\r\n> 1 bottle of perfume at 18,99\r\n> 1 packet of headache pills at 9,75\r\n> 1 box of imported chocolates at 11,25\r\n";
            // string richTextBoxContent = "> 1 imported bottle of perfume at 27,99\r\n> 1 bottle of perfume at 18,99\r\n> 1 packet of headache pills at 9,75\r\n> 1 box of imported chocolates at 11,25\r\n";
            string basketContent = method.ShowSampleBasket(richTextBox, itemsList3); // data written into richTextBox
            string richTextBoxContent = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text; // data read out from richTextBox
            bool condition = basketContent == richTextBoxContent;
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void ContentNewBasket()
        {
            // string basketContent = "";
            // string richTextBoxContent = "";
            string basketContent = method.ShowSampleBasket(richTextBox, itemsListNew); // data written into richTextBox
            string richTextBoxContent = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text; // data read out from richTextBox
            bool condition = basketContent == richTextBoxContent;
            Assert.IsTrue(condition);
        }
    }
}

