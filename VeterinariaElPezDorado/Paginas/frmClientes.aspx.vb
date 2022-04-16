Imports System.IO
Imports Negocios
Imports Entidades

Public Class Clientes
    Inherits System.Web.UI.Page
    Dim shtValor As Short
    Dim iClientes As New Entidades.ClienteVeterinaria

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.lblError.Visible = False
            Me.btnMantenimientoCliente.Visible = False

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
    ''' Llama a mantenimiento, y le envia el parametro a utilizar.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Protected Sub btnMantenimientoCliente_Click(sender As Object, e As EventArgs) Handles btnMantenimientoCliente.Click
        Try
            Me.lblMensajeError.Visible = False
            shtValor = Me.mnSeleccion.SelectedValue
            'comprueba primero que lo del html es correcto, trabaja con los validadores en la pg
            If Page.IsValid Then

                Dim iInfoCliente As New Entidades.ClienteVeterinaria With {
                    .IdentificacionCliente = Me.txtIdentificacion.Text,
                    .NombreCliente = Me.txtNombre.Text,
                    .ApellidosCliente = Me.txtApellidos.Text,
                    .Correoelectronico = Me.txtCorreo.Text,
                    .Telefono = CInt(IIf(String.IsNullOrEmpty(Me.txtTeléfono.Text.Trim), "0", Me.txtTeléfono.Text)),
                    .Direccion = New Entidades.Direccion With {
                    .Provincia = CStr(Me.cboProvincias.SelectedItem.Text),
                    .Canton = CStr(Me.cboCantones.SelectedItem.Text),
                    .Distrito = Me.txtDistrito.Text,
                    .DireccionExacta = Me.txtDireccion.Text}}


                Dim objNegocios As New Negocios.ClientesNegocios

                iClientes.mantenimiento(shtValor)
                Select Case shtValor
                    Case 1
                        objNegocios.RegistrarCliente(iInfoCliente)

                        ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('Se registro correctamente');", True)
                    Case 2
                        objNegocios.MOdificarCliente(iInfoCliente)

                        ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('Se modificó  correctamente');", True)
                    Case 3
                        objNegocios.EliminarCliente(iInfoCliente)

                        ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('Se eliminó correctamente');", True)
                End Select
            End If

            Me.Limpiar()

        Catch ex As Exception
            'estas no van a otra apgina xq son cosas que se arreglan en la misma
            Me.lblError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' Llama consultar y trae los datos para asignarlos a los campos respectivos.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click

        Try

            If Page.IsValid Then

                Dim strIdentificacionConsultar As String = Me.txtIdentificacionConsulta.Text
                Dim iInfoCliente As New Entidades.ClienteVeterinaria
                iInfoCliente.IdentificacionCliente = strIdentificacionConsultar

                Dim objNegocios As New ClientesNegocios
                iInfoCliente = objNegocios.ConsultarCliente(iInfoCliente.IdentificacionCliente)


                If Not iInfoCliente.IdentificacionCliente = "" Then 'Si el cliente existe
                    Cliente.Visible = True

                    Me.txtIdentificacion.Text = iInfoCliente.IdentificacionCliente
                    Me.txtIdentificacion.ReadOnly = True
                    Me.txtNombre.Text = iInfoCliente.NombreCliente
                    Me.txtApellidos.Text = iInfoCliente.ApellidosCliente
                    Me.txtCorreo.Text = iInfoCliente.Correoelectronico
                    Me.txtTeléfono.Text = iInfoCliente.Telefono
                    Me.txtDistrito.Text = iInfoCliente.Direccion.Distrito
                    Me.txtDireccion.Text = iInfoCliente.Direccion.DireccionExacta

                End If
                Me.btnMantenimientoCliente.Visible = True
                Me.txtIdentificacionConsulta.Visible = False
                Me.btnConsultar.Visible = False

            End If

        Catch ex As Exception
            Me.lblError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try

    End Sub

    ''' <summary>
    ''' Utiliza la opcion del menú, para mostrar en pantalla los campos.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub mnSeleccion_MenuItemClick(sender As Object, e As MenuEventArgs) Handles mnSeleccion.MenuItemClick
        Try
            Me.Limpiar()
            Me.btnMantenimientoCliente.Visible = False
            Me.Cliente.Visible = False
            Me.txtIdentificacionConsulta.Visible = False
            Me.btnConsultar.Visible = False
            shtValor = Me.mnSeleccion.SelectedValue
            Me.txtIdentificacion.ReadOnly = False
            Me.txtNombre.ReadOnly = False
            Me.txtApellidos.ReadOnly = False
            Me.txtCorreo.ReadOnly = False
            Me.txtTeléfono.ReadOnly = False
            Me.txtDistrito.ReadOnly = False
            Me.txtDireccion.ReadOnly = False

            Select Case Me.mnSeleccion.SelectedValue
                Case 1
                    Me.Cliente.Visible = True
                    Me.btnMantenimientoCliente.Text = "Registrar"
                    Me.btnMantenimientoCliente.Visible = True

                Case 2
                    Me.txtIdentificacionConsulta.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoCliente.Text = " Modificar"
                    Me.btnMantenimientoCliente.Visible = False
                Case 3
                    Me.txtIdentificacionConsulta.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoCliente.Text = "Eliminar"
                    Me.btnMantenimientoCliente.Visible = False

                    Me.txtIdentificacion.ReadOnly = True
                    Me.txtNombre.ReadOnly = True
                    Me.txtApellidos.ReadOnly = True
                    Me.txtCorreo.ReadOnly = True
                    Me.txtTeléfono.ReadOnly = True
                    Me.txtDistrito.ReadOnly = True
                    Me.txtDireccion.ReadOnly = True

            End Select

        Catch ex As Exception
            Me.lblError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try

    End Sub

    Protected Sub Limpiar()
        Me.txtNombre.Text = ""
        Me.txtApellidos.Text = ""
        Me.txtIdentificacion.Text = ""
        Me.txtCorreo.Text = ""
        Me.txtTeléfono.Text = ""
        Me.txtDireccion.Text = ""
        Me.txtDistrito.Text = ""
    End Sub

    Protected Sub cboProvincias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProvincias.SelectedIndexChanged
        Try
            cboCantones.Items.Clear()

            Dim URL As String = "C:\Users\Valdo\Downloads\VeterinariaElPezDorado\VeterinariaElPezDorado\ArchivosNecesarios\Cantones.xml"


            If File.Exists(URL) Then
                Dim ob_negocios As New ClientesNegocios
                Dim arr_infoEnInterfaz As ArrayList = ob_negocios.LeerXMLCanton(URL)


                For Each dato As String() In arr_infoEnInterfaz
                    If (cboProvincias.SelectedIndex) + 1 = dato(2) Then
                        Me.cboCantones.Items.Add(dato(0).ToString)
                    End If


                Next
            Else
                Throw New Exception
            End If

        Catch ex As Exception
            Me.lblError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try
    End Sub
End Class
'viewSate(" ") es el tipo de variables que nos permite guardar info en memoria para pasarlo a otro metodo o clase (vd 3 min 1:24)
'nota:esta info viaja en la pag