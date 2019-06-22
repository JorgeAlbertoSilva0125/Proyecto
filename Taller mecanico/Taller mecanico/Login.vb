
Public Class Login
    Dim adaptador As New MySqlDataAdapter
    Dim datos As New DataSet
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'conectamos la base de datos de contraseña y usuarios
        'conexion.ConnectionString = "server='localhost'; user='root'; password=''; Database='taller_mecanico'"
        ' Conectarse()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Cerrar la ventana de logeo 
        Me.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'el siguiente codigo nos sirve para iniciar una sesion en el programa 
        'permite dar el acceso a la base de datos, si esta registrado
        Dim consulta As String
        Dim lista As Byte
        If TextBox1.Text <> "" And TextBox2.Text <> "" And ComboBox1.SelectedItem <> "" Then
            consulta = "SELECT * FROM usuarios WHERE nombre='" & TextBox1.Text & "' and contraseña='" & TextBox2.Text & "'and puesto='" & ComboBox1.SelectedItem & "'"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            datos = New DataSet
            adaptador.Fill(datos, "usuarios")
            lista = datos.Tables("usuarios").Rows.Count
            If lista <> 0 Then
                MsgBox("Bienvenido")
                Home.Show()
                ' Me.Hide()
            Else
                MsgBox("Intentelo de nuevo")

            End If
        Else
            MessageBox.Show("El nombre de usuario o contraseña no son validos")
            TextBox1.Text = ""
            TextBox2.Text = ""
            ComboBox1.Focus()

        End If

    End Sub
End Class

