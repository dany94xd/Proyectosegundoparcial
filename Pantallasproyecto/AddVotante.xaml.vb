﻿Public Class AddVotante

    Private Sub winagregarvotante_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles winagregarvotante.Closing
        End
    End Sub

    Private Sub btnatras_Click(sender As Object, e As RoutedEventArgs) Handles btnatras.Click
        Dim anterior As New MenuAdmin
        anterior.Owner = Me
        Me.Hide()
        anterior.Show()
    End Sub

    Private Sub btningresar_Click(sender As Object, e As RoutedEventArgs) Handles btningresar.Click


    End Sub
End Class
