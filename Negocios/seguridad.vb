Public Class seguridad
    Public Function validarCredencial(ByVal strUsuario As String, ByVal strPassword As String) As Entidades.Usuarios
        Try
            Dim iUsuario As New Entidades.Usuarios
            iUsuario.Usuario = strUsuario
            iUsuario.Password = strPassword
            Dim iDatos As New Datos.DatosUsuarios
            Dim dtUsuario As DataTable = iDatos.buscarUsuarioSesion(iUsuario)
            If dtUsuario.Rows.Count <> 0 Then
                iUsuario.CredencialValida = True
            End If

            Return iUsuario
        Catch ex As Exception
            Throw ex
        End Try

    End Function

End Class
