Public Class MenuAdmin
    Private Sub btnAgregarpersona_Click(sender As Object, e As RoutedEventArgs) Handles btnAgregarpersona.Click
        Dim anterior As New AddVotante
        anterior.Owner = Me
        Me.Hide()
        anterior.Show()
    End Sub

    Private Sub btncandidato_Click(sender As Object, e As RoutedEventArgs) Handles btncandidato.Click
        Dim anterior As New AgregarCandidato
        anterior.Owner = Me
        Me.Hide()
        anterior.Show()
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        End
    End Sub
End Class
