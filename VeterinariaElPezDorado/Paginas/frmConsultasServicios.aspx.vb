Public Class Consultas_por_servicios
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.lblError.Visible = False

            Dim iUsuario As Entidades.Usuarios = CType(Session("UsuarioLogueado"), Entidades.Usuarios)

            If iUsuario Is Nothing Then
                FormsAuthentication.RedirectToLoginPage()
            End If

            Dim iServicio As New Negocios.ServiciosNegocios
            Dim dtServicio As DataTable = iServicio.consultaServiciosGrabados(0)
            Dim sbConsulta As New StringBuilder
            'En el forEach recorremos la consulta de los servicios registrados y los agregamos a un StringBuilder para luego mostrarlo en la pagina.
            For Each dr As DataRow In dtServicio.Rows
                With sbConsulta
                    .AppendLine("<tr>")
                    .AppendLine("<th scope = ""row"" >" & dr.Item(0) & "</th>")
                    .AppendLine("<td>" & dr.Item(1) & "</td>")
                    .AppendLine("<td>" & dr.Item(2) & "</td>")
                    .AppendLine("<td>" & dr.Item(3) & "</td>")
                    .AppendLine("<td>" & dr.Item(4) & "</td>")
                    .AppendLine("<td>" & dr.Item(5) & "</td>")
                    .AppendLine("<td>" & dr.Item(6) & "</td>")
                    .AppendLine("</tr>")

                End With

            Next

            Me.lstConsultaServicios.InnerHtml = sbConsulta.ToString  'aqui le pasamos a la tabla en html
        Catch ex As Exception
            'envio a la pag de error porque hubo problemas cuando apenas se estaba construyendo
            Session("Error") = ex
            Response.Redirect("~/Paginas/frmPaginaError", False)
        End Try

    End Sub

End Class