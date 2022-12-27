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

namespace Kvalic
{
    /// <summary>
    /// Логика взаимодействия для ProductList.xaml
    /// </summary>
    public partial class ProductList : Page
    {
        public ProductList()
        {
            InitializeComponent();
            ListProduct.ItemsSource = App.DB.Product.ToList();
            var allTypes = App.DB.Manufacturer.ToList();
            allTypes.Insert(0, new Manufacturer
            {
                Name = "Все"
            });
            Filtr.ItemsSource = allTypes;
            Filtr.SelectedIndex = 0;
            Update();
            //https://drive.google.com/file/d/1gjVQmQ84nSsO8mrMHjl6PBUvD1CoKZEg/view?usp=share_link
            //https://drive.google.com/drive/u/0/folders/1_6lpl0zTizhgqaUoIEYmcl2czQLM9Eov
        }
        private void Update()
        {

            var product = App.DB.Product.ToList();
            product = product.Where(p => p.Title.ToString().ToLower().Contains(SearchBox.Text.ToLower())).ToList();
            if (Filtr.SelectedIndex > 0)
            {
                var a = Filtr.SelectedIndex.ToString();
                product = product.Where(p => p.ManufacturerID.ToString().ToLower().Contains(a.ToLower())).ToList();
            }
            if (Sortir.SelectedIndex > 0)
            {
                if (Sortir.SelectedIndex == 1)
                {
                    product = product.OrderBy(x => x.Cost).ToList();
                }
                else if (Sortir.SelectedIndex == 2)
                {
                    product = product.OrderByDescending(x => x.Cost).ToList();
                }
            }
            ListProduct.ItemsSource = product.ToList();
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
        
            var select = ListProduct.SelectedItem as Product;
            NavigationService.Navigate(new ZakazPage(select));

        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
