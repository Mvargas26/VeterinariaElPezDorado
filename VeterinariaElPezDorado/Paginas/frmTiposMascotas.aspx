<%@ Page Title="Tipos de Mascotas" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmTiposMascotas.aspx.vb" Inherits="VeterinariaElPezDorado.TiposMascotas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:Menu ID="mnSeleccion" runat="server" Font-Size="20pt" BorderWidth="60px" BorderColor="#FFFFFF">
            <Items>
                <asp:MenuItem Text="Menú Tipo Mascotas" Value="0">
                    <asp:MenuItem Text="Registrar" Value="1"></asp:MenuItem>                    
                    <asp:MenuItem Text="Modificar" Value="2"></asp:MenuItem>
                    <asp:MenuItem Text="Eliminar" Value="3"></asp:MenuItem>
                    <asp:MenuItem Text="Consultar" Value="4"></asp:MenuItem>
                </asp:MenuItem>
            </Items>
        </asp:Menu>
        <div class="form-row">
            <asp:Label ID="lblAccionMenu" runat="server" Text="" Visible="false" CssClass="col-md-12" Font-Size="XX-Large"></asp:Label>
        </div>
        <asp:DropDownList ID="cboTipoMascotas" runat="server" required="required" Visible="false" style="width:200px" ></asp:DropDownList>
        <asp:Button ID="btnConsultar" runat="server" Visible="false" Text="Continuar" BorderWidth="20px" BorderColor="#FFFFFF" CssClass="btn btn-info" />
    </div>

    <div id="divTipoMascotas" runat="server" visible="false">
        <div class="form-row">
            <div class="col-md-12 mb-3">
                <label for="txtTipoMascosta">Tipo de Mascota</label>
                <asp:TextBox runat="server" class="form-control" ID="txtTipoMascosta" placeholder="Tipo de Mascota" required="required" pattern="[A-Za-záéíóúÁÉÍÓÚ ]{1,20}"></asp:TextBox>
                <div class="invalid-feedback">
                    Indique un tipo valido de mascota. 
                </div>
            </div>
        </div>

        <div>
            <asp:Button ID="btnMantenimientoTipoMascotas" runat="server" CssClass="btn btn-info" Text="Registrar" />
        </div>



    <!-- Manejo de errores  -->
        <div id="lblError" runat="server" visible="false" class="alert alert-danger" role="alert">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
