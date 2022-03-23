Public Class Mascotas
#Region "Variables"

    Private intIdentificacionDueno As ClienteVeterinaria
    Private shtCodigoMascota As Short
    Private strNombreMascota As String
    Private shtTipoMascota As Short
    Private strRaza As String = ""
    Private intPeso As Integer
    Private strEstadoSalud As String
    Private dteFechaNacimiento As Date

#End Region

#Region "Properties"


    Public Property IdentificacionDueno As ClienteVeterinaria
        Get
            Return intIdentificacionDueno
        End Get
        Set(value As ClienteVeterinaria)
            intIdentificacionDueno = value
        End Set
    End Property

    Public Property CodigoMascota As Integer
        Get
            Return shtCodigoMascota
        End Get
        Set(value As Integer)
            shtCodigoMascota = value
        End Set
    End Property

    Public Property NombreMascota As String
        Get
            Return strNombreMascota
        End Get
        Set(value As String)
            strNombreMascota = value
        End Set
    End Property

    Public Property TipoMascota As Short
        Get
            Return shtTipoMascota
        End Get
        Set(value As Short)
            shtTipoMascota = value
        End Set
    End Property

    Public Property Raza As String
        Get
            Return strRaza
        End Get
        Set(value As String)
            strRaza = value
        End Set
    End Property

    Public Property Peso As Integer
        Get
            Return intPeso
        End Get
        Set(value As Integer)
            intPeso = value
        End Set
    End Property

    Public Property EstadoSalud As String
        Get
            Return strEstadoSalud
        End Get
        Set(value As String)
            strEstadoSalud = value
        End Set
    End Property

    Public Property FechaNacimiento As Date
        Get
            Return dteFechaNacimiento
        End Get
        Set(value As Date)
            dteFechaNacimiento = value
        End Set
    End Property


#End Region


End Class
