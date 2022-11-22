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
using Market.ADO;

namespace Market320.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }
        private void RegistrationNavigate(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void Authorization(object sender, RoutedEventArgs e)
        {
            MarketEntities db = new MarketEntities();
            if (tbLogin.Text != "" && tbPassword.Text != "")
            {
                var account = db.Account.FirstOrDefault(x => x.Login == tbLogin.Text && x.Password == tbPassword.Text);
                if (account != null)
                {
                    if(account.User.Role.Name == "Admin")
                    {
                        NavigationService.Navigate(new AdminPage());
                    }
                    else
                    {
                        NavigationService.Navigate(new BuyerPage(account));                
                    }
                }
                else
                {
                    MessageBox.Show("Not have user with written login!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Fill login and password please!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
