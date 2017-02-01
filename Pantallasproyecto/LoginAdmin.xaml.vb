Imports System.Data
Imports System.Data.OleDb

Public Class LoginAdmin

    Dim dtAdministrador As New DataTable
    Dim encontrado As Boolean
    Dim nombre As String = ""


    Private Sub btnregresar_Click(sender As Object, e As RoutedEventArgs) Handles btnregresar.Click
        Dim anterior As New MenuUser
        anterior.Owner = Me
        Me.Hide()
        anterior.Show()
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        End
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)

        If (txtuser.Text = String.Empty Or txtpass.Password = String.Empty) Then
            MessageBox.Show("Por favor complete los valores de usuario y clave")
            Return
        End If

        Try
            encontrado = False
            Using conexion As New OleDbConnection(ConnectionString)


                Dim adapter As New OleDbDataAdapter(
                    New OleDbCommand("SELECT Administrador.AdministradorId, Persona.PersonaId, Persona.Cedula, Persona.Apellidos, Persona.Nombres, " + 
                                     " Administrador.Usuario, Administrador.Clave FROM Persona " +
                                     " INNER JOIN Administrador ON Persona.PersonaId = Administrador.PersonaId;", conexion))
                dim ds as new DataSet()

                adapter.Fill(ds, "Administrador")
                dtAdministrador = ds.Tables(0)
                For Each admin As DataRow In dtAdministrador.Rows

                    If admin("Usuario") = txtuser.Text AndAlso admin("Clave") = txtpass.Password Then
                        encontrado = True
                        nombre = admin("Nombres") + " " + admin ("Apellidos") 
                        Exit For
                    End If
                Next
                If encontrado Then
                    MessageBox.Show("Bienvenido: " & nombre)


                Else
                    MessageBox.Show("Usuario no encontrado...")
                End If
            End Using
        Catch ex As Exception
                    MessageBox.Show(ex.Message)

        End Try



    End Sub


End Class
