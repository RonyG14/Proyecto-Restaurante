using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Restaurant
{
    
    public class RestaurantSeguridadBL
    {
        Contexto _contexto;

        public RestaurantSeguridadBL()
        {
            _contexto = new Contexto();
        }
    

        public bool Autorizar(string Usuario, string Contrasena)
        {
            var usuarios = _contexto.Usuarios.ToList();

            foreach (var UsuarioDB in usuarios)
            {
                if (Usuario == UsuarioDB.Nombre && Contrasena == UsuarioDB .Contrasena )
                {
                    return true;
                }
            }
            return false;
            }
        }
     public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
    }
    }



