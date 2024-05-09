using ABMProductos;
using Microsoft.Ajax.Utilities;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace TPWebForm_equipo_2
{
    public partial class _Default : Page
    {
        //lista = prop  de esta pagina para accederla en el aspx
      
       public List<Articulo> ArticuloList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            var ArtGestion = new ArticuloGestion();
           ArticuloList = ArtGestion.Listado();



        }
    }
}