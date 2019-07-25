Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Public Class historial_y_seguimiento
    Dim comandos As New MySqlCommand
    Dim adaptador As New MySqlDataAdapter
    Dim datos As New DataSet
    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        Clientes.Show()
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Cerrar form Historial_y_Seguimiento      
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'Consulta tabla clientes para mostrar los clientes en el formulario de historial
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

    Private Sub Historial_y_Seguimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'conectamos la base de datos 
        ' conexion.ConnectionString = "server='localhost'; user='root'; password=''; Database='taller_mecanico1'"
        ' Conectarse()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Codigo para inserta 


        comandos = New MySqlCommand("INSERT INTO historialyseguimiento(num_historial,nombre,marca_vehiculo,modelo_vehiculo,reparacion,pendientes)" & Chr(13) &
                                      "VALUES('',@nombre,@marca_vehiculo,@modelo_vehiculo,@reparacion,@pendientes)", conexion)
        conexion.Open()

        If TextBox1.Text <> "" Then
            comandos.Parameters.AddWithValue("@nombre", ComboBox1.Text)
            comandos.Parameters.AddWithValue("@marca_vehiculo", TextBox3.Text)
            comandos.Parameters.AddWithValue("@modelo_vehiculo", TextBox4.Text)
            comandos.Parameters.AddWithValue("@reparacion", TextBox6.Text)
            comandos.Parameters.AddWithValue("@pendientes", TextBox8.Text)
            comandos.ExecuteNonQuery()
            MsgBox("Datos guardados")
            TextBox1.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox6.Clear()
            TextBox8.Clear()

            conexion.Close()


        Else

            TextBox1.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox6.Text = ""
            TextBox8.Text = ""
            MsgBox("Error al registar  Historial y Seguimiento")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Codigo para eliminar 
        Dim eliminar As String
        Dim si As Byte
        si = MsgBox("¿Desea eliminar?", vbYesNo, "Eliminar")
        conexion.Open()
        If si = 6 Then
            eliminar = "DELETE FROM historialyseguimiento WHERE nombre='" & TextBox10.Text & "'"
            comandos = New MySqlCommand(eliminar, conexion)
            comandos.ExecuteNonQuery()
            MsgBox("Eliminado")
            TextBox10.Clear()
            ComboBox1.Items.Clear()
            ComboBox1.DataSource = Nothing
            ComboBox1.Refresh()
            TextBox9.Clear()
            TextBox5.Clear()

            conexion.Close()

        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        ' Mostrar datos de datadridview en los texbox correspondientes 
        id.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString)
        ComboBox1.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString)
        TextBox3.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString)
        TextBox4.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString)
        TextBox6.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString)
        TextBox8.Text = Convert.ToString(DataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString)



    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'Consulta tabla  Historial_y_Seguimiento
        Dim consulta As String
        Dim lista As Byte
        Consultahistorialyseguimiento(DataGridView1)

        'If RadioButton4.Checked = False And RadioButton3.Checked = False And TextBox9.Text = "" And TextBox5.Text = "" And TextBox10.Text = "" Then
        '    Consultahistorialyseguimiento(DataGridView1)
        'End If


        If RadioButton3.Checked = True And TextBox9.Text = "" And TextBox5.Text = "" And RadioButton4.Checked = False Then

            consulta = "Select pendientes FROM historialyseguimiento WHERE nombre ='" & TextBox10.Text & "'"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            datos = New DataSet
            adaptador.Fill(datos, "historialyseguimiento")
            lista = datos.Tables("historialyseguimiento").Rows.Count

            If lista <> 0 Then

                'TextBox9.Text = datos.Tables(" Historial_y_Seguimiento").Rows(0).Item("marca_vehiculo")
                'TextBox5.Text = datos.Tables(" Historial_y_Seguimiento").Rows(0).Item("modelo_vehiculo")
                DataGridView1.DataSource = datos
                DataGridView1.DataMember = "historialyseguimiento"
            Else
                MsgBox("datos no encontrados")

            End If
            conexion.Close()

        End If



        If RadioButton3.Checked = True And TextBox10.Text = "" And TextBox5.Text = "" And RadioButton4.Checked = False Then
            'conexion.Open()

            consulta = "Select pendientes FROM historialyseguimiento WHERE marca_vehiculo ='" & TextBox9.Text & "'"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            datos = New DataSet
            adaptador.Fill(datos, "historialyseguimiento")
            lista = datos.Tables("historialyseguimiento").Rows.Count

            If lista <> 0 Then
                'TextBox2.Text = datos.Tables(" Historial_y_Seguimiento").Rows(0).Item("RFC")
                'TextBox9.Text = datos.Tables(" Historial_y_Seguimiento").Rows(0).Item("marca_vehiculo")
                'TextBox5.Text = datos.Tables(" Historial_y_Seguimiento").Rows(0).Item("modelo_vehiculo")
                DataGridView1.DataSource = datos
                DataGridView1.DataMember = "historialyseguimiento"
            Else
                MsgBox("datos no encontrados")

            End If
            conexion.Close()

        End If

        If RadioButton3.Checked = True And TextBox9.Text = "" And TextBox10.Text = "" And RadioButton4.Checked = False Then
            'conexion.Open()

            consulta = "Select pendientes FROM historialyseguimiento WHERE modelo_vehiculo ='" & TextBox5.Text & "'"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            datos = New DataSet
            adaptador.Fill(datos, "historialyseguimiento")
            lista = datos.Tables("historialyseguimiento").Rows.Count

            If lista <> 0 Then
                'TextBox2.Text = datos.Tables(" Historial_y_Seguimiento").Rows(0).Item("RFC")
                'TextBox9.Text = datos.Tables(" Historial_y_Seguimiento").Rows(0).Item("marca_vehiculo")
                'TextBox5.Text = datos.Tables(" Historial_y_Seguimiento").Rows(0).Item("modelo_vehiculo")
                DataGridView1.DataSource = datos
                DataGridView1.DataMember = "historialyseguimiento"
            Else
                MsgBox("datos no encontrados")

            End If
            conexion.Close()

        End If




        'Radiobutton Historial se selecciona hara lo siguiente 
        If RadioButton4.Checked = True And TextBox9.Text = "" And TextBox5.Text = "" And RadioButton3.Checked = False Then

            consulta = "Select * FROM historialyseguimiento WHERE nombre ='" & TextBox10.Text & "'"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            datos = New DataSet
            adaptador.Fill(datos, "historialyseguimiento")
            lista = datos.Tables("historialyseguimiento").Rows.Count

            If lista <> 0 Then
                'TextBox2.Text = datos.Tables(" Historial_y_Seguimiento").Rows(0).Item("RFC")
                'TextBox9.Text = datos.Tables(" Historial_y_Seguimiento").Rows(0).Item("marca_vehiculo")
                'TextBox5.Text = datos.Tables(" Historial_y_Seguimiento").Rows(0).Item("modelo_vehiculo")
                DataGridView1.DataSource = datos
                DataGridView1.DataMember = "historialyseguimiento"
            Else
                MsgBox("datos no encontrados")

            End If
            conexion.Close()

        End If


        If RadioButton4.Checked = True And TextBox10.Text = "" And TextBox5.Text = "" And RadioButton3.Checked = False Then

            consulta = "Select * FROM historialyseguimiento WHERE marca_vehiculo ='" & TextBox9.Text & "'"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            datos = New DataSet
            adaptador.Fill(datos, "historialyseguimiento")
            lista = datos.Tables("historialyseguimiento").Rows.Count

            If lista <> 0 Then
                'TextBox2.Text = datos.Tables(" Historial_y_Seguimiento").Rows(0).Item("RFC")
                'TextBox9.Text = datos.Tables(" Historial_y_Seguimiento").Rows(0).Item("marca_vehiculo")
                'TextBox5.Text = datos.Tables(" Historial_y_Seguimiento").Rows(0).Item("modelo_vehiculo")
                DataGridView1.DataSource = datos
                DataGridView1.DataMember = "historialyseguimiento"
            Else
                MsgBox("datos no encontrados")

            End If
            conexion.Close()



        End If





        If RadioButton4.Checked = True And TextBox10.Text = "" And TextBox9.Text = "" And RadioButton3.Checked = False Then

            consulta = "Select * FROM historialyseguimiento WHERE modelo_vehiculo ='" & TextBox5.Text & "'"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            datos = New DataSet
            adaptador.Fill(datos, "historialyseguimiento")
            lista = datos.Tables("historialyseguimiento").Rows.Count

            If lista <> 0 Then
                'TextBox2.Text = datos.Tables(" Historial_y_Seguimiento").Rows(0).Item("RFC")
                'TextBox9.Text = datos.Tables(" Historial_y_Seguimiento").Rows(0).Item("marca_vehiculo")
                'TextBox5.Text = datos.Tables(" Historial_y_Seguimiento").Rows(0).Item("modelo_vehiculo")
                DataGridView1.DataSource = datos
                DataGridView1.DataMember = "historialyseguimiento"
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
                'ListBox1.Items.Add("Marca del Vehículo:" + " " + Convert.ToString(datos.Tables("clientes").Rows(0).Item("marca_vehiculo")))
                'ListBox1.Items.Add("Modelo del Vehículo:" + " " + Convert.ToString(datos.Tables("clientes").Rows(0).Item("modelo_vehiculo")))
                ListBox1.Items.Add("Placas del Vehiculo:" + " " + Convert.ToString(datos.Tables("clientes").Rows(0).Item("placas")))

                'TextBox2.Text = datos.Tables("clientes").Rows(0).Item("direccion")
                'TextBox2.Text = datos.Tables("clientes").Rows(0).Item("municipio")
                'TextBox2.Text = datos.Tables("clientes").Rows(0).Item("CP")
                'TextBox2.Text = datos.Tables("clientes").Rows(0).Item("estado")
                TextBox3.Text = datos.Tables("clientes").Rows(0).Item("marca_vehiculo")
                TextBox4.Text = datos.Tables("clientes").Rows(0).Item("modelo_vehiculo")
                'TextBox2.Text = datos.Tables("clientes").Rows(0).Item("placas")

            Else

                MsgBox("datos no encontrados")

            End If
            conexion.Close()

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        '  Codigo para candelar un registro y limpiar el formulario 
        If MsgBox("Desea cancelar el registro", vbQuestion + vbYesNo) = vbYes Then

            TextBox1.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox6.Clear()
            TextBox8.Clear()
            ComboBox1.Items.Clear()
            ComboBox1.DataSource = Nothing
            ComboBox1.Refresh()
            ListBox1.Items.Clear()


        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        'codigo para actualizar registros 
        Dim actualizar As String
        Try
            ' conexion.Open()

            actualizar = "UPDATE historialyseguimiento SET nombre='" & ComboBox1.Text & "', marca_vehiculo='" & TextBox3.Text & "' ,modelo_vehiculo='" & TextBox4.Text & "', reparacion='" & TextBox6.Text & "' , pendientes='" & TextBox8.Text & "' WHERE num_historial='" & id.Text & "'"
            comandos = New MySqlCommand(actualizar, conexion)
            conexion.Open()

            comandos.ExecuteNonQuery()
            MsgBox("Los Datos se han actualizado con exito ")
            ComboBox1.Items.Clear()
            ComboBox1.DataSource = Nothing
            ComboBox1.Refresh()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox6.Clear()
            TextBox8.Clear()


        Catch ex As Exception
            MsgBox("Los datos no se actualizaron")
        End Try
        conexion.Close()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        Sololetras(e)
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        Solonumeros(e)
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        Sololetras(e)
    End Sub

    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress
        Sololetras(e)
    End Sub
End Class