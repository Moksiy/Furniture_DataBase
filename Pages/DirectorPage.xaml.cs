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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FurnitureDataBase_WS
{
    /// <summary>
    /// Логика взаимодействия для DirectorPage.xaml
    /// </summary>
    public partial class DirectorPage : Page
    {
        public DirectorPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Выход из учетной записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logOut_Click(object sender, RoutedEventArgs e)
        {
            logOutUser.logout();

            //Переход на страницу авторизации
            this.NavigationService.Navigate(new AuthorizationPage());
        }


    }
}
