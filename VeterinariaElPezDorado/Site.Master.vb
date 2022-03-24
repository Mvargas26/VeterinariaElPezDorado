Public Class SiteMaster
    Inherits MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Try
            Dim iUsuario As Entidades.Usuarios = CType(Session("UsuarioLogueado"), Entidades.Usuarios)

            If iUsuario IsNot Nothing Then
                Me.mnConsulta.Visible = True
                Me.mnMantenimientos.Visible = True
                Me.mnVeterinaria.Visible = True
                Me.mnAcercaDe.Visible = True
                Me.btnInicioSesion.Visible = False
            Else
                Me.mnConsulta.Visible = False
                Me.mnMantenimientos.Visible = False
                Me.mnVeterinaria.Visible = False
                Me.mnAcercaDe.Visible = False
            End If
        Catch ex As Exception
            Session("Error") = ex
            Response.Redirect("~/Paginas/frmPaginaError")
        End Try


    End Sub

    Protected Sub LoginVeterinaria_Authenticate(sender As Object, e As AuthenticateEventArgs) Handles LoginVeterinaria.Authenticate
        Try
            Dim strUsuario As String = Me.LoginVeterinaria.UserName
            Dim strPassword As String = Me.LoginVeterinaria.Password

            'Validamos las creedenciales
            'Instancia del objeto para validar las credenciales.
            Dim iSeguridad As New Negocios.seguridad
            Dim iUsuario As Entidades.Usuarios = iSeguridad.validarCredencial(strUsuario, strPassword)

            If iUsuario.CredencialValida Then
                Session("UsuarioLogueado") = iUsuario
                Response.Redirect(FormsAuthentication.DefaultUrl, False)
            Else
                Response.Redirect(FormsAuthentication.LoginUrl, False)
            End If

        Catch ex As Exception
            Session("Error") = ex
            Response.Redirect("~/Paginas/frmPaginaError")
        End Try
    End Sub
End Class