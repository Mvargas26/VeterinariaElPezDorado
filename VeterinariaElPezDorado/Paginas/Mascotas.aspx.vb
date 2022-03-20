Public Class Mascotas
    Inherits System.Web.UI.Page
    Dim shtValor As Short
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.lblError.Visible = False


        Catch ex As Exception
            'envio a la pag de error porque hubo problemas cuando apenas se estaba construyendo
            Session("Error") = ex
            Response.Redirect("~/Paginas/frmPaginaError", False)
        End Try
    End Sub

    Protected Sub mnSeleccion_MenuItemClick(sender As Object, e As MenuEventArgs) Handles mnSeleccion.MenuItemClick
        Try
            Me.Limpiar()
            Me.txtFechaNacimiento.Visible = False
            Me.lblFechaNacimiento.Visible = False
            Me.btnMantenimientoMascotas.Visible = True
            Me.Mascotas.Visible = False
            Me.txtIdentificacionConsulta.Visible = False
            Me.btnConsultar.Visible = False
            shtValor = Me.mnSeleccion.SelectedValue
            Select Case Me.mnSeleccion.SelectedValue
                Case 1
                    Me.Mascotas.Visible = True
                    Me.btnMantenimientoMascotas.Text = "Registrar"
                    Me.txtFechaNacimiento.Visible = True
                Case 2
                    Me.txtIdentificacionConsulta.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoMascotas.Text = "Eliminar"
                Case 3
                    Me.txtIdentificacionConsulta.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoMascotas.Text = "Modificar"
                Case 4
                    Me.txtIdentificacionConsulta.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoMascotas.Visible = False
            End Select

        Catch ex As Exception
            Me.lblError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Me.btnConsultar.Visible = False
        Me.txtIdentificacionConsulta.Visible = False
        Me.txtidentificacionDueno.Text = "101230456"
        Me.txtNombreMascota.Text = "Luna"
        Me.txtPeso.Text = 10
        Me.txtEstadoSalud.Text = "Esta saludable, y con cabello fuerte."
        Dim fecha As Date = Convert.ToDateTime("10/03/2022")
        Me.txtFechaNacimiento.Text = fecha.ToShortDateString
        Me.Mascotas.Visible = True
    End Sub

    Protected Sub btnMantenimientoMascotas_Click(sender As Object, e As EventArgs) Handles btnMantenimientoMascotas.Click
        Me.Limpiar()
        Try
            If Page.IsValid Then
                shtValor = Me.mnSeleccion.SelectedValue
                Me.lblMensajeError.Visible = False
                Select Case shtValor
                    Case 1
                        ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('Se registro correctamente');", True)
                    Case 2
                        ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('Se eliminó correctamente');", True)
                    Case 3
                        ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('Se modificó correctamente');", True)
                End Select
            End If

            Me.Limpiar()

        Catch ex As Exception
            'estas no van a otra apgina xq son cosas que se arreglan en la misma
            Me.lblError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try
    End Sub

    Protected Sub Limpiar()
        Me.txtidentificacionDueno.Text = ""
        Me.txtNombreMascota.Text = ""
        Me.txtPeso.Text = 0
        Me.txtEstadoSalud.Text = ""
        Me.txtFechaNacimiento.Text = ""
    End Sub


End Class