Public Class RegistroServicios
    Inherits System.Web.UI.Page
    Dim iServicios As New Negocios.ServiciosNegocios
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.lblError.Visible = False
            Dim iUsuario As Entidades.Usuarios = CType(Session("UsuarioLogueado"), Entidades.Usuarios)

            If iUsuario Is Nothing Then
                FormsAuthentication.RedirectToLoginPage()
            End If

        Catch ex As Exception
            'envio a la pag de error porque hubo problemas cuando apenas se estaba construyendo
            Session("Error") = ex
            Response.Redirect("~/Paginas/frmPaginaError", False)
        End Try
    End Sub
    ''' <summary>
    ''' Al dar click toma la identificacion del usuario y busca los datos para mostrarlos.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btnVerificar_Click(sender As Object, e As EventArgs) Handles btnVerificar.Click
        Try
            Me.lblError.Visible = False

            Dim dsServicios As DataSet = iServicios.consultaRegistroServiciosBrindados(txtIdentificacionDueno.Text)
            Dim lstArrayCosto As ArrayList = iServicios.calculoCosto(dsServicios.Tables(2).Rows(0)(2), dsServicios.Tables(2).Rows(0)(3), 0)
            Me.txtCodigoCobro.Visible = True
            Me.lblCodigoCobro.Visible = True
            Me.txtCodigoCobro.Text = ((dsServicios.Tables(1).Rows(0)(0)) + 1)
            Me.divRegistroServicios.Visible = True
            Me.txtIdentificacionDueno.ReadOnly = True
            Me.btnVerificar.Visible = False
            Me.cboMascota.DataSource = dsServicios.Tables(0)
            Me.cboMascota.DataTextField = "nombre_mascota"
            Me.cboMascota.DataValueField = "identificacion_mascotas"
            Me.cboMascota.DataBind()
            Me.cboServicios.DataSource = dsServicios.Tables(2)
            Me.cboServicios.DataTextField = "nombre_servicio"
            Me.cboServicios.DataValueField = "cod_servicios"
            Me.cboServicios.DataBind()
            Me.txtCostoServicio.Text = dsServicios.Tables(2).Rows(0)(2)
            Me.txtImpuesto.Text = lstArrayCosto.Item(0)
            Me.txtCostoNeto.Text = lstArrayCosto.Item(1)

        Catch ex As Exception
            'envio a la pag de error porque hubo problemas cuando apenas se estaba construyendo
            Session("Error") = ex
            Response.Redirect("~/Paginas/frmPaginaError", False)
        End Try



    End Sub
    ''' <summary>
    ''' Funcionalidad del boton mantenimiento. 
    ''' Al dar click se realiza el registro del servicios.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btnMantenimientoRegistrar_Click(sender As Object, e As EventArgs) Handles btnMantenimientoRegistrar.Click
        Try
            If txtCostoTotal.Text = "" Then txtCostoTotal.Text = 0
            Dim dtServicios As DataTable = iServicios.consultarServicios(cboServicios.SelectedValue)
            Dim lstArrayCosto As ArrayList = iServicios.calculoCosto(dtServicios.Rows(0)(2), dtServicios.Rows(0)(3), txtCostoTotal.Text)
            txtCostoTotal.Text = lstArrayCosto.Item(2)
            Dim dtCantidad As DataTable = iServicios.consultaNumCobro
            Dim eServicioBrindado As New Entidades.ServicosBrindados
            eServicioBrindado.CodCobro = txtCodigoCobro.Text
            eServicioBrindado.ServiciosBrindados(txtIdentificacionDueno.Text, cboMascota.SelectedValue, cboServicios.SelectedValue, txtFechaServicio.Text, txtCostoNeto.Text)
            If dtCantidad.Rows(0)(0) < txtCodigoCobro.Text Then
                iServicios.grabarRegistroServicios(eServicioBrindado)
            End If
            iServicios.grabarRegistroServiciosIndividuales(eServicioBrindado)
            Me.gdvServicios.DataSource = iServicios.consultaServiciosGrabados(txtCodigoCobro.Text)
            Me.gdvServicios.DataBind()

        Catch ex As Exception
            'envio a la pag de error porque hubo problemas cuando apenas se estaba construyendo
            Session("Error") = ex
            Response.Redirect("~/Paginas/frmPaginaError", False)
        End Try
    End Sub
    ''' <summary>
    ''' Se limpian los datos de los textbox
    ''' </summary>
    Protected Sub Limpiar()
        Me.txtCostoServicio.Text = 0
        Me.txtImpuesto.Text = "0"
        Me.txtIdentificacionDueno.Text = ""
    End Sub
    ''' <summary>
    ''' Se cargan los datos en las listas, para mostrarlas al usuario.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub cboServicios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboServicios.SelectedIndexChanged
        Try
            Dim dtServicios As DataTable = iServicios.consultarServicios(cboServicios.SelectedValue)
            Dim lstArrayCosto As ArrayList = iServicios.calculoCosto(dtServicios.Rows(0)(2), dtServicios.Rows(0)(3), 0)
            Me.txtCostoServicio.Text = dtServicios.Rows(0)(2)
            Me.txtImpuesto.Text = lstArrayCosto.Item(0)
            Me.txtCostoNeto.Text = lstArrayCosto.Item(1)
        Catch ex As Exception
            'envio a la pag de error porque hubo problemas cuando apenas se estaba construyendo
            Session("Error") = ex
            Response.Redirect("~/Paginas/frmPaginaError", False)
        End Try
    End Sub

End Class