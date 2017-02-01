Public Class MenuCandidato
    Private Sub btnresultados_Click(sender As Object, e As RoutedEventArgs) Handles btnresultados.Click
        Dim anterior As New ReporteCandidato
        anterior.Owner = Me
        Me.Hide()
        anterior.Show()
    End Sub
End Class
