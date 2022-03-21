Public Class Usuarios
    Inherits System.Web.UI.Page
    Dim shtValor As Short
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.lblError.Visible = False
            Me.cboUsuarios.Items.Clear()
            Me.cboUsuarios.Items.Add("admin")

        Catch ex As Exception
            'envio a la pag de error porque hubo problemas cuando apenas se estaba construyendo
            Session("Error") = ex
            Response.Redirect("~/Paginas/frmPaginaError", False)
        End Try
    End Sub

    Protected Sub mnSeleccion_MenuItemClick(sender As Object, e As MenuEventArgs) Handles mnSeleccion.MenuItemClick
        Try
            Me.btnMantenimientoUsuarios.Visible = True
            Me.divUsuarios.Visible = False
            Me.cboUsuarios.Visible = False
            Me.btnConsultar.Visible = False
            shtValor = Me.mnSeleccion.SelectedValue
            Select Case Me.mnSeleccion.SelectedValue
                Case 1
                    Me.lblAccionMenu.Visible = False
                    Me.divUsuarios.Visible = True
                    Me.btnMantenimientoUsuarios.Text = "Registrar"

                Case 2
                    Me.cboUsuarios.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoUsuarios.Text = "Eliminar"
                    Me.lblAccionMenu.Visible = True
                    Me.lblAccionMenu.Text = "Eliminar"
                Case 3
                    Me.cboUsuarios.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoUsuarios.Text = "Modificar"
                    Me.lblAccionMenu.Visible = True
                    Me.lblAccionMenu.Text = "Modificar"
                Case 4
                    Me.cboUsuarios.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoUsuarios.Visible = False
                    Me.lblAccionMenu.Visible = True
                    Me.lblAccionMenu.Text = "Consultar"
            End Select

        Catch ex As Exception
            Me.lblError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Try

            If Page.IsValid Then
                Me.btnConsultar.Visible = False
                Me.cboUsuarios.Visible = False
                Me.txtNombreUsuario.Text = Me.cboUsuarios.Text
                Me.txtClaveUsuario.Text = "admin"
                Me.divUsuarios.Visible = True
            End If

        Catch ex As Exception
            Me.lblError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try

    End Sub

    Protected Sub btnMantenimientoUsuarios_Click(sender As Object, e As EventArgs) Handles btnMantenimientoUsuarios.Click

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

    Protected Sub limpiar()
        Me.txtClaveUsuario.Text = ""
        Me.txtNombreUsuario.Text = ""
    End Sub

End Class