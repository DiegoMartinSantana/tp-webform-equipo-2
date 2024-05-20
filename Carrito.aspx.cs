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
            if (Request.QueryString["IdElim"] != null)
            {
                int id = int.Parse(Request.QueryString["IdElim"]);
                CarritoList = (List<Articulo>)Session["ListaProductosCarrito"];

                Articulo art = CarritoList.Find(a => a.Id == id);
                CarritoList.Remove(art);
                Session.Add("ListaProductosCarrito", CarritoList);


            }

            CarritoList = (List<Articulo>)Session["ListaProductosCarrito"];
            ListaOriginal = (List<Articulo>)Session["ListaProductos"];

            if (!IsPostBack)
            {
                // Calcular el total a pagar
                decimal total = 0;
                if (CarritoList != null)
                {
                    foreach (var art in CarritoList)
                    {
                        total += art.Precio;
                    }
                }
                lblTotal.InnerText = $"Total: ${total}";
            }
        }

        protected void btnVaciar_Click(object sender, EventArgs e)
        {
            CarritoList = new List<Articulo>();
            Session.Add("ListaProductosCarrito", CarritoList);
            Response.Redirect("Default.aspx", false);
        }

       
    }
}

