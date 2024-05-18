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

                <%--------------------ARTICULO--------------------%>

                <div class="cart-item">
                    <div class="row">
                        <div class="col-md-3">
                            <img src="https://i.ibb.co/bJxT4V0/digital-hive-sin-imagen-1.png" class="img-fluid" alt="Producto">
                        </div>
                        <div class="col-md-6">
                            <h5>ARTICULO</h5>

                        </div>
                        <div class="col-md-3 text-right">
                            <h5>$100</h5>
                            <%-- HAY QUE ARREGLAR EL IMPUT PARA QUE NO QUEDE TAN GRANDE :( --%>
                            <input type="number" min="1" value="1">
                            <button class="btn" style="background-color: var(--electric-indigo); color: var(--white);">Eliminar</button>
                        </div>
                    </div>
                </div>

                <%--------------------ARTICULO--------------------%>

                <div class="cart-item">
                    <div class="row">
                        <div class="col-md-3">
                            <img src="https://i.ibb.co/bJxT4V0/digital-hive-sin-imagen-1.png" class="img-fluid" alt="Producto">
                        </div>
                        <div class="col-md-6">
                            <h5>ARTICULO</h5>

                        </div>
                        <div class="col-md-3 text-right">
                            <h5>$100</h5>
                            <%-- HAY QUE ARREGLAR EL IMPUT PARA QUE NO QUEDE TAN GRANDE :( --%>
                            <input type="number" min="1" value="1">
                            <button class="btn" style="background-color: var(--electric-indigo); color: var(--white);">Eliminar</button>
                        </div>
                    </div>
                </div>

            </div>

            <%--------------------TOTAL A PAGAR--------------------%>

            <div class="col-md-4">
                <div class="card">
                    <div class="card-body">
                        <h4 class="card-title">Total: $100</h4>
                        <button class="btn btn-success btn-block border-bottom=none" style="background-color: var(--aquamarine); color: var(--raisin-black);">Pagar</button>
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
