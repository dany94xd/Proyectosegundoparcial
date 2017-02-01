Public Class AgregarCandidato
    Private Sub Btnregresar_Click(sender As Object, e As RoutedEventArgs) Handles Btnregresar.Click
        Dim anterior As New MenuAdmin
        anterior.Owner = Me
        Me.Hide()
        anterior.Show()
    End Sub

    Private Sub winagregarcandidato_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles winagregarcandidato.Closing
        End
    End Sub
End Class
