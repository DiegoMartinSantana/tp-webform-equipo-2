<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWebForm_equipo_2.Default" %>


<asp:Content ID="HeaderContent" ContentPlaceHolderID="SearchContent" runat="server">

    <asp:TextBox ID="TxtFiltro" runat="server" CssClass="form-control" placeholder="Buscar artículos" aria-label="Search"></asp:TextBox>

    <asp:Button runat="server" CssClass="boton-buscar" Style="width: 19%" ID="BtnFiltrarByNombre" OnClick="BtnFiltrarByNombre_Click" />

</asp:Content>

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

    <section class=" row mb-3 row-cols-1 text-center" id="cardsArticulos" style="padding-top: 30px" aria-labelledby="gettingStartedTitle">
        <% if (ArticuloList != null)
            { //inicio listado cards
                foreach (var Art in ArticuloList)
                {  %>


        <div class="card" style="width: 18rem; margin: 10px" id="cardsArticulos">
            <% string Img = Negocio.Helper.UrlImgFirst(Art.Id); %>
            <img src="<%: Img %>" class="card-img-top" alt="Imagen Articulo " style="margin-top: 2%" onerror="this.onerror=null;this.src='https://i.ibb.co/bJxT4V0/digital-hive-sin-imagen-1.png';" />
            <!-- SI LA URL NO FUNCA,CARGAR OTRA-->
            <div class="card-body">
                <h4 class="card-title"><%:Art.Nombre %></h4>
                <p class="card-text">$ <%:Art.Precio %></p>
                <a href="Producto.aspx?Id=<%:Art.Id %>" class="btn btn-primary" id="botonVerDetalles">Ver</a>
            </div>
        </div>

        <% }
            }//fin listado cards %>
    </section>

    <%--------------------ESTILOS--------------------%>

    <style>

        #botonVerDetalles {
            background-color: var(--electric-indigo);
            color: var(--white);
            border: none;
        }

        #cardsArticulos {
            justify-content: center;
            background-color: none;
            color: var(--raisin-black);
            border-color: var(--platinum);
            text-align: center;
            outline-color:aqua;
        }

        .boton-buscar {
            display: inline-block;
            font-weight: 400;
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            cursor: pointer;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
            border: 1px solid transparent;
            padding: .375rem .75rem;
            font-size: 1rem;
            line-height: 1.5;
            transition: color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;
            background-color: var(--white);
            color: #fff;
            background-image: url('data:image/svg+xml;utf8,<svg xmlns="http://www.w3.org/2000/svg" width="25" height="25" fill="black" class="bi bi-search" viewBox="0 0 16 16"><path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0"/></svg>');
            background-repeat: no-repeat;
            background-position: right .75rem center;
            background-size: 1.5em 1.5em;
            border-radius: 50px;
        }

        .form-control{

            border-radius: 50px;
        }
    </style>

</asp:Content>
