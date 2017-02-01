Public Class Candidato
    Private Sub btnreturn_Click(sender As Object, e As RoutedEventArgs) Handles btnreturn.Click
        Dim anterior As New LoginCandidato
        anterior.Owner = Me
        Me.Hide()
        anterior.Show()
    End Sub
End Class
