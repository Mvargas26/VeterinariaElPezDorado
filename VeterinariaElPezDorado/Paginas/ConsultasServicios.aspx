<%@ Page Title="Consultas por servicios" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ConsultasServicios.aspx.vb" Inherits="VeterinariaElPezDorado.Consultas_por_servicios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">





    <!-- Manejo de errores  -->
        <div id="lblError" runat="server" visible="false" class="alert alert-danger" role="alert">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
</asp:Content>
