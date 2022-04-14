<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmConsultasMascotas.aspx.vb" Inherits="VeterinariaElPezDorado.ConsultasMascotas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
     <font color="RoyalBlue" face="Comic Sans MS,arial">
  <h1 align="center"><i>Lista de Mascotas segun el Cliente</i></h1>
   </font>
    </div>

    <hr />
    <asp:TextBox ID="txtIdentificacionConsulta" class="form-control" runat="server" Visible="true" placeholder="Identificación" required="required" minlength="8" MaxLength="12"></asp:TextBox>
        <asp:Button ID="btnConsultar" runat="server" Visible="true" Text="Consultar" BorderWidth="20px" BorderColor="#FFFFFF" />
        <div class="invalid-feedback">
            Indique un cédula de minimo 8 digitos
        </div>
    <hr />
    <br />


    <div id="divtablaMascotas" runat="server" visible="false" >
         <table class="table">
  <thead class="thead-dark">
    <tr>
      <th scope="col">Identificación Mascota</th>
      <th scope="col">Nombre Mascota</th>
      <th scope="col">Tipo Mascota</th>
        <th scope="col">Peso</th>
      <th scope="col">Raza</th>
         <th scope="col">Estado Salud</th>
         <th scope="col">Fecha Nacimiento</th>
    </tr>
  </thead> <!--la info de esta tabla viene de la DB, ver el CodeBehind-->
  <tbody id="lstMascotas" runat="server">

 
  </tbody>
</table>

    </div>



    
    <!-- Manejo de errores  -->
        <div id="lblError" runat="server" visible="false" class="alert alert-danger" role="alert">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
</asp:Content>
