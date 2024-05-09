<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWebForm_equipo_2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
         <section class=" row mb-3 row-cols-1 text-center" id="cardsArticulos" aria-labelledby="gettingStartedTitle">
       <% if (ArticuloList != null) { //inicio listado cards
               foreach (var Art in ArticuloList)
               {  %>
        
           
                <div class="card" style="width: 18rem;">
                    <% string Img = Negocio.Helper.UrlImgFirst(Art.Id); %>
                    <img src=<%: Img %> class="card-img-top"  alt="Imagen Articulo " + <%: Art.Nombre %>"/> <!-- SI LA URL NO FUNCA,CARGAR OTRA-->
                    <div class="card-body">
                        <h5 class="card-title"><%:Art.Nombre %></h5>
                        <p class="card-text"><%:Art.Descripcion %></p>
                        <p class="card-text"> <%:Art.Precio %></p>
                        <a href="#" class="btn btn-primary">Ver</a>
                    </div>
                </div>
        
       <% }
           }//fin listado cards %>
            </section>

    </main>

</asp:Content>
