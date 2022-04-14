Public Class Servicios
    Inherits System.Web.UI.Page
    Dim shtValor As Short
    Dim iServicio As New Negocios.ServiciosNegocios
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.lblError.Visible = False
            'Me.cboServicios.Items.Clear()
            'Me.cboServicios.Items.Add("Peluqueria")
            'Me.cboServicios.Items.Add("Revisión médica")

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
                    Me.btnMantenimientoServicios.Text = "Modificar"
                    Me.lblAccionMenu.Visible = True
                    Me.lblAccionMenu.Text = "Modificar"

                    Me.cargarDatos()
                Case 3
                    Me.cboServicios.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoServicios.Text = "Eliminar"
                    Me.lblAccionMenu.Visible = True
                    Me.lblAccionMenu.Text = "Eliminar"


                    Me.cargarDatos()
                Case 4
                    Me.cboServicios.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoServicios.Visible = False
                    Me.lblAccionMenu.Visible = True
                    Me.lblAccionMenu.Text = "Consultar"

                    Me.cargarDatos()
            End Select

        Catch ex As Exception
            Me.lblError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try
    End Sub
    ''' <summary>
    ''' Limpia los datos de los txt.
    ''' </summary>
    Protected Sub limpiar()
        Me.txtNombreServicio.Text = ""
        Me.txtCosto.Text = 0
        Me.txtPorcentajeImpuesto.Text = "0"
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
                Dim dtServicio As DataTable = iServicio.consultarServicios(cboServicios.SelectedValue)
                Me.btnConsultar.Visible = False
                Me.cboServicios.Visible = False
                Me.txtNombreServicio.Text = dtServicio.Rows(0)(1)
                Me.txtCosto.Text = dtServicio.Rows(0)(2)
                Me.txtPorcentajeImpuesto.Text = dtServicio.Rows(0)(3)
                Me.divServicios.Visible = True
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
    Protected Sub btnMantenimientoServicios_Click(sender As Object, e As EventArgs) Handles btnMantenimientoServicios.Click
        Try
            Me.lblMensajeError.Visible = False
            shtValor = Me.mnSeleccion.SelectedValue
            If Page.IsValid Then
                Select Case shtValor
                    Case 1
                        Dim eServicios As New Entidades.Servicios
                        eServicios.Servicios(0, txtNombreServicio.Text, txtCosto.Text, txtPorcentajeImpuesto.Text)
                        iServicio.grabarServicios(shtValor, eServicios)

                        ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('Se registro correctamente');", True)
                    Case 2
                        Dim eServicios As New Entidades.Servicios
                        eServicios.Servicios(cboServicios.SelectedValue, txtNombreServicio.Text, txtCosto.Text, txtPorcentajeImpuesto.Text)
                        iServicio.grabarServicios(shtValor, eServicios)

                        ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('Se modificó correctamente');", True)
                    Case 3
                        Dim eServicios As New Entidades.Servicios
                        eServicios.Servicios(cboServicios.SelectedValue, txtNombreServicio.Text, txtCosto.Text, txtPorcentajeImpuesto.Text)
                        iServicio.grabarServicios(shtValor, eServicios)

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
    ''' Se carga los datos en el cboServicios
    ''' </summary>
    Protected Sub cargarDatos()
        Me.cboServicios.Items.Clear()
        Me.cboServicios.DataSource = iServicio.consultarServicios
        Me.cboServicios.DataTextField = "nombre_servicio"
        Me.cboServicios.DataValueField = "cod_servicios"
        Me.DataBind()
    End Sub
End Class