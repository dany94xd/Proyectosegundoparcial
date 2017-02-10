Imports System.Data
Imports System.Data.OleDb

Public Class AddVotante
    Public fila As DataRowView
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
        Dim sql As String = "insert into Persona (Cedula, Nombres, Apellidos) values(@Cedula, @Nombres, @Apellidos)"

        Dim conn As New OleDbConnection(ConnectionString)
        Dim com As New OleDbCommand(sql, conn)
        Using conn
            conn.Open()
            com.Parameters.AddWithValue("@Cedula", (txtcedula.Text))
            com.Parameters.AddWithValue("@Nombres", (txtnombre.Text))
            com.Parameters.AddWithValue("@Apellidos", (txtapellido.Text))


            Dim i = com.ExecuteNonQuery()


        End Using

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

    Private Sub DataGrid_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Try
            fila = sender.SelectedItem

            txtcedula.Text = fila("Cedula")
            txtnombre.Text = fila("Nombres")
            txtapellido.Text = fila("Apellidos")
        Catch ex As Exception
            MsgBox("fila vacia por favor seleccione otra fila")
        End Try




    End Sub

    Private Sub btnlimpiar_Click(sender As Object, e As RoutedEventArgs) Handles btnlimpiar.Click
        txtcedula.Text = ""
        txtnombre.Text = ""
        txtapellido.Text = ""

    End Sub
End Class
