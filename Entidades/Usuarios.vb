Public Class Usuarios

#Region "variables"
    Private strUsuario As String
    Private strPassword As String
    Private blnCredencialValida As Boolean = False
#End Region

#Region "Properties"
    Public Property Usuario As String
        Get
            Return strUsuario
        End Get
        Set(value As String)
            strUsuario = value
        End Set
    End Property

    Public Property Password As String
        Get
            Return strPassword
        End Get
        Set(value As String)
            strPassword = value
        End Set
    End Property

    Public Property CredencialValida As Boolean
        Get
            Return blnCredencialValida
        End Get
        Set(value As Boolean)
            blnCredencialValida = value
        End Set
    End Property

#End Region


End Class
