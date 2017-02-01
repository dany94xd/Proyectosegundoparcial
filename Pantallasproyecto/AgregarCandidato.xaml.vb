Public Class AgregarCandidato
    Private Sub Btnregresar_Click(sender As Object, e As RoutedEventArgs) Handles Btnregresar.Click
        Dim anterior As New MenuAdmin
        anterior.Owner = Me
        Me.Hide()
        anterior.Show()
    End Sub
End Class
