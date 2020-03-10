using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL.Restaurant
{
    public class ProductosBL
    {
        Contexto _contexto;//Variable Global


        public BindingList<Producto> ListaProductos { get; set; }


        public ProductosBL()
        {
            _contexto = new Contexto();
            ListaProductos = new BindingList<Producto>();

        }


        public BindingList<Producto> ObtenerProductos()
        {
            _contexto.Productos.Load(); //que da la tabla producto cargue los datos
            ListaProductos = _contexto.Productos.Local.ToBindingList(); //Transforma los datos de la lista producto hacia el bindingList

            return ListaProductos;
        }

        public Resultado  GuardarProducto(Producto producto)
        {
            var resultado = Validar(producto);
            if(resultado.Exitoso == false)
            {
                return resultado;
            }
            _contexto.SaveChanges();  // el entity se encarga de hacer el resto de los cambiios

            resultado.Exitoso = true;
            return resultado;
        }
        public void AgregarProducto()
        {
            var nuevoProducto = new Producto();
            ListaProductos.Add(nuevoProducto);

        }
        public bool EliminarProducto(int id)
        {
            foreach (var producto in ListaProductos)
            {
                if (producto.Id == id)
                {
                    ListaProductos.Remove(producto);
                    _contexto.SaveChanges();
                    return true;
                }
            }


            return false;
        }
        private Resultado Validar(Producto producto)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (string.IsNullOrEmpty(producto.Descripcion) == true)
            {
                resultado.Mensaje = "Ingrese una Descripcion";
                resultado.Exitoso = false;
            }

            if (producto.Cantidad <= 0)
            {
                resultado.Mensaje = " La Cantidad Debe Ser Mayor que Cero(0)";
                resultado.Exitoso = false;
            }

            if (producto.Precio <= 0)
            {
                resultado.Mensaje = "El Precio Debe Ser Mayor que Cero(0)";
                resultado.Exitoso = false;
            }


            if (producto.Tipo ==null)
            {
                resultado.Mensaje = "El Tipo No Puede Estar Vacio";
                resultado.Exitoso = false;
            }
            return resultado;
        }
    }

    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public string Tipo { get; set; }
        public bool Activo { get; set; }
    }

    public class Resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
}
}
