Public Class ServicosBrindados
#Region "Variables"
    Private shtCodCobro As Short
    Private strIdentificacionCliente As String
    Private strIdentificacionMascota As String
    Private shtCodServicio As Short
    Private dtFechaServicio As Date
    Private dblCostoTotal As Double



#End Region

#Region "Constructor"
    Public Sub ServiciosBrindados(strIdentificacionCliente As String, strIdentificacionMascota As String, shtCodServicio As Short, dtFechaServicio As Date, dblCostoTotal As Double)
        Me.strIdentificacionCliente = strIdentificacionCliente
        Me.strIdentificacionMascota = strIdentificacionMascota
        Me.shtCodServicio = shtCodServicio
        Me.dtFechaServicio = dtFechaServicio
        Me.dblCostoTotal = dblCostoTotal
    End Sub
#End Region

#Region "Properties"
    Public Property CodCobro As Short
        Get
            Return shtCodCobro
        End Get
        Set(value As Short)
            shtCodCobro = value
        End Set
    End Property

    Public Property IdentificacionCliente As String
        Get
            Return strIdentificacionCliente
        End Get
        Set(value As String)
            strIdentificacionCliente = value
        End Set
    End Property

    Public Property IdentificacionMascota As String
        Get
            Return strIdentificacionMascota
        End Get
        Set(value As String)
            strIdentificacionMascota = value
        End Set
    End Property

    Public Property CodServicio As Short
        Get
            Return shtCodServicio
        End Get
        Set(value As Short)
            shtCodServicio = value
        End Set
    End Property

    Public Property FechaServicio As Date
        Get
            Return dtFechaServicio
        End Get
        Set(value As Date)
            dtFechaServicio = value
        End Set
    End Property

    Public Property CostoTotal As Double
        Get
            Return dblCostoTotal
        End Get
        Set(value As Double)
            dblCostoTotal = value
        End Set
    End Property


#End Region

End Class
