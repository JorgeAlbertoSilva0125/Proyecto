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
        'Consulta tabla clientes 
        Dim consulta As String
        Dim lista As Byte

        consultagenda(DataGridView1)

        If TextBox14.Text <> "" Then ' (And calendario.SelectionEnd <> "") 

            consulta = "Select * FROM agenda WHERE nombre ='" & TextBox14.Text & "'" ' and fecha='" & calendario.SelectionEnd & "'"
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
End Class