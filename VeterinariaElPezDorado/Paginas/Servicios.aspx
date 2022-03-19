<%@ Page Title="Servicios" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Servicios.aspx.vb" Inherits="VeterinariaElPezDorado.Servicios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div>
        <asp:Menu ID="mnSeleccion" runat="server" Font-Size="20pt" BorderWidth="60px" BorderColor="#FFFFFF">
            <Items>
                <asp:MenuItem Text="Menú Servicios" Value="0">
                    <asp:MenuItem Text="Registrar" Value="1"></asp:MenuItem>
                    <asp:MenuItem Text="Eliminar" Value="2"></asp:MenuItem>
                    <asp:MenuItem Text="Actualizar" Value="3"></asp:MenuItem>
                    <asp:MenuItem Text="Consultar" Value="4"></asp:MenuItem>
                </asp:MenuItem>
            </Items>
        </asp:Menu>
        <asp:DropDownList ID="cboServicios" runat="server" required="required" Visible="false"></asp:DropDownList>        
        <asp:Button ID="btnConsultar" runat="server" Visible="false" Text="Button" BorderWidth="20px" BorderColor="#FFFFFF" />
    </div>

    <div id="divServicios" runat="server" visible="false">
    <div class="form-row">
            <div class="col-md-4 mb-3">
                <label for="txtNombreServicio">Nombre del servicio</label>
                <asp:TextBox runat="server" class="form-control" ID="txtNombreServicio" placeholder="Nombre del Servicio" required="required" pattern="[A-Za-z]{1,40}+"></asp:TextBox>
                <div class="invalid-feedback">
                    Indique un nombre valido. 
                </div>
            </div>
            <div class="col-md-4 mb-3">
                <label for="txtCosto">Peso</label>
                <asp:TextBox runat="server" class="form-control" ID="txtCosto" placeholder="Costo del servicio" pattern="[.]{0,1}+[0-9]+" required="required"></asp:TextBox>
                <div class="invalid-feedback">
                    Indique el costo del servicio.
                </div>
            </div>

            <div class="col-md-4 mb-3">
                <label for="txtPorcentajeImpuesto">Impuesto del servicio</label>
                <asp:TextBox runat="server" class="form-control" ID="txtPorcentajeImpuesto" placeholder="Porcentaje de impuesto." required="required" pattern="[1-9]{1,2}+"></asp:TextBox>
                <div class="invalid-feedback">
                    Indique el porcentaje tendrá el servicio (Solo utilice números del 1 al 99).
                </div>
            </div>
        </div>
        <div>
            <asp:Button ID="btnMantenimientoServicios" runat="server" CssClass="btn btn-info" Text="Registrar" />
        </div>

        <!-- Manejo de errores  -->
        <div id="Div1" runat="server" visible="false" class="alert alert-danger" role="alert">
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </div>


    <!-- Manejo de errores  -->
        <div id="lblError" runat="server" visible="false" class="alert alert-danger" role="alert">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
</asp:Content>
