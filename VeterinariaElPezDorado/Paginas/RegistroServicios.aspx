<%@ Page Title="Registro de servicios" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="RegistroServicios.aspx.vb" Inherits="VeterinariaElPezDorado.RegistroServicios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">




    <!-- Manejo de errores  -->
        <div id="lblError" runat="server" visible="false" class="alert alert-danger" role="alert">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
</asp:Content>
