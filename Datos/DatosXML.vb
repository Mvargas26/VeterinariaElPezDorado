Imports System.Xml

Public Class DatosXML
    'metodo que lee el documento y lo pasara a negocios
    Public Function LeerXMLenDatos(URL As String)
        Dim lectorEnDatos As New XmlDocument
        lectorEnDatos.Load(URL)

        Return lectorEnDatos
    End Function
End Class
