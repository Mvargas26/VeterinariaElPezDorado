<%@ Page Title="Consultas por cliente" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmConsultasCliente.aspx.vb" Inherits="VeterinariaElPezDorado.ConsultasCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
     <font color="RoyalBlue" face="Comic Sans MS,arial">
  <h1 align="center"><i>Lista de Clientes en la Base de datos</i></h1>
   </font>
    </div>

    <table class="table">
  <thead class="thead-dark">
    <tr>
      <th scope="col">Identificación</th>
      <th scope="col">Nombre</th>
      <th scope="col">Apellidos</th>
        <th scope="col">Correo electrónico</th>
      <th scope="col">teléfono</th>
         <th scope="col">Provincia</th>
         <th scope="col">Canton</th>
         <th scope="col">Distrito</th>
        <th scope="col">Direccion Exacta</th>
        
    </tr>
  </thead> <!--la info de esta tabla viene de la DB, ver el CodeBehind-->
  <tbody id="lstClientes" runat="server">

 
  </tbody>
</table>




    <!-- Manejo de errores  -->
        <div id="lblError" runat="server" visible="false" class="alert alert-danger" role="alert">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
</asp:Content>
