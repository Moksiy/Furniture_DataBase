using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FurnitureDataBase_WS
{
    /// <summary>
    /// Класс авторизации
    /// </summary>
    static class Authorisation
    {
        /// <summary>
        /// Метод авторизаци
        /// </summary>
        /// <param name="login">Логин с текстбокса</param>
        /// <param name="password">Пароль с пасвордбокса</param>
        /// <returns></returns>
        public static bool LogIn(string login, string password)
        {
            if (login != "" && password != "")
            {
                GetUser(login, password);
                if (Data.Login != "" && Data.Password != "")
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// Формируем текст каптчи
        /// </summary>
        /// <returns></returns>
        public static string CaptchaBuilder()
        {
            string captcha = default;

            Random rand = new Random();

            for (int i = 0; i < 4; i++)
            {
                captcha += (char)rand.Next('A', 'Z' + 1);
            }

            return captcha;
        }

        public static void GetUser(string log, string pas)
        {
            SqlConnection connection = new SqlConnection();

            try
            {
                connection.ConnectionString = MainWindow.ConnectionSrting;

                //Открываем подключение
                connection.Open();

                SqlCommand command = new SqlCommand();

                //Запрос
                command.CommandText = "SELECT * FROM [Users] WHERE Login = '" + log + "' AND Password = '" + pas + "'";

                command.Connection = connection;

                SqlDataReader dataReader = command.ExecuteReader();

                //Добавляем в список
                while (dataReader.Read())
                {
                    Data.Login = dataReader[0].ToString();
                    Data.Password = dataReader[1].ToString();
                    Data.Role = dataReader[2].ToString();
                    Data.LastName = dataReader[3].ToString();
                    Data.Name = dataReader[4].ToString();
                    Data.Patronum = dataReader[5].ToString();
                }
            }
            catch (SqlException ex)
            {
                Messages.Except(ex.ToString());
            }
            finally
            {
                //В любом случае закрываем подключение
                connection.Close();
            }

        }
    }
}
