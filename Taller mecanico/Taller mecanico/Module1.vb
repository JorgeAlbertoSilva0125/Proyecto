Imports MySql.Data.MySqlClient
Module modulo

    Public MysqlCommand As New MySqlCommand
    Public dread As MySqlDataReader
    Dim MysqlConnString As String = "server='localhost'; user='root'; password=''; Database='taller_mecanico1'"

    Public conexion As MySqlConnection = New MySqlConnection(MysqlConnString)

    Public Sub Conectarse()
        Try
            conexion.Open()
            MsgBox("la conexion fue exitosa")

        Catch ex As Exception
            MsgBox("no se conecto")
        End Try
    End Sub
    'Otra opcion de conectar un formulario con la BD
    ' Try
    'Dim conexion As New MySqlConnectionStringBuilder()
    'conexion.Server = "localhost"
    'conexion.UserID = "root"
    'conexion.Password = ""
    'conexion.Database = "taller_mecanico"
    'Dim con As New MySqlConnection(conexion.ToString())
    'con.Open()
    'Catch ex As Exception
    'MsgBox("No se pudo conectar" & ex.Message)
    'End Try




End Module

