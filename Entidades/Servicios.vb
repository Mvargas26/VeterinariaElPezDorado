Public Class Servicios
#Region "variables"
    Private shtcodServicios As Short
    Private strnombreServicio As String
    Private intCosto As Integer
    Private flImpuesto As Decimal

#End Region

#Region "Constructor"
    Public Sub Servicios(codServicios As Short, nombreServicio As String, costo As Integer, impuesto As Decimal)
        Me.codServicios = codServicios
        Me.nombreServicio = nombreServicio
        Me.Costo = costo
        Me.Impuesto = impuesto
    End Sub

#End Region
#Region "Properties"
    Public Property codServicios As Short
        Get
            Return shtcodServicios
        End Get
        Set(value As Short)
            shtcodServicios = value
        End Set
    End Property

    Public Property nombreServicio As String
        Get
            Return strnombreServicio
        End Get
        Set(value As String)
            strnombreServicio = value
        End Set
    End Property

    Public Property Costo As Integer
        Get
            Return intCosto
        End Get
        Set(value As Integer)
            intCosto = value
        End Set
    End Property

    Public Property Impuesto As Decimal
        Get
            Return flImpuesto
        End Get
        Set(value As Decimal)
            flImpuesto = value
        End Set
    End Property


#End Region



End Class
