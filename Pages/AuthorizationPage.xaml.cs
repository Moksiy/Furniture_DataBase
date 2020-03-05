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
            Captcha.Content = Authorisation.CaptchaBuilder();            
        }

        /// <summary>
        /// Войти в учетную запись
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logIn_Click(object sender, RoutedEventArgs e)
        {
            LoginBox.BorderBrush = Brushes.LightGray;
            PasswordBox.BorderBrush = Brushes.LightGray;
            CaptchaText.BorderBrush = Brushes.LightGray;            

            if (Authorisation.LogIn(LoginBox.Text, PasswordBox.Password))
            {
                if (Data.Role != "")
                {
                    if (Captcha.Content.ToString() == CaptchaText.Text.ToUpper())
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
                    else
                    {
                        CaptchaText.BorderBrush = Brushes.Red;
                    }
                }
                else
                {
                    MessageBox.Show("Это что еще за роль у тебя?");
                }
            }
            else
            {
                LoginBox.BorderBrush = Brushes.Red;
                PasswordBox.BorderBrush = Brushes.Red;
            }
            Captcha.Content = Authorisation.CaptchaBuilder();
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegistrationPage());
        }

        /// <summary>
        /// Обновляем капчу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Captcha.Content = Authorisation.CaptchaBuilder();
        }
    }

    public static class Messages
    {
        public static void Except(string error)
        {
            MessageBox.Show(error);
        }
    }
}
