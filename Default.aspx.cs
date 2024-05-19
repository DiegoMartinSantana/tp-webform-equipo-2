using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using System.Collections;
namespace TPWebForm_equipo_2
{
    public partial class Default : Page
    {
        //lista = prop  de esta pagina para accederla en el aspx
        public List<Articulo> ArticuloList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            var ArtGestion = new ArticuloGestion();
            if (!IsPostBack)
            {
                Session.Add("ListaProductos", ArtGestion.Listado());

                ArticuloList = (List<Articulo>)Session["ListaProductos"];
            }

            ArticuloList = (List<Articulo>)Session["ListaProductos"];


        }

        protected void BtnFiltrarByNombre_Click(object sender, EventArgs e)
        {
            List<Articulo> Lista = new List<Articulo>();
            ArticuloGestion ArtGestion = new ArticuloGestion();

            // Busqueda por Nombre, Marca o Categoria.

            if (TxtFiltro.Text.Length > 3)
            {
                Lista = ArtGestion.Listado().FindAll(x => x.Nombre.ToUpper().Contains(TxtFiltro.Text.ToUpper()) || x.Marca.Descripcion.ToUpper().Contains(TxtFiltro.Text.ToUpper()) || x.Categoria.Descripcion.ToUpper().Contains(TxtFiltro.Text.ToUpper()));

            }
            else
            {
                Lista = ArtGestion.Listado();
            }

            Session.Add("ListaProductos", Lista);
            ArticuloList = Lista;
        }
    }
}