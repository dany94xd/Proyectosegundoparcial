Imports System.Data
Imports System.Data.OleDb

Public Class gribpresidentes

    Private dsPersonas As DataSet


    Private Sub Listapresidentes_Loaded(sender As Object, e As RoutedEventArgs) Handles Listapresidentes.Loaded



    End Sub

    Private Sub TabItem_Loaded(sender As Object, e As RoutedEventArgs)
        Using conexion As New OleDbConnection(ConnectionString)

            Dim consulta As String = "SELECT Candidato.CandidatoId, Persona.Nombres, Persona.Apellidos, PartidoPolitico.Nombre, PartidoPolitico.Lista, Cargo.Descripción
FROM Persona INNER JOIN (PartidoPolitico INNER JOIN (Cargo INNER JOIN Candidato ON Cargo.CargoId = Candidato.CargoId) ON PartidoPolitico.PartidoId = Candidato.PartidoPoliticoId) ON Persona.PersonaId = Candidato.PersonaId
WHERE Cargo.CargoId = 2;"

            'Dim adapter As New OleDbDataAdapter(consulta, conexion)
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            dsPersonas = New DataSet("Candidato")
            adapter.FillSchema(dsPersonas, SchemaType.Source)

            adapter.Fill(dsPersonas, "Candidato")

            dataGrid.DataContext = dsPersonas

            Votar(2, 2)
        End Using

    End Sub


    Private Sub Votar(CandidatoId As Integer, CargoId As Integer)


        Using conexion As New OleDbConnection(ConnectionString)

            Dim consulta As String = "SELECT Cargo.CargoId, Cargo.Descripción
                                        FROM Voto INNER JOIN Cargo ON (Cargo.CargoId = Voto.CargoId) AND (Voto.CargoId = Cargo.CargoId)
                                        WHERE Voto.PersonaId = @PersonaId AND Voto.CargoId = @CargoId;"
            Using cmd As New OleDbCommand(consulta, conexion)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("PersonaId", Proyecto.Votante)
                cmd.Parameters.AddWithValue("CargoId", CargoId)
                conexion.Open()
                Using reader = cmd.ExecuteReader()

                    While reader.Read()
                        MessageBox.Show("Usted ya votó para ")
                    End While

                End Using

            End Using
            dataGrid.DataContext = dsPersonas
        End Using
    End Sub

    Private Sub TabItem_Loaded_1(sender As Object, e As RoutedEventArgs)
        Using conexion As New OleDbConnection(ConnectionString)

            Dim consulta As String = "SELECT Candidato.CandidatoId, Persona.Nombres, Persona.Apellidos, PartidoPolitico.Nombre, PartidoPolitico.Lista, Cargo.Descripción
FROM Persona INNER JOIN (PartidoPolitico INNER JOIN (Cargo INNER JOIN Candidato ON Cargo.CargoId = Candidato.CargoId) ON PartidoPolitico.PartidoId = Candidato.PartidoPoliticoId) ON Persona.PersonaId = Candidato.PersonaId
WHERE Cargo.CargoId = 4;"

            'Dim adapter As New OleDbDataAdapter(consulta, conexion)
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            dsPersonas = New DataSet("Candidato")
            adapter.FillSchema(dsPersonas, SchemaType.Source)

            adapter.Fill(dsPersonas, "Candidato")

            dataGrid1.DataContext = dsPersonas
        End Using
    End Sub

    Private Sub Listapresidentes_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles Listapresidentes.Closing
        End
    End Sub

    Private Sub tabprovinciales_Loaded(sender As Object, e As RoutedEventArgs) Handles tabprovinciales.Loaded
        Using conexion As New OleDbConnection(ConnectionString)

            Dim consulta As String = "SELECT Candidato.CandidatoId, Persona.Nombres, Persona.Apellidos, PartidoPolitico.Nombre, PartidoPolitico.Lista, Cargo.Descripción
FROM Persona INNER JOIN (PartidoPolitico INNER JOIN (Cargo INNER JOIN Candidato ON Cargo.CargoId = Candidato.CargoId) ON PartidoPolitico.PartidoId = Candidato.PartidoPoliticoId) ON Persona.PersonaId = Candidato.PersonaId
WHERE Cargo.CargoId = 5;"

            'Dim adapter As New OleDbDataAdapter(consulta, conexion)
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            dsPersonas = New DataSet("Candidato")
            adapter.FillSchema(dsPersonas, SchemaType.Source)

            adapter.Fill(dsPersonas, "Candidato")

            datagrib3.DataContext = dsPersonas
        End Using
    End Sub
End Class
