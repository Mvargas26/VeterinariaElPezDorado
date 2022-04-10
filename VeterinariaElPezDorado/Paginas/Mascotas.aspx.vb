Imports Negocios


Public Class Mascotas
    Inherits System.Web.UI.Page
    Dim shtValor As Short
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

    Protected Sub mnSeleccion_MenuItemClick(sender As Object, e As MenuEventArgs) Handles mnSeleccion.MenuItemClick
        Try
            Me.Limpiar()
            Me.txtFechaNacimiento.Visible = False
            Me.lblFechaNacimiento.Visible = False
            Me.btnMantenimientoMascotas.Visible = True
            Me.Mascotas.Visible = False
            Me.txtIdentificacionConsultaCliente.Visible = False
            Me.txtIndentificacionMascotaAConsultar.Visible = False
            Me.btnConsultar.Visible = False
            shtValor = Me.mnSeleccion.SelectedValue

            Select Case Me.mnSeleccion.SelectedValue
                Case 1
                    Me.Mascotas.Visible = True
                    Me.btnMantenimientoMascotas.Text = "Registrar"
                    Me.txtFechaNacimiento.Visible = True
                Case 2

                    Me.txtIdentificacionConsultaCliente.Visible = True
                    Me.txtIndentificacionMascotaAConsultar.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoMascotas.Text = "Modificar"

                    Me.txtidentificacionDueno.ReadOnly = True
                    Me.txtidentificacionMascota.ReadOnly = True

                Case 3
                    Me.txtIdentificacionConsultaCliente.Visible = True
                    Me.txtIndentificacionMascotaAConsultar.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoMascotas.Text = "Eliminar "

                    Me.txtidentificacionDueno.ReadOnly = True
                    Me.txtidentificacionMascota.ReadOnly = True
                    Me.txtNombreMascota.ReadOnly = True

                    Me.txtPeso.ReadOnly = True
                    Me.txtRaza.ReadOnly = True
                    Me.txtEstadoSalud.ReadOnly = True
                    Me.txtFechaNacimiento.ReadOnly = True
                Case 4
                    Me.txtIdentificacionConsultaCliente.Visible = True
                    Me.txtIndentificacionMascotaAConsultar.Visible = True
                    Me.btnConsultar.Visible = True
                    Me.btnMantenimientoMascotas.Visible = False
            End Select

        Catch ex As Exception
            Me.lblError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Try
            If Page.IsValid Then


                Me.btnConsultar.Visible = False
                Me.txtIdentificacionConsultaCliente.Visible = False
                Me.txtIndentificacionMascotaAConsultar.Visible = False

                If ClienteValidado() Then
                    Dim iClienteVeterinaria As New Entidades.ClienteVeterinaria
                    iClienteVeterinaria.IdentificacionCliente = Me.txtIdentificacionConsultaCliente.Text


                    Dim iInfoMascotas As New Entidades.Mascotas
                    iInfoMascotas.IdentificacionDueno = iClienteVeterinaria
                    iInfoMascotas.CodigoMascota = CInt(Me.txtIndentificacionMascotaAConsultar.Text)

                    Dim objNegocios As New MascotasNegocios
                    iInfoMascotas = objNegocios.ConsultarMascota(iClienteVeterinaria.IdentificacionCliente, iInfoMascotas.CodigoMascota)

                    If Not iClienteVeterinaria.IdentificacionCliente = "" And Not iInfoMascotas.CodigoMascota = 0 Then
                        Me.txtidentificacionDueno.Text = iInfoMascotas.IdentificacionDueno.IdentificacionCliente
                        Me.txtidentificacionMascota.Text = iInfoMascotas.CodigoMascota
                        Me.txtNombreMascota.Text = iInfoMascotas.NombreMascota

                        Me.txtPeso.Text = iInfoMascotas.Peso
                        Me.txtRaza.Text = iInfoMascotas.Raza
                        Me.txtEstadoSalud.Text = iInfoMascotas.EstadoSalud
                        Me.txtFechaNacimiento.Text = iInfoMascotas.FechaNacimiento
                    End If

                    Me.Mascotas.Visible = True
                    Me.txtIndentificacionMascotaAConsultar.Visible = False
                    Me.txtIdentificacionConsultaCliente.Visible = False
                Else
                    'si no hay un cliente para esa cedula cae aqui
                    ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('No hay cliente registrado con esa Cedula');", True)
                End If
            End If
        Catch ex As Exception
            Me.lblError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnMantenimientoMascotas_Click(sender As Object, e As EventArgs) Handles btnMantenimientoMascotas.Click
        Try
            If Page.IsValid Then
                shtValor = Me.mnSeleccion.SelectedValue
                Me.lblMensajeError.Visible = False

                If ClienteValidado() Then
                    If Not shtValor = 1 Then 'Si es registrar no iguala los valores xq estan vacios
                        Me.txtidentificacionDueno.Text = Me.txtidentificacionDueno.Text
                        Me.txtidentificacionMascota.Text = Me.txtIndentificacionMascotaAConsultar.Text
                    End If
                End If

                'Si el cliente no existe, no permite registrar una mascota
                If ClienteValidado() = False And shtValor = 1 Then
                    ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('Por favor registre el Dueño como Cliente Primero');", True)
                    Exit Sub
                End If


                Dim InfoMascota As New Entidades.Mascotas With {
                .IdentificacionDueno = New Entidades.ClienteVeterinaria With {.IdentificacionCliente = CStr(Me.txtidentificacionDueno.Text)},
                .CodigoMascota = CInt(Me.txtidentificacionMascota.Text),
                .NombreMascota = CStr(Me.txtNombreMascota.Text),
                .TipoMascota = CShort(Me.cboTipoMascota.SelectedValue),
                .Peso = CInt(Me.txtPeso.Text),
                .Raza = CStr(Me.txtRaza.Text),
                .EstadoSalud = CStr(Me.txtEstadoSalud.Text),
                .FechaNacimiento = CDate(Me.txtFechaNacimiento.Text)
                }

                Dim objNegocios As New Negocios.MascotasNegocios


                Select Case shtValor
                    Case 1
                        'llama al metodo que registra mascotas
                        objNegocios.RegistrarMascota(InfoMascota)

                        ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('Se registro correctamente');", True)
                    Case 2
                        'llama al metodo que modifica registro mascotas
                        objNegocios.MOdificarMascota(InfoMascota)

                        ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('Se modificó correctamente');", True)
                    Case 3
                        'llama al metodo queelimina registro mascotas
                        objNegocios.EliminarMascota(InfoMascota)

                        ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('Se eliminó  correctamente');", True)
                End Select
            End If

            Me.Limpiar()

        Catch ex As Exception
            'estas no van a otra apgina xq son cosas que se arreglan en la misma
            Me.lblError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try
    End Sub


