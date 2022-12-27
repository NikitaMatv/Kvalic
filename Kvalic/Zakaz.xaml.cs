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
using System.Windows.Shapes;

namespace Kvalic
{
    /// <summary>
    /// Логика взаимодействия для Zakaz.xaml
    /// </summary>
    public partial class Zakaz : Window
    {
        public Zakaz()
        {
            InitializeComponent();
            ListZakazov.ItemsSource = App.DB.ProductSale.ToList();
            var allTypes = App.DB.Product.ToList();
            allTypes.Insert(0, new Product
            {
                Title = "Все"
            });
            Filtr1.ItemsSource = allTypes;
            Filtr1.SelectedIndex = 0;
            Update();
        }
        private void Update()
        {

            var product = App.DB.ProductSale.ToList();
            if (Filtr1.SelectedIndex > 0)
            {
                var a = Filtr1.SelectedIndex.ToString();
                product = product.Where(p => p.ProductID.ToString().ToLower().Contains(a.ToLower())).ToList();
            }
            ListZakazov.ItemsSource = product.OrderByDescending(x => x.SaleDate).ToList();
        }
        private void Filtr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void Sortir_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
    }
}
