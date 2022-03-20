Imports System.Data.SqlClient
Imports System.Configuration

Public Class DatosSQL

    Dim conectar_A_SQL_Datos As SqlConnection 'variable q me permite conectarme
    Public Sub New() 'constructor
        Try
            Dim strConector As New System.Text.StringBuilder 'objeto almacena string de conexion

            With strConector
                .Append("Data Source=")
                .Append(ConfigurationManager.AppSettings("ServerName"))
                .Append(";Initial Catalog=")
                .Append(ConfigurationManager.AppSettings("DBName"))
                .Append(";Integrated Security=True;Trusted_Connection=true") ' con esta linea ingresa usando autentificacion de windows
                '.Append(";User=")
                '.Append(ConfigurationManager.AppSettings("UserDB"))
                '.Append(";Password=")
                '.Append(ConfigurationManager.AppSettings("PassDB"))
            End With

            Me.conectar_A_SQL_Datos = New SqlConnection(strConector.ToString) 'convertimos la variable en un objeto

        Catch sql As SqlException
            Throw sql
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function QueryDBwithDT(ByVal QuerySQL As String) As DataTable
        Try

            Dim cmd As New SqlCommand(QuerySQL) With {
            .Connection = Me.conectar_A_SQL_Datos
            }

            Dim adapter As New SqlDataAdapter(cmd) ' objeto adaptador q ejecuta la consulta

            Dim Tabla_Datos As New DataTable ' almacena info obtenida de la B.D

            adapter.Fill(Tabla_Datos)  'con fill abre conexion a B.D, ejecuta consulta, toma la info,agrega info al dataTable, cierra consulta

            Return Tabla_Datos ' retornamos el data set ya con la info 

        Catch sql As SqlException
            If conectar_A_SQL_Datos.State = ConnectionState.Open Then
                conectar_A_SQL_Datos.Close()
            End If
            Throw sql
        Catch ex As Exception
            Throw ex
        End Try


    End Function
End Class
