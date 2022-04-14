Public Class TipoMascotaNegocios
    ''' <summary>
    ''' Metodo para dar mantenimiento al tipo de mascota.
    ''' </summary>
    ''' <param name="accion">Se envia un numero para determinar el tipo de accionq ue se va a reallizar</param>
    ''' <param name="iTipoMascota"></param>
    Public Sub grabarTipoMascota(ByVal accion As Short, ByVal iTipoMascota As Entidades.TipoMascota)
        Try
            Dim iDatos As New Datos.DatosTipoMascotas
            iDatos.mantenimientoTipoMascota(accion, iTipoMascota)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' Metodo para consultar la informacion del tipo de mascotas. 
    ''' </summary>
    ''' <param name="shtCodTipoMascota"></param>
    ''' <returns></returns>
    Public Function consultarTipoMascota(ByVal Optional shtCodTipoMascota As Short = 0) As DataTable
        Dim iDatos As New Datos.DatosTipoMascotas
        Dim dtTipoMascota As DataTable = iDatos.consultaTipoMascota(shtCodTipoMascota)
        Return dtTipoMascota
    End Function

End Class
