<%@ Page Title="Consultas por cliente" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ConsultasCliente.aspx.vb" Inherits="VeterinariaElPezDorado.ConsultasCliente" %>
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
      <th scope="col">teléfono</th>
        <th scope="col">Dirección</th>
        <th scope="col">Correo electrónico</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">1</th>
      <td>Mark</td>
      <td>Otto</td>
      <td>88888888</td>
        <td>San jose Costa Rica</td>
        <td>correo@example.com</td>
        <td><a class="btn btn-info" href="Clientes.aspx"  role="button">Modificar</a></td>
        <td><a class="btn btn-danger" href="Clientes.aspx"  role="button">Eliminar</a></td>
    </tr>
  
  </tbody>
</table>




    <!-- Manejo de errores  -->
        <div id="lblError" runat="server" visible="false" class="alert alert-danger" role="alert">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
</asp:Content>
