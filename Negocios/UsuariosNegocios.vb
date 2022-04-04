Public Class UsuariosNegocios
    Private dtUsuario As DataTable

    Public Property Usuario As DataTable
        Get
            Return dtUsuario
        End Get
        Set(value As DataTable)
            dtUsuario = value
        End Set
    End Property

    Public Sub grabarUsuarios(ByVal accion As Short, ByVal usuarios As Entidades.Usuarios)
        Try
            Dim iUsuario As New Datos.DatosUsuarios
            iUsuario.mantenimientoUsuario(accion, usuarios)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function consultarUsuarios(ByVal Optional shtcodUsuario As Short = 0) As DataTable
        Dim iDatos As New Datos.DatosUsuarios
        Dim dtUsuario = iDatos.buscarUsuario(shtcodUsuario)
        Return dtUsuario
    End Function


End Class