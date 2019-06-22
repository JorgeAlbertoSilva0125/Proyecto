
Public Class Clientes
    Dim comandos As New MySqlCommand
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'conectamos la base de datos 
        'conexion.ConnectionString = "server='localhost'; user='root'; password=''; Database='taller_mecanico'"
        ' Conectarse()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            comandos = New MySqlCommand("INSERT INTO clientes(id_cliente,nombre,RFC,direccion,telefono,municipio,CP,email,estado,marca_vehiculo,modelo_vehiculo,placas)" & Chr(13) &
                                        "VALUES(@id_cliente,@nombre,@RFC,@direccion,@telefono,@municipio,@CP,@email,@estado,@marca_vehiculo,@modelo_vehiculo,@placas)", conexion)
            'comandos.Parameters.AddWithValue("@id_cliente", Txt12.Text)
            comandos.Parameters.AddWithValue("@nombre", Txt1.Text)
            comandos.Parameters.AddWithValue("@RFC", Txt2.Text)
            comandos.Parameters.AddWithValue("@direccion", Txt3.Text)
            comandos.Parameters.AddWithValue("@telefono", Txt4.Text)
            comandos.Parameters.AddWithValue("@municipio", Txt6.Text)
            comandos.Parameters.AddWithValue("@CP", Txt5.Text)
            comandos.Parameters.AddWithValue("@email", Txt8.Text)
            comandos.Parameters.AddWithValue("@estado", Txt7.Text)
            comandos.Parameters.AddWithValue("@marca_vehiculo", Txt9.Text)
            comandos.Parameters.AddWithValue("@modelo_vehiculo", Txt10.Text)
            comandos.Parameters.AddWithValue("@placas", Txt11.Text)
            comandos.ExecuteNonQuery()
            MsgBox("Datos guardados")

        Catch ex As Exception

            MsgBox("Error al registar cliente")



        End Try
    End Sub
End Class