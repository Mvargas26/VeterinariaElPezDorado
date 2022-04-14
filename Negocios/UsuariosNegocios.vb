Public Class UsuariosNegocios
    Private dtUsuario As DataTable
#Region "Propiedades"
    Public Property Usuario As DataTable
        Get
            Return dtUsuario
        End Get
        Set(value As DataTable)
            dtUsuario = value
        End Set
    End Property
#End Region

    ''' <summary>
    ''' Metodo para realizar el mantenimiento.
    ''' </summary>
    ''' <param name="accion">Recibe un numero para realizar una accion segun el numero recibido.</param>
    ''' <param name="usuarios">Recibe un usuario para realizar la accion seleccionada</param>
    Public Sub grabarUsuarios(ByVal accion As Short, ByVal usuarios As Entidades.Usuarios)
        Try
            Dim iUsuario As New Datos.DatosUsuarios
            iUsuario.mantenimientoUsuario(accion, usuarios)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' Metodo para consultar la informacion del usuario
    ''' </summary>
    ''' <param name="shtcodUsuario">Codigo del usuario</param>
    ''' <returns></returns>
    Public Function consultarUsuarios(ByVal Optional shtcodUsuario As Short = 0) As DataTable
        Dim iDatos As New Datos.DatosUsuarios
        Dim dtUsuario = iDatos.buscarUsuario(shtcodUsuario)
        Return dtUsuario
    End Function


End Class