<%@ Page Title="Registro de servicios" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="RegistroServicios.aspx.vb" Inherits="VeterinariaElPezDorado.RegistroServicios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-row">
        <div class="col-md-4 mb-3">
            <label runat="server" id="lblIdentificacion" for="txtIdentificacionDueno">Identificación dueño</label>
            <asp:TextBox ID="txtIdentificacionDueno" runat="server" class="form-control" placeholder="Identificación dueño" required="required" pattern="[A-Za-z0-9]{5,40}"></asp:TextBox>
            <div class="invalid-feedback">
                Indique una identificación valida
            </div>
        </div>
        

    </div>
    <asp:Button ID="btnVerificar" runat="server" Text="Verificar" />
    <div id="divRegistroServicios" runat="server" visible="false">
        <div class="form-row">
            <div class="col-md-4 mb-3">
                <label runat="server" id="lblMascota" for="cboMascota">Mascota</label>
                <asp:DropDownList ID="cboMascota" class="form-control" runat="server" required="required"></asp:DropDownList>
                <div class="invalid-feedback">
                    Seleccione una opción
                </div>
            </div>

            <div class="col-md-4 mb-3">
                <label runat="server" id="lblServicios" for="cboServicios">Servicio</label>
                <asp:DropDownList ID="cboServicios" runat="server" class="form-control"></asp:DropDownList>
                <div class="invalid-feedback">
                   Seleccione una opción
                </div>
            </div>
    
            <div class="col-md-4 mb-3">
                <label runat="server" id="lblFechaServicio" for="txtFechaServicio">Fecha del servicio</label>
                <asp:TextBox runat="server" class="form-control" ID="txtFechaServicio" placeholder="" required="required" TextMode="Date"></asp:TextBox>
                <div class="invalid-feedback">
                    Ingrese una fecha valida.
                </div>
            </div>
        </div>
        <div class="form-row">
            <div class="col-md-4 mb-3">
                <label runat="server" id="lblCostoServicio" for="Identificacion">Costo del servicio</label>
                <asp:TextBox runat="server" class="form-control" ID="txtCostoServicio" placeholder="Costo" required="required" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-md-4 mb-3">
                <label runat="server" id="lblImpuesto" for="Telefono">Impuesto</label>
                <asp:TextBox runat="server" class="form-control" ID="txtImpuesto" placeholder="10%" required="required" ReadOnly="True"></asp:TextBox>
            </div>            
        </div>       

        <div>
            <asp:Button ID="btnMantenimientoRegistrar" runat="server" CssClass="btn btn-info" Text="Registrar" />
        </div>



    <!-- Manejo de errores  -->
        <div id="lblError" runat="server" visible="false" class="alert alert-danger" role="alert">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>

        </div>
</asp:Content>
