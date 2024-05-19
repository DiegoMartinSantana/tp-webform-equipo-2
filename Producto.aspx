<%@ Page Title="Producto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="TPWebForm_equipo_2.Producto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- INICIO CARROUSEL-->
    <div id="carouselExampleDark" class="carousel carousel-dark slide" data-bs-ride="carousel">

        <div class="carousel-inner">
            <div class="carousel-item active" data-bs-interval="10000">
                <asp:Image ID="ImgProducto" CssClass="d-block" runat="server" style="width:40%; height:auto; margin-left:30%" ImageUrl="https://static3.depositphotos.com/1003671/179/i/450/depositphotos_1792145-stock-photo-mountain-tortoise.jpg" AlternateText="Img Producto" onerror="this.onerror=null;this.src='https://i.ibb.co/bJxT4V0/digital-hive-sin-imagen-1.png';"/>   

                <div class="carousel-caption d-none d-md-block">
                </div>
            </div>

        </div>
    <!-- MANEJO DE URLS DEL CARROUSEL DE BOOSTRAPP-->

        <asp:Button runat="server" CssClass="carousel-control-prev carousel-control-prev-icon" ID="BtnPrev" style="margin-left: 20% ; margin-top:20%"  OnClick="BtnPrev_Click" />
        <asp:Button runat="server" CssClass="carousel-control-next carousel-control-next-icon" ID="BtnNext" style="margin-right: 20% ; margin-top:20%" OnClick="BtnNext_Click" />
    <!-- FIN MANEJO-->

    </div>
    <!-- FIN CARROUSEL-->

    <!-- INICIO CARD-->

    <div class="card shadow-sm">
        <div class="card-body">
            <h5 id="TituloProducto" runat="server" class="card-title text-center mb-3"></h5>
            <asp:Label  ID="DescripcionProducto" class="card-text" runat="server" />
            <asp:Label  ID="MarcaProducto" class="card-text" runat="server" />
            <asp:Label  ID="CategoriaProducto" class="card-text" runat="server" />
            <asp:Label  ID="PrecioProducto" class="card-text" runat="server" />

            <div class="text-center">
                <asp:Button Text="Añadir al carrito" class="btn btn-primary" runat="server" ID="BtnAddCarrito" OnClick="BtnAddCarrito_Click" />
            </div>
        </div>
    </div>
    <!-- FIN CARD-->


</asp:Content>
