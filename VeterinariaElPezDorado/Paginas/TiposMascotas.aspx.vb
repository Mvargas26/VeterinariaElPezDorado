Public Class TiposMascotas
    Inherits System.Web.UI.Page
    Dim shtValor As Short
    Dim iTipoMascota As New Negocios.TipoMascotaNegocios
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.lblError.Visible = False
            'Me.cboTipoMascotas.Items.Clear()
            'Me.cboTipoMascotas.Items.Add("Tortuga")
            'Me.cboTipoMascotas.Items.Add("Pez")
            'Me.cboTipoMascotas.Items.Add("Conejo")
            'Me.cboTipoMascotas.Items.Add("Ave")
            'Me.cboTipoMascotas.Items.Add("Perro")
            'Me.cboTipoMascotas.Items.Add("Gato")
            'Me.cboTipoMascotas.Items.Add("Ratón")

            Dim iUsuario As Entidades.Usuarios = CType(Session("UsuarioLogueado"), Entidades.Usuarios)

            If iUsuario Is Nothing Then
                FormsAuthentication.RedirectToLoginPage()
            End If
        Catch ex As Exception
            Session("Error") = ex 'las variables de sesion permiten pasar info de una pagina a otra
            Response.Redirect("~/Paginas/frmPaginaError", False)
        End Try
    End Sub

    Protected Sub mnSeleccion_MenuItemClick(sender As Object, e As MenuEventArgs) Handles mnSeleccion.MenuItemClick
        Try
            Me.limpiar()
            Me.lblAccionMenu.Visible = False
            Me.btnMantenimientoTipoMascotas.Visible = True
            Me.divTipoMascotas.Visible = False
            Me.cboTipoMascotas.Visible = False
            Me.btnConsultar.Visible = False
            shtValor = Me.mnSeleccion.SelectedValue
            Select Case Me.mnSeleccion.SelectedValue
                Case 1
                    Me.lblAccionMenu.Visible = False
                    Me.divTipoMascotas.Visible = True
                    Me.btnMantenimientoTipoMascotas.Text = "Registrar"


                Case 2
                    Me.cboTipoMascotas.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoTipoMascotas.Text = "Modificar"
                    Me.lblAccionMenu.Text = "Modificar"
                    Me.lblAccionMenu.Visible = True

                    Me.cargarDatos()
                Case 3
                    Me.cboTipoMascotas.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoTipoMascotas.Text = "Eliminar"
                    Me.lblAccionMenu.Text = "Eliminar"
                    Me.lblAccionMenu.Visible = True
                    Me.txtTipoMascosta.ReadOnly = True

                    Me.cargarDatos()
                Case 4
                    Me.cboTipoMascotas.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoTipoMascotas.Visible = False
                    Me.lblAccionMenu.Text = "Consulta"
                    Me.lblAccionMenu.Visible = True
                    Me.txtTipoMascosta.ReadOnly = True

                    Me.cargarDatos()
            End Select

        Catch ex As Exception
            Me.lblError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnMantenimientoTipoMascotas_Click(sender As Object, e As EventArgs) Handles btnMantenimientoTipoMascotas.Click
        Try
            Me.lblMensajeError.Visible = False
            shtValor = Me.mnSeleccion.SelectedValue

            If Page.IsValid Then
                Select Case shtValor
                    Case 1
                        Dim eTipoMascota As New Entidades.TipoMascota
                        eTipoMascota.DescripcionTipoMascota = txtTipoMascosta.Text
                        eTipoMascota.CodigotipoMascota = 0
                        iTipoMascota.grabarTipoMascota(shtValor, eTipoMascota)
                        ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('Se registro correctamente');", True)
                    Case 2
                        Dim eTipoMascota As New Entidades.TipoMascota
                        eTipoMascota.DescripcionTipoMascota = txtTipoMascosta.Text
                        eTipoMascota.CodigotipoMascota = cboTipoMascotas.SelectedValue
                        iTipoMascota.grabarTipoMascota(shtValor, eTipoMascota)
                        ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('Se modificó correctamente');", True)
                    Case 3
                        Dim eTipoMascota As New Entidades.TipoMascota
                        eTipoMascota.DescripcionTipoMascota = txtTipoMascosta.Text
                        eTipoMascota.CodigotipoMascota = cboTipoMascotas.SelectedValue
                        iTipoMascota.grabarTipoMascota(shtValor, eTipoMascota)
                        ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('Se eliminó correctamente');", True)
                End Select
            End If

            Me.limpiar()

        Catch ex As Exception
            Me.lblError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try

    End Sub

    Protected Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Try

            If Page.IsValid Then
                Dim dtTipoMascota As DataTable = iTipoMascota.consultarTipoMascota(cboTipoMascotas.SelectedValue)
                Me.btnConsultar.Visible = False
                Me.cboTipoMascotas.Visible = False
                Me.txtTipoMascosta.Text = dtTipoMascota.Rows(0)(1)
                Me.divTipoMascotas.Visible = True
            End If

        Catch ex As Exception
            Me.lblError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try
    End Sub

    Protected Sub limpiar()
        txtTipoMascosta.Text = ""
    End Sub

    Protected Sub cargarDatos()
        Me.cboTipoMascotas.Items.Clear()
        Me.cboTipoMascotas.DataSource = iTipoMascota.consultarTipoMascota
        Me.cboTipoMascotas.DataTextField = "nombre_tipo_mascota"
        Me.cboTipoMascotas.DataValueField = "cod_tipo"
        Me.DataBind()
    End Sub

End Class