using System;
using System.Collections.Generic;
using System.Data.Common;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Market.ADO;

namespace Market320.Pages
{
    /// <summary>
    /// Логика взаимодействия для BuyerPage.xaml
    /// </summary>
    public partial class BuyerPage : Page
    {
        private Account _acc;
        private List<Basket> _basket = new List<Basket>();
        private List<Product> _products = new List<Product>();
        public BuyerPage(Account acc)
        {
            InitializeComponent();
            ProductList.ItemsSource = App.Connection.Product.ToList();
            _acc = acc;
            _basket = App.Connection.Basket.Where(x => x.User_Id == _acc.User_Id).ToList();
            foreach (var prod in _basket)
            {
                _products.Add(App.Connection.Product.Where(x => x.Product_Id == prod.Product_Id).FirstOrDefault());
            }
            BasketList.ItemsSource = _products;
        }

        private void Select(object sender, SelectionChangedEventArgs e)
        {
            var product = ProductList.SelectedItem as Product;

            var newBasket = new Basket
            {
                User_Id = _acc.User_Id,
                Product_Id = product.Product_Id
            };
            App.Connection.Basket.Add(newBasket);
            App.Connection.SaveChanges();

            _products.Add(product);
            BasketList.Items.Refresh();
        }
    }
}
