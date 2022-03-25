Imports Datos
Imports Entidades
Public Class DireccionNegocios

#Region "Consulta Direccion en Negocios"
    Public Function ConsultarTodasDirecionesenNegocios() As DataTable
        Try
            Dim iDirecciones As New DatosDireccion

            Return iDirecciones.CoonsultarDireccionEnDatos
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarDireccionEnNegocios() As Direccion
        Try
            Dim iDireccion As New DatosDireccion
            Dim dtDirecciones As DataTable = iDireccion.CoonsultarDireccionEnDatos

            Dim iInfoDireccion As Direccion = Nothing
            ' Dim iNumProvincias As Entidades.Enumeradores.EnumProvincias

            If dtDirecciones IsNot Nothing Then
                Dim drDireccion As DataRow = dtDirecciones.Rows(0) ' objeto de tipo fila 

                If dtDirecciones.Rows.Count > 0 Then

                    iInfoDireccion = New Direccion With {
                      .CodDireccion = CShort(drDireccion("cod_direccion")),
                      .CodigoProvincia = CShort(drDireccion("cod_provincia")),
                      .CodigoCanton = CShort(drDireccion("cod_canton")),
                      .Distrito = CStr(drDireccion("distrito")),
                      .DireccionExacta = CStr(drDireccion("direccion_exacta"))
                    }
                End If
            End If

            If iInfoDireccion Is Nothing Then
                Throw New NullReferenceException(String.Format("No se obtuvo info para la Direccion {0}"))
            End If

            Return iInfoDireccion

        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class
