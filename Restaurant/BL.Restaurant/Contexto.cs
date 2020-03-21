using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BL.Restaurant.TiemposBL;

namespace BL.Restaurant
{
    public class Contexto : DbContext 
    {
        public Contexto() : base("Menu")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer(new DatosdeInicio()); //Agrega datos de inicio a la base de Datos despues de eliminar 
        }



        public DbSet<Producto> Productos { get; set; }
        public DbSet <Tiempo> Tiempos{ get; set; }
        public DbSet <Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet <Factura> Facturas { get; set; }
    }

}
