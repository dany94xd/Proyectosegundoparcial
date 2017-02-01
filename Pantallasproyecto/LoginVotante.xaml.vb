Imports System.Data
Imports System.Data.OleDb
Imports System.Configuration
Public Class LoginVotante
    
    Public strbase As String = "G:\Pantallasproyecto\Pantallasproyecto\Database1.mdb"
    
    
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strbase
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
        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM Votante"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            dsVotantes = New DataSet("Votante")
            adapter.Fill(dsVotantes, "Votante")
            For Each votante As DataRow In dsVotantes.Tables("Votante").Rows

                If votante("cedula") = txtcedula.Text Then
                    encontrado = True
                    nombre = votante("nombre")
                    Dim anterior As New Menuvotante
                    anterior.Owner = Me
                    Me.Hide()
                    anterior.Show()

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
End Class
