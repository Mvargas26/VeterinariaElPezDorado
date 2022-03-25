Imports Negocios

Public Class Consultas_por_servicios
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.lblError.Visible = False

            Dim iUsuario As Entidades.Usuarios = CType(Session("UsuarioLogueado"), Entidades.Usuarios)

            If iUsuario Is Nothing Then
                FormsAuthentication.RedirectToLoginPage()
            End If
            '------------------------------------------------------------------------------------------------
            Dim objNegocios As New DireccionNegocios

            Dim dtClientes As DataTable = objNegocios.ConsultarTodasDirecionesenNegocios

            Dim strClientes As New System.Text.StringBuilder

            For Each drClientes As DataRow In dtClientes.Rows
                With strClientes
                    .AppendLine("<tr>")
                    .Append("<th scope=""row"">" & CShort(drClientes("cod_direccion")) & "</th>")
                    .Append("<td>" & CStr(drClientes("cod_provincia")) & "</td>")
                    .Append("<td>" & CStr(drClientes("cod_canton")) & "</td>")
                    .Append("<td>" & CStr(drClientes("distrito")) & "</td>")
                    .Append("<td>" & CStr(drClientes("direccion_exacta")) & "</td>")
                    .Append("<td><a class=""btn btn-info"" href=""Clientes.aspx""  role=""button"">Modificar</a></td>")
                    .Append("<td><a class=""btn btn-danger"" href=""Clientes.aspx""  role=""button"">Eliminar</a></td>")
                    .Append("</tr>")
                End With
            Next

            lstServicios.InnerHtml = strClientes.ToString



        Catch ex As Exception
            'envio a la pag de error porque hubo problemas cuando apenas se estaba construyendo
            Session("Error") = ex
            Response.Redirect("~/Paginas/frmPaginaError", False)
        End Try

    End Sub

End Class