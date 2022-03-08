Public Class Direccion
#Region "Variables"
    Dim intCodigoProvincia As Integer
    Dim strProvincia As String
    Dim strCanton As String
    Dim strDistrito As String
    Dim strDireccionExacta As String

#End Region

#Region "Properties"


    Public Property CodigoProvincia As Integer
        Get
            Return intCodigoProvincia
        End Get
        Set(value As Integer)
            intCodigoProvincia = value
        End Set
    End Property

    Public Property Provincia As String
        Get
            Return strProvincia
        End Get
        Set(value As String)
            strProvincia = value
        End Set
    End Property

    Public Property Canton As String
        Get
            Return strCanton
        End Get
        Set(value As String)
            strCanton = value
        End Set
    End Property

    Public Property Distrito As String
        Get
            Return strDistrito
        End Get
        Set(value As String)
            strDistrito = value
        End Set
    End Property

    Public Property DireccionExacta As String
        Get
            Return strDireccionExacta
        End Get
        Set(value As String)
            strDireccionExacta = value
        End Set
    End Property


#End Region
End Class
