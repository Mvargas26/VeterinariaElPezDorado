Public Class SiteMaster
    Inherits MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub LoginVeterinaria_Authenticate(sender As Object, e As AuthenticateEventArgs) Handles LoginVeterinaria.Authenticate
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "Alerta", "javascript:alert('Inicio de sección efectivo');", True)
    End Sub
End Class