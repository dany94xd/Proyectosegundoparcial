Public Class Menuvotante


    Private Sub btnelegir_Click(sender As Object, e As RoutedEventArgs) Handles btnelegir.Click
        Dim anterior As New gribpresidentes
        anterior.Owner = Me
        Me.Hide()
        anterior.Show()
    End Sub
End Class
