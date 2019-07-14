Public Class VisualizarPdf
    Private Sub VisualizarPdf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OpenFileDialog1.Filter = "PDF Files (*.pdf)|*.pdf"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then

            AxAcroPDF1.src = OpenFileDialog1.FileName

        End If
    End Sub
End Class