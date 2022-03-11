Public Class frmPaginaError
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Dim ex As Exception = CType(Session("Error"), Exception)

            Me.lblMensaje.Text = ex.Message
            Me.lblErrorTecnico.Text = ex.StackTrace
        Catch ex As Exception
            'si me genera un error al leer la variable de sesion cae aqui
            Me.lblMensaje.Text = ex.Message
            Me.lblErrorTecnico.Text = ex.StackTrace
        End Try


    End Sub

End Class