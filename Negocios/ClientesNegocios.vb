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
            Dim dtClientes As DataTable = iClientes.CoonsultarClientes

            Dim iInfoCliente As ClienteVeterinaria = Nothing

            If dtClientes IsNot Nothing Then
                Dim drClientes As DataRow = dtClientes.Rows(0) ' objeto de tipo fila 

                If dtClientes.Rows.Count > 0 Then


                    iInfoCliente = New ClienteVeterinaria With {
                       .IdentificacionCliente = CInt(drClientes("Identificacion")),
                    .NombreCliente = CStr(drClientes("Nombre")),
                    .ApellidosCliente = CStr(drClientes("Apellidos")),
                    .Correoelectronico = CStr(drClientes("Correo")),
                    .Telefono = CInt(drClientes("Telefono")),
                    .Direccion = New Direccion With {.CodigoProvincia = CInt("CodigoProvincia"),
                    .Canton = ("Canton"), .Distrito = CStr("Distrito"), .DireccionExacta = CStr("DireccionExacta")},
                    .CodServicioSolicitado = CShort(("codServicioUtilizado"))
                                        }
                End If
            End If

            If iInfoCliente Is Nothing Then
                Throw New NullReferenceException(String.Format("No se obtuvo info para el cliente {0}", Identificacion))
            End If

            Return iInfoCliente
        Catch ex As Exception
            Throw ex
        End Try



    End Function


End Class
