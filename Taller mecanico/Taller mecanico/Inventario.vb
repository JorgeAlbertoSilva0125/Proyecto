Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Public Class Inventario
    Dim comandos As New MySqlCommand
    Dim adaptador As New MySqlDataAdapter
    Dim datos As New DataSet
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'conectamos la base de datos 
        ' conexion.ConnectionString = "server='localhost'; user='root'; password=''; Database='taller_mecanico1'"
        ' Conectarse()
    End Sub
    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        Clientes.Show()
        Me.Close()
    End Sub

    Private Sub AgendaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgendaToolStripMenuItem.Click
        Agenda.Show()
        Me.Close()
    End Sub

    Private Sub HistorialYSeguimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistorialYSeguimientoToolStripMenuItem.Click
        Historial_y_Seguimiento.Show()
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
            actualizar = "UPDATE inventario SET nombre_refaccion='" & Txt1.Text & "', tipo_refaccion='" & Cmb1.SelectedItem & "' ,ubicacion='" & Txt3.Text & "',existencia_taller='" & Txt4.Text & "' ,cantidad_minima='" & Txt5.Text & "' ,entradas='" & Txt8.Text & "',salidas= '" & Txt7.Text & "' ,hora='" & Txt6.Text & "' , fecha='" & fecha.Text & "',costo_refacciones='" & Txt9.Text & "' WHERE nombre_refaccion='" & Txt1.Text & "'"
            comandos = New MySqlCommand(actualizar, conexion)
            comandos.ExecuteNonQuery()
            MsgBox("Los Datos se han actualizado con exito ")
            Txt1.Clear()
            Cmb1.Items.Clear()
            Txt3.Clear()
            Txt4.Clear()
            Txt5.Clear()
            Txt6.Clear()
            Txt7.Clear()
            Txt8.Clear()
            Txt9.Clear()


        Catch ex As Exception
            MsgBox("Los datos no se actualizaron")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Codigo para insertar 

        comandos = New MySqlCommand("INSERT INTO inventario(num_articulo,nombre_refaccion,tipo_refaccion,ubicacion,existencia_taller,cantidad_minima,entradas,salidas,hora,fecha,costo_refacciones)" & Chr(13) &
                                          "VALUES('',@nombre_refaccion,@tipo_refaccion,@ubicacion,@existencia_taller,@cantidad_minima,@entradas,@salidas,@hora,@fecha,@costo_refacciones)", conexion)

        conexion.Open()

        If Txt1.Text <> "" Then
            comandos.Parameters.AddWithValue("@nombre_refaccion", Txt1.Text)
            comandos.Parameters.AddWithValue("@tipo_refaccion", Cmb1.SelectedItem)
            comandos.Parameters.AddWithValue("@ubicacion", Txt3.Text)
            comandos.Parameters.AddWithValue("@existencia_taller", Txt4.Text)
            comandos.Parameters.AddWithValue("@cantidad_minima", Txt5.Text)
            comandos.Parameters.AddWithValue("@entradas", Txt8.Text)
            comandos.Parameters.AddWithValue("@salidas", Txt7.Text)
            comandos.Parameters.AddWithValue("@hora", Txt6.Text)
            comandos.Parameters.AddWithValue("@fecha", fecha.Text)
            comandos.Parameters.AddWithValue("@costo_refacciones", Txt9.Text)
            comandos.ExecuteNonQuery()

            MsgBox("Datos guardados")
            Txt1.Clear()
            Cmb1.Items.Clear()
            Txt3.Clear()
            Txt4.Clear()
            Txt5.Clear()
            Txt6.Clear()
            Txt7.Clear()
            Txt8.Clear()
            Txt9.Clear()
        Else

            Txt1.Text = ""
            Cmb1.Text = ""
            Txt3.Text = ""
            Txt4.Text = ""
            Txt5.Text = ""
            Txt6.Text = ""
            Txt7.Text = ""
            Txt8.Text = ""
            Txt9.Text = ""

            MsgBox("Error al registar cliente")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Codigo para eliminar 
        Dim eliminar As String
        Dim si As Byte
        si = MsgBox("¿Desea eliminar?", vbYesNo, "Eliminar")
        If si = 6 Then
            eliminar = "DELETE FROM Inventario  WHERE nombre_refaccion='" & TextBox10.Text & "' and tipo_refaccion='" & ComboBox2.SelectedItem & "'"
            comandos = New MySqlCommand(eliminar, conexion)
            comandos.ExecuteNonQuery()
            MsgBox("Eliminado")
            TextBox10.Clear()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If MsgBox("Desea cancelar el registro", vbQuestion + vbYesNo) = vbYes Then

            Txt1.Clear()
            Cmb1.Items.Clear()
            Txt3.Clear()
            Txt4.Clear()
            Txt5.Clear()
            Txt6.Clear()
            Txt7.Clear()
            Txt8.Clear()
            Txt9.Clear()

        End If


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Cerrar form Inventario 
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Consulta tabla inventario 
        Dim consulta As String
        Dim lista As Byte

        consultainventario(DataGridView1)

        If TextBox10.Text <> "" And ComboBox2.SelectedItem <> "" Then

            consulta = "Select * FROM inventario WHERE nombre_refaccion ='" & TextBox10.Text & "'and tipo_refaccion='" & ComboBox2.SelectedItem & "'"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            datos = New DataSet
            adaptador.Fill(datos, "inventario")
            lista = datos.Tables("inventario").Rows.Count

            If lista <> 0 Then
                'TextBox10.Text = datos.Tables("inventario").Rows(0).Item("nombre_refaccion")
                'combobox2.Text = datos.Tables("inventario").Rows(0).Item("tipo_refaccion")
                DataGridView1.DataSource = datos
                DataGridView1.DataMember = "inventario"
            Else
                MsgBox("datos no encontrados")

            End If

        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Txt1.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString)
        Cmb1.SelectedItem = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString)
        Txt3.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString)
        Txt4.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString)
        Txt5.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString)
        Txt6.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(8).Value.ToString)
        Txt7.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString)
        Txt8.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString)
        fecha.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(9).Value.ToString)
        Txt9.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(10).Value.ToString)


    End Sub
End Class