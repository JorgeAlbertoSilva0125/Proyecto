Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Public Class Clientes
    Dim comandos As New MySqlCommand
    Dim adaptador As New MySqlDataAdapter
    Dim datos As New DataSet
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'conectamos la base de datos 
        ' conexion.ConnectionString = "server='localhost'; user='root'; password=''; Database='taller_mecanico1'"
        ' Conectarse()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Codigo para insertar 


        comandos = New MySqlCommand("INSERT INTO clientes(id_cliente,nombre,RFC,direccion,telefono,municipio,CP,email,estado,marca_vehiculo,modelo_vehiculo,placas)" & Chr(13) &
                                      "VALUES('',@nombre,@RFC,@direccion,@telefono,@municipio,@CP,@email,@estado,@marca_vehiculo,@modelo_vehiculo,@placas)", conexion)
        If Txt1.Text <> "" Then
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



        Else

            Txt1.Text = ""
            Txt2.Text = ""
            Txt3.Text = ""
            Txt4.Text = ""
            Txt5.Text = ""
            Txt6.Text = ""
            Txt7.Text = ""
            Txt8.Text = ""
            Txt9.Text = ""
            Txt10.Text = ""
            Txt11.Text = ""
            MsgBox("Error al registar cliente")
        End If


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Cerrar form clientes 
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'Consulta tabla clientes 
        Dim consulta As String
        Dim lista As Byte

        consultaclientes(DataGridView1)

        If TextBox14.Text <> "" Then

            consulta = "Select * FROM clientes WHERE nombre ='" & TextBox14.Text & "'"
                adaptador = New MySqlDataAdapter(consulta, conexion)
            datos = New DataSet
            adaptador.Fill(datos, "clientes")
            lista = datos.Tables("clientes").Rows.Count

            If lista <> 0 Then
                'TextBox13.Text = datos.Tables("clientes").Rows(0).Item("RFC")
                'TextBox12.Text = datos.Tables("clientes").Rows(0).Item("placas")
                DataGridView1.DataSource = datos
                DataGridView1.DataMember = "clientes"
            Else
                MsgBox("datos no encontrados")

            End If

        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Codigo para eliminar 
        Dim eliminar As String
        Dim si As Byte
        si = MsgBox("¿Desea eliminar?", vbYesNo, "Eliminar")
        If si = 6 Then
            eliminar = "DELETE FROM clientes WHERE nombre='" & TextBox14.Text & "'"
            comandos = New MySqlCommand(eliminar, conexion)
            comandos.ExecuteNonQuery()
            MsgBox("Eliminado")
            TextBox14.Clear()
            TextBox13.Clear()
            TextBox12.Clear()

        End If

    End Sub

    Private Sub HistorialYSeguimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistorialYSeguimientoToolStripMenuItem.Click
        Historial_y_Seguimiento.Show()
        Me.Close()
    End Sub

    Private Sub AgendaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgendaToolStripMenuItem.Click
        Agenda.Show()
        Me.Close()
    End Sub

    Private Sub InventarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventarioToolStripMenuItem.Click
        Inventario.Show()
        Me.Close()
    End Sub

    Private Sub FacturacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturacionToolStripMenuItem.Click
        Facturacion.Show()
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim actualizar As String

        actualizar = "UPDATE clientes SET nombre=@nombre, RFC=@RFC ,direccion=@direccion ,telefono=@telefono ,municipio=@municipio ,CP=@CP ,email=@email ,estado=@estado ,marca_vehiculo=@marca_vehiculo ,modelo_vehiculo=@modelo_vehiculo ,placas=@placas WHERE nombre=@nombre "
        comandos = New MySqlCommand(actualizar, conexion)

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
        MsgBox("Los Datos se han actualizado ")
    End Sub
End Class