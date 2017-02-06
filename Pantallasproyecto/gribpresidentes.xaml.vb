﻿Imports System.Data
Imports System.Data.OleDb

Public Class gribpresidentes

    Private dsPersonas As DataSet
    Public fila As DataRowView
    Public vpres, vasam, vasap As Boolean


    Private Sub TabItem_Loaded(sender As Object, e As RoutedEventArgs)
        Using conexion As New OleDbConnection(ConnectionString)

            Dim consulta As String = "SELECT Candidato.CandidatoId, Persona.Nombres, Persona.Apellidos, PartidoPolitico.Nombre, PartidoPolitico.Lista, Cargo.Descripción, Cargo.CargoId FROM Persona INNER JOIN (PartidoPolitico INNER JOIN (Cargo INNER JOIN Candidato ON Cargo.CargoId = Candidato.CargoId) ON PartidoPolitico.PartidoId = Candidato.PartidoPoliticoId) ON Persona.PersonaId = Candidato.PersonaId WHERE Cargo.CargoId = 2;"

            'Dim adapter As New OleDbDataAdapter(consulta, conexion)
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            dsPersonas = New DataSet("Candidato")
            adapter.FillSchema(dsPersonas, SchemaType.Source)

            adapter.Fill(dsPersonas, "Candidato")

            dataGrid.DataContext = dsPersonas

            'If Votar(2) Then
            '    dataGrid.IsEnabled = False
            '    'mensaje ya boto
            'Else
            '    dataGrid.IsEnabled = True
            'End If
        End Using

    End Sub
End Class
