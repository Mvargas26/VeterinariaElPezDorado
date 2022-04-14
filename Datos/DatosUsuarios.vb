Imports System.Data.SqlClient

Public Class DatosUsuarios
    ''' <summary>
    ''' Mantenimiento del usuario
    ''' </summary>
    ''' <param name="accion">Numero para indicar la accion a realizar</param>
    ''' <param name="usuarios">Usuario con los datos para realizar el mantenimiento</param>
    Public Sub mantenimientoUsuario(ByVal accion As Short, ByVal usuarios As Entidades.Usuarios)
        Try
            Dim strNombreSP As String = "SP_GrabarUsuarios" ' Recomendacion copiarlo desde base de datos
            'lista para almacenar los parametros del procedimiento almacenado.
            Dim lstParametros As New List(Of SqlParameter) From {
                    New SqlParameter("@accion", CShort(accion)),
                    New SqlParameter("@codUsuario", CShort(usuarios.CodUsuario)),
                    New SqlParameter("@usuario", usuarios.Usuario),
                    New SqlParameter("@password", usuarios.Password)
                }

            Dim iConexion As New DatosSQL
            iConexion.ExecuteSP(strNombreSP, lstParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' Realiza la consulta del usuario para iniciar sesion.
    ''' </summary>
    ''' <param name="usuarios">Recibe un usuario con los datos para confirmar el inicio de seccion.</param>
    ''' <returns></returns>
    Public Function buscarUsuarioSesion(ByVal usuarios As Entidades.Usuarios) As DataTable
        Try
            Dim strNombreSP As String = "SP_consultaUsuario" ' Recomendacion copiarlo desde base de datos
            'lista para almacenar los parametros del procedimiento almacenado.
            Dim lstParametros As New List(Of SqlParameter) From {
                    New SqlParameter("@usuario", usuarios.Usuario),
                    New SqlParameter("@password", usuarios.Password)
                }

            Dim iConexion As New DatosSQL
            Dim dt As DataTable = iConexion.ExecuteSP_withDT(strNombreSP, lstParametros)

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Realiza la consulta para informacion del usuario.
    ''' </summary>
    ''' <param name="shtCodigo"></param>
    ''' <returns></returns>
    Public Function buscarUsuario(ByVal shtCodigo As Short) As DataTable
        Try
            Dim strNombreSP As String = "SP_ConsultaUsuarioMantenimiento" ' Recomendacion copiarlo desde base de datos
            'lista para almacenar los parametros del procedimiento almacenado.
            Dim lstParametros As New List(Of SqlParameter) From {
                    New SqlParameter("@codUsuario", shtCodigo)
                }
            Dim iConexion As New DatosSQL
            Dim dt As DataTable = iConexion.ExecuteSP_withDT(strNombreSP, lstParametros)

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class

