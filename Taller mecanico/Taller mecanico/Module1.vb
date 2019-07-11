Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports System.Collections.Generic
Imports System.Net
Imports System.Web
Module modulo

    Dim adaptador As New MySqlDataAdapter
    Public MysqlCommand As New MySqlCommand
    Public rdr As MySqlDataReader
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


    Sub consultaclientes(ByVal tabla As DataGridView)
        adaptador = New MySqlDataAdapter("SELECT * FROM clientes", conexion)
        Dim data As New DataSet
        adaptador.Fill(data, "clientes")
        tabla.DataSource = data.Tables("clientes")

    End Sub


    Sub consultagenda(ByVal tabla As DataGridView)
        adaptador = New MySqlDataAdapter("SELECT * FROM agenda", conexion)
        Dim data As New DataSet
        adaptador.Fill(data, "agenda")
        tabla.DataSource = data.Tables("agenda")

    End Sub

    Sub consultainventario(ByVal tabla As DataGridView)
        adaptador = New MySqlDataAdapter("SELECT * FROM inventario", conexion)
        Dim data As New DataSet
        adaptador.Fill(data, "inventario")
        tabla.DataSource = data.Tables("inventario")
    End Sub

    Public Function Encrypt(password As String) As String
        Dim strmsg As String = String.Empty
        Dim encode As Byte() = New Byte(password.Length - 1) {}
        encode = Encoding.UTF8.GetBytes(password)
        strmsg = Convert.ToBase64String(encode)
        Return strmsg
    End Function

    Public Function Decrypt(encryptpwd As String) As String
        Dim decryptpwd As String = String.Empty
        Dim encodepwd As New UTF8Encoding()
        Dim Decode As Decoder = encodepwd.GetDecoder()
        Dim todecode_byte As Byte() = Convert.FromBase64String(encryptpwd)
        Dim charCount As Integer = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length)
        Dim decoded_char As Char() = New Char(charCount - 1) {}
        Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0)
        decryptpwd = New [String](decoded_char)
        Return decryptpwd
    End Function

End Module

