Public Class MenuAdmin
    Private Sub btnAgregarpersona_Click(sender As Object, e As RoutedEventArgs) Handles btnAgregarpersona.Click
        Dim anterior As New AddVotante
        anterior.Owner = Me
        Me.Hide()
        anterior.Show()
    End Sub
End Class
