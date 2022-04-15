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


        Catch ex As Exception
            'envio a la pag de error porque hubo problemas cuando apenas se estaba construyendo
            Session("Error") = ex
            Response.Redirect("~/Paginas/frmPaginaError", False)
        End Try

    End Sub

    Protected Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Try
            Dim objNegocios As New MascotasNegocios

            Dim dtMascotas As DataTable = objNegocios.ConsultarMascotaparaUnDueno(Me.txtIdentificacionConsulta.Text)

            Dim strMascotas As New System.Text.StringBuilder

            For Each drMascotas As DataRow In dtMascotas.Rows
                With strMascotas
                    .AppendLine("<tr>")
                    .Append("<th scope=""row"">" & CInt(drMascotas("ID_Mascota")) & "</th>")
                    .Append("<td>" & CStr(drMascotas("Nombre_Mascota")) & "</td>")
                    .Append("<td>" & CStr(drMascotas("Tipo_Mascota")) & "</td>")
                    .Append("<td>" & CStr(drMascotas("Raza")) & "</td>")
                    .Append("<td>" & CStr(drMascotas("Peso")) & "</td>")
                    .Append("<td>" & CStr(drMascotas("Estado_Salud")) & "</td>")
                    .Append("<td>" & CStr(drMascotas("Fecha_Nacimiento")) & "</td>")
                    .Append("<td><a class=""btn btn-info"" href=""frmMascotas.aspx""  role=""button"">Modificar</a></td>")
                    .Append("<td><a class=""btn btn-danger"" href=""frmMascotas.aspx""  role=""button"">Eliminar</a></td>")
                    .Append("</tr>")
                End With
            Next

            lstMascotas.InnerHtml = strMascotas.ToString
            Me.divtablaMascotas.Visible = True
        Catch ex As Exception
            Me.lblError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try
    End Sub
End Class