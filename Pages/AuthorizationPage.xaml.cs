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

namespace FurnitureDataBase_WS
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

        /// <summary>
        /// Войти в учетную запись
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logIn_Click(object sender, RoutedEventArgs e)
        {
            if (Authorisation.LogIn(LoginBox.Text, PasswordBox.Password))
            {
                switch (Data.Role)
                {
                    case "Заказчик":
                        this.NavigationService.Navigate(new CustomerPage());
                        break;

                    case "Мастер":
                        this.NavigationService.Navigate(new MasterPage());
                        break;

                    case "Директор":
                        this.NavigationService.Navigate(new DirectorPage());
                        break;

                    case "Менеджер":
                        this.NavigationService.Navigate(new ManagerPage());
                        break;

                    case "Заместитель директора":
                        this.NavigationService.Navigate(new AssociateDirectorPage());
                        break;
                }
            }
        }
    }
}
