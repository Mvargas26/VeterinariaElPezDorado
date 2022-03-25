Imports System.Text
Imports System.Data.SqlClient
Public Class DatosDireccion

#Region "Consulta Direccion en Datos"
    Public Function CoonsultarDireccionEnDatos(ByVal Optional CodDireccion As Short = -1) As DataTable
        Try
            Dim consultaSQL As New StringBuilder

            With consultaSQL
                .Append("Select cod_direccion,cod_provincia, cod_canton, distrito,direccion_exacta FROM direccion")

                If CodDireccion <> -1 Then ' si es diferente a -1 , utiliza el filtro, osea agregueme el where 
                    .Append(" where cod_direccion = ")
                    .Append(CodDireccion)
                End If

            End With

            'ejecuta la consulta a nivel de la base de datos
            Dim sqlEjecucion As New DatosSQL
            Dim dtDireccion As DataTable = sqlEjecucion.QueryDBwithDT(consultaSQL.ToString)

            Return dtDireccion

        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region





End Class
