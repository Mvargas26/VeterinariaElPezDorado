Public Class Usuarios

#Region "variables"
    Private strUsuario As String
    Private strPassword As String
    Private shtCodUsuario As Short
    Private blnCredencialValida As Boolean = False
#End Region

#Region "Constructor"
    Public Sub Usuarios(strUsuario As String, strPassword As String)
        Me.strUsuario = strUsuario
        Me.strPassword = strPassword
    End Sub

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

    Public Property CodUsuario As Short
        Get
            Return shtCodUsuario
        End Get
        Set(value As Short)
            shtCodUsuario = value
        End Set
    End Property

#End Region


End Class
