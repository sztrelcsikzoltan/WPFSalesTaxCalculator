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
    }
}
