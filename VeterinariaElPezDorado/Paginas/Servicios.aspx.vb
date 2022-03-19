Public Class Servicios
    Inherits System.Web.UI.Page
    Dim shtValor As Short
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.lblError.Visible = False
            Me.cboServicios.Items.Clear()
            Me.cboServicios.Items.Add("Peluqueria")
            Me.cboServicios.Items.Add("Revisión médica")

        Catch ex As Exception
            'envio a la pag de error porque hubo problemas cuando apenas se estaba construyendo
            Session("Error") = ex
            Response.Redirect("~/Paginas/frmPaginaError", False)
        End Try
    End Sub

    Protected Sub mnSeleccion_MenuItemClick(sender As Object, e As MenuEventArgs) Handles mnSeleccion.MenuItemClick
        Try
            Me.btnMantenimientoServicios.Visible = True
            Me.divServicios.Visible = False
            Me.cboServicios.Visible = False
            Me.btnConsultar.Visible = False
            shtValor = Me.mnSeleccion.SelectedValue
            Select Case Me.mnSeleccion.SelectedValue
                Case 1
                    Me.divServicios.Visible = True
                    Me.btnMantenimientoServicios.Text = "Registrar"

                Case 2
                    Me.cboServicios.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoServicios.Text = "Eliminar"
                Case 3
                    Me.cboServicios.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoServicios.Text = "Modificar"
                Case 4
                    Me.cboServicios.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoServicios.Visible = False
            End Select

        Catch ex As Exception
            Me.lblError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try
    End Sub

End Class