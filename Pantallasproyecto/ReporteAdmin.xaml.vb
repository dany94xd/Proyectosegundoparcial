Public Class ReporteAdmin

    Private Sub btnregresar_Click(sender As Object, e As RoutedEventArgs) Handles btnregresar.Click
        Dim anterior As New MenuAdmin
        anterior.Owner = Me
        Me.Hide()
        anterior.Show()
    End Sub

    Private Sub btnsalir_Click(sender As Object, e As RoutedEventArgs) Handles btnsalir.Click

        MsgBox("consulta finalizada")
        End
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        End
    End Sub
End Class
