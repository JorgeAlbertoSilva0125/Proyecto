Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Public Class Facturacion
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

    Private Sub HistorialYSeguimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistorialYSeguimientoToolStripMenuItem.Click
        Historial_y_Seguimiento.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Facturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'Consulta tabla clientes para mostrar los clientes en el formulario de agenda 
        Dim consulta As String
        Dim lista As Byte

        If Txt1.Text <> "" Then

            consulta = "Select * FROM clientes WHERE nombre ='" & Txt1.Text & "'"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            datos = New DataSet
            adaptador.Fill(datos, "clientes")
            lista = datos.Tables("clientes").Rows.Count

            If lista <> 0 Then
                ComboBox1.Text = datos.Tables("clientes").Rows(0).Item("nombre")

            Else
                MsgBox("datos no encontrados")

            End If

        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Codigo para insertar 


        comandos = New MySqlCommand("INSERT INTO facturacion(id_fac,nombre,reparacion,costo_trabrealizado,costo_refaccion,IVA,total_pagar,fecha,modo_pago)" & Chr(13) &
                                      "VALUES('',@nombre,@reparacion,@costo_trabrealizado,@costo_refaccion,@IVA,@total_pagar,@fecha,@modo_pago)", conexion)
        conexion.Open()
        If ComboBox1.Text <> "" Then
            comandos.Parameters.AddWithValue("@nombre", ComboBox1.Text)
            comandos.Parameters.AddWithValue("@reparacion", Txt2.Text)
            comandos.Parameters.AddWithValue("@costo_trabrealizado", Txt3.Text)
            comandos.Parameters.AddWithValue("@costo_refaccion", Txt4.Text)
            comandos.Parameters.AddWithValue("@IVA", Txt5.Text)
            comandos.Parameters.AddWithValue("@total_pagar", Txt6.Text)
            comandos.Parameters.AddWithValue("@fecha", fecha.Text)
            comandos.Parameters.AddWithValue("@modo_pago", Cbx2.Text)

            comandos.ExecuteNonQuery()
            MsgBox("Datos guardados")
            Txt1.Clear()
            Txt2.Clear()
            Txt3.Clear()
            Txt4.Clear()
            Txt5.Clear()
            Txt6.Clear()
            ComboBox1.Items.Clear()
            Cbx2.Items.Clear()


        Else

            Txt1.Text = ""
            Txt2.Text = ""
            Txt3.Text = ""
            Txt4.Text = ""
            Txt5.Text = ""
            Txt6.Text = ""
            ComboBox1.Text = ""
            Cbx2.Text = ""
            MsgBox("Error al registar cliente")
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Codigo para eliminar 
        Dim eliminar As String
        Dim si As Byte
        si = MsgBox("¿Desea eliminar?", vbYesNo, "Eliminar")
        If si = 6 Then
            eliminar = "DELETE FROM facturacion WHERE nombre='" & TextBox14.Text & "'"
            comandos = New MySqlCommand(eliminar, conexion)
            comandos.ExecuteNonQuery()
            MsgBox("Eliminado")
            Txt1.Clear()
            Txt2.Clear()
            Txt3.Clear()
            Txt4.Clear()
            Txt5.Clear()
            Txt6.Clear()
            ComboBox1.Items.Clear()
            Cbx2.Items.Clear()
            ListBox1.Items.Clear()


        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        '  Codigo para candelar un registro y limpiar el formulario 
        If MsgBox("Desea cancelar el registro", vbQuestion + vbYesNo) = vbYes Then

            Txt1.Clear()
            Txt2.Clear()
            Txt3.Clear()
            Txt4.Clear()
            Txt5.Clear()
            Txt6.Clear()
            ComboBox1.Items.Clear()
            Cbx2.Items.Clear()
            ListBox1.Items.Clear()

        End If


    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim cto_trab As Double
        Dim cto_ref As Double
        Dim total As Double
        Dim IVA As Double

        cto_trab = Txt3.Text
        cto_ref = Txt4.Text
        IVA = (cto_trab + cto_ref) * 0.16
        total = cto_trab + cto_ref
        Txt5.Text = IVA
        Txt6.Text = total + IVA

    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Consulta tabla clientes para mostrar los clientes en el formulario de agenda 
        Dim consulta As String
        Dim lista As Byte



        If TextBox14.Text <> "" Then

            consulta = "Select * FROM clientes WHERE nombre ='" & TextBox14.Text & "'"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            datos = New DataSet
            adaptador.Fill(datos, "clientes")
            lista = datos.Tables("clientes").Rows.Count

            If lista <> 0 Then
                ComboBox3.Text = datos.Tables("clientes").Rows(0).Item("nombre")

            Else
                MsgBox("datos no encontrados")

            End If

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


            Else

                MsgBox("datos no encontrados")

            End If

        End If
    End Sub

    Private Sub Consultar_Click(sender As Object, e As EventArgs) Handles Consultar.Click
        'Consulta tabla agenda
        Dim dtgd As String
        Dim lis As Byte
        ' codigo que llama a la datagrid los datos que contiene la tabla agenda 
        consultafac(DataGridView1)

        If ComboBox3.Text <> "" And fecha2.Text <> "" Then

            dtgd = "Select * FROM facturacion WHERE nombre ='" & ComboBox3.Text & "' and fecha='" & fecha2.Text & "'"
            adaptador = New MySqlDataAdapter(dtgd, conexion)
            datos = New DataSet
            adaptador.Fill(datos, "facturacion")
            lis = datos.Tables("facturacion").Rows.Count

            If lis <> 0 Then
                'TextBox13.Text = datos.Tables("clientes").Rows(0).Item("RFC")
                'TextBox12.Text = datos.Tables("clientes").Rows(0).Item("placas")
                DataGridView1.DataSource = datos
                DataGridView1.DataMember = "facturacion"
            Else
                MsgBox("datos no encontrados")

            End If

        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

    End Sub
End Class