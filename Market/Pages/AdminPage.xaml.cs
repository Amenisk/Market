using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using Market.ADO;

namespace Market320.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public byte[] Image { get; set; }
        public AdminPage()
        {
            InitializeComponent();
        }

        private void Select(object sender, RoutedEventArgs e)
        {
            try
            {
                var BtnSelect = sender as Button;
                OpenFileDialog dialog = new OpenFileDialog();
                if(dialog.ShowDialog() != null)
                {
                    Image = File.ReadAllBytes(dialog.FileName);
                    BtnSelect.Background = Brushes.Green;
                }
            }
            catch
            {
                MessageBox.Show("Only photo!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if(Image != null && tbName.Text != "")
            {
                MarketEntities db = new MarketEntities();
                Product NewProduct = new Product()
                {
                    Name = tbName.Text,
                    Image = Image
                };

                db.Product.Add(NewProduct);
                db.SaveChanges();
            }
            

        }
    }
}
