Imports System.Data.SqlClient

Public Class DatosServicios
    Public Sub mantenimientoServicios(ByVal accion As Short, ByVal eServicios As Entidades.Servicios)
        Try
            Dim strNombreSP As String = "SP_GrabarServicios" ' Recomendacion copiarlo desde base de datos
            'lista para almacenar los parametros del procedimiento almacenado.
            Dim lstParametros As New List(Of SqlParameter) From {
                    New SqlParameter("@accion", CShort(accion)),
                    New SqlParameter("@codServicio", CShort(eServicios.codServicios)),
                    New SqlParameter("@nomServicio", eServicios.nombreServicio),
                    New SqlParameter("@intCosto", eServicios.Costo),
                    New SqlParameter("@fltImpuesto", eServicios.Impuesto)
                }

            Dim iConexion As New DatosSQL
            iConexion.ExecuteSP(strNombreSP, lstParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function buscarServicio(ByVal shtCodigo As Short) As DataTable
        Try
            Dim strNombreSP As String = "SP_ConsultaServicios" ' Recomendacion copiarlo desde base de datos
            'lista para almacenar los parametros del procedimiento almacenado.
            Dim lstParametros As New List(Of SqlParameter) From {
                    New SqlParameter("@codServicios", shtCodigo)
                }
            Dim iConexion As New DatosSQL
            Dim dt As DataTable = iConexion.ExecuteSP_withDT(strNombreSP, lstParametros)

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function buscarDatosRegistroServicio(ByVal strIdentificacion As String) As DataSet
        Try
            Dim strNombreSP As String = "SP_ConsultaRegistroServicios" ' Recomendacion copiarlo desde base de datos
            'lista para almacenar los parametros del procedimiento almacenado.
            Dim lstParametros As New List(Of SqlParameter) From {
                    New SqlParameter("@dueno", strIdentificacion)
                }
            Dim iConexion As New DatosSQL
            Dim ds As DataSet = iConexion.ExecutSPWithDS(strNombreSP, lstParametros)

            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub RegistroServiciosBrindados(ByVal eRegistrarServicios As Entidades.ServicosBrindados)
        Try
            Dim strNombreSP As String = "SP_GrabarServiciosBrindados" ' Recomendacion copiarlo desde base de datos
            'lista para almacenar los parametros del procedimiento almacenado.
            Dim lstParametros As New List(Of SqlParameter) From {
                    New SqlParameter("@idCliente", eRegistrarServicios.IdentificacionCliente),
                    New SqlParameter("@idMascota", eRegistrarServicios.IdentificacionMascota),
                    New SqlParameter("@codServicio", eRegistrarServicios.CodServicio),
                    New SqlParameter("@datFechaServicio", eRegistrarServicios.FechaServicio)
                }

            Dim iConexion As New DatosSQL
            iConexion.ExecuteSP(strNombreSP, lstParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
