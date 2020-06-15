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
using System.Collections.ObjectModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ItemsDataGrid.ItemsSource = Items;
        }

        //this is the Constructors for the items with the price and moms
        public class Item
        {
            public decimal ItemPrice { get; set; }
            public decimal MomsRate { get; set; }
        }

        //this is the list that will add items intro the data grid
        private ObservableCollection<Item> Items = new ObservableCollection<Item>();

        //this is used for adding the price and the moms rate to the list 
        private void AddNewItem(decimal itemPrice, decimal momsRate)
        {
            Item item = new Item()
            {
                ItemPrice = itemPrice,
                MomsRate = momsRate
            };

            //here it will add the information to the item list
            Items.Add(item);
        }

        //this is the button for adding items that will take the input in both and use he addnewitem class to get it to the list
        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                decimal itemPrice = Decimal.Parse(ItemPriceInput.Text);
                decimal momsRate = Decimal.Parse(MomsInput.Text) / 100;
                AddNewItem(itemPrice, momsRate);
            }

            //this is used for when the input is not setup right it will show a error message
            catch (Exception)
            {
                MessageBox.Show("Dette er ikke godkendt input");
            }
        }

        //this is the button for calculator everything in the list
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            decimal subtotal = 0;
            decimal total = 0;
            decimal momsAmount = 0;

            //here it takes all the items in the item list and calculator them
            foreach (var item in Items)
            {
                subtotal += item.ItemPrice;
                momsAmount += item.ItemPrice * item.MomsRate;
                total += (item.MomsRate * item.ItemPrice) + item.ItemPrice;
            }

            //this takes the calculated number and add them to the total sum on the xaml 
            Subtotal.Text = String.Format("{0:C}", subtotal);
            MomsAmount.Text = String.Format("{0:C}", momsAmount);
            TotalPrice.Text = String.Format("{0:C}", total);
        }

        //this is the button that clears everything from the list   
        private void Slet_Click(object sender, RoutedEventArgs e)
        {
            Items.Clear();
        }
    }
}
