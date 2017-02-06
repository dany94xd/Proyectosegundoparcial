Imports System.Data
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

            If Votar(2) Then
                dataGrid.IsEnabled = False
                'mensaje ya boto
            Else
                dataGrid.IsEnabled = True
            End If
        End Using

    End Sub

    Private Function Votar(CargoId As Integer) As Boolean
        Dim retorno As Boolean = False
        Using conexion As New OleDbConnection(ConnectionString)

            Dim consulta As String = "SELECT Cargo.CargoId, Cargo.Descripción FROM Voto INNER JOIN Cargo ON (Voto.CargoId = Cargo.CargoId) AND (Voto.CargoId = Cargo.CargoId) WHERE (((Voto.PersonaId)=" + Proyecto.Votante.ToString + ") AND ((Voto.CargoId)=" + CargoId.ToString + "));"

            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            dsPersonas = New DataSet("Candidato")
            'adapter.FillSchema(dsPersonas, SchemaType.Source)

            adapter.Fill(dsPersonas, "Candidato")
            If dsPersonas.Tables(0).Rows.Count = 0 Then
                retorno = False
            Else
                retorno = True
            End If
        End Using
        Return retorno
    End Function


    Private Sub TabItem_Loaded_1(sender As Object, e As RoutedEventArgs)
        Using conexion As New OleDbConnection(ConnectionString)

            Dim consulta As String = "SELECT Candidato.CandidatoId, Persona.Nombres, Persona.Apellidos, PartidoPolitico.Nombre, PartidoPolitico.Lista, Cargo.Descripción, Cargo.CargoId FROM Persona INNER JOIN (PartidoPolitico INNER JOIN (Cargo INNER JOIN Candidato ON Cargo.CargoId = Candidato.CargoId) ON PartidoPolitico.PartidoId = Candidato.PartidoPoliticoId) ON Persona.PersonaId = Candidato.PersonaId WHERE Cargo.CargoId = 4;"
            'Dim adapter As New OleDbDataAdapter(consulta, conexion)
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            dsPersonas = New DataSet("Candidato")
            'adapter.FillSchema(dsPersonas, SchemaType.Source)

            adapter.Fill(dsPersonas, "Candidato")

            dataGrid1.DataContext = dsPersonas
        End Using
    End Sub


    Private Sub Listapresidentes_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles Listapresidentes.Closing
        End
    End Sub

    Private Sub tabprovinciales_Loaded(sender As Object, e As RoutedEventArgs) Handles tabprovinciales.Loaded
        Using conexion As New OleDbConnection(ConnectionString)

            Dim consulta As String = "SELECT Candidato.CandidatoId, Persona.Nombres, Persona.Apellidos, PartidoPolitico.Nombre, PartidoPolitico.Lista, Cargo.Descripción, Cargo.CargoId FROM Persona INNER JOIN (PartidoPolitico INNER JOIN (Cargo INNER JOIN Candidato ON Cargo.CargoId = Candidato.CargoId) ON PartidoPolitico.PartidoId = Candidato.PartidoPoliticoId) ON Persona.PersonaId = Candidato.PersonaId WHERE Cargo.CargoId = 5;"
            'Dim adapter As New OleDbDataAdapter(consulta, conexion)
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            dsPersonas = New DataSet("Candidato")
            'adapter.FillSchema(dsPersonas, SchemaType.Source)

            adapter.Fill(dsPersonas, "Candidato")

            datagrib3.DataContext = dsPersonas
        End Using
    End Sub


    'este metodo es el que selecciona el item o elemento del datagrib'
    Private Sub dataGrid_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dataGrid.SelectionChanged
        fila = sender.SelectedItem
        'Dim sql As String = "insert into Voto (PersonaId, CargoId, CandidatoId,Fecha) values(@PersonaId, @CargoId, @CandidatoId, @Fecha)"
        If Votar(Integer.Parse(fila("CargoId"))) Then
            MessageBox.Show("Usted ya voto para Presidente")
            ' deshabilitar la pestana 
            Return
        End If

        If MessageBox.Show("Esta seguro de votar por: " + fila("Nombres") + " " + fila("Apellidos"),
                           "Sistema de votacion", MessageBoxButton.YesNo) = MessageBoxResult.Yes Then



            Dim a As Integer = 0
            btnsufragarp.IsEnabled = True

        End If
    End Sub



    Private Sub dataGrid1_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dataGrid1.SelectionChanged
        fila = sender.SelectedItem

        If Votar(Integer.Parse(fila("CargoId"))) Then
            MessageBox.Show("Usted ya voto para Asambleista")
            ' deshabilitar la pestana 
            Return
        End If

        If MessageBox.Show("Esta seguro de votar por: " + fila("Nombres") + " " + fila("Apellidos"),
                           "Sistema de votacion", MessageBoxButton.YesNo) = MessageBoxResult.Yes Then

            Dim vid = Proyecto.Votante
            Dim candid = Integer.Parse(fila("CandidatoId"))

            Dim a As Integer = 0
            btnsugrafara.IsEnabled = True

        End If

    End Sub



    Private Sub datagrib3_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles datagrib3.SelectionChanged
        fila = sender.SelectedItem

        If Votar(Integer.Parse(fila("CargoId"))) Then
            MessageBox.Show("Usted ya voto para Provincial")
            ' deshabilitar la pestana 
            Return
        End If

        If MessageBox.Show("Esta seguro de votar por: " + fila("Nombres") + " " + fila("Apellidos"),
                           "Sistema de votacion", MessageBoxButton.YesNo) = MessageBoxResult.Yes Then

            Dim vid = Proyecto.Votante
            Dim candid = Integer.Parse(fila("CandidatoId"))

            Dim a As Integer = 0
            btnsufragarPro.IsEnabled = True
        End If
    End Sub


    Private Sub btnsufragarp_Click(sender As Object, e As RoutedEventArgs) Handles btnsufragarp.Click
        Dim sql As String = "insert into Voto (PersonaId, CargoId, CandidatoId,Fecha) values(@PersonaId, @CargoId, @CandidatoId, @Fecha)"

        Dim conn As New OleDbConnection(ConnectionString)
        Dim com As New OleDbCommand(sql, conn)
        Using conn
            conn.Open()
            com.Parameters.AddWithValue("@PersonaId", Proyecto.Votante)
            com.Parameters.AddWithValue("@CargoId", Integer.Parse(fila("CargoId")))
            com.Parameters.AddWithValue("@CandidatoId", Integer.Parse(fila("CandidatoId")))
            com.Parameters.AddWithValue("@Fecha", Date.Now.ToString)

            Dim i = com.ExecuteNonQuery()

            If (i > 0) Then
                MessageBox.Show("Su voto ha sido registrado correctamente")
                dataGrid.IsEnabled = False
                btnsufragarp.IsEnabled = False
                vpres = True
            Else
                MessageBox.Show("Su voto no ha sido registrado, intente nuevamente")

            End If
        End Using

    End Sub

    Private Sub btnsufragarp_Initialized(sender As Object, e As EventArgs) Handles btnsufragarp.Initialized
        vpres = False
        vasam = False
        vasap = False
    End Sub



    Private Sub btnsugrafara_Click(sender As Object, e As RoutedEventArgs) Handles btnsugrafara.Click
        Dim sql As String = "insert into Voto (PersonaId, CargoId, CandidatoId,Fecha) values(@PersonaId, @CargoId, @CandidatoId, @Fecha)"

        Dim conn As New OleDbConnection(ConnectionString)
        Dim com As New OleDbCommand(sql, conn)
        Using conn
            conn.Open()
            com.Parameters.AddWithValue("@PersonaId", Proyecto.Votante)
            com.Parameters.AddWithValue("@CargoId", Integer.Parse(fila("CargoId")))
            com.Parameters.AddWithValue("@CandidatoId", Integer.Parse(fila("CandidatoId")))
            com.Parameters.AddWithValue("@Fecha", Date.Now.ToString)

            Dim i = com.ExecuteNonQuery()

            If (i > 0) Then
                MessageBox.Show("Su voto ha sido registrado correctamente")
                dataGrid1.IsEnabled = False
                btnsugrafara.IsEnabled = False
                vpres = True
            Else
                MessageBox.Show("Su voto no ha sido registrado, intente nuevamente")

            End If
        End Using
    End Sub


    Private Sub btnterminar_Click(sender As Object, e As RoutedEventArgs) Handles btnterminar.Click
        Dim anterior As New MenuUser
        anterior.Owner = Me
        Me.Hide()
        anterior.Show()

    End Sub

End Class
