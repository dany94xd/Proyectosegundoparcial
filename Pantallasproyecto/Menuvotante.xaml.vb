Public Class Menuvotante


    Private Sub btnpresident_Click(sender As Object, e As RoutedEventArgs) Handles btnpresident.Click
        Dim anterior As New gribpresidentes
        anterior.Owner = Me
        Me.Hide()
        anterior.Show()
    End Sub
End Class
