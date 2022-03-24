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
                '.Append(";Integrated Security=True;Trusted_Connection=true") ' con esta linea ingresa usando autentificacion de windows
                .Append(";User=")
                .Append(ConfigurationManager.AppSettings("UserDB"))
                .Append(";Password=")
                .Append(ConfigurationManager.AppSettings("PassDB"))
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


#Region "Manejo de Procedimientos Alacenados"
    Public Sub ExecuteSP(ByVal SP_Nombre As String, ByVal listaParametros As List(Of SqlParameter))
        Try

            Dim cmd As New SqlCommand() With {
            .CommandType = CommandType.StoredProcedure,
            .CommandText = SP_Nombre,
            .Connection = Me.conectar_A_SQL_Datos
            }


            For Each sqlParam As SqlParameter In listaParametros 'aqui comprobamos si la lista trae parametros y no venga vacia ni nula
                cmd.Parameters.Add(sqlParam) 'al obj comando le agregamos la lista de parametros que se llenaran en la clase q lo llame
            Next

            conectar_A_SQL_Datos.Open() ' abrimos conexion a la base de datos 

            cmd.ExecuteNonQuery() ' ejecuta la consulta

            conectar_A_SQL_Datos.Close() ' cierra la conexion 

        Catch sql As SqlException
            If conectar_A_SQL_Datos.State = ConnectionState.Open Then ' si la conexion esta abierta, cierrela 
                conectar_A_SQL_Datos.Close()
            End If
            Throw sql
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function ExecuteSP_withDT(ByVal SP_Nombre As String, ByVal listaParametros As List(Of SqlParameter)) As DataTable
        Try

            Dim cmd As New SqlCommand() With {
            .CommandType = CommandType.StoredProcedure,
            .CommandText = SP_Nombre,
            .Connection = Me.conectar_A_SQL_Datos
            }


            For Each sqlParam As SqlParameter In listaParametros 'aqui comprobamos si la lista trae parametros y no venga vacia ni nula
                cmd.Parameters.Add(sqlParam) 'al obj comando le agregamos la lista de parametros que se llenaran en la clase q lo llame
            Next

            Dim adapter As New SqlDataAdapter(cmd) ' objeto adaptador q ejecuta la consulta

            Dim Tabla_Datos As New DataTable ' almacena info obtenida de la B.D

            adapter.Fill(Tabla_Datos)  'con fill abre conexion a B.D, ejecuta consulta, toma la info,agrega info al dataset, cierra consulta

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
#End Region
End Class
