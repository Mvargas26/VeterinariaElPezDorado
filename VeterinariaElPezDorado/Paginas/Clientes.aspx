<%@ Page Title="Clientes" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Clientes.aspx.vb" Inherits="VeterinariaElPezDorado.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Clientes</h1>
    <%-- Menu para seleccionar el tipo de mantenimiento --%>
    <div>
        <asp:Menu ID="mnSeleccion" runat="server" Font-Size="20pt" BorderWidth="60px" BorderColor="#FFFFFF">
            <Items>
                <asp:MenuItem Text="Menú Clientes " Value="0">
                    <asp:MenuItem Text="Registrar" Value="1"></asp:MenuItem>
                    <asp:MenuItem Text="Eliminar" Value="2"></asp:MenuItem>
                    <asp:MenuItem Text="Modificar" Value="3"></asp:MenuItem>
                    <asp:MenuItem Text="Consultar" Value="4"></asp:MenuItem>
                </asp:MenuItem>
            </Items>
        </asp:Menu>
        <asp:TextBox ID="txtIdentificacionConsulta" class="form-control" runat="server" Visible="false" placeholder="Identificación" required="required" minlength="8" MaxLength="12"></asp:TextBox>
        <asp:Button ID="btnConsultar" runat="server" Visible="false" Text="Continuar" BorderWidth="20px" BorderColor="#FFFFFF" />
        <div class="invalid-feedback">
            Indique un cédula de minimo 8 digitos
        </div>
    </div>
    <%-- Pantalla de los datos --%>
    <div id="Cliente" runat="server" visible="false">
        <div class="form-row">
            <div class="col-md-4 mb-3">
                <label runat="server" id="lblNombre" for="Nombre">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" class="form-control" placeholder="Nombre" required="required" pattern="[A-Za-z]+"></asp:TextBox>
                <div class="invalid-feedback">
                    Indique solo letras en su nombre
                </div>
            </div>

            <div class="col-md-4 mb-3">
                <label runat="server" id="lblPrimerApellido" for="PrimerApellido">Primer Apellido</label>
                <asp:TextBox runat="server" class="form-control" ID="txtPrimerApellido" placeholder="Primer Apellido" required="required" pattern="[A-Za-z]+"></asp:TextBox>
                <div class="invalid-feedback">
                    Indique solo letras en su apellido
                </div>
            </div>

            <div class="col-md-4 mb-3">
                <label runat="server" id="lblSegundoApellido" for="SegundoApellido">Segundo Apellido</label>
                <div class="input-group">
                    <asp:TextBox runat="server" class="form-control" ID="txtSegundoNombre" placeholder="Segundo Apellido" pattern="[A-Za-z]+"></asp:TextBox>
                    <div class="invalid-feedback">
                        Indique solo letras en su apellido
                    </div>
                </div>

            </div>
        </div>
        <div class="form-row">
            <div class="col-md-4 mb-3">
                <label runat="server" id="lblIdentificacion" for="Identificacion">Identificación</label>
                <asp:TextBox runat="server" class="form-control" ID="txtIdentificacion" placeholder="102340567" required="required" pattern="[A-Za-z0-9]{5,40}"></asp:TextBox>
                <div class="invalid-feedback">
                    Por favor indique su cédula, sin guiones.
                </div>
            </div>
            <div class="col-md-4 mb-3">
                <label runat="server" id="lblTelefono" for="Telefono">Teléfono</label>
                <asp:TextBox runat="server" class="form-control" ID="txtTeléfono" placeholder="88888888" pattern="[0-9]{8,12}" required="required"></asp:TextBox>
                <div class="invalid-feedback">
                    Ejemplo: 22225555
                </div>
            </div>

            <div class="col-md-4 mb-3">
                <label runat="server" id="lblCorreo" for="Correo">Correo Electrónico</label>
                <asp:TextBox runat="server" class="form-control" ID="txtCorreo" placeholder="correoelectronico@example.com" required="required" pattern="[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*@[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*[.][a-zA-Z]{1,5}"></asp:TextBox>
                <div class="invalid-feedback">
                    Indique un correo valido.
                </div>
            </div>

        </div>
        <div class="form-row">

            <div class="form-group col-md-4">
                <select id="cboProvincia" runat="server" class="custom-select" required>
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
            <div class="invalid-feedback">Seleccione una provincia</div>

            <div class="form-group col-md-4">
                <select id="cboCanton" runat="server" class="custom-select" required>
                    <option value="">Cantón</option>
                    <option value="1">CENTRAL</option>
                    <option value="2">CONCEPCION</option>
                    <option value="3">CANTON </option>
                </select>
                <div class="invalid-feedback">Seleccione un cantón</div>
            </div>

            <div class="col-md-4 mb-3">
                <asp:TextBox runat="server" class="form-control" ID="txtDistrito" placeholder="Distrito" required="requiered" pattern="[A-Za-z]{5,25}"></asp:TextBox>
                 <div class="invalid-feedback">Indique un distrito</div>
            </div>

        </div>


        <div class="form-row">
            <div class="col-md-4 mb-3">
                <asp:TextBox runat="server" class="form-control" ID="txtDireccion" placeholder="Direccion Exacta" required="requiered" pattern="[A-Za-z0-9 ]{5,150}"></asp:TextBox>
                <div class="invalid-feedback">Indique su dirección</div>
            </div>
        </div>

        <div>
            <asp:Button ID="btnMantenimientoCliente" runat="server" CssClass="btn btn-info" Text="Registrar" />
        </div>

        <!-- Manejo de errores  -->
        <div id="lblError" runat="server" visible="false" class="alert alert-danger" role="alert">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>