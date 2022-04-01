Imports Datos
Imports Entidades
Imports System.IO
Imports System.Xml
Public Class ClientesNegocios
    ''' <summary>
    ''' metodo Me va a dar todos los clientes que estan en la tabla que viene de Datos/DatosClientes/consultarClientes(sin parametro)
    ''' </summary>
    ''' <returns></returns>
    Public Function ConsultarClientes() As DataTable
        Try
            Dim iClientes As New DatosClientes

            Return iClientes.CoonsultarClientes
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Metodo que me va a retornar no un data table, si no un objeto de tipo cliente veterinaria
    ''' </summary>
    ''' <param name="Identificacion"></param>
    ''' <returns></returns>
    Public Function ConsultarCliente(ByVal Identificacion) As ClienteVeterinaria
        Try
            Dim iClientes As New DatosClientes
            Dim dtClientes As DataTable = iClientes.CoonsultarClientes

            Dim iInfoCliente As ClienteVeterinaria = Nothing

            If dtClientes IsNot Nothing Then
                Dim drClientes As DataRow = dtClientes.Rows(0) ' objeto de tipo fila 

                If dtClientes.Rows.Count > 0 Then


                    iInfoCliente = New ClienteVeterinaria With {
                       .IdentificacionCliente = CStr(drClientes("identificacion")),
                    .NombreCliente = CStr(drClientes("nombre")),
                    .ApellidosCliente = CStr(drClientes("apellidos")),
                    .Correoelectronico = CStr(drClientes("correo")),
                    .Telefono = CInt(drClientes("telefono")),
                    .Direccion = New Direccion With {.Provincia = CStr(drClientes("provincia")),
                    .Canton = CStr(drClientes("canton")),
                    .Distrito = CStr(drClientes("distrito")),
                    .DireccionExacta = CStr(drClientes("direccion_Exacta"))}}
                End If
            End If

            If iInfoCliente Is Nothing Then
                Throw New NullReferenceException(String.Format("No se obtuvo info para el cliente {0}", Identificacion))
            End If

            Return iInfoCliente
        Catch ex As Exception
            Throw ex
        End Try

    End Function

#Region "Lectura Cantones en Negocios"
    'funcion que lee el xml de los cantones y los devuelve en un arraylist
    Public Function LeerXMLCanton(URL As String) As ArrayList
        Try
            Dim arr_info As New ArrayList
            Dim codigoCanton As String = ""
            Dim codigoProvincia As String = ""
            Dim nombreCanton As String = ""

            Dim obj_deDatos As New DatosXML
            Dim doc_xml As New XmlDocument

            doc_xml = obj_deDatos.LeerXMLenDatos(URL)

            Dim xmlNodoListCantones As XmlNodeList = doc_xml.SelectNodes("/Cantones/Canton")

            For Each nodoCanton As XmlNode In xmlNodoListCantones
                codigoCanton = nodoCanton("CodigoCanton").InnerText
                codigoProvincia = nodoCanton("CodigoProvincia").InnerText
                nombreCanton = nodoCanton("NombreCanton").InnerText

                Dim lineaLeida As String = nombreCanton + "/" + codigoCanton + "/" + codigoProvincia
                Dim vecValores() As String = lineaLeida.Split("/")

                arr_info.Add(vecValores)
            Next

            Return arr_info

        Catch ex As Exception
            Throw New Exception("Error al leer el archivo XML Cantones en negocios, cliente")
        End Try
    End Function
#End Region

#Region "Manejo Procedimientos almacenados Agregar,Modificar,Eliminar en Negocios"

    Private Sub MantenimientoCliente(Accion As Entidades.Enumeradores.Accion, Cliente As Entidades.ClienteVeterinaria)
        Dim objClienteDatos As New Datos.DatosClientes
        objClienteDatos.GrabarCliente(Accion, Cliente)
    End Sub


    Public Sub RegistrarCliente(Cliente As Entidades.ClienteVeterinaria)
        Me.MantenimientoCliente(Entidades.Enumeradores.Accion.Registrar, Cliente)
    End Sub

    Public Sub MOdificarCliente(Cliente As Entidades.ClienteVeterinaria)
        Me.MantenimientoCliente(Entidades.Enumeradores.Accion.Modificar, Cliente)
    End Sub

    Public Sub EliminarCliente(Cliente As Entidades.ClienteVeterinaria)
        Me.MantenimientoCliente(Entidades.Enumeradores.Accion.Eliminar, Cliente)
    End Sub
#End Region

End Class
