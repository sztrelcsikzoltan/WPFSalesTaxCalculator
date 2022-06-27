using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSalesTaxCalculator.Classes
{
    public class Methods
    {
        Dictionary<string, string> productByCategory = new Dictionary<string, string>() { { "book", "book" }, { "chocolate", "food" }, { "headache pill", "medical" } };
        // method to determine the category of a product
        public string CalculateCategory(string name)
        {
            string category = productByCategory.FirstOrDefault(d => name.Contains(d.Key)).Value;
            /*
            foreach (var item in productByCategory)
            {
                if (name.Contains(item.Key))
                {
                    category = item.Value;
                    break;
                }
            }
            */
            if (category == null) { category = "other"; }
            return category;
        }

        Dictionary<string, double> categoryByTaxDict = new Dictionary<string, double>() { { "book", 0.00 }, { "food", 0.00 }, { "medical", 0.00 }, { "default", 0.10 } };
        // method to calculate tax rate based on product category and import status
        public double CalculateTaxRate(string category, bool imported)
        {
            double taxRate = categoryByTaxDict.FirstOrDefault(d => d.Key == "default").Value;
            if (categoryByTaxDict.ContainsKey(category))
            {
                taxRate = categoryByTaxDict.FirstOrDefault(d => d.Key == category).Value;
            }
            if (imported) taxRate += 0.05;
            return Math.Floor(taxRate * 100) / 100; // floor to 2 decimal placed due to eventual floating point fractions
        }
    }
}
