Public Class Clientes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.lblError.Visible = False

        Catch ex As Exception
            'envio a la pag de erroe porque hubo problemas cuando apenas se estab construyendo
            Session("Error") = ex
            Response.Redirect("~/Paginas/frmPaginaError", False)
        End Try
    End Sub

    Protected Sub btnRegistrarCliente_Click(sender As Object, e As EventArgs) Handles btnRegistrarCliente.Click
        Try
            Me.lblMensajeError.Visible = False

            'comprueba primero que lo del html es correcto, trabaja con los validadores e la pg
            If Page.IsValid Then





            End If



        Catch ex As Exception
            'estas no van a otra apgina xq son cosas que se arreglan en la misma
            Me.lblError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try
    End Sub
End Class
'viewSate(" ") es el tipo de variables que nos permite guardar info en memoria para pasarlo a otro metodo o clase (vd 3 min 1:24)
'nota:esta info viaja en la pag