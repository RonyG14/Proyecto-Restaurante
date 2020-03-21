using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BL.Restaurant
{
    public class CategoriasBL
    {
          
        Contexto _contexto;
        public BindingList<Categoria> ListaCategorias { get; set; }
        public string Descripcion { get; internal set; }

        public CategoriasBL()
        {
            _contexto = new Restaurant.Contexto();
            ListaCategorias = new BindingList<Categoria>();
        }
        public BindingList<Categoria> ObtenerCategorias()
        {
            _contexto.Categorias.Load();
            ListaCategorias = _contexto.Categorias.Local.ToBindingList();

            return ListaCategorias;

        }

    }

    public class Categoria
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
