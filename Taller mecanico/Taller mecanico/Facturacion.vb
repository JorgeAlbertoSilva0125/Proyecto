Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

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
        TextBox1.Text = total
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
        ' Vamos a encontrar la ruta donde se va a guardar el PDF
        ' Muestro el SaveFileDialog y guardo el contenido PDF
        Dim SaveFileDialog As New SaveFileDialog
        Dim ruta As String
        With SaveFileDialog
            .Title = "Guardar"
            ' Selecciono la generacion por defecto 
            ' Entodos los demas casos uso la ruta por defecto 
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            .Filter = "Archivo pdf  (*.pdf)|*.pdf"
            .FileName = "Archivo"
            .OverwritePrompt = True
            .CheckPathExists = True

        End With

        If SaveFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            ruta = SaveFileDialog.FileName
        Else
            ruta = String.Empty
            Exit Sub
        End If

        ' Vamos a generar  el pdf 
        Try
            'Creamos un documento 
            Dim document As New iTextSharp.text.Document(PageSize.A4)

            'Ahora configuramos la hoja 
            document.PageSize.Rotate()
            ' Propiedades de hoja 
            document.AddAuthor("")
            document.AddTitle("")
            Dim writer As PdfWriter = PdfWriter.GetInstance(document, New System.IO.FileStream(ruta, System.IO.FileMode.Create))
            Dim pdfw As iTextSharp.text.pdf.PdfWriter
            ' con  esto conseguiremos que el documento sea presentado como pagina simple 
            writer.ViewerPreferences = PdfWriter.PageLayoutSinglePage

            'Abrimos el documento para empezar a escribir 
            document.Open()

            ' Epezamos definiendo la fuente y el tamaño 
            Dim cb As PdfContentByte = writer.DirectContent
            Dim bf As BaseFont = BaseFont.CreateFont(BaseFont.COURIER_BOLD, BaseFont.CP1250, BaseFont.NOT_EMBEDDED)
            cb.SetFontAndSize(bf, 10)
            '-------------------------------------------------------------------------------------------------------
            'Dim titulo As PdfContentByte = writer.DirectContent
            'Dim fuente As BaseFont = BaseFont.CreateFont(BaseFont.COURIER_BOLD, BaseFont.CP1250, BaseFont.NOT_EMBEDDED)
            'titulo.SetFontAndSize(fuente, 12)
            '----------------------------------------------------------------------------------------------------------
            'Dim oImagen As iTextSharp.text.Image
            'Dim coordenadaX As Single = 10.5
            'Dim coordenadaY As Single = 10.5

            'oImagen = iTextSharp.text.Image.GetInstance(“C:\imenfac.jpg”)
            'oImagen.SetAbsolutePosition(coordenadaX, coordenadaY)
            'document.Add(oImagen)
            '  ----------------------------------------------------------------------------------------------------------


            cb.BeginText()


            '  document.Add(New Paragraph())
            Dim imag As Image = Image.GetInstance("imenfac.jpeg")
            imag.ScalePercent(15.5)
            imag.SetAbsolutePosition(40, 730)
            document.Add(imag)
            'Datos empresa
            '----------------------------------------------------------------------------------------------------
            cb.SetTextMatrix(150, 790)
            cb.ShowText("TALLER MECANICO ÁNGEL ")
            cb.SetTextMatrix(150, 775)
            cb.ShowText("TMA0125465EC2")
            cb.SetTextMatrix(150, 760)
            cb.ShowText("CALLE VICENTE GUERRERO # 123")
            cb.SetTextMatrix(150, 745)
            cb.ShowText("COL. CENTRO     CP:56900")
            cb.SetTextMatrix(150, 730)
            cb.ShowText("AMECAMECA EDO. MEXICO ")
            '-------------------------------------------------------------------------------------------------------

            'Datos fiscales 
            'posicion margen izquierdo
            '-------------------------------------------------------------------------------------------------------
            cb.SetTextMatrix(40, 700)
            cb.ShowText("Regimen fical: 601")
            cb.SetTextMatrix(40, 685)
            cb.ShowText("Folio Fiscal:")
            cb.SetTextMatrix(40, 675)
            cb.ShowText("ASCEC0-3ASDSAF2")
            cb.SetTextMatrix(40, 665)
            cb.ShowText("ASFAS-S21DSAD")
            cb.SetTextMatrix(40, 645)
            cb.ShowText("N° Serie:")
            cb.SetTextMatrix(40, 635)
            cb.ShowText("0213210620001221321")

            '-------------------------------------------------------------------------------------------------------
            'Datos fiscales 
            'posicion margen Derecho
            '-------------------------------------------------------------------------------------------------------
            cb.SetTextMatrix(200, 700)
            cb.ShowText("Fecha y hora de emisión:")
            cb.SetTextMatrix(200, 685)
            cb.ShowText(Me.DateTimePicker1.Value)
            cb.SetTextMatrix(200, 670)
            cb.ShowText("Fecha y hora de certificación")
            cb.SetTextMatrix(200, 655)
            cb.ShowText(Me.DateTimePicker1.Value)
            cb.SetTextMatrix(200, 640)
            cb.ShowText("Uso de CFDI:")
            cb.SetTextMatrix(200, 625)
            cb.ShowText("G03 Gastos en general")

            '-------------------------------------------------------------------------------------------------------
            'Datos de factura 
            '------------------------------------------------------------------------------------------------------
            cb.SetTextMatrix(120, 600)
            cb.ShowText("Tipo de comprobante: Ingreso")
            cb.SetTextMatrix(120, 585)
            cb.ShowText("Verion: 1")
            cb.SetTextMatrix(120, 570)
            cb.ShowText("Moneda: MXN")
            cb.SetTextMatrix(120, 555)
            cb.ShowText("Serie: TAL")
            cb.SetTextMatrix(120, 540)
            cb.ShowText("Folio: 10264")

            '-------------------------------------------------------------------------------------------------------
            'Datos de cliente
            '------------------------------------------------------------------------------------------------------

            cb.SetTextMatrix(40, 510)
            cb.ShowText("Nombre Cliente: " & Me.ComboBox1.Text)
            cb.SetTextMatrix(40, 495)
            cb.ShowText(Me.ListBox1.Items(0))
            cb.SetTextMatrix(40, 485)
            cb.ShowText(Me.ListBox1.Items(1))
            cb.SetTextMatrix(40, 475)
            cb.ShowText(Me.ListBox1.Items(2))
            cb.SetTextMatrix(40, 465)
            cb.ShowText(Me.ListBox1.Items(3))
            cb.SetTextMatrix(40, 455)
            cb.ShowText(Me.ListBox1.Items(4))
            cb.SetTextMatrix(40, 445)
            cb.ShowText(Me.ListBox1.Items(5))
            cb.SetTextMatrix(40, 435)
            cb.ShowText(Me.ListBox1.Items(6))
            cb.SetTextMatrix(40, 425)
            cb.ShowText(Me.ListBox1.Items(7))
            'cb.SetTextMatrix(40, 445)
            'cb.ShowText(Me.ListBox1.Items(8))


            '-------------------------------------------------------------------------------------------------------

            'Datos de concepto y pago por concepto 
            '------------------------------------------------------------------------------------------------------
            cb.SetTextMatrix(40, 400)
            cb.ShowText("Reparaciones: " & Me.Txt2.Text)
            cb.SetTextMatrix(20, 385)
            cb.ShowText("Costo por trab")
            cb.SetTextMatrix(20, 375)
            cb.ShowText("realizado")
            cb.SetTextMatrix(20, 365)
            cb.ShowText(Me.Txt3.Text)

            cb.SetTextMatrix(120, 385)
            cb.ShowText("Costo por")
            cb.SetTextMatrix(120, 375)
            cb.ShowText("Refacción")
            cb.SetTextMatrix(120, 365)
            cb.ShowText(Me.Txt4.Text)

            cb.SetTextMatrix(180, 375)
            cb.ShowText("IVA")
            cb.SetTextMatrix(180, 365)
            cb.ShowText(Me.Txt5.Text)

            cb.SetTextMatrix(220, 375)
            cb.ShowText("Subtotal")
            cb.SetTextMatrix(220, 365)
            cb.ShowText(Me.TextBox1.Text)

            cb.SetTextMatrix(270, 375)
            cb.ShowText("Total a pagar")
            cb.SetTextMatrix(270, 365)
            cb.ShowText(Me.Txt6.Text)

            cb.SetTextMatrix(40, 345)
            cb.ShowText("Modo de pago: " & Me.Cbx2.Text)
            cb.SetTextMatrix(40, 330)
            cb.ShowText("Condiciones de pago: Contado")

            cb.SetTextMatrix(40, 315)
            cb.ShowText("Cantidad con letra: ")
            cb.SetTextMatrix(40, 300)
            cb.ShowText(Letras(Txt6.Text) & "Pesos 00/100 MXN")

            '-------------------------------------------------------------------------------------------------------

            'Sello de CFDI      
            '------------------------------------------------------------------------------------------------------

            cb.SetTextMatrix(40, 285)
            cb.ShowText("Sello digital del CFDI: ")
            cb.SetTextMatrix(40, 270)
            cb.ShowText("f0Tb/489LdeGja/SeZWWe/FnFcH6fo08Vj5MeO67pEPg81bWvSR")
            cb.SetTextMatrix(40, 260)
            cb.ShowText("Yaaf2OSD9TV10aoKFh+VpIrOBgj6bsx6sg+")
            cb.SetTextMatrix(40, 250)
            cb.ShowText(" UBByzb5iE6HxsSTSLT9GanGDi4Gw27t1KnGkeV915YsU58SBg4")
            cb.SetTextMatrix(40, 240)
            cb.ShowText("Er7H0vIw0XOBD5+d6YvNiwMZ2UBBy5MXrfcPa+PUg ")
            cb.SetTextMatrix(40, 230)
            cb.ShowText("p12zw3X31knyzFavOHyuqVLD9BnmrbY4Hj7jyzniFOj77tJ5Htt")
            cb.SetTextMatrix(40, 220)
            cb.ShowText("hiGYro2AE08aBEJzmog == ")

            'Dim table As New PdfPTable(2)
            'Dim sellosat As New PdfPCell("f0Tb/489LdeGja/SeZWWe/FnFcH6fo08Vj5MeO67pEPg81bWvSRYaaf2OSD9TV10aoKFh" +
            '                                        "+VpIrOBgj6bsx6sg+" +
            '                                        "UBByzb5iE6HxsSTSLT9GanGDi4Gw27t1KnGkeV915YsU58SBg4Er7H0vIw0XOBD5+d6YvNiwMZ2UBB" +
            '                                        "5u20U75ekJKDQ9N" +
            '                                        "oEY87DwumJTjtPtEYblyCs9aolVgPXHvr7SfZJZa1Rq0XUEVvsjfrSXrgP6FXWdpSDlUQRhTogamgrGH" +
            '                                        "y5MXrfcPa+PUg" +
            '                                        "p12zw3X31knyzFavOHyuqVLD9BnmrbY4Hj7jyzniFOj77tJ5HtthiGYro2AE08aBEJzmog==", New Font(bf, 10))

            'table.AddCell(sellosat)

            '-------------------------------------------------------------------------------------------------------

            'Sello sat          
            '------------------------------------------------------------------------------------------------------
            cb.SetTextMatrix(40, 205)
            cb.ShowText("Sello SAT: ")
            cb.SetTextMatrix(40, 190)
            cb.ShowText("GqDiRrea6 E2wQhqOCVzwME4866yVEME/8PD1S1g6AV48D8VrL")
            cb.SetTextMatrix(40, 180)
            cb.ShowText("hKUDq0Sjqnp9IwfMAbX0ggwUCLRKaHg5q8aYhya63If2HVqH1s")
            cb.SetTextMatrix(40, 170)
            cb.ShowText("A08poer080P1J6Z BwTrQkhcb5Jw8jENXoErkFE8qdOcIdFFAu")
            cb.SetTextMatrix(40, 160)
            cb.ShowText("ZPVT9mkTb0Xn5Emu5U8=")


            '-------------------------------------------------------------------------------------------------------

            'imagen de Codigo QR         
            '------------------------------------------------------------------------------------------------------


            Dim ima As Image = Image.GetInstance("CQR.png")
            ima.ScalePercent(25.5)
            ima.SetAbsolutePosition(150, 40)
            document.Add(ima)

            cb.SetTextMatrix(40, 20)
            cb.ShowText("Este documento es la representación impresa de un CFDI")


            cb.EndText()

            'cerramos documento 
            document.Close()

        Catch ex As Exception
            MessageBox.Show("Error en la generacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'codigo para agregar el contenido de una datagrid
        'cb.SetTextMatrix(50, 670)
        'cb.ShowText(Me.DataGridView1.Text)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        VisualizarPdf.Show()

    End Sub
End Class