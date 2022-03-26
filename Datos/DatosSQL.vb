Imports System.Data.SqlClient
Imports System.Configuration

Public Class DatosSQL

    Dim sqlConn As SqlConnection 'variable q me permite conectarme
    Public Sub New() 'constructor
        Try
            Dim strConector As New System.Text.StringBuilder 'objeto almacena string de conexion

            With strConector
                .Append("Data Source=")
                .Append(ConfigurationManager.AppSettings("ServerName"))
                .Append(";Initial Catalog=")
                .Append(ConfigurationManager.AppSettings("DBName"))
                '.Append(";Integrated Security=True;Trusted_Connection=true") ' con esta linea ingresa usando autentificacion de windows
                .Append(";User=")
                .Append(ConfigurationManager.AppSettings("UserDB"))
                .Append(";Password=")
                .Append(ConfigurationManager.AppSettings("PassDB"))
            End With

            Me.sqlConn = New SqlConnection(strConector.ToString) 'convertimos la variable en un objeto

        Catch sql As SqlException
            Throw sql
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function QueryDBwithDT(ByVal QuerySQL As String) As DataTable
        Try

            Dim cmd As New SqlCommand(QuerySQL) With {
            .Connection = Me.sqlConn
            }

            Dim adapter As New SqlDataAdapter(cmd) ' objeto adaptador q ejecuta la consulta

            Dim Tabla_Datos As New DataTable ' almacena info obtenida de la B.D

            adapter.Fill(Tabla_Datos)  'con fill abre conexion a B.D, ejecuta consulta, toma la info,agrega info al dataTable, cierra consulta

            Return Tabla_Datos ' retornamos el data set ya con la info 

        Catch sql As SqlException
            If sqlConn.State = ConnectionState.Open Then
                sqlConn.Close()
            End If
            Throw sql
        Catch ex As Exception
            Throw ex
        End Try


    End Function

#Region "Manejo de Procedimientos Almacenados"

    Public Sub ExecuteSP(ByVal SPName As String, ByVal ListaParametros As List(Of SqlParameter))
        Try
            'indica la consulta de base de datos que se desea ejecutar
            Dim cmd As New SqlCommand() With {
                .CommandType = CommandType.StoredProcedure,
                .CommandText = SPName,'NOmbre del procedimiento almacenado
                .Connection = Me.sqlConn
            }

            'agrega los parametros a la ejecución del SP
            For Each sqlParam As SqlParameter In ListaParametros
                cmd.Parameters.Add(sqlParam)
            Next

            'abrimos la conexion con la BD
            sqlConn.Open()

            'ejecuta la consulta de base de datos
            cmd.ExecuteNonQuery()

            'cierra la conexión con la base de datos
            'Siempre es importante cerar la conexion ya que las coneciones a las bases de datos son finitas.
            sqlConn.Close()

        Catch sql As SqlException
            If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
            Throw sql
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ExecuteSPWithDT(ByVal SPName As String, ByVal ListaParametros As List(Of SqlParameter)) As DataTable
        Try
            'indica la consulta de base de datos que se desea ejecutar
            Dim cmd As New SqlCommand() With {
                .CommandType = CommandType.StoredProcedure,
                .CommandText = SPName,
                .Connection = Me.sqlConn
            }

            'agrega los parametros a la ejecución del SP
            For Each sqlParam As SqlParameter In ListaParametros
                cmd.Parameters.Add(sqlParam)
            Next

            'objeto para ejecutar la consulta de la base de datos que retorna información
            Dim adapter As New SqlDataAdapter(cmd)

            'objeto para almacenar la información que se obtiene de la base de datos
            Dim dtDatos As New DataTable

            'ejecuta la consulta
            adapter.Fill(dtDatos)

            'retorna el resultado obtenido
            Return dtDatos

        Catch sql As SqlException
            If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
            Throw sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
