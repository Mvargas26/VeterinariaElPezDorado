Public Class Servicios
#Region "variables"
    Private shtcodServicios As Short
    Private strnombreServicio As String
    Private intCosto As Integer
    Private flImpuesto As Decimal

#End Region
#Region "Properties"
    Public Property ShtcodServicios1 As Short
        Get
            Return shtcodServicios
        End Get
        Set(value As Short)
            shtcodServicios = value
        End Set
    End Property

    Public Property StrnombreServicio1 As String
        Get
            Return strnombreServicio
        End Get
        Set(value As String)
            strnombreServicio = value
        End Set
    End Property

    Public Property IntCosto1 As Integer
        Get
            Return intCosto
        End Get
        Set(value As Integer)
            intCosto = value
        End Set
    End Property

    Public Property FlImpuesto1 As Decimal
        Get
            Return flImpuesto
        End Get
        Set(value As Decimal)
            flImpuesto = value
        End Set
    End Property


#End Region



End Class
