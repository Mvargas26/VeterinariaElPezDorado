<%@ Page Title="Servicios" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmServicios.aspx.vb" Inherits="VeterinariaElPezDorado.Servicios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:Menu ID="mnSeleccion" runat="server" Font-Size="20pt" BorderWidth="60px" BorderColor="#FFFFFF">
            <Items>
                <asp:MenuItem Text="Menú Servicios" Value=0>
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
        <asp:DropDownList ID="cboServicios" runat="server" required="required" Visible="false" style="width:200px"></asp:DropDownList>
        <asp:Button ID="btnConsultar" runat="server" Visible="false" Text="Continuar" BorderWidth="20px" BorderColor="#FFFFFF" CssClass="btn btn-info" />
    </div>

    <div id="divServicios" runat="server" visible="false">
        <div class="form-row">
            <div class="col-md-4 mb-3">
                <label for="txtNombreServicio">Nombre del servicio</label>
                <asp:TextBox runat="server" class="form-control" ID="txtNombreServicio" placeholder="Nombre del Servicio" required="required" pattern="[A-Za-záéíóúÁÉÍÓÚñÑ ]{2,40}"></asp:TextBox>
                <div class="invalid-feedback">
                    Indique un nombre valido. 
                </div>
            </div>
            <div class="col-md-4 mb-3">
                <label for="txtCosto">Costo del Servicio</label>
                <asp:TextBox runat="server" class="form-control" ID="txtCosto" placeholder="Costo del servicio" pattern="[0-9]{2,8}" required="required"></asp:TextBox>
                <div class="invalid-feedback">
                    Indique el costo del servicio.
                </div>
            </div>

            <div class="col-md-4 mb-3">
                <label for="txtPorcentajeImpuesto">Impuesto del servicio</label>
                <asp:TextBox runat="server" class="form-control" ID="txtPorcentajeImpuesto" placeholder="Porcentaje de impuesto." required="required" pattern="[0-9]{1,2}"></asp:TextBox>
                <div class="invalid-feedback">
                    Indique el porcentaje tendrá el servicio (Solo utilice números del 1 al 99).                    
                </div>
                
            </div>
        </div>

        <div>
            <asp:Button ID="btnMantenimientoServicios" runat="server" CssClass="btn btn-info" Text="Registrar" />
        </div>


        <!-- Manejo de errores  -->
        <div id="lblError" runat="server" visible="false" class="alert alert-danger" role="alert">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
