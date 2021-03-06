Public Class ClienteVeterinaria
#Region "Variables"
    Private strNombreCliente As String
    Private strApellidosCliente As String
    Private strIdentificacionCliente As String
    Private strDireccion As New Direccion
    Private intTelefono As Integer
    Private strCorreoElectronico As String
    Private shtCodServicioSolicitado As Short
    Private shtCodDireccion As Short

#End Region

#Region "Properties"


    Public Property NombreCliente As String
        Get
            Return strNombreCliente
        End Get
        Set(value As String)
            strNombreCliente = value
        End Set
    End Property

    Public Property ApellidosCliente As String
        Get
            Return strApellidosCliente
        End Get
        Set(value As String)
            strApellidosCliente = value
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

    Public Property Direccion As Direccion
        Get
            Return strDireccion
        End Get
        Set(value As Direccion)
            strDireccion = value
        End Set
    End Property

    Public Property Telefono As Integer
        Get
            Return intTelefono
        End Get
        Set(value As Integer)
            intTelefono = value
        End Set
    End Property

    Public Property Correoelectronico As String
        Get
            Return strCorreoelectronico
        End Get
        Set(value As String)
            strCorreoelectronico = value
        End Set
    End Property

    Public Property CodServicioSolicitado As Short
        Get
            Return shtCodServicioSolicitado
        End Get
        Set(value As Short)
            shtCodServicioSolicitado = value
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



#End Region

#Region "Metodos"
    ''' <summary>
    ''' Consultar los datos de cliente, y los asigna al objeto para mostrarlos en pantalla
    ''' </summary>
    ''' <param name="id">Identificación del cliente</param>
    Public Sub consultarCliente(ByVal id As String)
        'Se llama consultar y se trae el datos necesario y se envia el id para traer la informacion
        NombreCliente = "Carlos"
        ApellidosCliente = "Ugalde"
        IdentificacionCliente = "321654988"
        Telefono = "88997788"
        Correoelectronico = "carlos@gmail.com"
        strDireccion.Provincia = 1
        strDireccion.Canton = 1
        strDireccion.DireccionExacta = "400 sur de la plaza"
    End Sub
    ''' <summary>
    ''' Se elije el mantenimiento a realizar
    ''' </summary>
    ''' <param name="shtSeleccion">número recibido del menu</param>
    Public Sub mantenimiento(ByVal shtSeleccion As Short)
        Select Case shtSeleccion
            Case 1
                'Llama insertar
            Case 2
                'Llama eliminar
            Case 3
                'Llama modificar
            Case 4
                'LLama consultar
        End Select
    End Sub

#End Region
End Class
