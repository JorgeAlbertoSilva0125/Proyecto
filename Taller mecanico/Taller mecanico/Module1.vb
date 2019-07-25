Imports MySql.Data.MySqlClient

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


    Sub Consultaclientes(ByVal tabla As DataGridView)
        adaptador = New MySqlDataAdapter("SELECT * FROM clientes", conexion)
        Dim data As New DataSet
        adaptador.Fill(data, "clientes")
        tabla.DataSource = data.Tables("clientes")

    End Sub


    Sub Consultagenda(ByVal tabla As DataGridView)
        adaptador = New MySqlDataAdapter("SELECT * FROM agenda", conexion)
        Dim data As New DataSet
        adaptador.Fill(data, "agenda")
        tabla.DataSource = data.Tables("agenda")

    End Sub

    Sub Consultahistorialyseguimiento(ByVal tabla As DataGridView)
        adaptador = New MySqlDataAdapter("SELECT * FROM historialyseguimiento", conexion)
        Dim data As New DataSet
        adaptador.Fill(data, "historialyseguimiento")
        tabla.DataSource = data.Tables("historialyseguimiento")
    End Sub

    Sub Consultainventario(ByVal tabla As DataGridView)
        adaptador = New MySqlDataAdapter("SELECT * FROM inventario", conexion)
        Dim data As New DataSet
        adaptador.Fill(data, "inventario")
        tabla.DataSource = data.Tables("inventario")
    End Sub

    Sub Consultafac(ByVal tabla As DataGridView)
        adaptador = New MySqlDataAdapter("SELECT * FROM facturacion", conexion)
        Dim data As New DataSet
        adaptador.Fill(data, "facturacion")
        tabla.DataSource = data.Tables("facturacion")
    End Sub

    'restrinccion a solo numeros
    Public Sub Solonumeros(ByRef e As System.Windows.Forms.KeyPressEventArgs)

        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True

        End If
    End Sub

    Public Sub Sololetras(ByRef e As System.Windows.Forms.KeyPressEventArgs)

        'SOLO LETRAS'
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

End Module

