Public Class TiposMascotas
    Inherits System.Web.UI.Page
    Dim shtValor As Short
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.lblError.Visible = False
            Me.cboTipoMascotas.Items.Clear()
            Me.cboTipoMascotas.Items.Add("Tortuga")
            Me.cboTipoMascotas.Items.Add("Pez")
            Me.cboTipoMascotas.Items.Add("Conejo")
            Me.cboTipoMascotas.Items.Add("Ave")
            Me.cboTipoMascotas.Items.Add("Perro")
            Me.cboTipoMascotas.Items.Add("Gato")
            Me.cboTipoMascotas.Items.Add("Ratón")
        Catch ex As Exception
            Session("Error") = ex 'las variables de sesion permiten pasar info de una pagina a otra
            Response.Redirect("~/Paginas/frmPaginaError", False)
        End Try
    End Sub

    Protected Sub mnSeleccion_MenuItemClick(sender As Object, e As MenuEventArgs) Handles mnSeleccion.MenuItemClick
        Try
            Me.btnMantenimientoTipoMascotas.Visible = True
            Me.divTipoMascotas.Visible = False
            Me.cboTipoMascotas.Visible = False
            Me.btnConsultar.Visible = False
            shtValor = Me.mnSeleccion.SelectedValue
            Select Case Me.mnSeleccion.SelectedValue
                Case 1
                    Me.divTipoMascotas.Visible = True
                    Me.btnMantenimientoTipoMascotas.Text = "Registrar"

                Case 2
                    Me.cboTipoMascotas.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoTipoMascotas.Text = "Eliminar"
                    Me.lblAccionMenu.Text = "Eliminar"
                    Me.lblAccionMenu.Visible = True
                Case 3
                    Me.cboTipoMascotas.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoTipoMascotas.Text = "Modificar"
                    Me.lblAccionMenu.Text = "Modificar"
                    Me.lblAccionMenu.Visible = True
                Case 4
                    Me.cboTipoMascotas.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoTipoMascotas.Visible = False
                    Me.lblAccionMenu.Text = "Consulta"
                    Me.lblAccionMenu.Visible = True
            End Select

        Catch ex As Exception
            Me.lblError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnMantenimientoTipoMascotas_Click(sender As Object, e As EventArgs) Handles btnMantenimientoTipoMascotas.Click

    End Sub

    Protected Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click

    End Sub
End Class