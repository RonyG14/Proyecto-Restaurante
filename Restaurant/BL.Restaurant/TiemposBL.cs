using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Restaurant
{
   public  class TiemposBL
    {
        Contexto _contexto;
        public BindingList<Tiempo > ListaTiempos { get; set; }
        public string Descripcion { get; internal set; }

        public TiemposBL()
        {
            _contexto = new Restaurant.Contexto();
            ListaTiempos = new BindingList<Tiempo>(); 
        }
        public BindingList<Tiempo> ObtenerTiempo()
        {
            _contexto.Tiempos.Load();
            ListaTiempos = _contexto.Tiempos.Local.ToBindingList();

            return ListaTiempos; 

    }

    public class Tiempo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
    }
}
