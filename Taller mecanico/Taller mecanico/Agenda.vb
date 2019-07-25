Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Public Class Agenda
    Dim comandos As New MySqlCommand
    Dim adaptador As New MySqlDataAdapter
    Dim datos As New DataSet

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        Clientes.Show()
        Me.Close()
    End Sub

    Private Sub InventarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventarioToolStripMenuItem.Click
        Inventario.Show()
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'Consulta tabla clientes para mostrar los clientes en el formulario de agenda 
        Dim consulta As String
        Dim lista As Byte

        If TextBox1.Text <> "" Then

            consulta = "Select * FROM clientes WHERE nombre ='" & TextBox1.Text & "'"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            datos = New DataSet
            adaptador.Fill(datos, "clientes")
            lista = datos.Tables("clientes").Rows.Count

            If lista <> 0 Then
                ComboBox1.Text = datos.Tables("clientes").Rows(0).Item("nombre")
                'TextBox12.Text = datos.Tables("clientes").Rows(0).Item("placas")

                ' ComboBox1.DataSource = datos
                'ComboBox1.DisplayMember = "nombre"
            Else
                MsgBox("datos no encontrados")

            End If
            conexion.Close()

        End If
    End Sub

    Private Sub ComboBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboBox1.MouseClick
        'Consulta tabla clientes para escoger el cliente y despues poder llamar sus datos en el listbox 
        Dim consulta As String
        Dim lista As Byte

        If ComboBox1.SelectedText <> "" Then

            consulta = "Select * FROM clientes WHERE nombre ='" & ComboBox1.SelectedText & "'"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            datos = New DataSet
            adaptador.Fill(datos, "clientes")
            lista = datos.Tables("clientes").Rows.Count

            'ListBox1.Items.Add(Convert.ToString(datos.Tables("clientes").Rows(0).Item("placas")))
            If lista <> 0 Then
                ListBox1.Items.Add("RFC:" + " " + Convert.ToString(datos.Tables("clientes").Rows(0).Item("RFC")))
                ListBox1.Items.Add("Dirección:" + " " + Convert.ToString(datos.Tables("clientes").Rows(0).Item("direccion")))
                ListBox1.Items.Add("Municipio:" + " " + Convert.ToString(datos.Tables("clientes").Rows(0).Item("municipio")))
                ListBox1.Items.Add("Estado:" + " " + Convert.ToString(datos.Tables("clientes").Rows(0).Item("estado")))
                ListBox1.Items.Add("Códogo Postal:" + " " + Convert.ToString(datos.Tables("clientes").Rows(0).Item("CP")))
                ListBox1.Items.Add("Marca del Vehículo:" + " " + Convert.ToString(datos.Tables("clientes").Rows(0).Item("marca_vehiculo")))
                ListBox1.Items.Add("Modelo del Vehículo:" + " " + Convert.ToString(datos.Tables("clientes").Rows(0).Item("modelo_vehiculo")))
                ListBox1.Items.Add("Placas del Vehiculo:" + " " + Convert.ToString(datos.Tables("clientes").Rows(0).Item("placas")))

                'TextBox2.Text = datos.Tables("clientes").Rows(0).Item("direccion")
                'TextBox2.Text = datos.Tables("clientes").Rows(0).Item("municipio")
                'TextBox2.Text = datos.Tables("clientes").Rows(0).Item("CP")
                'TextBox2.Text = datos.Tables("clientes").Rows(0).Item("estado")
                'TextBox2.Text = datos.Tables("clientes").Rows(0).Item("marca_vehiculo")
                'TextBox2.Text = datos.Tables("clientes").Rows(0).Item("modelo_vehiculo")
                'TextBox2.Text = datos.Tables("clientes").Rows(0).Item("placas")

            Else

                MsgBox("datos no encontrados")

            End If
            conexion.Close()


        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Consulta tabla agenda
        Dim consulta As String
        Dim lista As Byte
        ' codigo que llama a la datagrid los datos que contiene la tabla agenda 

        Consultagenda(DataGridView1)

        If TextBox14.Text <> "" And Calendar_Consul.Text <> "" Then

            consulta = "Select * FROM agenda WHERE nombre ='" & TextBox14.Text & "' And fecha = '" & Calendar_Consul.Text & "'"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            datos = New DataSet
            adaptador.Fill(datos, "agenda")
            lista = datos.Tables("agenda").Rows.Count

            If lista <> 0 Then
                'TextBox13.Text = datos.Tables("clientes").Rows(0).Item("RFC")
                'TextBox12.Text = datos.Tables("clientes").Rows(0).Item("placas")
                DataGridView1.DataSource = datos
                DataGridView1.DataMember = "agenda"
            Else
                MsgBox("datos no encontrados")

            End If
            conexion.Close()



        End If

        'If Calendar_Consul.Value.ToShortDateString Then
        '    consulta = "Select * FROM agenda WHERE fecha='" & Calendar_Consul.Value.ToShortDateString & "'"
        '    adaptador = New MySqlDataAdapter(consulta, conexion)
        '    datos = New DataSet
        '    adaptador.Fill(datos, "agenda")
        '    lista = datos.Tables("agenda").Rows.Count

        '    If lista <> 0 Then
        '        'TextBox13.Text = datos.Tables("clientes").Rows(0).Item("RFC")
        '        'TextBox12.Text = datos.Tables("clientes").Rows(0).Item("placas")
        '        DataGridView1.DataSource = datos
        '        DataGridView1.DataMember = "agenda"
        '    Else
        '        MsgBox("datos no encontrados")

        '    End If
        '    conexion.Close()
        'End If
        ' conexion.Close()



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Codigo para eliminar 
        Dim eliminar As String
        Dim si As Byte
        si = MsgBox("¿Desea eliminar?", vbYesNo, "Eliminar")
        If si = 6 Then
            conexion.Open()
            eliminar = "DELETE FROM agenda WHERE nombre='" & TextBox14.Text & "'"
            comandos = New MySqlCommand(eliminar, conexion)
            comandos.ExecuteNonQuery()
            MsgBox("Eliminado")
            TextBox14.Clear()
            DataGridView1.Refresh()

        End If
        conexion.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Codigo para cancelar registo al seleccionar yes en el msbox 
        If MsgBox("Desea cancelar el registro", vbQuestion + vbYesNo) = vbYes Then

            TextBox1.Clear()
            ComboBox1.Items.Clear()
            ListBox1.Items.Clear()
            TextBox2.Clear()
            TextBox3.Clear()

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Codigo para insertar Cita 


        comandos = New MySqlCommand("INSERT INTO agenda(num_cita,nombre,fecha,hora,asunto)" & Chr(13) &
                                      "VALUES('',@nombre,@fecha,@hora,@asunto)", conexion)


        conexion.Open()
        If ComboBox1.Text <> "" Then
            comandos.Parameters.AddWithValue("@nombre", ComboBox1.Text)
            comandos.Parameters.AddWithValue("@fecha", Calendar.Text)
            comandos.Parameters.AddWithValue("@hora", TextBox3.Text)
            comandos.Parameters.AddWithValue("@asunto", TextBox2.Text)
            comandos.ExecuteNonQuery()
            MsgBox("Datos guardados")
            TextBox1.Clear()
            ComboBox1.Items.Clear()
            ListBox1.Items.Clear()
            TextBox2.Clear()
            TextBox3.Clear()


        Else

            TextBox1.Text = ""
            ComboBox1.Text = ""
            ListBox1.ResetText()
            TextBox2.Text = ""
            TextBox3.Text = ""
            MsgBox("Error al registar Cita")
        End If
        conexion.Close()
        DataGridView1.Refresh()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        ' Mostrar datos de datadridview en los campos correspondientes 
        id.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString)
        ComboBox1.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString)
        Calendar.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString)
        TextBox3.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString)
        TextBox2.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString)

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        'codigo para actualizar registros 
        Dim actualizar As String
        Try
            conexion.Open()

            actualizar = "UPDATE agenda SET nombre='" & ComboBox1.Text & "', fecha='" & Calendar.Text & "' ,hora='" & TextBox3.Text & "',asunto='" & TextBox2.Text & "' WHERE num_cita='" & id.Text & "'"
            comandos = New MySqlCommand(actualizar, conexion)
            comandos.ExecuteNonQuery()

            'comandos.Parameters.AddWithValue("@nombre", ComboBox1.Text)
            'comandos.Parameters.AddWithValue("@fecha", Calendar.Text)
            'comandos.Parameters.AddWithValue("@hora", TextBox3.Text)
            'comandos.Parameters.AddWithValue("@asunto", TextBox2.Text)

            MsgBox("Los datos se han actualizado con exito")
            TextBox1.Clear()
            ComboBox1.Items.Clear()
            ComboBox1.DataSource = Nothing
            ComboBox1.Refresh()
            ListBox1.Items.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
        Catch ex As Exception
            MsgBox("Los datos no se actualizaron")
        End Try
        conexion.Close()
        DataGridView1.Refresh()
    End Sub



    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        Sololetras(e)
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        Sololetras(e)
    End Sub

End Class