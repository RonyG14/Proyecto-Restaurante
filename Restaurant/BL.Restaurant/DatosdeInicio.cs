using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Restaurant
{
    
    public class DatosdeInicio : CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            var tipo1 = new Tipo();
            tipo1.Descripcion = "Desayuno";
            contexto.Tipos.Add(tipo1);

            var tipo2 = new Tipo();
            tipo2.Descripcion = "Almuerzo";
            contexto.Tipos.Add(tipo2);

            var tipo3 = new Tipo();
            tipo3.Descripcion = "Cena";
            contexto.Tipos.Add(tipo3);

            var produ1 = new Producto();
            produ1.Id = 1;
            produ1.Descripcion = "Baleadas Simples";
            
            contexto.Productos.Add(produ1);

            base.Seed(contexto);
           
        }


    }
}
