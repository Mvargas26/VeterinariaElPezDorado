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
                    .Append("<th scope=""row"">" & CInt(drClientes("Identificacion")) & "</th>")
                    .Append("<td>" & CStr(drClientes("Nombre")) & "</td>")
                    .Append("<td>" & CStr(drClientes("Apellidos")) & "</td>")
                    .Append("<td>" & CStr(drClientes("Correo")) & "</td>")
                    .Append(" <td>" & If(drClientes("Telefono") Is DBNull.Value, 0, CInt(drClientes("Telefono"))) & "</td>") ' si drclientes("telefono") viene vacio, ponga un 0, si no ponga lo que tiene Cint(drClientes("Telefono")
                    .Append("<td>" & CShort(drClientes("codServicioUtilizado")) & "</td>")
                    .Append("<td><a class=""btn btn-info"" href=""Clientes.aspx""  role=""button"">Modificar</a></td>")
                    .Append("<td><a class=""btn btn-danger"" href=""Clientes.aspx""  role=""button"">Eliminar</a></td>")
                    .Append("</tr>")
                End With
            Next

            lstClientes.InnerHtml = strClientes.ToString 'aqui le pasamos a la tabla en html lo que tiene el with de strClientes(codigo envevido)


        Catch ex As Exception
            'envio a la pag de error porque hubo problemas cuando apenas se estaba construyendo
            Session("Error") = ex
            Response.Redirect("~/Paginas/frmPaginaError", False)
        End Try

    End Sub

End Class