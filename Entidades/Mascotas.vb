Public Class Mascotas
#Region "Variables"

    Private intIdentificacionDueno As ClienteVeterinaria
    Private intCodigoMascota As Integer
    Private strNombreMascota As String
    Private strTipoMascota As TipoMascota
    Private strRaza As String = ""
    Private intPeso As Integer
    Private strEstadoSalud As String
    Private dteFechaNacimiento As Date
    'Cambio

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
            Return intCodigoMascota
        End Get
        Set(value As Integer)
            intCodigoMascota = value
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

    Public Property TipoMascota As TipoMascota
        Get
            Return strTipoMascota
        End Get
        Set(value As TipoMascota)
            strTipoMascota = value
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
