using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

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

        // method to calculate sales tax and round up to the nearest 0.05
        public double CalculateSalesTax(double price, double taxRate)
        {
            double tax = price * taxRate;
            double rFactor = 1 / 0.05; // returns 20, the multiplying and dividing factor of rounding
            double taxRounded = Math.Ceiling(tax * rFactor) / rFactor; // rounding up to the nearest 0.05
            return taxRounded;
        }

        // method to display the content of any sample basket or of the new basket
        public string ShowSampleBasket(RichTextBox richTextBox, List<Item> itemsList)
        {
            richTextBox.Document.Blocks.Clear();
            string basketContent = "";
            string row = "";
            foreach (Item item in itemsList)
            {
                row = $"> {item.Amount} {item.Name} at {item.PriceNet.ToString("0.00")}";
                richTextBox.Document.Blocks.Add(new Paragraph(new Run(row)));
                basketContent += row + "\r\n";
            }
            return basketContent;
        }

        // method to check whether content written into and read out of the richTextBox are identical
        public bool CheckRichTextBoxContent(string basketContent, RichTextBox richTextBox)
        {
            string richTextBoxContent = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
            return basketContent == richTextBoxContent;
        }

        // method to calculate the output for a basket, including sales tax
        public string showOutputBasket(ListBox listBox, List<Item> itemsList)
        {
            listBox.Items.Clear();
            string row = "";
            string output = "";

            foreach (Item item in itemsList)
            {
                row = $"> {item.Amount} {item.Name}: {(item.Amount * item.PriceGross).ToString("0.00")}";
                output += row + "\n";
                listBox.Items.Add(row);
            }

            double salesTaxes = itemsList.Sum(item => item.Amount * item.Tax);
            double total = itemsList.Sum(item => item.Amount * item.PriceGross);
            row = $"> Sales Taxes: {salesTaxes.ToString("0.00")}";
            output += row + "\n"; ;
            listBox.Items.Add(row);
            row = $"> Total: {total.ToString("0.00")}";
            output += row + "\n"; ;
            listBox.Items.Add(row);
            return output;
        }


    }
}
