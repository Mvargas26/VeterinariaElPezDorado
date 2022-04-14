Public Class Usuarios
    Inherits System.Web.UI.Page
    Dim shtValor As Short
    Dim iConsultaUsuario As New Negocios.UsuariosNegocios
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
    ''' <summary>
    ''' Evento para selecionar la funcionalidad que se va a aplicar en el mantenimiento.
    ''' Al seleccionar la opcion en el menu se toma el valor dado en dicha opcion. Y se filtra por cada select.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub mnSeleccion_MenuItemClick(sender As Object, e As MenuEventArgs) Handles mnSeleccion.MenuItemClick
        Try
            Me.limpiar()
            Me.btnMantenimientoUsuarios.Visible = True
            Me.divUsuarios.Visible = False
            Me.cboUsuarios.Visible = False
            Me.btnConsultar.Visible = False
            Me.lblAccionMenu.Visible = False
            Me.txtNombreUsuario.ReadOnly = False
            Me.txtClaveUsuario.ReadOnly = False
            shtValor = Me.mnSeleccion.SelectedValue
            Select Case Me.mnSeleccion.SelectedValue
                Case 1
                    Me.lblAccionMenu.Visible = False
                    Me.divUsuarios.Visible = True
                    Me.btnMantenimientoUsuarios.Text = "Registrar"

                Case 2
                    Me.cboUsuarios.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoUsuarios.Text = "Modificar"
                    Me.lblAccionMenu.Visible = True
                    Me.lblAccionMenu.Text = "Modificar"

                    Me.cboUsuarios.Items.Clear()
                    Me.cboUsuarios.DataSource = iConsultaUsuario.consultarUsuarios
                    Me.cboUsuarios.DataTextField = "nombre_usuario"
                    Me.cboUsuarios.DataValueField = "cod_usuario"
                    Me.DataBind()
                Case 3
                    Me.cboUsuarios.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoUsuarios.Text = "Eliminar"
                    Me.lblAccionMenu.Visible = True
                    Me.lblAccionMenu.Text = "Eliminar"
                    Me.txtNombreUsuario.ReadOnly = True
                    Me.txtClaveUsuario.ReadOnly = True

                    Me.cboUsuarios.Items.Clear()
                    Me.cboUsuarios.DataSource = iConsultaUsuario.consultarUsuarios
                    Me.cboUsuarios.DataTextField = "nombre_usuario"
                    Me.cboUsuarios.DataValueField = "cod_usuario"
                    Me.DataBind()
                Case 4
                    Me.cboUsuarios.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoUsuarios.Visible = False
                    Me.lblAccionMenu.Visible = True
                    Me.lblAccionMenu.Text = "Consultar"
                    Me.txtNombreUsuario.ReadOnly = True
                    Me.txtClaveUsuario.ReadOnly = True

                    Me.cboUsuarios.Items.Clear()
                    Me.cboUsuarios.DataSource = iConsultaUsuario.consultarUsuarios
                    Me.cboUsuarios.DataTextField = "nombre_usuario"
                    Me.cboUsuarios.DataValueField = "cod_usuario"
                    Me.DataBind()
            End Select

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
                Dim dtUsuario As DataTable = iConsultaUsuario.consultarUsuarios(cboUsuarios.SelectedValue)
                Me.btnConsultar.Visible = False
                Me.cboUsuarios.Visible = False
                Me.txtNombreUsuario.Text = dtUsuario.Rows(0)(1)
                Me.txtClaveUsuario.Text = dtUsuario.Rows(0)(2)
                Me.divUsuarios.Visible = True

            End If

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
    Protected Sub btnMantenimientoUsuarios_Click(sender As Object, e As EventArgs) Handles btnMantenimientoUsuarios.Click

        Try
            Me.lblMensajeError.Visible = False
            shtValor = Me.mnSeleccion.SelectedValue
            If Page.IsValid Then
                Select Case shtValor
                    Case 1
                        Dim iUsuario As New Entidades.Usuarios
                        iUsuario.Usuarios(txtNombreUsuario.Text, txtClaveUsuario.Text)
                        iUsuario.CodUsuario = 0
                        Dim iUsuarioNegocio As New Negocios.UsuariosNegocios
                        iUsuarioNegocio.grabarUsuarios(shtValor, iUsuario)
                        ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('Se registro correctamente');", True)
                    Case 2
                        Dim iUsuario As New Entidades.Usuarios
                        iUsuario.Usuarios(txtNombreUsuario.Text, txtClaveUsuario.Text)
                        iUsuario.CodUsuario = cboUsuarios.SelectedValue
                        Dim iUsuarioNegocio As New Negocios.UsuariosNegocios
                        iUsuarioNegocio.grabarUsuarios(shtValor, iUsuario)
                        ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('Se modificó correctamente');", True)
                    Case 3
                        Me.txtNombreUsuario.ReadOnly = True
                        Me.txtClaveUsuario.ReadOnly = True
                        Dim iUsuario As New Entidades.Usuarios
                        iUsuario.Usuarios(txtNombreUsuario.Text, txtClaveUsuario.Text)
                        iUsuario.CodUsuario = cboUsuarios.SelectedValue
                        Dim iUsuarioNegocio As New Negocios.UsuariosNegocios
                        iUsuarioNegocio.grabarUsuarios(shtValor, iUsuario)
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
    ''' Limpia los datos de los txt.
    ''' </summary>
    Protected Sub limpiar()
        Me.txtClaveUsuario.Text = ""
        Me.txtNombreUsuario.Text = ""
        Me.txtNombreUsuario.ReadOnly = False
        Me.txtClaveUsuario.ReadOnly = False
    End Sub

End Class