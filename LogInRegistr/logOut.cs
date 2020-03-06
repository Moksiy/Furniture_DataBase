using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureDataBase_WS
{
    public static class logOut
    {
        public static void logoutUser()
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
