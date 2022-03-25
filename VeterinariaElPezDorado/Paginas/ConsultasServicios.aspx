<%@ Page Title="Consultas por servicios" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ConsultasServicios.aspx.vb" Inherits="VeterinariaElPezDorado.Consultas_por_servicios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div>
     <font color="RoyalBlue" face="Comic Sans MS,arial">
  <h1 align="center"><i>Registro en la base de datos de los Servicios Brindados</i></h1>
 
  </font>
    </div>

    <table class="table">
  <thead class="thead-dark">
    <tr>
      <th scope="col">Codigo del Servicio</th>
      <th scope="col">Nombre del Servicio</th>
      <th scope="col">Costo del Servicio</th>
      <th scope="col">Impuesto</th>
     </tr>
  </thead>
  <tbody>
    <tbody id="lstServicios" runat="server">
  
  </tbody>
</table>





    <!-- Manejo de errores  -->
        <div id="lblError" runat="server" visible="false" class="alert alert-danger" role="alert">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
</asp:Content>
