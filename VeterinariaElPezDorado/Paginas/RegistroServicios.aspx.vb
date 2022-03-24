Public Class RegistroServicios
    Inherits System.Web.UI.Page

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
            Me.divRegistroServicios.Visible = True
            Me.txtCostoServicio.Text = 10000
            Me.txtImpuesto.Text = "12%"
            Me.txtIdentificacionDueno.ReadOnly = True
            Me.btnVerificar.Visible = False
            Me.cboMascota.Items.Add("Susy")
            Me.cboMascota.Items.Add("Perlita")
            Me.cboServicios.Items.Add("Corte de uñas")

        Catch ex As Exception
            'envio a la pag de error porque hubo problemas cuando apenas se estaba construyendo
            Session("Error") = ex
            Response.Redirect("~/Paginas/frmPaginaError", False)
        End Try



    End Sub

    Protected Sub btnMantenimientoRegistrar_Click(sender As Object, e As EventArgs) Handles btnMantenimientoRegistrar.Click
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('Se registro correctamente');", True)
        Me.Limpiar()
    End Sub

    Protected Sub Limpiar()
        Me.txtCostoServicio.Text = 0
        Me.txtImpuesto.Text = "0"
        Me.txtIdentificacionDueno.Text = ""
    End Sub
End Class