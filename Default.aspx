<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWebForm_equipo_2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--------------------CAROUSEL--------------------%>

    <div id="carouselExample" class="carousel carousel-dark slide ">
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="https://i.ibb.co/MRKCydk/carousel-1.jpg" class="d-block w-100" alt="Image Carrousel">
            </div>
            <div class="carousel-item">
                <img src="https://i.ibb.co/mcZ550J/carousel-2.jpg" class="d-block w-100" alt="Image Carrousel">
            </div>
            <div class="carousel-item">
                <img src="https://i.ibb.co/L8B0Bp4/carousel-3.jpg" class="d-block w-100" alt="Image Carrousel">
            </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>

    <%--------------------CARDS DE ARTICULOS--------------------%>

    <main>
         <section class=" row mb-3 row-cols-1 text-center" id="cardsArticulos" style="padding-top:30px" aria-labelledby="gettingStartedTitle">
       <% if (ArticuloList != null) { //inicio listado cards
               foreach (var Art in ArticuloList)
               {  %>
        
           
                <div class="card" style="width: 18rem; margin:10px">
                    <% string Img = Negocio.Helper.UrlImgFirst(Art.Id); %>
                    <img src=<%: Img %> class="card-img-top"  alt="Imagen Articulo "/> <!-- SI LA URL NO FUNCA,CARGAR OTRA-->
                    <div class="card-body">
                        <h5 class="card-title"><%:Art.Nombre %></h5>
                        <p class="card-text"><%:Art.Descripcion %></p>
                        <p class="card-text"> <%:Art.Precio %></p>
                        <a href="Producto.aspx?Id=<%:Art.Id %>" class="btn btn-primary">Ver</a>
                    </div>
                </div>
        
       <% }
           }//fin listado cards %>
            </section>
    </main>

</asp:Content>
