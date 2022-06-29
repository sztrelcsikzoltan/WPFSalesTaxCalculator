using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using WPFSalesTaxCalculator.Classes;

namespace WPFSalesTaxCalculatorTests
{
    [TestClass]
    public class UnitTest_ShowSampleBasket
    {
        Methods method = new Methods();
        RichTextBox richTextBox = new RichTextBox();
        List<Item> itemsList1 = new List<Item>() { new Item(1, "book", 1, 12.49), new Item(2, "music CD", 1, 14.99), new Item(3, "chocolate bar", 1, 0.85) };
        List<Item> itemsList2 = new List<Item>() { new Item(1, "imported box of chocolates", 1, 10.00), new Item(2, "imported bottle of perfume", 1, 47.50) };
        List<Item> itemsList3 = new List<Item>() { new Item(1, "imported bottle of perfume", 1, 27.99), new Item(2, "bottle of perfume", 1, 18.99), new Item(3, "packet of headache pills", 1, 9.75), new Item(4, "box of imported chocolates", 1, 11.25) };
        List<Item> itemsListNew = new List<Item>();

        [TestMethod]
        public void ContentSampleBasket1()
        {
            // in WPF RichTextBox, the lines are separated by the '\r\n>' characters, so it must be considered
            // also, the content with decimal symbol ',' or '.' can be correct depending on the actual regional settings
            // string actual = "> 1 book at 12,49\r\n> 1 music CD at 14,99\r\n> 1 chocolate bar at 0,85\r\n";
            string actual = method.ShowSampleBasket(richTextBox, itemsList1);
            bool condition = actual == "> 1 book at 12,49\r\n> 1 music CD at 14,99\r\n> 1 chocolate bar at 0,85\r\n" || actual == "> 1 book at 12.49\r\n> 1 music CD at 14.99\r\n> 1 chocolate bar at 0.85\r\n";
            Assert.IsTrue(condition);
        }
         
        [TestMethod]
        public void ContentSampleBasket2()
        {
            // in WPF RichTextBox, the lines are separated by the '\r\n>' characters, so it must be considered
            // also, the content with decimal symbol ',' or '.' can be correct depending on the actual regional settings
            // string actual = "> 1 imported box of chocolates at 10,00\r\n> 1 imported bottle of parfume at 47,50\r\n";
            string actual = method.ShowSampleBasket(richTextBox, itemsList2);
            bool condition = actual == "> 1 imported box of chocolates at 10,00\r\n> 1 imported bottle of perfume at 47,50\r\n" || actual == "> 1 imported box of chocolates at 10,00\r\n> 1 imported bottle of perfume at 47,50\r\n";
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void ContentSampleBasket3()
        {
            // in WPF RichTextBox, the lines are separated by the '\r\n>' characters, so it must be considered
            // also, the content with decimal symbol ',' or '.' can be correct depending on the actual regional settings
            // string actual = "> 1 imported bottle of parfume at 27,99\r\n> 1 bottle of parfume at 18,99\r\n> 1 packet of headache pills at 9,75\r\n> 1 box of imported chocolates at 11,25\r\n";
            string actual = method.ShowSampleBasket(richTextBox, itemsList3);
            bool condition = actual == "> 1 imported bottle of perfume at 27,99\r\n> 1 bottle of perfume at 18,99\r\n> 1 packet of headache pills at 9,75\r\n> 1 box of imported chocolates at 11,25\r\n" || actual == "> 1 imported bottle of perfume at 27.99\r\n > 1 bottle of perfume at 18.99\r\n > 1 packet of headache pills at 9.75\r\n > 1 box of imported chocolates at 11.25\r\n";
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void ContentNewBasket()
        {
            // string actual = "";
            string actual = method.ShowSampleBasket(richTextBox, itemsListNew);
            bool condition = actual == "";
            Assert.IsTrue(condition);
        }
    }
}
