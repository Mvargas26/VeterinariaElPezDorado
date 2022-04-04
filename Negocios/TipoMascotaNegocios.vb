Public Class TipoMascotaNegocios
    Public Sub grabarTipoMascota(ByVal accion As Short, ByVal iTipoMascota As Entidades.TipoMascota)
        Try
            Dim iDatos As New Datos.DatosTipoMascotas
            iDatos.mantenimientoTipoMascota(accion, iTipoMascota)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function consultarTipoMascota(ByVal Optional shtCodTipoMascota As Short = 0) As DataTable
        Dim iDatos As New Datos.DatosTipoMascotas
        Dim dtTipoMascota As DataTable = iDatos.consultaTipoMascota(shtCodTipoMascota)
        Return dtTipoMascota
    End Function

End Class
