Public Class ServiciosNegocios
    ''' <summary>
    ''' Metodo para realizar los mantenimientos a los servicios. 
    ''' Recibe un numero para realizar los diferentes mantenimientos. 
    ''' </summary>
    ''' <param name="accion">Numero para realizar los diferentes mantenimientos.</param>
    ''' <param name="eServicio">Entidad de servicio con la informacion para realziar el mantenimiento</param>
    Public Sub grabarServicios(ByVal accion As Short, ByVal eServicio As Entidades.Servicios)
        Try
            Dim iServicio As New Datos.DatosServicios
            iServicio.mantenimientoServicios(accion, eServicio)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' Metodo para realizar la consulta del servicio.
    ''' </summary>
    ''' <param name="shtCodServicio">Se envia el codigo del servicio para realizar la consulta</param>
    ''' <returns></returns>
    Public Function consultarServicios(ByVal Optional shtCodServicio As Short = 0) As DataTable
        Dim iDatos As New Datos.DatosServicios
        Dim dtServicio = iDatos.buscarServicio(shtCodServicio)
        Return dtServicio
    End Function
    ''' <summary>
    ''' Realiza la consulta de los datos necesarios para elegir el servicio a brindar.
    ''' </summary>
    ''' <param name="strIdentificacion">Identificacion del cliente</param>
    ''' <returns></returns>
    Public Function consultaRegistroServiciosBrindados(ByVal strIdentificacion As String)
        Try
            Dim iServicio As New Datos.DatosServicios
            Return iServicio.buscarDatosRegistroServicio(strIdentificacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Calculo del costo de los servicios.
    ''' </summary>
    ''' <param name="intCosto">Costo bruto del servicio</param>
    ''' <param name="intImpuesto">Costo del impuesto</param>
    ''' <returns></returns>
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
    ''' <summary>
    ''' Metodo para registrar el servicio brindado
    ''' </summary>
    ''' <param name="eServiciosBrindados"></param>
    Public Sub grabarRegistroServicios(ByVal eServiciosBrindados As Entidades.ServicosBrindados)
        Try
            Dim iServicio As New Datos.DatosServicios
            iServicio.RegistroServiciosBrindados(eServiciosBrindados)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
