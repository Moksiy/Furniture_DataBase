using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureDataBase_WS
{
    public static class PasswordCheck
    {
        /// <summary>
        /// Проверяем пароль на безопасность
        /// </summary>
        /// <param name="pass1">Пароль</param>
        /// <param name="pass2">Пароль повторный</param>
        /// <returns></returns>
        /*
         При регистрации пароль должен отвечать следующим
         требованиям:
        • должен содержать от 6 до 18 символов,
        • не должно быть 3 и более подряд идущих одинаковых символа,
        • должны встречаться цифры,
        • минимум 1 символ из набора: * & { } | +.
             */
        public static string passwordCheck(string pass1, string pass2)
        {            
            string error = default;

            bool hasNums = default;

            bool hasRepeats = default;

            //Проверка на совпадение паролей
            if (pass1 != pass2)
                return "Введеные пароли не совпадают\n";

            //Проверка на минимальную длину пароля
            if (pass1.Length < 6)
                error+= "Пароль должен содержать более 6 символов\n";

            //Проверка на максимальную длину пароля
            if (pass1.Length > 18)
                error+= "Пароль должен содержать не более 18 символов\n";

            //Проверка на содержание в пароле спец символов
            if (!pass1.Contains("*") || !pass1.Contains("&") || !pass1.Contains("{") || !pass1.Contains("}") || !pass1.Contains("|") || pass1.Contains("+"))
                error+= "Пароль должен содержать минимум 1 символ из набора: * & { } | +\n";

            //Проверка на содержание цифр
            foreach(var c in pass1)
            {
                if (Char.IsDigit(c))
                    hasNums = true;
            }
            if(!hasNums)
                error+= "Пароль должен содержать цифры";

            //Проверка на повторение символов
            int i = 0;
            char s = default;
            foreach(var c in pass1)
            {
                if (i >= 3)
                    hasRepeats = true;
                if (c == s)
                    i++;
                else i = 0;
                s = c;
            }
            if (hasRepeats)
                error += "не должно быть 3 и более подряд идущих одинаковых символа";

            return error;
        }
    }
}
