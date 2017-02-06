Imports System.Data
Imports System.Data.OleDb

Public Class ReporteAdmin
    Private dsCandidatos As DataSet
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


    Private Sub Gridpresi_Loaded(sender As Object, e As RoutedEventArgs) Handles Gridpresi.Loaded
        Using conexion As New OleDbConnection(ConnectionString)

            Dim consulta As String = "SELECT Cargo.Descripción, PartidoPolitico.Nombre, Persona.Nombres, Persona.Apellidos, Count(1) AS Conteo FROM Persona INNER JOIN ((PartidoPolitico INNER JOIN (Cargo INNER JOIN Candidato ON Cargo.CargoId = Candidato.CargoId) ON PartidoPolitico.PartidoId = Candidato.PartidoPoliticoId) INNER JOIN Voto ON (Cargo.CargoId = Voto.CargoId) AND (Candidato.CandidatoId = Voto.CandidatoId)) ON Persona.PersonaId = Candidato.PersonaId WHERE(((Voto.CargoId) = 2)) GROUP BY Cargo.Descripción, PartidoPolitico.Nombre, Persona.Nombres, Persona.Apellidos ORDER BY Count(1) DESC;"
            'Dim adapter As New OleDbDataAdapter(consulta, conexion)
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            dsCandidatos = New DataSet("Candidato")
            'adapter.FillSchema(dsPersonas, SchemaType.Source)

            adapter.Fill(dsCandidatos, "Candidato")


            Gridpresi.DataContext = dsCandidatos
        End Using

    End Sub

    Private Sub gribasam_Loaded(sender As Object, e As RoutedEventArgs) Handles gribasam.Loaded
        Using conexion As New OleDbConnection(ConnectionString)

            Dim consulta As String = "SELECT Cargo.Descripción, PartidoPolitico.Nombre, Persona.Nombres, Persona.Apellidos, Count(1) AS Conteo FROM Persona INNER JOIN ((PartidoPolitico INNER JOIN (Cargo INNER JOIN Candidato ON Cargo.CargoId = Candidato.CargoId) ON PartidoPolitico.PartidoId = Candidato.PartidoPoliticoId) INNER JOIN Voto ON (Cargo.CargoId = Voto.CargoId) AND (Candidato.CandidatoId = Voto.CandidatoId)) ON Persona.PersonaId = Candidato.PersonaId WHERE(((Voto.CargoId) = 4)) GROUP BY Cargo.Descripción, PartidoPolitico.Nombre, Persona.Nombres, Persona.Apellidos ORDER BY Count(1) DESC;"

            'Dim adapter As New OleDbDataAdapter(consulta, conexion)
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            dsCandidatos = New DataSet("Candidato")
            'adapter.FillSchema(dsPersonas, SchemaType.Source)

            adapter.Fill(dsCandidatos, "Candidato")


            gribasam.DataContext = dsCandidatos
        End Using
    End Sub


    Private Sub gridProvin_Loaded(sender As Object, e As RoutedEventArgs) Handles gridProvin.Loaded
        Using conexion As New OleDbConnection(ConnectionString)

            Dim consulta As String = "SELECT Cargo.Descripción, PartidoPolitico.Nombre, Persona.Nombres, Persona.Apellidos, Count(1) AS Conteo FROM Persona INNER JOIN ((PartidoPolitico INNER JOIN (Cargo INNER JOIN Candidato ON Cargo.CargoId = Candidato.CargoId) ON PartidoPolitico.PartidoId = Candidato.PartidoPoliticoId) INNER JOIN Voto ON (Cargo.CargoId = Voto.CargoId) AND (Candidato.CandidatoId = Voto.CandidatoId)) ON Persona.PersonaId = Candidato.PersonaId WHERE(((Voto.CargoId) = 5)) GROUP BY Cargo.Descripción, PartidoPolitico.Nombre, Persona.Nombres, Persona.Apellidos ORDER BY Count(1) DESC;"

            'Dim adapter As New OleDbDataAdapter(consulta, conexion)
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            dsCandidatos = New DataSet("Candidato")
            'adapter.FillSchema(dsPersonas, SchemaType.Source)

            adapter.Fill(dsCandidatos, "Candidato")


            gridProvin.DataContext = dsCandidatos
        End Using
    End Sub
End Class
