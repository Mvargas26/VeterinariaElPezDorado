Public Class Direccion
#Region "Variables"
    Private shtCodDireccion As Short
    Private shtCodigoProvincia As Short
    Private strProvincia As String
    Private shtCodigoCanton As Short
    Private strCanton As String
    Private strDireccionExacta As String

#End Region

#Region "Properties"


    Public Property CodigoProvincia As Integer
        Get
            Return shtCodigoProvincia
        End Get
        Set(value As Integer)
            shtCodigoProvincia = value
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

    Public Property DireccionExacta As String
        Get
            Return strDireccionExacta
        End Get
        Set(value As String)
            strDireccionExacta = value
        End Set
    End Property

    Public Property CodDireccion As Short
        Get
            Return shtCodDireccion
        End Get
        Set(value As Short)
            shtCodDireccion = value
        End Set
    End Property

    Public Property CodigoCanton As Short
        Get
            Return shtCodigoCanton
        End Get
        Set(value As Short)
            shtCodigoCanton = value
        End Set
    End Property


#End Region
End Class
