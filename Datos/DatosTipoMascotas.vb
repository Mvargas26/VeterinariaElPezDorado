﻿Imports System.Data.SqlClient

Public Class DatosTipoMascotas
    Public Sub mantenimientoTipoMascota(ByVal accion As Short, ByVal iTipoMascotas As Entidades.TipoMascota)
        Try
            Dim strNombreSP As String = "SP_GrabarTipoMascota" ' Recomendacion copiarlo desde base de datos
            'lista para almacenar los parametros del procedimiento almacenado.
            Dim lstParametros As New List(Of SqlParameter) From {
                    New SqlParameter("@accion", CShort(accion)),
                    New SqlParameter("@codTipoMascota", CShort(iTipoMascotas.CodigotipoMascota)),
                    New SqlParameter("@desTipoMascota", iTipoMascotas.DescripcionTipoMascota)
                }

            Dim iConexion As New DatosSQL
            iConexion.ExecuteSP(strNombreSP, lstParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function consultaTipoMascota(ByVal shtCodigo As Short) As DataTable
        Try
            Dim strNombreSP As String = "SP_ConsultaTipoMascota" ' Recomendacion copiarlo desde base de datos
            'lista para almacenar los parametros del procedimiento almacenado.
            Dim lstParametros As New List(Of SqlParameter) From {
                    New SqlParameter("@codTipoMascota", shtCodigo)
                }
            Dim iConexion As New DatosSQL
            Dim dt As DataTable = iConexion.ExecuteSP_withDT(strNombreSP, lstParametros)

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
