Public Class ReporteCandidato

    Private Sub btnregresar_Click(sender As Object, e As RoutedEventArgs) Handles btnregresar.Click
        Dim anterior As New MenuCandidato
        anterior.Owner = Me
        Me.Hide()
        anterior.Show()
    End Sub

    Private Sub btnsalir_Click(sender As Object, e As RoutedEventArgs) Handles btnsalir.Click
        End
    End Sub

    Private Sub winreportecand_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles winreportecand.Closing
        End
    End Sub
End Class
