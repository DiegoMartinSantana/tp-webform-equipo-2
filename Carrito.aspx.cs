using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TPWebForm_equipo_2
{
    public partial class Carrito : System.Web.UI.Page
    {
        public List<Articulo> CarritoList { get; set; }
        public List<Articulo> ListaOriginal { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            CarritoList = (List<Articulo>)Session["ListaProductosCarrito"];
            ListaOriginal = (List<Articulo>)Session["ListaProductos"];
            
        }

        protected void btnVaciar_Click(object sender, EventArgs e)
        {
            CarritoList = new List<Articulo>();
            Session.Add("ListaProductosCarrito", CarritoList);
            Response.Redirect("Default.aspx", false);
        }

        protected void btnVaciar_Click1(object sender, EventArgs e)
        {
            CarritoList = new List<Articulo>();
            Session.Add("ListaProductosCarrito", CarritoList);
            Response.Redirect("Default.aspx", false);
        }
    }


}
