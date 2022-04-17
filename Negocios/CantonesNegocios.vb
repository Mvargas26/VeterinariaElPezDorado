Imports Datos
Imports Entidades
Public Class CantonesNegocios
    Public Function ConsultarCantonesEnNegocios() As DataTable
        Try
            Dim iCantones As New DatosCantones

            Return iCantones.ConsultarCantones
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarEnNegociosPorProvincia(CodigoProvincia As Short) As DataTable
        Try
            Dim iCantones As New DatosCantones

            Return iCantones.ConsultarCantones(CodigoProvincia)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
