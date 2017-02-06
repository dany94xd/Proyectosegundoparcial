Imports System.Data.OleDb
Imports System.Data

Public Class ReporteCandidato
    Private dsCandidatos As DataSet


    Private Sub winreportecand_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles winreportecand.Closing
        End
    End Sub



    Private Sub datagribconsulta_Loaded(sender As Object, e As RoutedEventArgs) Handles datagribconsulta.Loaded
        Using conexion As New OleDbConnection(ConnectionString)





            Dim consulta As String = "SELECT Cargo.Descripción, PartidoPolitico.Nombre, Persona.Nombres, Persona.Apellidos, Count(1) AS Conteo FROM Persona INNER JOIN ((PartidoPolitico INNER JOIN (Cargo INNER JOIN Candidato ON Cargo.CargoId = Candidato.CargoId) ON PartidoPolitico.PartidoId = Candidato.PartidoPoliticoId) INNER JOIN Voto ON (Candidato.CandidatoId = Voto.CandidatoId) AND (Cargo.CargoId = Voto.CargoId)) ON Persona.PersonaId = Candidato.PersonaId WHERE(((Voto.CargoId) = " + Cargo.ToString + ")) GROUP BY Cargo.Descripción, PartidoPolitico.Nombre, Persona.Nombres, Persona.Apellidos ORDER BY Count(1) DESC;"
            'Dim adapter As New OleDbDataAdapter(consulta, conexion)
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            dsCandidatos = New DataSet("Candidato")
            'adapter.FillSchema(dsPersonas, SchemaType.Source)

            adapter.Fill(dsCandidatos, "Candidato")


            datagribconsulta.DataContext = dsCandidatos
        End Using

    End Sub

    Private Sub btnmenuprincipal_Click(sender As Object, e As RoutedEventArgs) Handles btnmenuprincipal.Click
        Dim anterior As New MenuUser
        anterior.Owner = Me
        Me.Hide()
        anterior.Show()
    End Sub
End Class

