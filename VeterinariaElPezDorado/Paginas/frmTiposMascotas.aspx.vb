Public Class TiposMascotas
    Inherits System.Web.UI.Page
    Dim shtValor As Short
    Dim iTipoMascota As New Negocios.TipoMascotaNegocios
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.lblError.Visible = False

            Dim iUsuario As Entidades.Usuarios = CType(Session("UsuarioLogueado"), Entidades.Usuarios)

            If iUsuario Is Nothing Then
                FormsAuthentication.RedirectToLoginPage()
            End If
        Catch ex As Exception
            Session("Error") = ex 'las variables de sesion permiten pasar info de una pagina a otra
            Response.Redirect("~/Paginas/frmPaginaError", False)
        End Try
    End Sub
    ''' <summary>
    ''' Evento para selecionar la funcionalidad que se va a aplicar en el mantenimiento.
    ''' Al seleccionar la opcion en el menu se toma el valor dado en dicha opcion. Y se filtra por cada select.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub mnSeleccion_MenuItemClick(sender As Object, e As MenuEventArgs) Handles mnSeleccion.MenuItemClick
        Try
            Me.limpiar()
            Me.lblAccionMenu.Visible = False
            Me.btnMantenimientoTipoMascotas.Visible = True
            Me.divTipoMascotas.Visible = False
            Me.cboTipoMascotas.Visible = False
            Me.btnConsultar.Visible = False
            Me.txtTipoMascosta.ReadOnly = False
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
    ''' <summary>
    ''' Funcionalidad del boton mantenimiento (Registrar, Eliminar y modificar.)
    ''' La opcion que se haya utilizado se filtra por el select y se envia el parametro accion, segun haya seleccionado. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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
    ''' <summary>
    ''' Funcionalidad de boton consultar.
    ''' Para realizar los mantenimientos (Eliminar, modificar, consultar), se debe seleccionar a quien se le va a realizar los mantenimientos.
    ''' Se realiza una consulta a la base de datos, con la opcion que se haya realizado para mostrar los datos de dicha opcion.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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
    ''' <summary>
    ''' Limpia los datos de los txt.
    ''' </summary>
    Protected Sub limpiar()
        txtTipoMascosta.Text = ""
    End Sub
    ''' <summary>
    ''' Carga los datos en el dropDownList tipo de mascotas
    ''' </summary>
    Protected Sub cargarDatos()
        Me.cboTipoMascotas.Items.Clear()
        Me.cboTipoMascotas.DataSource = iTipoMascota.consultarTipoMascota
        Me.cboTipoMascotas.DataTextField = "nombre_tipo_mascota"
        Me.cboTipoMascotas.DataValueField = "cod_tipo"
        Me.DataBind()
    End Sub

End Class