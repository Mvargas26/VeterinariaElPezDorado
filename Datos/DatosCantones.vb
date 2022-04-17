Imports System.Text
Imports System.Data.SqlClient
Public Class DatosCantones
    Public Function ConsultarCantones(ByVal Optional paramNumProvincia As Short = -1) As DataTable
        Try
            Dim consultaSQL As New StringBuilder

            With consultaSQL
                .Append("SELECT [cod_canton],[nombre_canton],[cod_provincia]FROM [dbo].[canton]")

                If paramNumProvincia <> -1 Then
                    .Append("WHERE [cod_provincia]= ")
                    .Append(paramNumProvincia)
                End If

            End With

            'ejecuta la consulta a nivel de la base de datos
            Dim sqlEjecucion As New DatosSQL
            Dim dtCantones As DataTable = sqlEjecucion.QueryDBwithDT(consultaSQL.ToString)

            Return dtCantones

        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
