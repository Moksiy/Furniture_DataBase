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
using System.Data.SqlClient;

namespace FurnitureDataBase_WS
{
    /// <summary>
    /// Логика взаимодействия для AddNewFurn.xaml
    /// </summary>
    public partial class AddNewFurn : Page
    {
        public AddNewFurn()
        {
            InitializeComponent();
            GetTypes();
        }

        public List<CharactElement> List = new List<CharactElement>();

        private async void GetTypes()
        {
            SqlConnection connection = new SqlConnection();

            try
            {
                connection.ConnectionString = MainWindow.ConnectionSrting;

                //Открываем подключение
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand();

                //Запрос
                command.CommandText = "SELECT * FROM Type_equipment";

                command.Connection = connection;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Content = dataReader[0].ToString();
                    TypeF.Items.Add(item);
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

        /// <summary>
        /// Назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DirectorPage());
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(Charact.Text)&&
                !String.IsNullOrEmpty(CharactName.Text))
            {
                List.Add(new CharactElement(CharactName.Text, Charact.Text));
                CharactList.Items.Add(CharactName.Text + " - "+ Charact.Text);
                Charact.Text = ""; CharactName.Text = "";
            }
        }

        /// <summary>
        /// Сброс выделения
        /// </summary>
        public void ResetColors()
        {
            Mark.BorderBrush = Brushes.SlateGray;
            NameF.BorderBrush = Brushes.SlateGray;

        }

        /// <summary>
        /// проверка введенных данных
        /// </summary>
        /// <returns></returns>
        public bool Check()
        {
            if(!String.IsNullOrEmpty(Mark.Text)&&
                !String.IsNullOrEmpty(NameF.Text)&&
                !String.IsNullOrEmpty(TypeF.Text)&&
                List.Count() > 0)
                return true;

            return false;
        }

        /// <summary>
        /// Добавление фурнитуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddFurn_Click(object sender, RoutedEventArgs e)
        {
            ResetColors();
            if(Check())
            {
                AddFurniture();
            }
            else
            {
                if (List.Count() < 1)
                    CharactError.Content = "Добавьте характеристики";
                if (String.IsNullOrEmpty(Mark.Text))
                    Mark.BorderBrush = Brushes.Red;
                if (String.IsNullOrEmpty(NameF.Text))
                    NameF.BorderBrush = Brushes.Red;
                if (String.IsNullOrEmpty(TypeF.Text))
                    TypeError.Content = "Выберите тип оборудования";
            }
        }

        //public void JSON()
       // {
            //string a = JsonConvert.SerializeObject(List);
           // MessageBox.Show(a.ToString());
            //List<CharactElement> list = JsonConvert.DeserializeObject<List<CharactElement>>(a);

       // }

        /// <summary>
        /// Добавление в БД
        /// </summary>
        private async void AddFurniture()
        {
            SqlConnection connection = new SqlConnection();

            try
            {
                connection.ConnectionString = MainWindow.ConnectionSrting;

                //Открываем подключение
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand();

                //JSON
                string a = JsonConvert.SerializeObject(List);

                //Запрос
                command.CommandText = "INSERT INTO Equipment VALUES('"+Mark.Text+"','"+TypeF.Text+"','"+a+"')";

                command.Connection = connection;

                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                //В любом случае закрываем подключение
                connection.Close();
                this.NavigationService.Navigate(new DirectorPage());
            }
        }
    }
}
