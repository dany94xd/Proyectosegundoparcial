Public Class MenuAdmin
    Private Sub btnAgregarpersona_Click(sender As Object, e As RoutedEventArgs) Handles btnAgregarpersona.Click
        Dim anterior As New AddVotante
        anterior.Owner = Me
        Me.Hide()
        anterior.Show()
    End Sub



    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        End
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As RoutedEventArgs) Handles btnConsultar.Click
        Dim anterior As New ReporteAdmin
        anterior.Owner = Me
        Me.Hide()
        anterior.Show()
    End Sub

    Private Sub btnregre_Click(sender As Object, e As RoutedEventArgs) Handles btnregre.Click
        Dim anterior As New MenuAdmin
        anterior.Owner = Me
        Me.Hide()
        anterior.Show()
    End Sub
End Class
