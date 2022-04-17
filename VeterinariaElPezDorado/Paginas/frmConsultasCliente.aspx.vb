Imports Negocios

Public Class ConsultasCliente
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.lblError.Visible = False

            Dim objNegocios As New ClientesNegocios

            Dim dtClientes As DataTable = objNegocios.ConsultarClientes

            Dim strClientes As New System.Text.StringBuilder

            For Each drClientes As DataRow In dtClientes.Rows
                With strClientes
                    .AppendLine("<tr>")
                    .Append("<th scope=""row"">" & CStr(drClientes("identificacion")) & "</th>")
                    .Append("<td>" & CStr(drClientes("nombre")) & "</td>")
                    .Append("<td>" & CStr(drClientes("apellidos")) & "</td>")
                    .Append("<td>" & CStr(drClientes("correo")) & "</td>")
                    .Append(" <td>" & If(drClientes("telefono") Is DBNull.Value, 0, CInt(drClientes("Telefono"))) & "</td>") ' si drclientes("telefono") viene vacio, ponga un 0, si no ponga lo que tiene Cint(drClientes("Telefono")
                    .Append("<td>" & CShort(drClientes("cod_provincia")) & "</td>")
                    .Append("<td>" & CShort(drClientes("cod_canton")) & "</td>")
                    .Append("<td>" & CStr(drClientes("distrito")) & "</td>")
                    .Append("<td>" & CStr(drClientes("direccion_Exacta")) & "</td>")
                    .Append("<td><a class=""btn btn-info"" href=""frmClientes.aspx""  role=""button"">Modificar</a></td>")
                    .Append("<td><a class=""btn btn-danger"" href=""frmClientes.aspx""  role=""button"">Eliminar</a></td>")
                    .Append("</tr>")
                End With
            Next

            lstClientes.InnerHtml = strClientes.ToString 'aqui le pasamos a la tabla en html lo que tiene el with de strClientes(codigo envevido)

            Dim iUsuario As Entidades.Usuarios = CType(Session("UsuarioLogueado"), Entidades.Usuarios)

            If iUsuario Is Nothing Then
                FormsAuthentication.RedirectToLoginPage()
            End If

        Catch ex As Exception
            'envio a la pag de error porque hubo problemas cuando apenas se estaba construyendo
            Session("Error") = ex
            Response.Redirect("~/Paginas/frmPaginaError", False)
        End Try

    End Sub

End Class