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
End Class