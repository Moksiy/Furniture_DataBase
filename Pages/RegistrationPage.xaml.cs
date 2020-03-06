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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
            UserImage.Source = new BitmapImage(new Uri("/Image/defImage.jpg", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
        }

        /// <summary>
        /// Окно входа в учетную запись
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logIn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AuthorizationPage());
        }

        /// <summary>
        /// Зарегистрироваться
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            bool isEmpt = default;

            if (Login.Text == "")
            {
                Login.BorderBrush = Brushes.Red;
                isEmpt = true;
            }
            else
                Login.BorderBrush = Brushes.LightGray;
            if (Password.Password == "")
            {
                Password.BorderBrush = Brushes.Red;
                isEmpt = true;
            }
            else
                Password.BorderBrush = Brushes.LightGray;
            if (Password2.Password == "")
            {
                Password2.BorderBrush = Brushes.Red;
                isEmpt = true;
            }
            else
                Password2.BorderBrush = Brushes.LightGray;
            if (LastName.Text == "")
            {
                LastName.BorderBrush = Brushes.Red;
                isEmpt = true;
            }
            else
                LastName.BorderBrush = Brushes.LightGray;
            if (FirstName.Text == "")
            {
                FirstName.BorderBrush = Brushes.Red;
                isEmpt = true;
            }
            else
                FirstName.BorderBrush = Brushes.LightGray;
            if (Patronum.Text == "")
            {
                Patronum.BorderBrush = Brushes.Red;
                isEmpt = true;
            }
            else
                Patronum.BorderBrush = Brushes.LightGray;

            string error = PasswordCheck.passwordCheck(Password.Password, Password2.Password);

            if (String.IsNullOrEmpty(error) && !isEmpt)
            {
                //регистрируем
                string errorText = RegUser.RegistrationUser(Login.Text, Password.Password, LastName.Text, FirstName.Text, Patronum.Text);

                //ВЫводим текст ошибки если она есть
                if (!String.IsNullOrEmpty(errorText))
                    MessageBox.Show(errorText);
                //Если ошибок нет, то переходим на страницу юзера
                else
                    this.NavigationService.Navigate(new CustomerPage());
            }
            else
            {
                //Выводим текст ошибки
                MessageBox.Show(error);
            }

            isEmpt = false;
        }

        /// <summary>
        /// Выбор фото
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseImage_Click(object sender, RoutedEventArgs e)
        {
            DialogWindow.OpenFileDialog();
            if(DialogWindow.FilePath != null)
                this.UserImage.Source = new BitmapImage(new Uri(DialogWindow.FilePath, UriKind.Relative)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
        }
    }
}
