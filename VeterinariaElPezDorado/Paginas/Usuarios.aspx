<%@ Page Title="Usuarios" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Usuarios.aspx.vb" Inherits="VeterinariaElPezDorado.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
        <asp:Menu ID="mnSeleccion" runat="server" Font-Size="20pt" BorderWidth="60px" BorderColor="#FFFFFF">
            <Items>
                <asp:MenuItem Text="Menú Usuarios" Value=0>
                    <asp:MenuItem Text="Registrar" Value=1></asp:MenuItem>                    
                    <asp:MenuItem Text="Modificar" Value=2></asp:MenuItem>
                    <asp:MenuItem Text="Eliminar" Value=3></asp:MenuItem>
                    <asp:MenuItem Text="Consultar" Value=4></asp:MenuItem>
                </asp:MenuItem>
            </Items>
        </asp:Menu>
         <div class="form-row">
            <asp:Label ID="lblAccionMenu" runat="server" Text="" Visible="false" CssClass="col-md-12" Font-Size="XX-Large"  ></asp:Label>
        </div>
        <asp:DropDownList ID="cboUsuarios" runat="server" required="required" Visible="false" style="width:200px"></asp:DropDownList>
        <asp:Button ID="btnConsultar" runat="server" Visible="false" Text="Continuar" BorderWidth="20px" BorderColor="#FFFFFF" CssClass="btn btn-info" />
    </div>

    <div id="divUsuarios" runat="server" visible="false">
        <div class="form-row">
            <div class="col-md-4 mb-3">
                <label for="txtNombreUsuario">Nombre del Usuario</label>
                <asp:TextBox runat="server" class="form-control" ID="txtNombreUsuario" placeholder="Nombre del Usuario" required="required" pattern="[A-Za-z]{5,40}"></asp:TextBox>
                <div class="invalid-feedback">
                    Indique un nombre de usuario valido valido (Minimo 5 caracteres). 
                </div>
            </div>
            <div class="col-md-8 mb-3">
                <label for="txtClaveUsuario">Clave del usuario</label>
                <asp:TextBox runat="server" class="form-control" ID="txtClaveUsuario" placeholder="Clave del usuario" pattern="[0-9A-Za-z]+" required="required"></asp:TextBox>
                <div class="invalid-feedback">
                    Indique el costo del servicio.
                </div>
            </div>        
        </div>

        <div>
            <asp:Button ID="btnMantenimientoUsuarios" runat="server" CssClass="btn btn-info" Text="Registrar" />
        </div>



    <!-- Manejo de errores  -->
        <div id="lblError" runat="server" visible="false" class="alert alert-danger" role="alert">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
        </div>
</asp:Content>
