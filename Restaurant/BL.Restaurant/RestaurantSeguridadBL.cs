using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Restaurant
{
    public class RestaurantSeguridadBL
    {
        public bool Autorizar(string Usuario, string Contrasena)
        {
            if (Usuario == "Admin" && Contrasena == "123")
            {
                return true;
            }
            else
            {
                if (Usuario == "User" && Contrasena == "456")
                {
                    return true;

                }
                return false;
            }
        }
    }
}
