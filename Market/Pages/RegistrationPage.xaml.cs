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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void Reverse(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Registration(object sender, RoutedEventArgs e)
        {
            MarketEntities db = new MarketEntities(); 

            if (tbLogin.Text != "" && tbPassword.Text != "" && tbName.Text != "" && tbRole.Text != "")
            {
                var user = new User
                {
                    Name = tbName.Text,
                    Role_Id = Convert.ToInt32(tbRole.Text)
                };
                var account = new Account
                {
                    Login = tbLogin.Text,
                    Password = tbPassword.Text,
                };

                user.Account.Add(account);
                db.User.Add(user);
                db.Account.Add(account);
                db.SaveChanges();
                MessageBox.Show("Registration success!");
            }
        }
    }
}
