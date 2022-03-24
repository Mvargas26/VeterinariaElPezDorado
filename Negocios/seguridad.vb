Public Class seguridad
    Public Function validarCredencial(ByVal Usuarios As String, ByVal Password As String) As Entidades.Usuarios
        Try
            Dim iusuario As New Entidades.Usuarios

            If Usuarios.Equals("Admin") And Password.Equals("Admin") Then
                iusuario.CredencialValida = True
            End If

            Return iusuario
        Catch ex As Exception
            Throw ex
        End Try

    End Function

End Class
