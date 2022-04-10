Imports Negocios

Public Class ConsultasMascotas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Me.lblError.Visible = False

            Dim iUsuario As Entidades.Usuarios = CType(Session("UsuarioLogueado"), Entidades.Usuarios)

            If iUsuario Is Nothing Then
                FormsAuthentication.RedirectToLoginPage()
            End If

            Dim objNegocios As New MascotasNegocios

            Dim dtMascotas As DataTable = objNegocios.ConsultarMascotas

            Dim strMascotas As New System.Text.StringBuilder

            For Each drMascotas As DataRow In dtMascotas.Rows
                With strMascotas
                    .AppendLine("<tr>")
                    .Append("<th scope=""row"">" & CInt(drMascotas("identificacion_mascotas")) & "</th>")
                    .Append("<td>" & CStr(drMascotas("nombre_mascota")) & "</td>")
                    .Append("<td>" & CStr(drMascotas("cod_tipo")) & "</td>")
                    .Append("<td>" & CStr(drMascotas("raza")) & "</td>")
                    .Append("<td>" & CStr(drMascotas("raza")) & "</td>")
                    .Append("<td>" & CStr(drMascotas("peso")) & "</td>")
                    .Append("<td>" & CStr(drMascotas("estado_salud")) & "</td>")
                    .Append("<td>" & CStr(drMascotas("fecha_nacimiento")) & "</td>")
                    .Append("<td><a class=""btn btn-info"" href=""Mascotas.aspx""  role=""button"">Modificar</a></td>")
                    .Append("<td><a class=""btn btn-danger"" href=""Mascotas.aspx""  role=""button"">Eliminar</a></td>")
                    .Append("</tr>")
                End With
            Next

            lstMascotas.InnerHtml = strMascotas.ToString
            Me.divtablaMascotas.Visible = True


        Catch ex As Exception
            'envio a la pag de error porque hubo problemas cuando apenas se estaba construyendo
            Session("Error") = ex
            Response.Redirect("~/Paginas/frmPaginaError", False)
        End Try

    End Sub

End Class