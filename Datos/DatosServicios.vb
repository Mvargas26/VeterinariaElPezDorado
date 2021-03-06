Imports System.Data.SqlClient

Public Class DatosServicios
    ''' <summary>
    ''' Se realiza el mantenimiento de los servicios 
    ''' </summary>
    ''' <param name="accion">Numero para seleccionar el mantenimiento a realizar</param>
    ''' <param name="eServicios">Entidad de servicio con la informacion para realizar el mantenimiento</param>
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
    ''' <summary>
    ''' Realiza la consulta de los servicios.
    ''' </summary>
    ''' <param name="shtCodigo">Codigo del servicio</param>
    ''' <returns></returns>
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
    ''' <summary>
    ''' Realiza la consulta de los datos necesarios para brindar un servicio
    ''' </summary>
    ''' <param name="strIdentificacion">Numero de identificacion</param>
    ''' <returns></returns>
    Public Function buscarDatosRegistroServicio(ByVal strIdentificacion As String) As DataSet
        Try
            Dim strNombreSP As String = "SP_ConsultaDatosServicios" ' Recomendacion copiarlo desde base de datos
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
    ''' <summary>
    ''' Metodo para registrar los datos del servicio
    ''' </summary>
    ''' <param name="eRegistrarServicios">Contiene los datos necesarios para realizar la consulta</param>
    Public Sub RegistroServiciosBrindados(ByVal eRegistrarServicios As Entidades.ServicosBrindados)
        Try
            Dim strNombreSP As String = "SP_GrabarServiciosBrindados" ' Recomendacion copiarlo desde base de datos
            'lista para almacenar los parametros del procedimiento almacenado.
            Dim lstParametros As New List(Of SqlParameter) From {
                    New SqlParameter("@idCliente", eRegistrarServicios.IdentificacionCliente),
                    New SqlParameter("@idMascota", eRegistrarServicios.IdentificacionMascota),
                    New SqlParameter("@datFechaServicio", eRegistrarServicios.FechaServicio)
                }

            Dim iConexion As New DatosSQL
            iConexion.ExecuteSP(strNombreSP, lstParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' Metodo para registrar el servicio
    ''' </summary>
    ''' <param name="eRegistrarServicios">Contiene los datos necesarios para realizar la consulta</param>
    Public Sub RegistroServiciosIndividuales(ByVal eRegistrarServicios As Entidades.ServicosBrindados)
        Try
            Dim strNombreSP As String = "SP_RegistrarServicio" ' Recomendacion copiarlo desde base de datos
            'lista para almacenar los parametros del procedimiento almacenado.
            Dim lstParametros As New List(Of SqlParameter) From {
                    New SqlParameter("@codCobro", eRegistrarServicios.CodCobro),
                    New SqlParameter("@codServicio", eRegistrarServicios.CodServicio),
                    New SqlParameter("@costoTotal", eRegistrarServicios.CostoTotal)
                }

            Dim iConexion As New DatosSQL
            iConexion.ExecuteSP(strNombreSP, lstParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Metodo para consultar los registros de un numero de cobro particular
    ''' </summary>
    ''' <param name="shtcodCobro">Numero de cobro</param>
    ''' <returns></returns>
    Public Function consultaServiciosRegistrados(ByVal shtcodCobro As Short)
        Try
            Dim strNombreSP As String = "SP_ConsultaRegistroServicios" ' Recomendacion copiarlo desde base de datos
            'lista para almacenar los parametros del procedimiento almacenado.
            Dim lstParametros As New List(Of SqlParameter) From {
                    New SqlParameter("@codCobro", shtcodCobro)
                }
            Dim iConexion As New DatosSQL
            Dim dt As DataTable = iConexion.ExecuteSP_withDT(strNombreSP, lstParametros)

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Consulta el ultimo numero de cobro.
    ''' </summary>
    ''' <returns></returns>
    Public Function consultaNumCobro()
        Try
            Dim strQuery As String = "SELECT MAX(cod_cobro) as [cod_cobro] FROM [dbo].[serviciosBrindados]"
            'lista para almacenar los parametros del procedimiento almacenado.
            Dim iConexion As New DatosSQL
            Dim dt As DataTable = iConexion.QueryDBwithDT(strQuery)

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
