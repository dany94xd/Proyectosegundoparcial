Imports System.Data
Imports System.Data.OleDb

Public Class LoginCandidato

    Dim dsCandidato As New DataSet
    Dim encontrado As Boolean
    Dim nombre As String = ""


    'Public Basevotaciones As String = "../../votaciones.xml"
    Private Sub btnregresar_Click_1(sender As Object, e As RoutedEventArgs) Handles btnregresar.Click
        Dim anterior As New MenuUser
        anterior.Owner = Me
        Me.Hide()
        anterior.Show()
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        End
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)

        encontrado = False
        Using conexion As New OleDbConnection(ConnectionString)

            Dim adapter As New OleDbDataAdapter(New OleDbCommand("SELECT Candidato.CandidatoId, Persona.PersonaId, Persona.Cedula, Persona.Apellidos, Persona.Nombres, Cargo.Descripción, Candidato.Usuario, Candidato.Clave " + 
                                                                 "FROM Persona INNER JOIN (PartidoPolitico INNER JOIN (Cargo INNER JOIN Candidato ON Cargo.CargoId = Candidato.CargoId) " + 
                                                                 "ON PartidoPolitico.PartidoId = Candidato.PartidoPoliticoId) ON Persona.PersonaId = Candidato.PersonaId;" , conexion))
            dsCandidato = New DataSet()
            adapter.Fill(dsCandidato, "Candidato")
            dim dt as new DataTable
            dt = dsCandidato.Tables(0)
            For Each candidato As DataRow In dt.Rows
                If candidato("Usuario") = txtusercand.Text AndAlso candidato("Clave") = passcand.Password Then
                    encontrado = True
                    nombre = candidato("Nombres") + candidato("Apellidos")
                    Exit For
                End If

            Next
            If encontrado Then
                MessageBox.Show("Bienvenido: " & nombre)


            Else
                MessageBox.Show("Usuario no encontrado...")
            End If

        End Using






    End Sub

    Private Sub wincandi_Loaded(sender As Object, e As RoutedEventArgs) Handles wincandi.Loaded


    End Sub
End Class
