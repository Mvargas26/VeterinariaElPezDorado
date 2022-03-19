<%@ Page Title="Acerca De" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AcercaDe.aspx.vb" Inherits="VeterinariaElPezDorado.AcercaDe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         
    <div>
     <font color="RoyalBlue" face="Comic Sans MS,arial">
  <h1 align="center"><i>Curso programación 2</i></h1>
  <h2 align="center">Veterinaria El Pez Dorado</h2>
  </font>
    </div>

    <div class="text-center">
  <img src="../Imagenes/AcercaDe.jpg" class="rounded" alt="...">
</div>




    <!-- Manejo de errores  -->
        <div id="lblError" runat="server" visible="false" class="alert alert-danger" role="alert">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
</asp:Content>
