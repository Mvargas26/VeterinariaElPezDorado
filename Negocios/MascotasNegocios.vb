Imports Datos
Imports Entidades
Public Class MascotasNegocios

    'Devuelve todas las mascotas
    Public Function ConsultarMascotas() As DataTable
        Try
            Dim iMascotas As New DatosMascotas

            Return iMascotas.CoonsultarMascotas
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    'Devuelve las mascotas basadas en el dueno y el id de las mascotas
    Public Function ConsultarMascota(ByVal IdentificacionDueno, ByVal IdentificacionMascota) As Mascotas
        Try
            Dim iMascota As New DatosMascotas
            Dim dtMascotas As DataTable = iMascota.CoonsultarMascotas(IdentificacionDueno.ToString, IdentificacionMascota.ToString)

            Dim iInfoMascota As Mascotas = Nothing

            If dtMascotas IsNot Nothing Then
                Dim drMascotas As DataRow = dtMascotas.Rows(0)

                If dtMascotas.Rows.Count > 0 Then

                    iInfoMascota = New Mascotas With {
                       .IdentificacionDueno = New ClienteVeterinaria With {.IdentificacionCliente = CStr(drMascotas("identificacion_dueno"))},
                    .CodigoMascota = CInt(drMascotas("identificacion_mascotas")),
                    .NombreMascota = CStr(drMascotas("nombre_mascota")),
                    .TipoMascota = CShort(drMascotas("cod_tipo")),
                    .Raza = CStr(drMascotas("raza")),
                    .Peso = CInt(drMascotas("peso")),
                    .EstadoSalud = CStr(drMascotas("estado_salud")),
                    .FechaNacimiento = CDate(drMascotas("fecha_nacimiento"))}

                End If

            End If

            If iInfoMascota Is Nothing Then
                Throw New NullReferenceException(String.Format("No se obtuvo registro de mascotas para el cliente :", IdentificacionDueno))
            End If
            Return iInfoMascota
        Catch ex As Exception
            Throw ex
        End Try

    End Function



#Region "Manejo Procedimientos almacenados Registrar,Modificar,Eliminar en MAscotasNegocios"

    Private Sub MantenimientoMascotas(Accion As Entidades.Enumeradores.Accion, Mascota As Entidades.Mascotas)
        Dim objMascotasDatos As New Datos.DatosMascotas
        objMascotasDatos.GrabarMascotaEnDatos(Accion, Mascota)
    End Sub


    Public Sub RegistrarMascota(Mascota As Entidades.Mascotas)
        Me.MantenimientoMascotas(Entidades.Enumeradores.Accion.Registrar, Mascota)
    End Sub

    Public Sub MOdificarMascota(Mascota As Entidades.Mascotas)
        Me.MantenimientoMascotas(Entidades.Enumeradores.Accion.Modificar, Mascota)
    End Sub

    Public Sub EliminarMascota(Mascota As Entidades.Mascotas)
        Me.MantenimientoMascotas(Entidades.Enumeradores.Accion.Eliminar, Mascota)
    End Sub
#End Region
End Class
