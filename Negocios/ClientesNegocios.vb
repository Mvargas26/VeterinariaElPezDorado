Imports Datos
Imports Entidades

Public Class ClientesNegocios
    ''' <summary>
    ''' metodo Me va a dar todos los clientes que estan en la tabla que viene de Datos/DatosClientes/consultarClientes(sin parametro)
    ''' </summary>
    ''' <returns></returns>
    Public Function ConsultarClientes() As DataTable
        Try
            Dim iClientes As New DatosClientes

            Return iClientes.CoonsultarClientes
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Metodo que me va a retornar no un data table, si no un objeto de tipo cliente veterinaria
    ''' </summary>
    ''' <param name="Identificacion"></param>
    ''' <returns></returns>
    Public Function ConsultarCliente(ByVal Identificacion) As ClienteVeterinaria
        Try
            Dim iClientes As New DatosClientes
            Dim dtClientes As DataTable = iClientes.CoonsultarClientes(Identificacion.ToString)

            Dim iInfoCliente As ClienteVeterinaria = Nothing

            If dtClientes IsNot Nothing Then
                Dim drClientes As DataRow = dtClientes.Rows(0) ' objeto de tipo fila 

                If dtClientes.Rows.Count > 0 Then

                    iInfoCliente = New ClienteVeterinaria With {
                       .IdentificacionCliente = CStr(drClientes("identificacion")),
                    .NombreCliente = CStr(drClientes("nombre")),
                    .ApellidosCliente = CStr(drClientes("apellidos")),
                    .Correoelectronico = CStr(drClientes("correo")),
                    .Telefono = CInt(drClientes("telefono")),
                    .Direccion = New Direccion With {.Provincia = CStr(drClientes("cod_provincia")),
                    .Canton = CStr(drClientes("cod_canton")),
                    .Distrito = CStr(drClientes("distrito")),
                    .DireccionExacta = CStr(drClientes("direccion_Exacta"))}}

                End If

            End If

            If iInfoCliente Is Nothing Then
                Throw New NullReferenceException(String.Format("No se obtuvo info para el cliente :", Identificacion))
            End If
            Return iInfoCliente
        Catch ex As Exception
            Throw ex
        End Try

    End Function


#Region "Manejo Procedimientos almacenados Agregar,Modificar,Eliminar en Negocios"

    Private Sub MantenimientoCliente(Accion As Entidades.Enumeradores.Accion, Cliente As Entidades.ClienteVeterinaria)
        Dim objClienteDatos As New Datos.DatosClientes
        objClienteDatos.GrabarCliente(Accion, Cliente)
    End Sub


    Public Sub RegistrarCliente(Cliente As Entidades.ClienteVeterinaria)
        Me.MantenimientoCliente(Entidades.Enumeradores.Accion.Registrar, Cliente)
    End Sub

    Public Sub MOdificarCliente(Cliente As Entidades.ClienteVeterinaria)
        Me.MantenimientoCliente(Entidades.Enumeradores.Accion.Modificar, Cliente)
    End Sub

    Public Sub EliminarCliente(Cliente As Entidades.ClienteVeterinaria)
        Me.MantenimientoCliente(Entidades.Enumeradores.Accion.Eliminar, Cliente)
    End Sub
#End Region

End Class
