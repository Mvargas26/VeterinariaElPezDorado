﻿Imports System.IO
Imports Negocios

Public Class Clientes
    Inherits System.Web.UI.Page
    Dim shtValor As Short
    Dim iClientes As New Entidades.ClienteVeterinaria

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
    ''' Llama a mantenimiento, y le envia el parametro a utilizar.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Protected Sub btnMantenimientoCliente_Click(sender As Object, e As EventArgs) Handles btnMantenimientoCliente.Click
        Try
            Me.lblMensajeError.Visible = False
            shtValor = Me.mnSeleccion.SelectedValue
            'comprueba primero que lo del html es correcto, trabaja con los validadores e la pg
            If Page.IsValid Then
                iClientes.mantenimiento(shtValor)
                Select Case shtValor
                    Case 1
                        Dim iInfoCliente As New Entidades.ClienteVeterinaria With {
                    .IdentificacionCliente = Me.txtIdentificacion.Text,
                    .NombreCliente = Me.txtNombre.Text,
                    .ApellidosCliente = Me.txtPrimerApellido.Text + " " + Me.txtSegundoApellido.Text,
                    .Correoelectronico = Me.txtCorreo.Text,
                    .Telefono = CInt(IIf(String.IsNullOrEmpty(Me.txtTeléfono.Text.Trim), "0", Me.txtTeléfono.Text)),
                    .Direccion = New Entidades.Direccion With {
                    .Provincia = CStr(Me.cboProvincias.SelectedItem.Text),
                    .Canton = CStr(Me.cboCantones.SelectedItem.Text),
                    .Distrito = Me.txtDistrito.Text,
                    .DireccionExacta = Me.txtDireccion.Text}}

                        Dim objNegocios As New Negocios.ClientesNegocios
                        objNegocios.RegistrarCliente(iInfoCliente)


                        'Me.ModalRegistroSatisfactorio.Visible = True

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

    ''' <summary>
    ''' Llama consultar y trae los datos para asignarlos a los campos respectivos.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click

        Try

            If Page.IsValid Then

                Me.btnConsultar.Visible = False
                Me.txtIdentificacionConsulta.Visible = False
                Dim strId As String = Me.txtIdentificacionConsulta.Text
                iClientes.consultarCliente(CStr(strId))
                txtNombre.Text = iClientes.NombreCliente
                txtPrimerApellido.Text = iClientes.ApellidosCliente
                txtIdentificacion.Text = iClientes.IdentificacionCliente
                txtCorreo.Text = iClientes.Correoelectronico
                txtTeléfono.Text = iClientes.Telefono
                'cboProvincia.SelectedIndex = 1
                'cboCanton.SelectedIndex = 1
                txtDireccion.Text = iClientes.Direccion.DireccionExacta


                Me.Cliente.Visible = True

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
            Me.btnMantenimientoCliente.Visible = True
            Me.Cliente.Visible = False
            Me.txtIdentificacionConsulta.Visible = False
            Me.btnConsultar.Visible = False
            shtValor = Me.mnSeleccion.SelectedValue
            Select Case Me.mnSeleccion.SelectedValue
                Case 1
                    Me.Cliente.Visible = True
                    Me.btnMantenimientoCliente.Text = "Registrar"

                Case 2
                    Me.txtIdentificacionConsulta.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoCliente.Text = "Eliminar"
                Case 3
                    Me.txtIdentificacionConsulta.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoCliente.Text = "Modificar"
                Case 4
                    Me.txtIdentificacionConsulta.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoCliente.Visible = False
            End Select

        Catch ex As Exception
            Me.lblError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try

    End Sub

    Protected Sub Limpiar()
        Me.txtNombre.Text = ""
        Me.txtPrimerApellido.Text = ""
        Me.txtIdentificacion.Text = ""
        Me.txtCorreo.Text = ""
        Me.txtTeléfono.Text = ""
        Me.txtDireccion.Text = ""
        Me.txtDistrito.Text = ""
    End Sub

    Protected Sub cboCantones_Load(sender As Object, e As EventArgs) Handles cboCantones.Load
        Try
            cboCantones.Items.Clear()

            Dim URL As String = "C:\inetpub\wwwroot\VeterinariaElPezDorado\VeterinariaElPezDorado\ArchivosNecesarios\Cantones.xml"


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

    Protected Sub cboCantones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCantones.SelectedIndexChanged
        Try
            cboCantones.Items.Clear()

            Dim URL As String = "C:\inetpub\wwwroot\VeterinariaElPezDorado\VeterinariaElPezDorado\ArchivosNecesarios\Cantones.xml"


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