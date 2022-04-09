﻿Public Class ServiciosNegocios
    Public Sub grabarServicios(ByVal accion As Short, ByVal eServicio As Entidades.Servicios)
        Try
            Dim iServicio As New Datos.DatosServicios
            iServicio.mantenimientoServicios(accion, eServicio)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function consultarServicios(ByVal Optional shtCodServicio As Short = 0) As DataTable
        Dim iDatos As New Datos.DatosServicios
        Dim dtServicio = iDatos.buscarServicio(shtCodServicio)
        Return dtServicio
    End Function
End Class