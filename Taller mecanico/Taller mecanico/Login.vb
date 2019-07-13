Imports MySql.Data.MySqlClient

Public Class Login
    Dim cmd As New MySqlCommand
    Dim adaptador As New MySqlDataAdapter
    Dim datos As New DataSet
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'conectamos la base de datos de contraseña y usuarios
        'conexion.ConnectionString = "server='localhost'; user='root'; password=''; Database='taller_mecanico'"
        Conectarse()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Cerrar la ventana de logeo 
        Me.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'el siguiente codigo nos sirve para iniciar una sesion en el programa 
        'permite dar el acceso a la base de datos, si esta registrado

        If Len(Trim(TextBox1.Text)) = 0 Then
            MessageBox.Show("Por favor ingrese usuario", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBox1.Focus()
            Exit Sub
        End If
        If Len(Trim(TextBox2.Text)) = 0 Then
            MessageBox.Show("Por favor ingrese contraseña", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBox2.Focus()
            Exit Sub
        End If
        If Len(Trim(ComboBox1.SelectedItem)) = 0 Then
            MessageBox.Show("Por favor ingrese puesto", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ComboBox1.Focus()
            Exit Sub
        End If
        Try

            Dim consulta As String
            Dim lista As Byte
            If TextBox1.Text <> "" And TextBox2.Text <> "" And ComboBox1.SelectedItem <> "" Then
                consulta = "SELECT * FROM usuarios WHERE nombre='" & TextBox1.Text & "' and contraseña='" & TextBox2.Text & "'and puesto='" & ComboBox1.SelectedItem & "'"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                datos = New DataSet
                adaptador.Fill(datos, "usuarios")
                lista = datos.Tables("usuarios").Rows.Count

                If lista <> 0 Then
                    MsgBox("Bienvenido" + " " + TextBox1.Text)
                    Home.Show()

                Else
                    MsgBox("Intentelo de nuevo")

                End If



                If ComboBox1.SelectedItem = "Admistrador" Then

                    Clientes.TabPage1.Enabled = True
                    Clientes.TabPage2.Enabled = True
                    Agenda.TabPage1.Enabled = True
                    Agenda.TabPage2.Enabled = True
                    Inventario.TabPage1.Enabled = True
                    Inventario.TabPage2.Enabled = True
                    Historial_y_Seguimiento.TabPage1.Enabled = True
                    Historial_y_Seguimiento.TabPage2.Enabled = True
                    Facturacion.TabPage1.Enabled = True
                    Facturacion.TabPage2.Enabled = True

                End If
                If ComboBox1.SelectedItem = "Mecánico" Then

                    Clientes.TabPage1.Enabled = True
                    Clientes.TabPage2.Enabled = True
                    Agenda.TabPage1.Enabled = True
                    Agenda.TabPage2.Enabled = True
                    Inventario.TabPage1.Enabled = True
                    Inventario.TabPage2.Enabled = True
                    Historial_y_Seguimiento.TabPage1.Enabled = True
                    Historial_y_Seguimiento.TabPage2.Enabled = True
                    Facturacion.TabPage1.Enabled = True
                    Facturacion.TabPage2.Enabled = True
                End If
                If ComboBox1.SelectedItem = "Ayudante" Then

                    Clientes.TabPage2.Enabled = True
                    Agenda.TabPage2.Enabled = True
                    Inventario.TabPage2.Enabled = True
                    Historial_y_Seguimiento.TabPage2.Enabled = True
                    Facturacion.TabPage2.Enabled = True

                    Clientes.TabPage1.Enabled = False
                    Agenda.TabPage1.Enabled = False
                    Inventario.TabPage1.Enabled = False
                    Historial_y_Seguimiento.TabPage1.Enabled = False
                    Facturacion.TabPage1.Enabled = False

                    '    MsgBox("No tiene permiso para acceder")
                End If
                'Else

                '    MessageBox.Show("El nombre de usuario o contraseña no son validos")
                '    TextBox1.Text = ""
                '    TextBox2.Text = ""
                '    ComboBox1.Focus()
                'End If

            Else
                MsgBox("Login is Failed...Try again !", MsgBoxStyle.Critical, "Login Denied")
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox1.Focus()
            End If
            cmd.Dispose()
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try




    End Sub
End Class