#Region "Metodos popios de  Pag Mascotas"
    Protected Sub Limpiar()
        Me.txtidentificacionDueno.Text = ""
        Me.txtidentificacionMascota.Text = ""
        Me.txtNombreMascota.Text = ""
        Me.txtPeso.Text = 0
        Me.txtEstadoSalud.Text = ""
        Me.txtFechaNacimiento.Text = ""
    End Sub


    'funcion que comprueba que el numero de cedula ingresado ya este como un cliente de la veterinaria
    Protected Function ClienteValidado() As Boolean
        Dim strCedulaAConsultar As String = Me.txtIdentificacionConsultaCliente.Text

        'en el caso de registro no se uso el texbox de consulta, usamos directamnete el texbox donde se ingresa cedula del cliente
        If Me.txtIdentificacionConsultaCliente.Text = "" Then
            strCedulaAConsultar = Me.txtidentificacionDueno.Text
        End If

        'objeto de negocios con la info de los clientes
        Dim objNegocios As New ClientesNegocios
        Dim dtClientes As DataTable = objNegocios.ConsultarClientes

        For Each drClientes As DataRow In dtClientes.Rows
            If strCedulaAConsultar = CStr(drClientes("identificacion")) Then
                Return True
                Exit Function
            End If
        Next
        Return False
    End Function

#End Region





End Class