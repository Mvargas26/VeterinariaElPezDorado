Imports System.Text

Public Class DatosClientes
    ''' <summary>
    ''' Devuelve la info de los clientes que esta en la base de datos en un data table
    ''' </summary>
    ''' <param name="paramIdentificacion">si se le ingresa la identificacion devuelve esa ,si no devuelve todas</param>
    ''' <returns></returns>
    Public Function CoonsultarClientes(ByVal Optional paramIdentificacion As Integer = -1) As DataTable ' el parametro identificacion es opcional , si viene sin parametro se trae todo lo que tenga la tabla clientes
        Try
            Dim consultaSQL As New StringBuilder

            With consultaSQL
                .Append("Select Identificacion, Nombre, Apellidos, Telefono, Correo, cod_direccion FROM Clientes")

                If paramIdentificacion <> -1 Then ' si es diferente a -1 , utiliza el filtro, osea agregueme el where min 20 parte 2
                    .Append(" where Identificacion = ")
                    .Append(paramIdentificacion)
                End If

            End With

            'ejecuta la consulta a nivel de la base de datos
            Dim sqlEjecucion As New DatosSQL
            Dim dtClientes As DataTable = sqlEjecucion.QueryDBwithDT(consultaSQL.ToString)

            Return dtClientes

        Catch ex As Exception
            Throw ex
        End Try
    End Function



End Class
