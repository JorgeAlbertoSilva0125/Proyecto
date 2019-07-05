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
            Txt1.Clear()
            Txt2.Clear()
            Txt3.Clear()
            Txt4.Clear()
            Txt5.Clear()
            Txt6.Clear()
            Txt7.Clear()
            Txt8.Clear()
            Txt9.Clear()
            Txt10.Clear()
            Txt11.Clear()


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
        'codigo para actualizar registros 
        Dim actualizar As String
        Try
            actualizar = "UPDATE clientes SET nombre='" & Txt1.Text & "', RFC='" & Txt2.Text & "' ,direccion='" & Txt3.Text & "',telefono='" & Txt4.Text & "' ,municipio='" & Txt6.Text & "' ,CP='" & Txt5.Text & "',email= '" & Txt8.Text & "' ,estado='" & Txt7.Text & "' ,marca_vehiculo='" & Txt9.Text & "' ,modelo_vehiculo='" & Txt10.Text & "' ,placas= '" & Txt11.Text & "' WHERE nombre='" & TextBox14.Text & "'"
            comandos = New MySqlCommand(actualizar, conexion)
            comandos.ExecuteNonQuery()
            MsgBox("Los Datos se han actualizado con exito ")
            Txt1.Clear()
            Txt2.Clear()
            Txt3.Clear()
            Txt4.Clear()
            Txt5.Clear()
            Txt6.Clear()
            Txt7.Clear()
            Txt8.Clear()
            Txt9.Clear()
            Txt10.Clear()
            Txt11.Clear()
        Catch ex As Exception
            MsgBox("Los datos no se actualizaron")
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        ' Mostrar datos de datadridview en los texbox correspondientes 
        Txt1.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString)
        Txt2.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString)
        Txt3.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString)
        Txt4.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString)
        Txt5.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString)
        Txt6.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString)
        Txt7.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(8).Value.ToString)
        Txt8.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString)
        Txt9.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(9).Value.ToString)
        Txt10.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(10).Value.ToString)
        Txt11.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(11).Value.ToString)


    End Sub
End Class