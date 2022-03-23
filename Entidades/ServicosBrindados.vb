Public Class ServicosBrindados
#Region "Variables"
    Private shtCodCobro As Short
    Private strIdentificacionCliente As String
    Private strIdentificacionMascota As String
    Private shtCodServicio As Short
    Private dtFechaServicio As Date

#End Region

#Region "Properties"
    Public Property ShtCodCobro1 As Short
        Get
            Return shtCodCobro
        End Get
        Set(value As Short)
            shtCodCobro = value
        End Set
    End Property

    Public Property StrIdentificacionCliente1 As String
        Get
            Return strIdentificacionCliente
        End Get
        Set(value As String)
            strIdentificacionCliente = value
        End Set
    End Property

    Public Property StrIdentificacionMascota1 As String
        Get
            Return strIdentificacionMascota
        End Get
        Set(value As String)
            strIdentificacionMascota = value
        End Set
    End Property

    Public Property ShtCodServicio1 As Short
        Get
            Return shtCodServicio
        End Get
        Set(value As Short)
            shtCodServicio = value
        End Set
    End Property

    Public Property DtFechaServicio1 As Date
        Get
            Return dtFechaServicio
        End Get
        Set(value As Date)
            dtFechaServicio = value
        End Set
    End Property


#End Region

End Class
