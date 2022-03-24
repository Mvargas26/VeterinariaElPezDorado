Public Class Servicios
    Inherits System.Web.UI.Page
    Dim shtValor As Short
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.lblError.Visible = False
            Me.cboServicios.Items.Clear()
            Me.cboServicios.Items.Add("Peluqueria")
            Me.cboServicios.Items.Add("Revisión médica")

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

    Protected Sub mnSeleccion_MenuItemClick(sender As Object, e As MenuEventArgs) Handles mnSeleccion.MenuItemClick
        Try
            Me.limpiar()
            Me.btnMantenimientoServicios.Visible = True
            Me.divServicios.Visible = False
            Me.cboServicios.Visible = False
            Me.btnConsultar.Visible = False
            shtValor = Me.mnSeleccion.SelectedValue
            Select Case Me.mnSeleccion.SelectedValue
                Case 1
                    Me.lblAccionMenu.Visible = False
                    Me.divServicios.Visible = True
                    Me.btnMantenimientoServicios.Text = "Registrar"

                Case 2
                    Me.cboServicios.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoServicios.Text = "Eliminar"
                    Me.lblAccionMenu.Visible = True
                    Me.lblAccionMenu.Text = "Eliminar"
                Case 3
                    Me.cboServicios.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoServicios.Text = "Modificar"
                    Me.lblAccionMenu.Visible = True
                    Me.lblAccionMenu.Text = "Modificar"
                Case 4
                    Me.cboServicios.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoServicios.Visible = False
                    Me.lblAccionMenu.Visible = True
                    Me.lblAccionMenu.Text = "Consultar"
            End Select

        Catch ex As Exception
            Me.lblError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try
    End Sub

    Protected Sub limpiar()
        Me.txtNombreServicio.Text = ""
        Me.txtCosto.Text = 0
        Me.txtPorcentajeImpuesto.Text = "0"
    End Sub

    Protected Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Try

            If Page.IsValid Then

                Me.btnConsultar.Visible = False
                Me.cboServicios.Visible = False
                Me.txtNombreServicio.Text = Me.cboServicios.Text
                Me.txtCosto.Text = 2500
                Me.txtPorcentajeImpuesto.Text = 10
                Me.divServicios.Visible = True
            End If

        Catch ex As Exception
            Me.lblError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnMantenimientoServicios_Click(sender As Object, e As EventArgs) Handles btnMantenimientoServicios.Click
        Try
            Me.lblMensajeError.Visible = False
            shtValor = Me.mnSeleccion.SelectedValue
            If Page.IsValid Then
                Select Case shtValor
                    Case 1
                        ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('Se registro correctamente');", True)
                    Case 2
                        ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('Se eliminó correctamente');", True)
                    Case 3
                        ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('Se modificó correctamente');", True)
                End Select
            End If

            Me.limpiar()

        Catch ex As Exception
            Me.lblError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try
    End Sub
End Class