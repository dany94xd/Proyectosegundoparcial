Public Class MenuUser
    Private Sub btnvoto_Click(sender As Object, e As RoutedEventArgs) Handles btnvoto.Click
        Dim ventanaVotante As New LoginVotante
        ventanaVotante.Owner = Me
        Me.Hide()
        ventanaVotante.Show()


    End Sub

    Private Sub btncandi_Click(sender As Object, e As RoutedEventArgs) Handles btncandi.Click
        Dim ventanaCandidato As New LoginCandidato
        ventanaCandidato.Owner = Me
        Me.Hide()
        ventanaCandidato.Show()
    End Sub

    Private Sub btnadmin_Click(sender As Object, e As RoutedEventArgs) Handles btnadmin.Click
        Dim ventanaAdmin As New LoginAdmin
        ventanaAdmin.Owner = Me
        Me.Hide()
        ventanaAdmin.Show()
    End Sub

    Private Sub winuser_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles winuser.Closing
        End
    End Sub

    Private Sub btnregresar_Click(sender As Object, e As RoutedEventArgs) Handles btnregresar.Click
        Dim segundaventana As New MainWindow
        segundaventana.Owner = Me
        Me.Hide()
        segundaventana.Show()
    End Sub
End Class
