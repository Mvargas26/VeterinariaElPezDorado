<%@ Page Title="Consultas por servicios" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmConsultasServicios.aspx.vb" Inherits="VeterinariaElPezDorado.Consultas_por_servicios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div>
     <font color="RoyalBlue" face="Comic Sans MS,arial">
  <h1 align="center"><i>Registro en la base de datos de los Servicios Brindados</i></h1>
 
  </font>
    </div>

    <table class="table">
        <thead class="thead-dark">
            <tr>
                <th scope="col">Código Cobro</th>
                <th scope="col">Identificación Dueño</th>
                <th scope="col">Nombre Mascota</th>
                <th scope="col">Nombre del Servicio</th>
                <th scope="col">Costo del Servicio</th>
                <th scope="col">Impuesto</th>
                <th scope="col">Costo Total</th>
            </tr>
  </thead>
  <tbody runat="server" id="lstConsultaServicios">
  </tbody>
</table>

    <!-- Manejo de errores  -->
        <div id="lblError" runat="server" visible="false" class="alert alert-danger" role="alert">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
</asp:Content>
