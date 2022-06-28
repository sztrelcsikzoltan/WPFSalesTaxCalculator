using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFSalesTaxCalculator.Classes;

namespace WPFSalesTaxCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Item> itemsList = new List<Item>();
        List<Item> itemsList1 = new List<Item>() { new Item(1, "book", 1, 12.49), new Item(2, "music CD", 1, 14.99), new Item(3, "chocolate bar", 1, 0.85) };
        List<Item> itemsList2 = new List<Item>() { new Item(1, "imported box of chocolates", 1, 10.00), new Item(2, "imported bottle of perfume", 1, 47.50) };
        List<Item> itemsList3 = new List<Item>() { new Item(1, "imported bottle of perfume", 1, 27.99), new Item(1, "bottle of parfume", 1, 18.99), new Item(2, "packet of headache pills", 1, 9.75), new Item(3, "box of imported chocolates", 1, 11.25) };
        List<Item> itemsListNew = new List<Item>();
        Methods method = new Methods();
        bool contentChanged = false;
        string output = "";
        public MainWindow()
        {
            InitializeComponent();

            textBox.Text = "Welcome to itemis Sales Tax Calculator!\n Please select a sample basket or simply start entering the product(s) for your basket.";
        }

        public void button_inputBasket1_Click(object sender, RoutedEventArgs e)
        {
            itemsList = itemsList1;
            output = "";
            string basketContent = method.ShowSampleBasket(richTextBox, itemsList);
            // check whether content written into and read out of the richtextBox are identical
            // bool contentOK = method.CheckRichTextBoxContent(basketContent, richTextBox);
        }

        public void button_inputBasket2_Click(object sender, RoutedEventArgs e)
        {
            itemsList = itemsList2;
            output = "";
            string basketContent = method.ShowSampleBasket(richTextBox, itemsList);
            // check whether content written into and read out of the richtextBox are identical
            // bool contentOK = method.CheckRichTextBoxContent(basketContent, richTextBox);
        }

        public void button_inputBasket3_Click(object sender, RoutedEventArgs e)
        {
            itemsList = itemsList3;
            output = "";
            string basketContent = method.ShowSampleBasket(richTextBox, itemsList);
            // check whether content written into and read out of the richtextBox are identical
            // bool contentOK = method.CheckRichTextBoxContent(basketContent, richTextBox);
        }

        private void button_inputNewBasket_Click(object sender, RoutedEventArgs e)
        {
            itemsList = itemsListNew;
            richTextBox.Document.Blocks.Clear();
            richTextBox.Focus();
            output = "";
            string basketContent = method.ShowSampleBasket(richTextBox, itemsList);
            // check whether content written into and read out of the richtextBox are identical
            // bool contentOK = method.CheckRichTextBoxContent(basketContent, richTextBox);
        }

        private void button_outputBasket_Click(object sender, RoutedEventArgs e)
        {
            string richtextBoxContent = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
            string[] rows = richtextBoxContent.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            // Create output in itemsList based on the content of richTextBox:

            // return if richTextBoxContent did not change and output in listBox already available
            if (contentChanged == false && output != "") { return; }

            if (rows.Length <= 1 || richtextBoxContent.Replace("\r\n", "").Replace(" ", "") == "")
            {
                textBox.Text = "Please enter a least 1 item before calculating the result!\nOr simply use a sample basket.";
                // MessageBox.Show("Please enter a least 1 item before calculating the result!\nOr simply use a sample basket.");
                return;
            }

            List<Item> itemsList0 = new List<Item>(); // use a temporary list to store items, because the loop can be broken; once completed, add stored values into itemsList
            int counter = 1;
            foreach (var row in rows)
            {
                if (counter == rows.Length) { break; } // stop before last row (the last row is empty in richTextBox)
                if (row == "") { continue; } // skip eventual empty row)
                string row1 = row.Replace(">", "").Replace("<", "");
                row1 = row1.Replace(" at ", " ");
                row1 = System.Text.RegularExpressions.Regex.Replace(row1, @"\s+", " ").Trim(); // remove unnecessary spaces
                string[] parts = row1.Split(' ');

                if (parts.Length < 3) // 3 parts are required: amount, name and price
                {
                    textBox.Text = $"Missing information for item {counter}. Please add Amount, Name and Price (separated by space).";
                    richTextBox.Focus();
                    return;
                }

                bool isInteger = int.TryParse(parts[0], out int result1);
                if (!isInteger)
                {
                    textBox.Text = $"The amount '{parts[0]}' for item {counter} is incorrect. It must be a whole number. Please modify!";
                    richTextBox.Focus();
                    return;
                }

                int amount = result1;
                if (amount < 1)
                {
                    textBox.Text = $"The amount '{parts[0]}' for item {counter} is incorrect. It must be 1 or more units. Please modify!";
                    richTextBox.Focus();
                    return;
                }

                string name = ""; // add individual words of the name (at least 1 word)
                for (int i = 1; i < parts.Length - 1; i++)
                {
                    if (i > 1) { name += " "; }
                    name += parts[i];
                }

                bool isDouble = double.TryParse(parts[parts.Length - 1], out double result2); // the last part is the price
                if (!isDouble)
                {
                    textBox.Text = $"The price '{parts[parts.Length - 1]}' for item {counter} is incorrect. Please modify!";
                    return;
                }


                double priceNet = result2;
                if (priceNet <= 0)
                {
                    textBox.Text = $"The price '{parts[parts.Length - 1]}' for item {counter} is incorrect. It must more than zero. Please modify!";
                    return;
                }

                itemsList0.Add(new Item(counter, name, amount, priceNet));
                counter++;
            }
        }
        private void richTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            contentChanged = true;
        }

    }
}
