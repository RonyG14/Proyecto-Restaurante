using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Restaurant
{
    public class TipoBL
    {
        Contexto _contexto;
        public BindingList<Tipo> ListadeTipos { get; set; }


        public TipoBL()
        {
            _contexto = new Contexto();
            ListadeTipos = new BindingList<Tipo>();
        }

        public BindingList<Tipo> ObtenerTipos()
        {
            _contexto.Tipos.Load(); //que da la tabla producto cargue los datos
            ListadeTipos = _contexto.Tipos.Local.ToBindingList(); //Transforma los datos de la lista producto hacia el bindingList

            return ListadeTipos;
        }

    }

    public class Tipo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
