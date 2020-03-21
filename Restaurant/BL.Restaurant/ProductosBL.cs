﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BL.Restaurant.TiemposBL;

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

        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }

        public Resultado GuardarProducto(Producto producto)
        {
            var resultado = Validar(producto);
            if (resultado.Exitoso == false)
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

            if (producto == null)
            {
                resultado.Mensaje = "Agregue un producto";
                resultado.Exitoso = false;


                return resultado;

            }

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


    

            if (producto.CategoriaId == 0)
            {
                resultado.Mensaje = "Seleccione una Categoria de Comida";
                resultado.Exitoso = false;
            }


               if (producto.TiempoId == 0)
            {
                resultado.Mensaje = "Seleccione un Tiempo de Comida";
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
            public int Existencia { get; set; }

            public int TiempoId { get; set; }
            public Tiempo Tiempo { get; set; }
            public int CategoriaId { get; set; }
            public Categoria Categoria { get; set; }
            public byte[] Foto { get; set; }
            public bool Activo { get; set; }
    
            


        }

        public class Resultado
        {
            public bool Exitoso { get; set; }
            public string Mensaje { get; set; }
        }
    }

