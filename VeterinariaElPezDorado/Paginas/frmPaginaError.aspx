<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmPaginaError.aspx.vb" Inherits="VeterinariaElPezDorado.frmPaginaError" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <div> 
        <h1 >¡ A ocurrido algo inesperado !</h1>
        <br />
        <h2 > Por favor contacte a Soporte</h2>
    </div>

    <br />
    <br />
    <div>
        <div class="alert alert-danger" role="alert">
            <h4 class="alert-heading">¡Error!</h4>
            <p>
                <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
            </p>
            <hr>
            <p class="mb-0">
                <asp:Label ID="lblErrorTecnico" runat="server" Text=""></asp:Label>

            </p>
        </div>
    </div>
    <br />
    <br />


</asp:Content>
