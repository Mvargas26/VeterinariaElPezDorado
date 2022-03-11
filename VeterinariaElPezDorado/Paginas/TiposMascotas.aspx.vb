Public Class TiposMascotas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '  Throw New Exception

        Catch ex As Exception
            Session("Error") = ex 'las variables de sesion permiten pasar info de una pagina a otra
            Response.Redirect("~/Paginas/frmPaginaError", False)
        End Try
    End Sub

End Class