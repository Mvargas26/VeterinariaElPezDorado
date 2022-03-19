<%@ Page Title="Tipos de Mascotas" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="TiposMascotas.aspx.vb" Inherits="VeterinariaElPezDorado.TiposMascotas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">





    <!-- Manejo de errores  -->
        <div id="lblError" runat="server" visible="false" class="alert alert-danger" role="alert">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
</asp:Content>
