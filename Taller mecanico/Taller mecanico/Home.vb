Public Class Home
    Private Sub TabPage2_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        Clientes.Show()
    End Sub

    Private Sub AgendaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgendaToolStripMenuItem.Click
        Agenda.Show()
    End Sub

    Private Sub InventarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventarioToolStripMenuItem.Click
        Inventario.Show()
    End Sub

    Private Sub HistorialYSeguimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistorialYSeguimientoToolStripMenuItem.Click
        Historial_y_Seguimiento.Show()
    End Sub

    Private Sub FacturacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturacionToolStripMenuItem.Click
        Facturacion.Show()
    End Sub
End Class