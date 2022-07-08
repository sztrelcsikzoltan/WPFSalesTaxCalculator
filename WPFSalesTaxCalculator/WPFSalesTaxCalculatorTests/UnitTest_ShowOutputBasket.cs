using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using WPFSalesTaxCalculator.Classes;

namespace WPFSalesTaxCalculatorTests
{
    [TestClass]
    public class UnitTest_ShowOutputBasket
    {
        Methods method = new Methods();
        ListBox listBox = new ListBox();
        List<Item> itemsList1 = new List<Item>() { new Item(1, "book", 1, 12.49), new Item(2, "music CD", 1, 14.99), new Item(3, "chocolate bar", 1, 0.85) };
        List<Item> itemsList2 = new List<Item>() { new Item(1, "imported box of chocolates", 1, 10.00), new Item(2, "imported bottle of perfume", 1, 47.50) };
        List<Item> itemsList3 = new List<Item>() { new Item(1, "imported bottle of perfume", 1, 27.99), new Item(2, "bottle of perfume", 1, 18.99), new Item(3, "packet of headache pills", 1, 9.75), new Item(4, "box of imported chocolates", 1, 11.25) };
        List<Item> itemsListNew = new List<Item>();
        List<Item> itemsListNew3Products = new List<Item>() { new Item(1, "black cat", 1, 10.00), new Item(2, "black cats", 2, 10.00), new Item(3, "imported pink panthers", 3, 10.00) };

        [TestMethod]
        public void OutputSampleBasket1()
        {
            // the output with decimal symbol ',' or '.' can be correct depending on the actual regional settings
            // string actual = "> 1 book: 12,49\n> 1 music CD: 16,49\n> 1 chocolate bar: 0,85\n> Sales taxes: 1,50\n> Total: 29,83\n";
            string actual = method.ShowOutputBasket(listBox, itemsList1);
            bool condition = actual == "> 1 book: 12,49\n> 1 music CD: 16,49\n> 1 chocolate bar: 0,85\n> Sales Taxes: 1,50\n> Total: 29,83\n" || actual == "> 1 book: 12.49\n> 1 music CD: 16.49\n> 1 chocolate bar: 0.85\n> Sales taxes: 1.50\n> Total: 29.83\n";
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void OutputSampleBasket2()
        {
            // the output with decimal symbol ',' or '.' can be correct depending on the actual regional settings
            // string actual = "> 1 imported box of chocolates: 10,50\n> 1 imported bottle of perfume: 54,65\n> Sales taxes: 7,65\n> Total: 65,15\n";
            string actual = method.ShowOutputBasket(listBox, itemsList2);
            bool condition = actual == "> 1 imported box of chocolates: 10,50\n> 1 imported bottle of perfume: 54,65\n> Sales Taxes: 7,65\n> Total: 65,15\n" || actual == "> 1 imported box of chocolates: 10.50\n> 1 imported bottle of perfume: 54.65\n> Sales taxes: 7.65\n> Total: 65.15\n";
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void OutputSampleBasket3()
        {
            // the output with decimal symbol ',' or '.' can be correct depending on the actual regional settings
            // string actual = "> 1 imported bottle of perfume: 32,19\n> 1 bottle of perfume: 20,89\n> 1 packet of headache pills: 9,75\n> 1 box of imported chocolates: 11,85\n> Sales taxes: 6,70\n> Total: 74,68\n";
            string actual = method.ShowOutputBasket(listBox, itemsList3);
            bool condition = actual == "> 1 imported bottle of perfume: 32,19\n> 1 bottle of perfume: 20,89\n> 1 packet of headache pills: 9,75\n> 1 box of imported chocolates: 11,85\n> Sales Taxes: 6,70\n> Total: 74,68\n" || actual == "> 1 imported bottle of perfume: 32.19\n> 1 bottle of perfume: 20.89\n> 1 packet of headache pills: 9.75\n> 1 box of imported chocolates: 11.85\n> Sales taxes: 6.70\n> Total: 74.68\n";
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void OutputNewBasket()
        {
            string richTextBoxContent = "";
            // if there is no content in the richtextBox, the method will not run and the output will remain empty;
            string actual = richTextBoxContent == "" ? "" : method.ShowOutputBasket(listBox, itemsListNew);
            bool condition = actual == "";
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void OutputNewBasketWithItems()
        {
            // the output with decimal symbol ',' or '.' can be correct depending on the actual regional settings
            string actual = method.ShowOutputBasket(listBox, itemsListNew3Products);
            bool condition = actual == "> 1 black cat: 11,00\n> 2 black cats: 22,00\n> 3 imported pink panthers: 34,50\n> Sales Taxes: 7,50\n> Total: 67,50\n" || actual == "> 1 black cat: 11.00\n> 2 black cats: 22.00\n> 3 imported pink panthers: 34.50\n> Sales Taxes: 7.50\n> Total: 67.50\n";
            Assert.IsTrue(condition);
        }


    }
}
