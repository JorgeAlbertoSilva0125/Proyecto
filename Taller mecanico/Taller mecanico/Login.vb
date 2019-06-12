Imports MySql.Data.MySqlClient
Public Class Login
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim conexion As New MySqlConnectionStringBuilder()
            conexion.Server = "localhost"
            conexion.UserID = "root"
            conexion.Password = "1234"
            conexion.Database = ""
            Dim con As New MySqlConnection(conexion.ToString())
            con.Open()
        Catch ex As Exception
            MsgBox("No se pudo conectar" & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub
End Class
