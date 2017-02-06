Imports System.Data
Imports System.Data.OleDb

Public Class AddVotante

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

    Private Sub Grid_Initialized(sender As Object, e As EventArgs)
        Dim consulta As String = "SELECT Persona.[PersonaId], Persona.[Cedula], Persona.[Apellidos], Persona.[Nombres] FROM Persona;"

        Using conexion As New OleDbConnection(ConnectionString)

            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            Dim dsCandidatos = New DataSet("Candidato")
            'adapter.FillSchema(dsPersonas, SchemaType.Source)

            adapter.Fill(dsCandidatos, "Candidato")


            gridPersona.DataContext = dsCandidatos
        End Using

    End Sub
End Class
