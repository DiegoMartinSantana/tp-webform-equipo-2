using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWebForm_equipo_2
{
    public partial class SiteMaster : MasterPage
    {
        List<Articulo> cantProdList;
       
        public int cantProductos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ListaProductosCarrito"] != null)
            {
            cantProdList = (List<Articulo>)Session["ListaProductosCarrito"];
            cantProductos += cantProdList.Count;
            lblCarrito.Text= cantProductos.ToString();
            } else
            {
                lblCarrito.Text = "0";
            }
        }

        
    }
}