Class MainWindow
    Private Sub btinciar_Click(sender As Object, e As RoutedEventArgs) Handles btinciar.Click
        Dim segundaventana As New MenuUser
        segundaventana.Owner = Me
        Me.Hide()
        segundaventana.Show()



    End Sub

    Private Sub btsalir_Click(sender As Object, e As RoutedEventArgs) Handles btsalir.Click
        End
    End Sub

Private Sub WinVotaciones_Loaded(sender As Object , e As RoutedEventArgs) Handles WinVotaciones.Loaded
        Connect()

    End Sub

    
    Private Sub publicidad1_Loaded(sender As Object, e As RoutedEventArgs) Handles publicidad1.Loaded
        publicidad1.Play()
    End Sub
End Class
