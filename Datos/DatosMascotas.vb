Imports System.Text
Imports System.Data.SqlClient
Public Class DatosMascotas
    Public Function CoonsultarMascotas(ByVal Optional paramIdentificacionDueno As String = "-1", ByVal Optional paramIdentificacionMascota As String = "-1") As DataTable
        Try
            Dim consultaSQL As New StringBuilder

            With consultaSQL
                .Append("SELECT  identificacion_dueno,identificacion_mascotas,nombre_mascota,cod_tipo,raza,peso,estado_salud,fecha_nacimiento FROM mascotas")

                If paramIdentificacionDueno <> "-1" And paramIdentificacionMascota <> "-1" Then ' si es diferente a -1 , utiliza el filtro, osea agregueme el where 
                    .Append(" WHERE identificacion_dueno = ")
                    .Append(paramIdentificacionDueno)
                    .Append(" and ")
                    .Append("identificacion_mascotas= ")
                    .Append(paramIdentificacionMascota)
                End If

            End With

            'ejecuta la consulta a nivel de la base de datos
            Dim sqlEjecucion As New DatosSQL
            Dim dtClientes As DataTable = sqlEjecucion.QueryDBwithDT(consultaSQL.ToString)

            Return dtClientes

        Catch ex As Exception
            Throw ex
        End Try
    End Function


#Region "Manejo de Procedimientos almacenados en DatosMascotas"
    Public Sub GrabarMascotaEnDatos(Accion As Entidades.Enumeradores.Accion, Mascota As Entidades.Mascotas)
        Try
            Dim strNombreSP As String = "SP_Mascotas"

            'lista parametros q se va mandar a datos
            Dim lstParametros As New List(Of SqlParameter) From {
            New SqlParameter("@accion", CShort(Accion)),
            New SqlParameter("@identificacionDueno", Mascota.IdentificacionDueno.IdentificacionCliente),
            New SqlParameter("@identificacionMascota", Mascota.CodigoMascota),
            New SqlParameter("@nombreMAscota", Mascota.NombreMascota),
            New SqlParameter("@codTipo", Mascota.TipoMascota),
            New SqlParameter("@raza", Mascota.Raza),
            New SqlParameter("@peso", Mascota.Peso),
            New SqlParameter("@estadoSalud", Mascota.EstadoSalud),
            New SqlParameter("@fechaNacimineto", Mascota.FechaNacimiento)
            }

            'objeto q ejecuta el procedimineto SP
            Dim objDatosSQL As New DatosSQL

            objDatosSQL.ExecuteSP(strNombreSP, lstParametros)


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

End Class
