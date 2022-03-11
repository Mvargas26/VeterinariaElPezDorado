<%@ Page Title="Clientes" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Clientes.aspx.vb" Inherits="VeterinariaElPezDorado.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Clientes</h1>
    <div class="form-row">
        <div class="col-md-4 mb-3">
            <label for="Nombre">Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" class="form-control" placeholder="Nombre" required="required"></asp:TextBox>
           </div>
        <div class="col-md-4 mb-3">
            <label for="PrimerApellido">Primer Apellido</label>
            <input type="text" class="form-control" id="PrimerApellido" placeholder="Primer Apellido" value="" required="required">
        </div>
        <div class="col-md-4 mb-3">
            <label for="SegundoApellido">Segundo Apellido</label>
            <div class="input-group">
                <input type="text" class="form-control" id="SegundoNombre" placeholder="Segundo Apellido">
            </div>
        </div>
    </div>
    <div class="form-row">
        <div class="col-md-4 mb-3">
            <label for="Identificacion">Identificación</label>
            <input type="text" class="form-control" id="Identificacion" placeholder="102340567" required="required">
        </div>
        <div class="col-md-4 mb-3">
            <label for="Telefono">Teléfono</label>
            <input type="tel" class="form-control" id="Teléfono" placeholder="88888888" pattern="[0-9]{8}" required="required">
            <div class="invalid-feedback">
                Ejemplo: 22225555
            </div>
        </div>

        <div class="col-md-4 mb-3">
            <label for="Correo">Correo Electrónico</label>
            <input type="email" class="form-control" id="Correo" placeholder="correoelectronico@example.com" required="required">
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-4">
            <select class="custom-select" required>
                <option value="">Provincia</option>
                <option value="1">San Jose</option>
                <option value="2">Alajuela</option>
                <option value="3">Cartago</option>
                 <option value="4">Heredia</option>
                 <option value="5">Guanacaste</option>
                 <option value="6">Puntarenas</option>
                 <option value="7">Limón</option>
            </select>
            <div class="invalid-feedback">Seleccione una provincia</div>
        </div>

        <div class="form-group col-md-4">
            <select class="custom-select" required>
                <option value="">Cantón</option>
                <option value="1">One</option>
                <option value="2">Two</option>
                <option value="3">Three</option>
            </select>
            <div class="invalid-feedback">Seleccione un cantón</div>
        </div>

        <div class="col-md-4 mb-3">
            <input type="text" class="form-control" id="Distrito" placeholder="Distrito" required>
        </div>

    </div>
    <div class="form-row">
        <div class="col-md-4 mb-3">
            <input type="text" class="form-control" id="Dirrecion" placeholder="Direccion" required>
        </div>
    </div>

    <div>
        <asp:Button ID="btnRegistrarCliente" runat="server" Cssclass="btn btn-info" Text="Registrar" />
             <a href="ConsultasCliente.aspx" class="btn btn-danger" >Cancelar</a>
     </div>
    
    <!-- Manejo de errores  -->
    <div id="lblError" runat="server" visible="false" class="alert alert-danger" role="alert">
        <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        

    </div>

</asp:Content>
