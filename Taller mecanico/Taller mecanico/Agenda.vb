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
        'Consulta tabla clientes 
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

        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboBox1.MouseClick
        'Consulta tabla clientes 
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

        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Consulta tabla agenda
        Dim consulta As String
        Dim lista As Byte
        ' codigo que llama a la datagrid los datos que contiene la tabla agenda 
        consultagenda(DataGridView1)

        If TextBox14.Text <> "" And Calendar_Consul.Text <> "" Then

            consulta = "Select * FROM agenda WHERE nombre ='" & TextBox14.Text & "' and fecha='" & Calendar_Consul.Text & "'"
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

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Codigo para eliminar 
        Dim eliminar As String
        Dim si As Byte
        si = MsgBox("¿Desea eliminar?", vbYesNo, "Eliminar")
        If si = 6 Then
            eliminar = "DELETE FROM agenda WHERE nombre='" & TextBox14.Text & "'"
            comandos = New MySqlCommand(eliminar, conexion)
            comandos.ExecuteNonQuery()
            MsgBox("Eliminado")
            TextBox14.Clear()

        End If
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
        'Codigo para insertar 


        comandos = New MySqlCommand("INSERT INTO agenda(id_cliente,nombre,RFC,direccion,telefono,municipio,CP,email,estado,marca_vehiculo,modelo_vehiculo,placas)" & Chr(13) &
                                      "VALUES('',@nombre,@RFC,@direccion,@telefono,@municipio,@CP,@email,@estado,@marca_vehiculo,@modelo_vehiculo,@placas)", conexion)
        'If Txt1.Text <> "" Then
        '    comandos.Parameters.AddWithValue("@nombre", Txt1.Text)
        '    comandos.Parameters.AddWithValue("@RFC", Txt2.Text)
        '    comandos.Parameters.AddWithValue("@direccion", Txt3.Text)
        '    comandos.Parameters.AddWithValue("@telefono", Txt4.Text)
        '    comandos.Parameters.AddWithValue("@municipio", Txt6.Text)
        '    comandos.Parameters.AddWithValue("@CP", Txt5.Text)
        '    comandos.Parameters.AddWithValue("@email", Txt8.Text)
        '    comandos.Parameters.AddWithValue("@estado", Txt7.Text)
        '    comandos.Parameters.AddWithValue("@marca_vehiculo", Txt9.Text)
        '    comandos.Parameters.AddWithValue("@modelo_vehiculo", Txt10.Text)
        '    comandos.Parameters.AddWithValue("@placas", Txt11.Text)
        '    comandos.ExecuteNonQuery()
        '    MsgBox("Datos guardados")
        '    TextBox1.Clear()
        '    ComboBox1.Items.Clear()
        '    ListBox1.Items.Clear()
        '    TextBox2.Clear()
        '    TextBox3.Clear()


        'Else

        '    Txt1.Text = ""
        '    Txt2.Text = ""
        '    Txt3.Text = ""
        '    Txt4.Text = ""
        '    Txt5.Text = ""
        '    Txt6.Text = ""
        '    Txt7.Text = ""
        '    Txt8.Text = ""
        '    Txt9.Text = ""
        '    Txt10.Text = ""
        '    Txt11.Text = ""
        '    MsgBox("Error al registar cliente")
        'End If
    End Sub
End Class