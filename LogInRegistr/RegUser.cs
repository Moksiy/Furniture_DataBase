using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FurnitureDataBase_WS
{
    public static class RegUser
    {
        public static string RegistrationUser(string login, string password, string lastname, string firstname, string patronum)
        {
            string error = default;

            SqlConnection connection = new SqlConnection();

            try
            {
                connection.ConnectionString = MainWindow.ConnectionSrting;

                //Открываем подключение
                connection.Open();

                SqlCommand command = new SqlCommand();

                //Запрос
                command.CommandText = "INSERT INTO Users VALUES('"+login+"','"+password+
                    "','Заказчик','"+lastname+"','"+firstname+"','"+patronum+"', 'NULL')";

                command.Connection = connection;

                SqlDataReader dataReader = command.ExecuteReader();
            }
            catch (SqlException ex)
            {
                //Возвращаем ошибку
                error = ex.ToString();
            }
            finally
            {
                //В любом случае закрываем подключение
                connection.Close();
            }
            return error;
        }

        /// <summary>
        /// Проверка на существавание логина 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public static bool IsContains(string login)
        {
            SqlConnection connection = new SqlConnection();

            bool isContain = default;

            try
            {                
                connection.ConnectionString = MainWindow.ConnectionSrting;

                //Открываем подключение
                connection.Open();

                SqlCommand command = new SqlCommand();

                //Запрос
                command.CommandText = "SELECT * FROM [Users] WHERE Login = '" + login + "'";

                command.Connection = connection;

                SqlDataReader dataReader = command.ExecuteReader();

                string loginCheck = default;

                while (dataReader.Read())
                {
                    loginCheck = dataReader[0].ToString();
                }

                if (!String.IsNullOrEmpty(loginCheck))
                    isContain = true;
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                //В любом случае закрываем подключение
                connection.Close();
            }

            return isContain;
        }
    }
}
