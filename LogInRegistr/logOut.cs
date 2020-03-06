using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureDataBase_WS
{
    public static class logOutUser
    {
        public static void logout()
        {
            Data.LastName = "";
            Data.Login = "";
            Data.Name = "";
            Data.Password = "";
            Data.Patronum = "";
            Data.Role = "";
        }
    }
}
