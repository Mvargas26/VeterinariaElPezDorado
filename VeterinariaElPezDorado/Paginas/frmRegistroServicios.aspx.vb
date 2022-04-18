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
            If dsServicios.Tables(0).Rows.Count <> 0 Then

                Dim lstArrayCosto As ArrayList = iServicios.calculoCosto(dsServicios.Tables(2).Rows(0)(2), dsServicios.Tables(2).Rows(0)(3), 0)
                Me.txtCodigoCobro.Visible = True
                Me.lblCodigoCobro.Visible = True
                If IsNumeric(dsServicios.Tables(1).Rows(0)(0)) Then
                    Me.txtCodigoCobro.Text = (Int(dsServicios.Tables(1).Rows(0)(0)) + 1)
                Else
                    Me.txtCodigoCobro.Text = 0
                End If
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
                Me.cboServicios.Text
            Else
                ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('No hay mascotas registradas para está identificación de cliente.');", True)
            End If

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
            Dim fechaActual As Date = Format(Now, “yyyy-MM-dd”)
            If Me.txtFechaServicio.Text >= fechaActual Then
                txtFechaServicio.ReadOnly = True
                If txtCostoTotal.Text = "" Then txtCostoTotal.Text = 0
                Dim dtServicios As DataTable = iServicios.consultarServicios(cboServicios.SelectedValue)
                Dim lstArrayCosto As ArrayList = iServicios.calculoCosto(dtServicios.Rows(0)(2), dtServicios.Rows(0)(3), txtCostoTotal.Text)
                txtCostoTotal.Text = lstArrayCosto.Item(2)
                Dim dtCantidad As DataTable = iServicios.consultaNumCobro
                Dim eServicioBrindado As New Entidades.ServicosBrindados
                eServicioBrindado.ServiciosBrindados(txtIdentificacionDueno.Text, cboMascota.SelectedValue, cboServicios.SelectedValue, txtFechaServicio.Text, txtCostoNeto.Text)
                Dim numServicio As Integer
                If IsNumeric(dtCantidad.Rows(0)(0)) Then
                    numServicio = dtCantidad.Rows(0)(0)
                Else
                    numServicio = -1
                End If
                If numServicio < txtCodigoCobro.Text Then
                    iServicios.grabarRegistroServicios(eServicioBrindado)
                    dtCantidad = iServicios.consultaNumCobro
                    Me.txtCodigoCobro.Text = dtCantidad.Rows(0)(0)
                End If
                eServicioBrindado.CodCobro = dtCantidad.Rows(0)(0)
                iServicios.grabarRegistroServiciosIndividuales(eServicioBrindado)
                Me.gdvServicios.DataSource = iServicios.consultaServiciosGrabados(txtCodigoCobro.Text)
                Me.gdvServicios.DataBind()
                Dim dsServicios As DataSet = iServicios.consultaRegistroServiciosBrindados(txtIdentificacionDueno.Text)
            Else
                ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('La fecha debe ser igual o mayor a la actual.');", True)
            End If
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