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
    public partial class Producto : System.Web.UI.Page
    { 
        public List<Imagen> ListUrls { get; set; }
        public int Indice { get; set; } 
        public int IdProd { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            Indice = 0;

            IdProd = int.Parse(Request.QueryString["Id"].ToString());
            var ArtGestion = new ArticuloGestion();
            Articulo ArtMostrar = ArtGestion.Existencia(IdProd);
            if (ArtMostrar == null)
            {
                Response.Redirect("Default.aspx");
            }
            IdProd = ArtMostrar.Id;
            CargarImagenes(IdProd);
            CargarCampos(ArtMostrar);
        }
        #region MetodosMostrarProducto
      
        public void CargarCampos(Articulo artMostrar)
        {
            //llamada a imagen 
            CargarImagenes(artMostrar.Id);
            //post llamada a img..
            TituloProducto.InnerText = artMostrar.Nombre;// inner text =  texto entre etiquetas aper y cierre
            DescripcionProducto.Text = artMostrar.Descripcion;
            MarcaProducto.Text = artMostrar.Marca.Descripcion;
            CategoriaProducto.Text = artMostrar.Categoria.Descripcion;
            PrecioProducto.Text = "$" + artMostrar.Precio.ToString();

        }
        public void CargarImagenes( int id)
        {

            var ImgGestion = new ImagenGestion();   
            ListUrls = ImgGestion.ListByIdArticulo(id);
            if (ListUrls == null)
            {
                ImgProducto.ImageUrl= "https://ih1.redbubble.net/image.2289245086.4528/bg,f8f8f8-flat,750x,075,f-pad,750x1000,f8f8f8.jpg";
            }
            else
            {
                CargarImagen();

            }

        }
        public void CargarImagen()
        {
            try
            {
                ImgProducto.ImageUrl = ListUrls[Indice].UrlImagen;

            }
            catch (Exception)
            {
                //validar funcionamiento
                ImgProducto.ImageUrl = "https://static.wikia.nocookie.net/mitologa/images/a/a3/Imagen_por_defecto.png/revision/latest/thumbnail/width/360/height/360?cb=20150824230838&path-prefix=es";
            }

        }
        protected void BtnPrev_Click(object sender, EventArgs e)
        {
            CargarImagenes(IdProd);
           if(Indice>0)
            {
                Indice--;
                CargarImagen();
            }
            CargarImagen();

        }

        #endregion
        #region ManejoCarrouselFotos
        protected void BtnNext_Click(object sender, EventArgs e)
        {
            CargarImagenes(IdProd);
            if (Indice < (ListUrls.Count() - 1))
            { 
                
                Indice++;
                CargarImagen();

            }
            CargarImagen();

        }
        #endregion
        protected void BtnAddCarrito_Click(object sender, EventArgs e)
        {
            //   Response.Redirect("Default.aspx");
        }
    }
}