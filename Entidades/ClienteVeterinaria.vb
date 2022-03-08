Public Class ClienteVeterinaria
#Region "Variables"
    Dim strNombreCliente As String
    Dim strApellidosCliente As String
    Dim intIdentificacionCliente As Integer
    Dim strDireccion As Direccion
    Dim intTelefono As Integer
    Dim strCorreoelectronico As String

#End Region

#Region "Properties"


    Public Property NombreCliente As String
        Get
            Return strNombreCliente
        End Get
        Set(value As String)
            strNombreCliente = value
        End Set
    End Property

    Public Property ApellidosCliente As String
        Get
            Return strApellidosCliente
        End Get
        Set(value As String)
            strApellidosCliente = value
        End Set
    End Property

    Public Property IdentificacionCliente As Integer
        Get
            Return intIdentificacionCliente
        End Get
        Set(value As Integer)
            intIdentificacionCliente = value
        End Set
    End Property

    Public Property Direccion As Direccion
        Get
            Return strDireccion
        End Get
        Set(value As Direccion)
            strDireccion = value
        End Set
    End Property

    Public Property Telefono As Integer
        Get
            Return intTelefono
        End Get
        Set(value As Integer)
            intTelefono = value
        End Set
    End Property

    Public Property Correoelectronico As String
        Get
            Return strCorreoelectronico
        End Get
        Set(value As String)
            strCorreoelectronico = value
        End Set
    End Property



#End Region


End Class
