<%@ Page Title="Mascotas" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Mascotas.aspx.vb" Inherits="VeterinariaElPezDorado.Mascotas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%-- Menu para seleccionar el tipo de mantenimiento --%>
    <div>
        <asp:Menu ID="mnSeleccion" runat="server" Font-Size="20pt" BorderWidth="60px" BorderColor="#FFFFFF">
            <Items>
                <asp:MenuItem Text="Menú Mascotas" Value="0">
                    <asp:MenuItem Text="Registrar" Value=1></asp:MenuItem>
                    <asp:MenuItem Text="Eliminar" Value=3></asp:MenuItem>
                    <asp:MenuItem Text="Modificar" Value=2></asp:MenuItem>
                    <asp:MenuItem Text="Consultar" Value=4></asp:MenuItem>
                </asp:MenuItem>
            </Items>
        </asp:Menu>
        <asp:TextBox ID="txtIdentificacionConsulta" class="form-control" runat="server" Visible="false" placeholder="Identificación" required="required" minlength="8" MaxLength="12"></asp:TextBox>
        <asp:Button ID="btnConsultar" runat="server" Visible="false" Text="Continuar" BorderWidth="20px" BorderColor="#FFFFFF" CssClass="btn btn-info"/>
        <div class="invalid-feedback">
            Indique la cédula del dueño de la mascota (mínimo 8 digitos)
        </div>
    </div>
    <%-- Pantalla de los datos --%>
    <div id="Mascotas" runat="server" visible="false">
        <div class="form-row">
            <div class="col-md-4 mb-3">
                <label runat="server" id="lblIdentificacionDueno" for="txtidentificacionDueno">Identificación dueño</label>
                <asp:TextBox ID="txtidentificacionDueno" runat="server" class="form-control" placeholder="Identificación Dueño" required="required" pattern="[A-Za-z0-9]{5,40}+"></asp:TextBox>
                <div class="invalid-feedback">
                    Por favor indique la identificación del cliente
                </div>
            </div>

            <div class="col-md-4 mb-3">
                <label runat="server" id="lblNombreMascota" for="txtNombreMascota">Nombre Mascota</label>
                <asp:TextBox runat="server" class="form-control" ID="txtNombreMascota" placeholder="Nombre Mascota" required="required" pattern="[A-Za-z]{2,40}"></asp:TextBox>
                <div class="invalid-feedback">
                    Indique el nombre de la mascota (Indique solamente letras)
                </div>
            </div>

            <div class="col-md-4 mb-3">
                <label runat="server" id="lblTipoMascota" for="cboTipoMascota">Tipo de mascota</label>                
                    <asp:DropDownList ID="cboTipoMascota" runat="server" Width=200px CssClass=" form-control">
                        <asp:ListItem Text="Tortuga" Value=1>Tortuga</asp:ListItem>
                        <asp:ListItem Text="Pez" Value=2>Pez</asp:ListItem>
                        <asp:ListItem Text="Conejo" Value=3>Conejo</asp:ListItem>
                        <asp:ListItem Text="Ave" Value=4>Ave</asp:ListItem>
                        <asp:ListItem Text="Perro" Value=5>Perro</asp:ListItem>
                        <asp:ListItem Text="Gato" Value=6>Gato</asp:ListItem>
                        <asp:ListItem Text="Ratón" Value=7>Ratón</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-row">
            <div class="col-md-4 mb-3">
                <label runat="server" id="lblRaza" for="txtRaza">Raza</label>
                <asp:TextBox runat="server" class="form-control" ID="txtRaza" placeholder="Raza" pattern="[A-Za-z]"></asp:TextBox>
                <div class="invalid-feedback">
                    Al indicar la raza no utilice números.
                </div>
            </div>
            <div class="col-md-4 mb-3">
                <label runat="server" id="lblPeso" for="txtPeso">Peso</label>
                <asp:TextBox runat="server" class="form-control" ID="txtPeso" placeholder="Peso" pattern="[0-9]" required="required"></asp:TextBox>
                <div class="invalid-feedback">
                    Indique el peso de la mascota.
                </div>
            </div>

            <div class="col-md-4 mb-3">
                <label runat="server" id="lblEstadoSalud" for="txtEstadoSalud">Estado de salud</label>
                <asp:TextBox runat="server" class="form-control" ID="txtEstadoSalud" placeholder="Descripción del estado de salud." required="required" pattern="[A-Za-z0-9]{5,40}"></asp:TextBox>
                <div class="invalid-feedback">
                    Indique el estado de salud de la mascota (Máximo 40 caracteres).
                </div>
            </div>
        </div>

        <div class="form-row">
            <div class="form-group col-md-4">
                <label runat="server" id="lblFechaNacimiento" for="txtFechaNacimiento">Fecha de nacimiento</label>
                <asp:TextBox ID="txtFechaNacimiento" runat="server" class=" form-control"  required="required" TextMode="Date"></asp:TextBox>
                <div class="invalid-feedback">Seleccione una fecha</div>
            </div>
        </div>      

        <div>
            <asp:Button ID="btnMantenimientoMascotas" runat="server" CssClass="btn btn-info" Text="Registrar" />
        </div>

        <!-- Manejo de errores  -->
        <div id="lblError" runat="server" visible="false" class="alert alert-danger" role="alert">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
    </div>


</asp:Content>
