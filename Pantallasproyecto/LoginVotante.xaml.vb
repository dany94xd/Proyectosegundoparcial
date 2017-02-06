Imports System.Data
Imports System.Data.OleDb
Imports System.Configuration

Public Class LoginVotante

    Dim dsVotantes As New DataSet
    Dim encontrado As Boolean
    Dim nombre As String = ""



    Private Sub btnregresar_Click_1(sender As Object, e As RoutedEventArgs) Handles btnregresar.Click
        Dim anterior As New MenuUser
        anterior.Owner = Me
        Me.Hide()
        anterior.Show()
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        End
    End Sub

    Private Sub btnlogin_Click(sender As Object, e As RoutedEventArgs) Handles btnlogin.Click
        encontrado = False
        Dim sufrago = False
        Dim fechasufragio As String = ""
        Using conexion As New OleDbConnection(ConnectionString)
            Dim consulta As String = "Select * FROM Persona"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            dsVotantes = New DataSet("Votante")
            adapter.Fill(dsVotantes, "Votante")
            Dim dt As New DataTable
            dt = dsVotantes.Tables(0)
            For Each votante As DataRow In dt.Rows



                If votante("Cedula") = txtcedula.Text Then
                    encontrado = True
                    nombre = votante("Nombres") + " " + votante("Apellidos")
                    Proyecto.Votante = votante("PersonaId")
                    'if(votante("Sufrago") = "True" )
                    '    sufrago = true
                    '    fechasufragio = votante("FechaSufragio")
                    'End If
                    Exit For
                End If

            Next

            If encontrado Then
                MessageBox.Show("Bienvenido: " & nombre)
                txtcedula.Text = ""
                If sufrago Then
                    MessageBox.Show("Usuario ya sufragó la fecha: " + fechasufragio)
                    Return
                End If

                Dim anterior As New gribpresidentes
                anterior.Owner = Me
                Me.Hide()
                anterior.Show()

            Else
                MessageBox.Show("Usuario no encontrado...")
            End If
        End Using


    End Sub


End Class
