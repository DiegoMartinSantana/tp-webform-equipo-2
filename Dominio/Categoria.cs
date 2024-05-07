using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMProductos
{
   public  class Categoria
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        
        //sobrescritura de to string necesaria para determinar que muestra el dvg
        public override string ToString()
        {
            return Descripcion;
        }

    }
}
