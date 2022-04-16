<%@ Page Title="Clientes" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmClientes.aspx.vb" Inherits="VeterinariaElPezDorado.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Clientes</h1>
    <%-- Menu para seleccionar el tipo de mantenimiento --%>
    <div>
        <asp:Menu ID="mnSeleccion" runat="server" Font-Size="20pt" BorderWidth="60px" BorderColor="#FFFFFF">
            <Items>
                <asp:MenuItem Text="Menú Clientes " Value="0">
                    <asp:MenuItem Text="Registrar" Value="1"></asp:MenuItem>
                    <asp:MenuItem Text="Eliminar" Value="3"></asp:MenuItem>
                    <asp:MenuItem Text="Modificar" Value="2"></asp:MenuItem>                    
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
                <asp:TextBox ID="txtNombre" runat="server" class="form-control" placeholder="Nombre" required="required" pattern="[A-Za-zÁÉÍÓÚáéíóúÑñ]+"></asp:TextBox>
                <div class="invalid-feedback">
                    Indique solo letras en su nombre
                </div>
            </div>

            <div class="col-md-4 mb-3">
                <label runat="server" id="lblApellidos" for="Apellidos">Apellidos</label>
                <asp:TextBox runat="server" class="form-control" ID="txtApellidos" placeholder="Apellidos" required="required" pattern="[A-Za-zÁÉÍÓÚáéíóúÑñ ]+"></asp:TextBox>
                <div class="invalid-feedback">
                    Indique solo letras en sus apellidos
                </div>
            </div>

             <div class="col-md-4 mb-3">
                <label runat="server" id="lblIdentificacion" for="Identificacion">Identificación</label>
                <asp:TextBox runat="server" class="form-control" ID="txtIdentificacion" placeholder="102340567" required="required" pattern="[A-Za-z0-9]+{5,40}"></asp:TextBox>
                <div class="invalid-feedback">
                    Por favor indique su cédula, sin guiones.
                </div>
            </div>

        </div>

        <div class="form-row">
           
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

            <!-- cboProvincias -->
               <div class="col-md-4 mb-3">
                <label runat="server" id="lblProvincias" for="cboProvincias">Provincias</label>                
                    <asp:DropDownList ID="cboProvincias" runat="server" Width=200px CssClass=" form-control" AutoPostBack="True">
                        <asp:ListItem Text="San Jose" Value=1>sanJose</asp:ListItem>
                        <asp:ListItem Text="Alajuela" Value=2>Alajuela</asp:ListItem>
                        <asp:ListItem Text="Cartago" Value=3>Cartago</asp:ListItem>
                        <asp:ListItem Text="Heredia" Value=4>Heredia</asp:ListItem>
                        <asp:ListItem Text="Guanacaste" Value=5>Guanacaste</asp:ListItem>
                        <asp:ListItem Text="Puntarenas" Value=6>Puntarenas</asp:ListItem>
                        <asp:ListItem Text="Limon" Value=7>Limon</asp:ListItem>
                </asp:DropDownList>
            </div>

        </div>

          <div class="form-row">
         
         <!-- cboCantones -->
         <div class="col-md-4 mb-3">
                <label runat="server" id="lblCantones" for="cboCantones">Cantones</label>                
                    <asp:DropDownList ID="cboCantones" runat="server" Width=200px CssClass=" form-control">
                        <asp:ListItem Text="Central" Value=1>Central</asp:ListItem>
                </asp:DropDownList>
            </div>
               

         <div class="col-md-4 mb-3">
                <label runat="server" id="lblDistrito" for="txtDistrito">Distrito</label> 
                <asp:TextBox runat="server" class="form-control" ID="txtDistrito" placeholder="Distrito" required="requiered" pattern="[A-Za-zÁÉÍÓÚáéíóúÑñ]+{5,25}"></asp:TextBox>
                 <div class="invalid-feedback">Indique un distrito</div>
            </div>

               <div class="col-md-4 mb-3">
                 <label runat="server" id="lblDireccion" for="txtDireccion">Direccion Exacta</label>
                <asp:TextBox runat="server" class="form-control" ID="txtDireccion" placeholder="Direccion Exacta" required="requiered" minlength="5" MaxLength="400"></asp:TextBox>
                <div class="invalid-feedback">Indique su dirección</div>
            </div>

        </div>

       </div> <!--// Fin form clientes // -->

       
        
        <div>
            <asp:Button ID="btnMantenimientoCliente" runat="server" CssClass="btn btn-info" Text="Registrar" />
        </div>

        <!-- Manejo de errores  -->
        <div id="lblError" runat="server" visible="false" class="alert alert-danger" role="alert">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
    
</asp:Content>