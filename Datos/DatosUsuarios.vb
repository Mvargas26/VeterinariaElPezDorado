Imports System.Data.SqlClient

Public Class DatosUsuarios

        Public Sub mantenimientoUsuario(ByVal accion As Short, ByVal usuarios As Entidades.Usuarios)
            Try
                Dim strNombreSP As String = "SP_GrabarUsuarios" ' Recomendacion copiarlo desde base de datos
                'lista para almacenar los parametros del procedimiento almacenado.
                Dim lstParametros As New List(Of SqlParameter) From {
                    New SqlParameter("@accion", CShort(accion)),
                    New SqlParameter("@nombreUsuario", usuarios.Usuario),
                    New SqlParameter("@clave", usuarios.Password)
                }

                Dim iConexion As New DatosSQL
                iConexion.ExecuteSP(strNombreSP, lstParametros)

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Function buscarUsuario(ByVal usuarios As Entidades.Usuarios) As DataTable
            Try
                Dim strNombreSP As String = "SP_consultaUsuario" ' Recomendacion copiarlo desde base de datos
                'lista para almacenar los parametros del procedimiento almacenado.
                Dim lstParametros As New List(Of SqlParameter) From {
                    New SqlParameter("@usuario", usuarios.Usuario),
                    New SqlParameter("@password", usuarios.Password)
                }

                Dim iConexion As New DatosSQL
                Dim dt As DataTable = iConexion.ExecuteSPWithDT(strNombreSP, lstParametros)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class
