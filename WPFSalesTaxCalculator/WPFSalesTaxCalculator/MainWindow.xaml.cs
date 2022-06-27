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
        bool contentChanged = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void richTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            contentChanged = true;
        }
    }
}
