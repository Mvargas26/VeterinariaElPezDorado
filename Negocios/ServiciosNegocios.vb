Public Class ServiciosNegocios
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

    Public Function consultaRegistroServiciosBrindados(ByVal strIdentificacion As String)
        Try
            Dim iServicio As New Datos.DatosServicios
            Return iServicio.buscarDatosRegistroServicio(strIdentificacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function calculoCosto(ByVal intCosto As Integer, ByVal intImpuesto As Integer)
        Dim lstCosto As New ArrayList
        Dim intCostoImpuesto As Integer
        Dim intCostoTotal As Double

        intCostoImpuesto = (intImpuesto * intCosto) / 100
        intCostoTotal = intCostoImpuesto + intCosto
        lstCosto.Add(intCostoImpuesto)
        lstCosto.Add(intCostoTotal)

        Return lstCosto
    End Function

    Public Sub grabarRegistroServicios(ByVal eServiciosBrindados As Entidades.ServicosBrindados)
        Try
            Dim iServicio As New Datos.DatosServicios
            iServicio.RegistroServiciosBrindados(eServiciosBrindados)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
