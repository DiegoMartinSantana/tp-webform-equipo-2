<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPWebForm_equipo_2.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%--------------------TITULO DE PAGINA--------------------%>

    <div class="col-md-12 text-center">
        <h3>Carrito</h3>
    </div>

    <%--------------------ARTICULOS--------------------%>

    <div class="container mt-5">
        <div class="row">
            <div class="col-md-8">
          
                <%-----------------IMPLANTO FOREACH PARA MOSTRAT LOS PRODUCTOS QUE ESTAN EN LA LISTA DEL CARRITO---------------------------------%>
        
         <section class=" row mb-3 row-cols-1 text-center" id="cardsArticulosCarrito" style="padding-top: 30px" aria-labelledby="gettingStartedTitle">
       <% if (CarritoList != null)
           { //inicio listado cards dentro de la lista de carrito
               foreach (var Art in CarritoList)
               {  %>
       <div class="row"">
              <div class="col-md-3">
           <% string Img = Negocio.Helper.UrlImgFirst(Art.Id); %>
           <img src="<%: Img %>" class="card-img-top" alt="Imagen Articulo " style="margin-top: 2%" onerror="this.onerror=null;this.src='https://i.ibb.co/bJxT4V0/digital-hive-sin-imagen-1.png';" />
              </div>
           <div class="col-md-6">
               <h4 class="card-title"><%:Art.Nombre %></h4>
               <p class="card-text"><%:Art.Descripcion %></p>
               <p class="card-text">$ <%:Art.Precio %></p>            
           </div>
           <div class="col-md-3 text-right">
               <h5> Cantidad</h5>
           </div>
       </div>

       <% }
           }
           else
           {//fin listado cards %>
   </section>
              
                
                <%--------------------SI LA LISTA EN EL FOREACH ESTA VACIA MEUSTRO ESTO ARTICULO--------------------%>
                
                <div class="cart-item">
                    <div class="row">
                        <div class="col-md-3">
                            <img src="https://i.ibb.co/bJxT4V0/digital-hive-sin-imagen-1.png" class="img-fluid" alt="Producto">
                        </div>
                        <div class="col-md-6">
                            <h5>Ningun articulo agregado</h5>
                        </div>
                        <div class="col-md-3 text-right">
                            <h5>$0</h5>                     
                           <%-- <input type="number" min="1" value="1">--%>                            
                        </div>
                    </div>
                </div>
                <%} %>
            </div>

            <%--------------------TOTAL A PAGAR--------------------%>

            <div class="col-md-4">
                <div class="card">
                    <div class="card-body">
                        <h4 class="card-title">Total: $0</h4>
                        <button class="btn btn-success btn-block border-bottom=none" style="background-color: var(--aquamarine); color: var(--raisin-black);">Pagar</button>
                        <asp:Button ID="btnVaciar" CssClass="btn btn-danger" runat="server" Text="Vaciar Carrito" OnClick="btnVaciar_Click1" />
                    </div>
                </div>
            </div>

        </div>
    </div>

    <%--------------------ESTILOS--------------------%>

    <%-- No se como colocar esto en DigitalHiveStyle.css y que lo tome, por eso lo hago aca mismo :) --%>

    <style>
        .cart-item {
            border-bottom: 1px solid #ccc;
            padding: 10px 0 !important;
        }

            .cart-item:last-child {
                border-bottom: none !important;
            }

        .btn-success {
            border-color: transparent;
            font-weight: bold;
        }

        .btn {
            border-color: transparent;
            font-weight: bold;
        }
    </style>


</asp:Content>
