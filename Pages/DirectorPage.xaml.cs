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
using System.Data.SqlClient;
using Newtonsoft.Json;

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
            GetEquip();
        }

        /// <summary>
        /// Выход из учетной записи
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"></param>
        private void logOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Вы уверены, что хотите выйти из учетной записи?", "Выход из учетной записи", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                logOutUser.logout();

                //Переход на страницу авторизации
                this.NavigationService.Navigate(new AuthorizationPage());
            }            
        }

        private async void GetEquip()
        {
            SqlConnection connection = new SqlConnection();

            try
            {
                connection.ConnectionString = MainWindow.ConnectionSrting;

                //Открываем подключение
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand();

                //Запрос
                command.CommandText = "SELECT * FROM Equipment";

                command.Connection = connection;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    List<CharactElement> list = JsonConvert.DeserializeObject<List<CharactElement>>(dataReader[2].ToString());
                    string charact = default;
                    foreach(var item in list)
                    {
                        charact += item.Name + " - " + item.Charact + "\n";
                    }
                    LIST.Items.Add(new FurnitureElement(dataReader[0].ToString(), dataReader[1].ToString(), charact));
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                //В любом случае закрываем подключение
                connection.Close();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddNewFurn());
        }
    }
}
