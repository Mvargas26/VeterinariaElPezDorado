Public Class TipoMascota
#Region "variables"
    Private shtCodigoTipoMascota As Short
    Private strDescripcionTipoMascota As String

#End Region

#Region "Properties"

    Public Property CodigotipoMascota As Short
        Get
            Return shtCodigoTipoMascota
        End Get
        Set(value As Short)
            shtCodigoTipoMascota = value
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
