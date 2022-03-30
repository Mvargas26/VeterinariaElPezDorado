Imports System.Text
Imports System.Data.SqlClient
Public Class DatosClientes
    ''' <summary>
    ''' Devuelve la info de los clientes que esta en la base de datos en un data table
    ''' </summary>
    ''' <param name="paramIdentificacion">si se le ingresa la identificacion devuelve esa ,si no devuelve todas</param>
    ''' <returns></returns>
    Public Function CoonsultarClientes(ByVal Optional paramIdentificacion As String = "-1") As DataTable ' el parametro identificacion es opcional , si viene sin parametro se trae todo lo que tenga la tabla clientes
        Try
            Dim consultaSQL As New StringBuilder

            With consultaSQL
                .Append("SELECT identificacion, nombre, apellidos,telefono,correo, provincia,canton,distrito,direccion_Exacta  FROM Clientes")

                If paramIdentificacion <> "-1" Then ' si es diferente a -1 , utiliza el filtro, osea agregueme el where 
                    .Append(" where identificacion = ")
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

#Region "Manejo de Procedimientos almacenados en DatosClientes"
    ''' <summary>
    ''' Mantenimineto a Cliente
    ''' </summary>
    ''' <param name="Accion"></param>
    ''' <para>1-- REgistro</para>
    ''' <para>2-- Modifica</para>
    ''' <para>3-- Elimina</para>
    ''' <param name="Cliente"></param>
    Public Sub GrabarCliente(Accion As Entidades.Enumeradores.Accion, Cliente As Entidades.ClienteVeterinaria)
        Try
            Dim strNombreSP As String = "SP_Clientes2"

            'lista parametros q se va mandar a datos
            Dim lstParametros As New List(Of SqlParameter) From {
            New SqlParameter("@accion", CShort(Accion)),
            New SqlParameter("@identificacion", Cliente.IdentificacionCliente),
            New SqlParameter("@nombre", Cliente.NombreCliente),
            New SqlParameter("@apellidos", Cliente.ApellidosCliente),
            New SqlParameter("@telefono", IIf(Cliente.Telefono.Equals(""), 0, Cliente.Telefono)),
            New SqlParameter("@correo", Cliente.Correoelectronico),
            New SqlParameter("@provincia", Cliente.Direccion.Provincia),
            New SqlParameter("@canton", Cliente.Direccion.Canton),
            New SqlParameter("@distrito", Cliente.Direccion.Distrito),
            New SqlParameter("@direccionExacta", Cliente.Direccion.DireccionExacta)
            }

            'objeto q ejecuta el procedimineto SP
            Dim objDatosSQL As New DatosSQL

            objDatosSQL.ExecuteSP(strNombreSP, lstParametros)


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

End Class
