using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
namespace TPWebForm_equipo_2
{
    public partial class _Default : Page
    {
        //lista = prop  de esta pagina para accederla en el aspx
        public string ImgAlter { get; set; }
       public List<Articulo> ArticuloList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            var ArtGestion = new ArticuloGestion();
            ArticuloList = ArtGestion.Listado();
            ImgAlter = "https://img.freepik.com/vector-premium/foto-vacia-sombra-pegada-cinta-adhesiva-ilustracion_87543-3824.jpg";


        }


    }
}