<%@ Page Title="Producto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="TPWebForm_equipo_2.Producto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- INICIO CARROUSEL-->
    <div class="container mt-5">

        <div class="row">

            <div class="col-md-6">

                <div id="carouselExampleDark" class="carousel carousel-dark slide" data-bs-ride="carousel">

                    <div class="carousel-inner">
                        <div class="carousel-item active" data-bs-interval="10000">
                            <asp:Image ID="ImgProducto" CssClass="d-block" runat="server" Style="width: 40%; height: auto; margin-left: 30%" ImageUrl="https://static3.depositphotos.com/1003671/179/i/450/depositphotos_1792145-stock-photo-mountain-tortoise.jpg" AlternateText="ERROR" onerror="this.onerror=null;this.src='https://i.ibb.co/bJxT4V0/digital-hive-sin-imagen-1.png';" />

                            <div class="carousel-caption d-none d-md-block">
                            </div>
                        </div>

                    </div>

                    <!-- MANEJO DE URLS DEL CARROUSEL DE BOOSTRAPP-->
                    <asp:Button runat="server" CssClass="carousel-control-prev carousel-control-prev-icon" ID="BtnPrev" Style="margin-left: 20%; margin-top: 20%" OnClick="BtnPrev_Click" />
                    <asp:Button runat="server" CssClass="carousel-control-next carousel-control-next-icon" ID="BtnNext" Style="margin-right: 20%; margin-top: 20%" OnClick="BtnNext_Click" />
                    <!-- FIN MANEJO-->

                </div>
                <!-- FIN CARROUSEL-->

            </div>

            <!-- INICIO CARD-->

            <div class="col-md-6">
                <div class="card shadow-sm">
                    <div class="card-body">
                        <h5 id="TituloProducto" runat="server" class="card-title mb-3">Nombre del Producto</h5>
                        <asp:Label ID="PrecioProducto" runat="server" CssClass="card-text d-block mb-3" Text="$ Precio del producto aquí." />
                        <asp:Label ID="DescripcionProducto" runat="server" CssClass="card-text d-block mb-3" Text="Descripción del producto aquí." />
                        <asp:Label ID="MarcaProducto" runat="server" CssClass="card-text d-block mb-3" Text="Marca del producto aquí." />
                        <asp:Label ID="CategoriaProducto" runat="server" CssClass="card-text d-block mb-3" Text="Categoría del producto aquí." />

                        <div class="text-center" id="BotonAddCarrito">
                            <asp:Button Text="Añadir al carrito" style="background-color: var(--electric-indigo); color: var(--white); border: none; border-radius: 5px; height:40px" runat="server" ID="BtnAddCarrito" OnClick="BtnAddCarrito_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <!-- FIN CARD-->

        </div>

    </div>

</asp:Content>
