using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
   public  class Marca
    {
        public int Id { get; set; }
        [DisplayName("Nombre de Marca")]
        public string Descripcion { get; set; }
        public override string ToString() // Sobrescritura de to string necesaria para determinar que muestra el dvg
        {
            return Descripcion;
        }
    }
}
