using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSalesTaxCalculator.Classes
{
    public class Item // class to hold items (products) for the shopping basket
    {
        public int Id { get; }
        public string Name { get; }
        public string Category { get; }
        public bool Imported { get; }
        public int Amount { get; }
        public double PriceNet { get; }
        public double TaxRate { get; }
        public double Tax { get; }
        public double PriceGross { get; }

        public Item(int id, string name, int amount, double priceNet)
        {
            Methods method = new Methods();
            Id = id;
            Name = name;
            Amount = amount;
            PriceNet = priceNet;
            Category = method.CalculateCategory(name);
            Imported = name.Contains("imported") ? true : false;
            TaxRate = method.CalculateTaxRate(Category, Imported);
            Tax = method.CalculateSalesTax(priceNet, TaxRate);
            PriceGross = priceNet + Tax;
        }
    }
}
