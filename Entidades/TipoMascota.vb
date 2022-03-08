Public Class TipoMascota
#Region "variables"
    Private intCodigotipoMascota As Integer
    Private strDescripcionTipoMascota As String

#End Region

#Region "Properties"


    Public Property CodigotipoMascota As Integer
        Get
            Return intCodigotipoMascota
        End Get
        Set(value As Integer)
            intCodigotipoMascota = value
        End Set
    End Property

    Public Property DescripcionTipoMascota As String
        Get
            Return strDescripcionTipoMascota
        End Get
        Set(value As String)
            strDescripcionTipoMascota = value
        End Set
    End Property

#End Region

End Class
