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

    Protected Sub btnVerificar_Click(sender As Object, e As EventArgs) Handles btnVerificar.Click
        Try
            Me.lblError.Visible = False

            Dim dsServicios As DataSet = iServicios.consultaRegistroServiciosBrindados(txtIdentificacionDueno.Text)
            Dim lstArrayCosto As ArrayList = iServicios.calculoCosto(dsServicios.Tables(2).Rows(0)(2), dsServicios.Tables(2).Rows(0)(3))
            Me.txtCodigoCobro.Visible = True
            Me.lblCodigoCobro.Visible = True
            Me.txtCodigoCobro.Text = ((dsServicios.Tables(1).Rows.Count) + 1)
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
            Me.txtCostoTotal.Text = lstArrayCosto.Item(1)

        Catch ex As Exception
            'envio a la pag de error porque hubo problemas cuando apenas se estaba construyendo
            Session("Error") = ex
            Response.Redirect("~/Paginas/frmPaginaError", False)
        End Try



    End Sub

    Protected Sub btnMantenimientoRegistrar_Click(sender As Object, e As EventArgs) Handles btnMantenimientoRegistrar.Click
        Dim eServicioBrindado As New Entidades.ServicosBrindados
        eServicioBrindado.ServiciosBrindados(txtIdentificacionDueno.Text, cboMascota.SelectedValue, cboServicios.SelectedValue, txtFechaServicio.Text)
        iServicios.grabarRegistroServicios(eServicioBrindado)

        ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('Se registro correctamente');", True)
        Me.Limpiar()
    End Sub

    Protected Sub Limpiar()
        Me.txtCostoServicio.Text = 0
        Me.txtImpuesto.Text = "0"
        Me.txtIdentificacionDueno.Text = ""
    End Sub

    Protected Sub cboServicios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboServicios.SelectedIndexChanged
        Dim dtServicios As DataTable = iServicios.consultarServicios(cboServicios.SelectedValue)
        Dim lstArrayCosto As ArrayList = iServicios.calculoCosto(dtServicios.Rows(0)(2), dtServicios.Rows(0)(3))
        Me.txtCostoServicio.Text = dtServicios.Rows(0)(2)
        Me.txtImpuesto.Text = lstArrayCosto.Item(0)
        Me.txtCostoTotal.Text = lstArrayCosto.Item(1)
    End Sub
End Class